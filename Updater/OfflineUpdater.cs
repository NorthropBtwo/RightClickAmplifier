using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RightClickAmplifier.Updater
{
    public class OfflineUpdater : Updater
    {
      
        string downloadPath = "";

        public OfflineUpdater(string wwwLatestRelease, bool isBetaVersion = false) : base(wwwLatestRelease, isBetaVersion)
        {
            
            try
            {
                if (File.Exists(updaterConfigFile))
                {
                    string[] lines = File.ReadAllLines(updaterConfigFile);
                    downloadPath = lines[0];
                }
            }  
            catch(Exception)
            {
            }     
        }

        public override Release getLatestReleaseVersion()
        {
            Release release = new Release();

            if (downloadPath != "" && File.Exists(downloadPath))
            {
                Version latestRelease = AssemblyName.GetAssemblyName(downloadPath).Version;
                release.version = "v" + latestRelease.Major + "." + latestRelease.Minor + "." + latestRelease.Build + "-beta";
                release.downloadUrl = downloadPath;
            }
            else
            {
                throw new Exception("dile not found: " + downloadPath);
            }

            return release;
        }

        public override string DownloadReleaseVersion(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.Copy(downloadPath, fileName);

            return "";
        }



    }
}
