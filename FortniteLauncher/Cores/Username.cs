using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FortniteLauncher.Cores
{
    public static class Username
    {
        public static string UsernameString()
        {
            try
            {
                if (!File.Exists(AppPaths.UsernameConfing))
                {
                    if (CreateConfigFile())
                    {
                        string name = File.ReadAllText(AppPaths.UsernameConfing);
                        return name;
                    }
                    else if (!CreateConfigFile())
                    {
                        return "Error";
                    }
                }
                else if (File.Exists(AppPaths.UsernameConfing))
                {
                    string name = File.ReadAllText(AppPaths.UsernameConfing);
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
                using (StreamWriter sw = File.CreateText(AppPaths.UsernameConfing))
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
                if (!File.Exists(AppPaths.UsernameConfing))
                {
                    if (CreateConfigFile())
                    {
                        //delete the file
                        File.Delete(AppPaths.UsernameConfing);
                        using (StreamWriter sw = File.CreateText(AppPaths.UsernameConfing))
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
                else if (File.Exists(AppPaths.UsernameConfing))
                {
                    File.Delete(AppPaths.UsernameConfing);
                    using (StreamWriter sw = File.CreateText(AppPaths.UsernameConfing))
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
