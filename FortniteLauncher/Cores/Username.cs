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
                return null;
            }

            return null;
        }
        public static bool CreateConfigFile()
        {
            try
            {
                File.Create(AppPaths.UsernameConfing);
                using (StreamWriter sw = new StreamWriter(AppPaths.UsernameConfing))
                {
                    sw.WriteLine("Player");
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
                        //create a file and write the new username to it
                        File.Create(AppPaths.UsernameConfing);
                        using (StreamWriter sw = new StreamWriter(AppPaths.UsernameConfing))
                        {
                            sw.WriteLine(name);
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
                    //delete the file
                    File.Delete(AppPaths.UsernameConfing);
                    //create a file and write the new username to it
                    File.Create(AppPaths.UsernameConfing);
                    using (StreamWriter sw = new StreamWriter(AppPaths.UsernameConfing))
                    {
                        sw.WriteLine(name);
                        sw.Close();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return false;
        }
    }
}
