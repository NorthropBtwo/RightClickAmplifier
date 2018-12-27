using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Windows.Forms;

namespace RightClickAmplifier.conFunc
{
    [Serializable]
    public class ConfFuncNTFSJunction : ContextFunction
    {

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, uint dwFlags);

        const uint SYMBLOC_LINK_FLAG_FILE = 0x0;
        const uint SYMBLOC_LINK_FLAG_DIRECTORY = 0x1;


        public ConfFuncNTFSJunction() : base()
        {

        }

        public ConfFuncNTFSJunction(string name) : base(name)
        {

        }

        public override string ToString()
        {
            return "NTFSJunction: " + base.ToString();
        }

        public override void PerformAction(ContextMakro currentMakro, string[] parameters)
        {
            if(!SecurityMgmt.HasAdminRights())
            {
                SecurityMgmt.ReRunAsAdmin();
            }

            FolderBrowserDialog selFolder = new FolderBrowserDialog();
            selFolder.SelectedPath =  Directory.GetCurrentDirectory();

            if (selFolder.ShowDialog() == DialogResult.OK)
            {

                string wd = Directory.GetCurrentDirectory();

                try
                {
                    CreateSymbolicLink(wd + "\\NewLink", selFolder.SelectedPath, SYMBLOC_LINK_FLAG_DIRECTORY);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

    }
}
