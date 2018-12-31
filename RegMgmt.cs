using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightClickAmplifier
{
    public class RegMgmt
    {

        public const string ALLFILES = "* (all files)";

        //------------GetEnabledContextFunctions------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static List<string> GetEnabledContextFunctions(string keyName)
        {
            List<string> enabledFunctions = new List<string>();
            RegistryKey currenKey = null;
            RegistryKey backupKey = null;
            string[] keyNamePart = keyName.Split('/');

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyNamePart[0]))
            {
                if (key == null)
                {
                    return enabledFunctions;
                }
                else if(keyNamePart.Length > 1)
                {
                    backupKey = key;
                    currenKey = key.OpenSubKey(keyNamePart[1]);
                }
                else
                {
                    currenKey = key;
                }

                if (currenKey == null)
                {
                    return enabledFunctions;
                }

                string shellstr = "";
                if (currenKey.GetSubKeyNames().Contains("shell"))
                    shellstr = "shell";
                if (currenKey.GetSubKeyNames().Contains("Shell"))
                    shellstr = "Shell";


                if (shellstr != "")
                {
                    using (RegistryKey shellKey = currenKey.OpenSubKey(shellstr))
                    {
                        string[] functionNames = shellKey.GetSubKeyNames();
                        foreach (var functionName in functionNames)
                        {
                            using (RegistryKey functionKey = shellKey.OpenSubKey(functionName))
                            {
                                if (functionKey.GetSubKeyNames().Contains("command"))
                                {
                                    using (RegistryKey cmdKey = functionKey.OpenSubKey("command"))
                                    {
                                        string stdvalue = cmdKey.GetValue("") as string;
                                        if (stdvalue != null && stdvalue.StartsWith("\"" + System.Reflection.Assembly.GetCallingAssembly().Location + "\"" + " "))
                                        {
                                            enabledFunctions.Add(functionName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (currenKey != null)
                currenKey.Dispose();
            if (backupKey != null)
                backupKey.Dispose();

            return enabledFunctions;
        }


        //------------RemoveContextFunction------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void RemoveContextFunction(string keyName, string confunc)
        {
            RegistryKey backupKey = null;
            RegistryKey currentKey = null;
            string[] fileTypeKeyParts = keyName.Split('/');

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(fileTypeKeyParts[0]))
            {
                if (key == null)
                {
                    MessageBox.Show("file type not found in registry: " + keyName, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (fileTypeKeyParts.Length > 1)
                {
                    backupKey = key;
                    currentKey = key.OpenSubKey(fileTypeKeyParts[1]);
                }
                else
                {
                    currentKey = key;
                }

                if (currentKey == null)
                {
                    MessageBox.Show("file type not found in registry: " + keyName, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string shellstr = "";
                if (currentKey.GetSubKeyNames().Contains("shell"))
                    shellstr = "shell";
                if (currentKey.GetSubKeyNames().Contains("Shell"))
                    shellstr = "Shell";

                if (shellstr != "")
                {
                    /*if you get an error here, start Visual studio with admin rights*/
                    using (RegistryKey shellKey = currentKey.OpenSubKey(shellstr, true))
                    {
                        string[] functionNames = shellKey.GetSubKeyNames();
                        if (functionNames.Contains(confunc))
                        {
                            shellKey.DeleteSubKeyTree(confunc);
                        }
                    }
                }
            }
            if (backupKey != null)
                backupKey.Dispose();
            if (currentKey != null)
                currentKey.Dispose();
        }

        //------------GetExtensions------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static string[] GetExtensions()
        {
            List<string> extensions = new List<string>(Registry.ClassesRoot.GetSubKeyNames());
            return extensions.Where(item => item.StartsWith(".")).ToArray();
        }


        //------------GetFileType------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static string GetFileType(string extension)
        {
            string fileType = null;

            fileType = GetFileTypeFromUserChoice(extension) as string;

            if (fileType == null)
            {
                fileType = GetFileTypeFromCLASSES_ROOT(extension) as string;
            }

            if (fileType == null)
            {
                fileType = extension;
            }

            return fileType;
        }

        private static object GetFileTypeFromUserChoice(string extension)
        {
            string path = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + extension + @"\UserChoice";
            return GetRegKeyValue(path, "ProgId");
        }

        private static object GetFileTypeFromCLASSES_ROOT(string extension)
        {
            string path = @"Computer\HKEY_CLASSES_ROOT\" + extension;
            return GetRegKeyValue(path, "");
        }




        private static object GetRegKeyValue(string path, string valueName)
        {
            List<RegistryKey> listKeys = new List<RegistryKey>();
            object retval = null;
            int i = 0;

            string[] folders = path.Split('\\');

            if (folders[i] == "Computer")
            {
                if (folders[i] == "Computer")
                {
                    i++;
                }
            }

            if (folders[i] == "HKEY_CURRENT_USER")
            {
                i++;
                listKeys.Add(Registry.CurrentUser);
                retval = GetRegKeyValue(folders, i, listKeys, valueName);
            }
            else if (folders[i] == "HKEY_CLASSES_ROOT")
            {
                i++;
                listKeys.Add(Registry.ClassesRoot);
                retval = GetRegKeyValue(folders, i, listKeys, valueName);
            }

            return retval;
        }

        private static object GetRegKeyValue(string[] folders, int i, List<RegistryKey> listKeys, string valueName)
        {
            object retval = null;
            RegistryKey key = listKeys.Last();

            if (i < folders.Length)
            {
                if (key.GetSubKeyNames().Contains(folders[i]))
                {
                    using (RegistryKey keySub = key.OpenSubKey(folders[i]))
                    {
                        listKeys.Add(keySub);
                        i++;
                        retval = GetRegKeyValue(folders, i, listKeys, valueName);
                    }
                }
            }
            else
            {
                retval = key.GetValue(valueName);
            }

            return retval;
        }


        //------------AddContextFunction------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static void AddContextFunction(string fileTypeKeyName, ContextMakro confunc)
        {
            RegistryKey backupKey = null;
            RegistryKey currentKey = null;
            string[] fileTypeKeyParts = fileTypeKeyName.Split('/');

            using (RegistryKey fileTypeKey = Registry.ClassesRoot.OpenSubKey(fileTypeKeyParts[0], true))
            {
                if (fileTypeKey == null)
                {
                    MessageBox.Show("file type not found in registry: " + fileTypeKeyName, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(fileTypeKeyParts.Length > 1)
                {
                    backupKey = fileTypeKey;
                    currentKey = fileTypeKey.OpenSubKey(fileTypeKeyParts[1]);
                }
                else
                {
                    currentKey = fileTypeKey;
                }

                if (currentKey == null)
                {
                    MessageBox.Show("file type not found in registry: " + fileTypeKeyName, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (currentKey.GetSubKeyNames().Contains("shell"))
                {
                    using (RegistryKey shellKey = currentKey.OpenSubKey("shell", true))
                    {
                        AddContextFunctionInShellKey(shellKey, confunc, backupKey!= null);
                    }
                }
                else
                {
                    using (RegistryKey shellKey = currentKey.CreateSubKey("shell"))
                    {
                        AddContextFunctionInShellKey(shellKey, confunc, backupKey != null);
                    }
                }
            }
            if(backupKey!= null)
             backupKey.Dispose();
            if (currentKey != null)
                currentKey.Dispose();
        }

        private static void AddContextFunctionInShellKey(RegistryKey shellKey, ContextMakro confunc, bool isBackground)
        {
            string enhKeyName = confunc.Name;
            if (shellKey.GetSubKeyNames().Contains(enhKeyName))
            {
                using (RegistryKey enhKey = shellKey.OpenSubKey(enhKeyName, true))
                {
                    AddCommandKey(enhKey, confunc, isBackground);
                }
            }
            else
            {
                using (RegistryKey enhKey = shellKey.CreateSubKey(enhKeyName))
                {
                    AddCommandKey(enhKey, confunc, isBackground);
                }
            }
        }

        private static void AddCommandKey(RegistryKey enhKey, ContextMakro confunc, bool isBackground)
        {
            string cmdKeyName = "command";
            if (enhKey.GetSubKeyNames().Contains(cmdKeyName))
            {
                using (RegistryKey cmdKey = enhKey.OpenSubKey(cmdKeyName, true))
                {
                    SetCommandKeyValue(cmdKey, confunc, isBackground);
                }
            }
            else
            {
                using (RegistryKey cmdKey = enhKey.CreateSubKey(cmdKeyName))
                {
                    SetCommandKeyValue(cmdKey, confunc, isBackground);
                }
            }
        }

        private static void SetCommandKeyValue(RegistryKey cmdKey, ContextMakro confunc, bool isBackground)
        {
            if(isBackground)
            {
                cmdKey.SetValue("", "\"" + System.Reflection.Assembly.GetCallingAssembly().Location + "\"" + " " + confunc.Name);
            }
            else
            {
                cmdKey.SetValue("", "\"" + System.Reflection.Assembly.GetCallingAssembly().Location + "\"" + " " + confunc.Name + " \"%1\"");
            }
          
        }



    }
}
