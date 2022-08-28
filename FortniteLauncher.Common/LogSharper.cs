using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.Common;

namespace LogSharper
{
    public class LogSharper
    {
        /// <summary>
        /// Basic info about LogSharper
        /// </summary>
        private static string Version = "1.0";
        /// <summary>
        /// VersionString of LogSharper
        /// </summary>

        public static string GetVersion()
        {        /// <summary>
                 /// Gets the version of LogSharper
                 /// </summary>
                 /// <returns>Version of LogSharper</returns>
            return Version;
        }

        public static void LogLoggerInfo()
        {
            /// <summary>
            /// Displays basic info about the logger
            /// </summary>
            Logger.Info("LogSharper, (An attempt at making) A simple Single-File logger solution in c#, made by Jurij15, Version " + GetVersion());
        }

        public static void Setup(bool showSucessMessage)
        {
            /// <summary>
            /// Sets up the logger
            /// </summary>
            /// <param name="showSucessMessage">if true, displays a simple message</param>
            if (showSucessMessage)
            {
                Logger.Info("LogSharper Initialized!");
            }
        }
    }

    public static class LoggerSettings
    {
        /// <summary>
        /// Logger Settings
        /// 
        /// You can set these at any time, and it will apply immidiately
        /// If you don't change any of these, default values will be used
        /// 
        /// DEFAULT VALUES:
        /// UseColorLogging = true ---Use colors when logging
        /// UseTimeDateLogging = true ---Displays the time and date with the log
        /// LogToFile = false ---logs to the file
        /// LogFile = null ---The file that logger will use to log to
        ///
        /// /// </summary>
        public static void UseColorLoggingSettingChange(bool newValue, bool logChange, Logger.LogTypes LogType)
        {
            /// <summary>
            /// Changes the value of the UseColorLoggging Setting
            /// </summary>
            /// <param name="newValue">New value</param>
            /// <param name="logChange">Logs the changed setting</param>
            /// <param name="LogType"> Which type should the log message be(error, success...)</param>
            LoggerProperties.UseColorLogging = newValue;
            if (logChange)
            {
                LoggerInternal.Log_SettingChanged("UseColorLogging", LogType);
            }
        }

        public static void UseTimeDateOnLoggingSettingChange(bool newValue, bool logChange, Logger.LogTypes LogType)
        {
            /// <summary>
            /// Changes the value of the UseTimeDateOnLogging Setting
            /// </summary>
            /// <param name="newValue">New value</param>
            /// <param name="logChange">Logs the changed setting</param>
            /// <param name="LogType">Which type should the log message be(error, success...)</param>
            LoggerProperties.UseTimeAndDateOnLogging = newValue;
            if (logChange)
            {
                LoggerInternal.Log_SettingChanged("UseTimeAndDateOnLogging", LogType);
            }
        }

        public static void LogToFileSettingChange(bool newValue, bool logChange, Logger.LogTypes LogType)
        {
            /// <summary>
            /// Changes the value of the LogToFile Setting
            /// </summary>
            /// <param name="newValue">New value</param>
            /// <param name="logChange">Logs the changed setting</param>
            /// <param name="LogType">Which type should the log message be(error, success...)</param>
            LoggerProperties.WriteToFile = newValue;
            if (logChange)
            {
                LoggerInternal.Log_SettingChanged("LogToFile", LogType);
            }
        }

        public static void LogFileSettingChange(string newValue, bool logChange, Logger.LogTypes LogType)
        {
            /// <summary>
            /// Changes the value of the LogFile Setting
            /// </summary>
            /// <param name="newValue">New value</param>
            /// <param name="logChange">Logs the changed setting</param>
            /// <param name="LogType">Which type should the log message be(error, success...)</param>
            LoggerProperties.LogFile = newValue;
            if (logChange)
            {
                LoggerInternal.Log_SettingChanged("LogFile", LogType);
            }
        }
    }

    internal class LoggerProperties
    {
        /// <summary>
        /// Properties, for internal use
        /// 
        /// DO NOT CHAGE ANY VALUES! USE LoggerSettings TO CHANGE THEM!
        /// </summary>
        public static bool UseColorLogging = true;
        public static bool UseTimeAndDateOnLogging = true;
        public static bool WriteToFile = false;
        public static string LogFile = null;
    }

    internal class LoggerInternal
    {
        /// <summary>
        /// Internal stuff for the logger
        /// </summary>
        public static string GetCurrentTime(bool ForLog)
        {
            /// <summary>
            /// Gets the current DateTime
            /// </summary>
            /// <param name="ForLog">Changes to a format, used for logging</param>
            /// <returns>Current Date and Time</returns>
            if (ForLog)
            {
                return "["+DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss")+"]";
            }
            else if (!ForLog)
            {
                return DateTime.Now.ToString();
            }

            return null; //NoT AlL CoDe PaThS ReTuRn A vAlUe
        }

        public static void Log_SettingChanged(string SettingName, Logger.LogTypes LogType)
        {
            /// <summary>
            /// Logs the setting that was changed
            /// </summary>
            /// <param name="SettingName">Name of the setting that was changed</param>
            /// <param name="LogType">Type of the log (Error, Success, ...)</param>
            string text = "[LogSharperSettings]" + SettingName + " was changed";
            Logger.Universal(text, LogType);
        }
    }

    internal class LoggerFile
    {
        /// <summary>
        /// Logger File Class
        /// 
        /// Contains methods and functions to write text to files
        /// DO NOT CALL THIS CLASS, IT IS USED FOR INTERNAL LOGGING!
        /// </summary>
        public static void WriteToFile(string text)
        {
            /// <summary>
            /// Writes the provided string of text to a file
            /// </summary>
            /// <param name="text">Text to be written to the file</param>
            if (LoggerProperties.WriteToFile)
            {
                if (LoggerProperties.LogFile != null)
                {
                    if (File.Exists(LoggerProperties.LogFile))
                    {
                        using (StreamWriter sw = new StreamWriter(LoggerProperties.LogFile))
                        {
                            sw.WriteLine(text);
                            sw.Close();
                        }
                    }
                    else if (!File.Exists(LoggerProperties.LogFile))
                    {
                        using (StreamWriter sw = File.CreateText(LoggerProperties.LogFile))
                        {
                            sw.WriteLine(text);
                            sw.Close();
                        }
                    }
                }
            }
        }
    }

    public static class Logger
    {
        /// <summary>
        /// Well, logger...
        /// </summary>
        public enum LogTypes
        {
            /// <summary>
            /// LogTypes
            /// </summary>
            Error, //LogType Error
            Warning, //LogType Warning
            Info, //LogType Info
            Sucess //LogType Success
        }
        
        public static void Info(string text)
        {
            /// <summary>
            /// Logs the provided text as a normal Information
            /// </summary>
            /// <param name="text">text to log</param>
            string LogText = "";

            if (LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = LoggerInternal.GetCurrentTime(true) + "[Info]" + text;
            }
            else if (!LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = "[Info]"+text;
            }
            LoggerFile.WriteToFile(LogText);
            Console.WriteLine(LogText);
        }

        public static void Warning(string text)
        {
            /// <summary>
            /// Logs the provided text as a Warning
            /// </summary>
            /// <param name="text">text to log</param>
            string LogText = "";
            if (LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = LoggerInternal.GetCurrentTime(true)+ "[Warning]" + text;
            }
            else if (!LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = text;
            }

            if (LoggerProperties.UseColorLogging)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            LoggerFile.WriteToFile(LogText);
            Console.WriteLine(LogText);
            Console.ResetColor();
        }

        public static void Success(string text)
        {
            /// <summary>
            /// Logs the provided text as success
            /// </summary>
            /// <param name="text">text to log</param>
            string LogText = "";
            if (LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = LoggerInternal.GetCurrentTime(true) + "[Success]" + text;
            }
            else if (!LoggerProperties.UseColorLogging)
            {
                LogText = "[Success]" + text;
            }

            if (LoggerProperties.UseColorLogging)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            LoggerFile.WriteToFile(LogText);
            Console.WriteLine(LogText);
            Console.ResetColor();
        }

        public static void Error(string text)
        {
            /// <summary>
            /// Logs the provided text as Error
            /// </summary>
            /// <param name="text">text to log</param>
            string LogText = "";
            if (LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = LoggerInternal.GetCurrentTime(true) + "[Error]" + text;
            }
            else if (!LoggerProperties.UseTimeAndDateOnLogging)
            {
                LogText = LoggerInternal.GetCurrentTime(true) + "[Error]" + text;
            }

            if (LoggerProperties.UseColorLogging)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            LoggerFile.WriteToFile(LogText);
            Console.WriteLine(LogText);
            Console.ResetColor();
        }

        public static void Universal(string text, LogTypes LogType)
        {
            /// <summary>
            /// Attempt at making a universal logger, this is just for testing
            /// </summary>
            /// <param name="text">text to log</param>
            /// <param name="LogType">Type of the log (Error, Success, ...)</param>
            switch (LogType)
            {
                case ((LogTypes)(int)LogTypes.Info):
                    Info(text); 
                    break;
                case ((LogTypes)(int)LogTypes.Warning):
                    Warning(text);
                    break;
                case ((LogTypes)(int)LogTypes.Sucess):
                    Success(text);
                    break;
                case ((LogTypes)(int)LogTypes.Error):
                    Error(text);
                    break;
            }
        }
    }
}
