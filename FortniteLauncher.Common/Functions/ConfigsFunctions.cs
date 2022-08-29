using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteLauncher.Common.Functions
{
    public class ConfigsFunctions
    {
        public class UsernameFunctions
        {
            public static string UsernameString()
            {
                try
                {
                    if (!File.Exists(Strings.UsernameConfing))
                    {
                        if (CreateConfigFile())
                        {
                            string name = File.ReadAllText(Strings.UsernameConfing);
                            return name;
                        }
                        else if (!CreateConfigFile())
                        {
                            return "Error";
                        }
                    }
                    else if (File.Exists(Strings.UsernameConfing))
                    {
                        string name = File.ReadAllText(Strings.UsernameConfing);
                        return name;
                    }
                }
                catch (Exception ex)
                {
                    return "Error!";
                }

                return null;
            }
            public static bool CreateConfigFile()
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(Strings.UsernameConfing))
                    {
                        sw.Write("Player");
                        sw.Close();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                return false;
            }
            public static bool SaveUsername(string name)
            {
                try
                {
                    if (!File.Exists(Strings.UsernameConfing))
                    {
                        if (CreateConfigFile())
                        {
                            //delete the file
                            File.Delete(Strings.UsernameConfing);
                            using (StreamWriter sw = File.CreateText(Strings.UsernameConfing))
                            {
                                sw.Write(name);
                                sw.Close();
                            }
                            return true;
                        }
                        else if (!CreateConfigFile())
                        {
                            return false;
                        }
                    }
                    else if (File.Exists(Strings.UsernameConfing))
                    {
                        File.Delete(Strings.UsernameConfing);
                        using (StreamWriter sw = File.CreateText(Strings.UsernameConfing))
                        {
                            sw.Write(name);
                            sw.Close();
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    //will do later
                }
                return false;
            }
        }
    }
}
