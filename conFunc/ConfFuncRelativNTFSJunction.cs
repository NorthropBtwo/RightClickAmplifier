using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Windows.Forms;

namespace RightClickAmplifier
{
    [Serializable]
    public class ConfFuncRelativNTFSJunction : ContextFunction
    {
        
        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, uint dwFlags);
        const uint SYMBLOC_LINK_FLAG_FILE = 0x0;
        const uint SYMBLOC_LINK_FLAG_DIRECTORY = 0x1;

            /*
        [DllImport("kernel32.dll", EntryPoint = "CreateSymbolicLinkW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CreateSymbolicLink([In] string lpSymlinkFileName, [In] string lpTargetFileName, [In] int dwFlags);
        private const int SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1;
        */


        public ConfFuncRelativNTFSJunction() : base()
        {

        }

        public ConfFuncRelativNTFSJunction(string name) : base(name)
        {

        }

        public override string ToString()
        {
            return "NTFSJunction: " + base.ToString();
        }

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            if (!SecurityMgmt.HasAdminRights())
            {
                SecurityMgmt.ReRunAsAdmin();
            }

            FolderBrowserDialog selFolder = new FolderBrowserDialog();
            selFolder.SelectedPath = Directory.GetCurrentDirectory();

            if (selFolder.ShowDialog() == DialogResult.OK)
            {

                string wd = Directory.GetCurrentDirectory();

                try
                {
                    Uri relativePath = new Uri(wd).MakeRelativeUri(new Uri(selFolder.SelectedPath));
                     CreateSymbolicLink(wd + "\\NewLink", "..\\" + relativePath.ToString(), SYMBLOC_LINK_FLAG_DIRECTORY);

                    /*
                    string link = wd + "\\NewLink";
                    string target = "..\\" + relativePath.ToString();
                    MessageBox.Show("mklink " + "/D" + " \"" + link + "\" \"" + target + "\"");
                    string response = CMD.Execute("mklink " + "/D" + " \"" + link + "\" \"" + target + "\"");
                    MessageBox.Show(response);*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }


        //--Presets------------------------------------------------------------------------------------------------------------

        public override List<ContextMakro> GetPresets()
        {
            ContextMakro makro = new ContextMakro("CreateRelativeSoftLink");
            makro.FileExtensions.Add(new CString("directory/Background"));
            makro.Functions.Add(new ConfFuncRelativNTFSJunction("newRelativeLink"));
            return new List<ContextMakro>() { makro };
        }

        //--------------------------------------------------------------------------------------------------------------

    }
}
