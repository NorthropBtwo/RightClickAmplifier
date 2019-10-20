using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace RightClickAmplifier
{


    public partial class FrmMain : Form
    {


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        List<ContextMakro> makros = new List<ContextMakro>();
        List<ContextMakro> oldMakros = new List<ContextMakro>();

        string configXML;

        Updater.Updater updater = Updater.Updater.GetActiveUpdater("https://api.github.com/repos/NorthropBtwo/RightClickAmplifier/releases/latest" , true);

        public FrmMain()
        {
            InitializeComponent();
        }

        string GetFileLocaation()
        {
           return Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           configXML = GetFileLocaation() + "\\rightClickSettings.xml";

            if (File.Exists(configXML))
            {

                XDocument xml = XDocument.Load(configXML);
                using (var reader = xml.CreateReader())
                {
                    try
                    {
                        var deserializer = new DataContractSerializer(makros.GetType(), PlugInSystem.GetAllTypes(typeof(ContextFunction)));
                        makros = ((List<ContextMakro>)deserializer.ReadObject(reader, false));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Unknown Makro Found: " + Environment.NewLine + Environment.NewLine + ex.Message);
                    }
                }



                string[] args = Environment.GetCommandLineArgs();

                if (args.Length > 1) //exectuted from right-click menu
                {
                    string makroName = args[1];
                    List<ContextMakro> machingMakros =  makros.Where(x => x.Name == makroName).ToList();
                    if(machingMakros.Count > 0)
                    {
                        machingMakros[0].PerformAction(args);
                    }

                    Environment.Exit(0);
                }
            }
            else
            {
               // makros.AddRange(new ContextMakro[] { new ContextMakro("aaaa"), new ContextMakro("bb"), new ContextMakro("cc"), new ContextMakro("dd"), new ContextMakro("ee"), new ContextMakro("ff"), new ContextMakro("gg"), new ContextMakro("hh"), new ContextMakro("jj") });
            }

#if !DEBUG
            if (!SecurityMgmt.HasAdminRights())
            {
                SecurityMgmt.ReRunAsAdmin();
            }
#endif

            UpdateMakroView();

            OverwriteMakroBackup();

            try
            {
                if(File.Exists(oldVersion))
                {
                    File.Delete(oldVersion);
                }

                if (!updater.IsUpToDate())
                {
                    cmdUpdate.Visible = true;
                }
            }
            catch (Exception)
            {
            } 
        }

        private void OverwriteMakroBackup()
        {
            oldMakros.Clear();
            foreach (var makro in makros)
            {
                oldMakros.Add(makro.Clone());
            }

        }



        private void UpdateMakroView()
        {

            SendMessage(grpMakros.Handle, WM_SETREDRAW, false, 0);

            grpMakros.Items.Clear();
            foreach (var makro in makros)
            {
                grpMakros.Items.Add(makro);
            }

            SendMessage(grpMakros.Handle, WM_SETREDRAW, true, 0);
            grpMakros.Refresh();
        }

        private void CmdMakroEdit_Click(object sender, EventArgs e)
        {
            Control contrl = sender as Control;
            if (contrl != null)
            {
                ContextMakro makro = contrl.Tag as ContextMakro;
                if (makro != null)
                {
                    (new FrmMakroEditor()).ShowDialog(makro);
                    UpdateMakroView();
                }
            }
        }

        private void cmdAddMakro_Click(object sender, EventArgs e)
        {
            ContextMakro newMakro;
            if ((newMakro = (new FrmMakroEditor()).ShowDialog(null)) != null)
            {
                makros.Add(newMakro);
                UpdateMakroView();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void SaveXML_Click(object sender, EventArgs e)
        {
            XDocument xml = new XDocument();
            using (var writer = xml.CreateWriter())
            {
                List<Type> knownTypes = PlugInSystem.GetAllTypes(typeof(ContextFunction));
                knownTypes.Add(makros.GetType());
                var serializer = new DataContractSerializer(makros.GetType(), knownTypes);
                serializer.WriteObject(writer, makros);
            }                
            xml.Save(configXML);
        }

        private void cmdSaveReg_Click(object sender, EventArgs e)
        {
            foreach(var makro in makros)
            {
                foreach(var fileExt in makro.FileExtensions)
                {
                    string fileType = RegMgmt.GetFileType(fileExt.ToString());
                    RegMgmt.AddContextFunction(fileType, makro);
                }
            }

            OverwriteMakroBackup();
        }

        private void cmdCleanReg_Click(object sender, EventArgs e)
        {
            var extensions = RegMgmt.GetExtensions();
            List<string> listExtens = new List<string>(extensions);
            listExtens.Add("*");
            listExtens.Add("directory");
            listExtens.Add("directory/Background");

            List<string> fileTypes = new List<string>();
            foreach (var extend in listExtens)
            {
                fileTypes.Add(RegMgmt.GetFileType(extend));
            }

            List<string> totalEnbaledFunctions = new List<string>();
            foreach (var fileType in fileTypes)
            {
                List<string> enbaledFunctions = RegMgmt.GetEnabledContextFunctions(fileType);
                totalEnbaledFunctions.AddRange(enbaledFunctions);

                foreach (var enbaledFunction in enbaledFunctions)
                {
                    RegMgmt.RemoveContextFunction(fileType, enbaledFunction);
                }
            }
            MessageBox.Show("Successfully cleaned up registry");
        }


        private void cmdFastClean_Click(object sender, EventArgs e)
        {
            foreach(var makro in oldMakros)
            {
                foreach(var extension in makro.FileExtensions)
                {
                    string fileType = RegMgmt.GetFileType(extension.ToString());
                    RegMgmt.RemoveContextFunction(fileType, makro.Name);
                }
            }
        }

        private void cmd2pdf_Click(object sender, EventArgs e)
        {
            ContextFunction conFunc = new ConFuncWordtoPDF();
            conFunc.PerformAction(null, new string[] { "", "", @"C:\Users\Northrop\Desktop\temp\testwordsPDF eraer aasd2.docx" });

        }

        private void cndSave_Click(object sender, EventArgs e)
        {
            cmdFastClean_Click(sender, e);
            cmdSaveReg_Click(sender, e);
            SaveXML_Click(sender, e);
            MessageBox.Show("Successfully saved");
        }

        private void grpMakros_ButtonEditClick(object sender, EventArgs e)
        {
            var makro = ((Control)sender).Tag as ContextMakro;
            if (makro != null)
            {
                (new FrmMakroEditor()).ShowDialog(makro);
                UpdateMakroView();
            }
        }

        private void grpMakros_ButtonDeleteClick(object sender, EventArgs e)
        {
            var makro = ((Control)sender).Tag as ContextMakro;
            if (makro != null)
            {
                makros.Remove(makro);
                UpdateMakroView();
            }
        }

        private void cmdCreateSoftLink_Click(object sender, EventArgs e)
        {
            ConfFuncRelativNTFSJunction conf = new ConfFuncRelativNTFSJunction();
            conf.PerformAction(null, null);
        }

        string newestVersion = Process.GetCurrentProcess().MainModule.FileName + ".temp";
        string oldVersion = Process.GetCurrentProcess().MainModule.FileName + ".oldtemp";
        string curVersion = Process.GetCurrentProcess().MainModule.FileName;

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            updater.DownloadReleaseVersion(newestVersion);
            File.Move(curVersion, oldVersion);
            File.Move(newestVersion, curVersion);

            if (File.Exists(curVersion))
            {
                Process.Start(curVersion);
            }

            Environment.Exit(0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FrmAboutBox()).ShowDialog();
        }
    }


  
}
