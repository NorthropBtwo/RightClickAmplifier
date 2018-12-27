using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace RightClickAmplifier
{
    public class SecurityMgmt
    {

        public static bool HasAdminRights()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error HasAdminRights: " + ex.ToString());
                return false;
            }
          
        }


        public static void ReRunAsAdmin()
        {
            try
            {
                

                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().CodeBase;
                proc.Verb = "runas";
                proc.Arguments = string.Join(" " ,Environment.GetCommandLineArgs().Skip(1).ToArray());
                Process.Start(proc);

                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error ReRunAsAdmin: " + ex.ToString());
            }
        }


         




    }
}
