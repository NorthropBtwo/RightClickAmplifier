using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace RightClickAmplifier.Updater
{
    public abstract class Updater
    {

        public string CurrentVersion { get { return "v" + asVersion.Major + "." + asVersion.Minor + "." + asVersion.Build + suffixVersion; } }
        public string wwwLatestRelease;

        Version asVersion;
        string suffixVersion = "";

        protected const string updaterConfigFile = "rightClickUpdater.txt";

        public class Release
        {
            public string version;
            public string downloadUrl;
        }

        public Updater(string wwwLatestRelease, bool isBetaVersion = false)
        {
            this.wwwLatestRelease = wwwLatestRelease;

            asVersion = Assembly.GetEntryAssembly().GetName().Version;
            if(isBetaVersion)
            {
                suffixVersion = "-beta";
            }          
        }

        public virtual bool IsUpToDate()
        {
            try
            {
                return getLatestReleaseVersion().version == CurrentVersion;
            }
            catch (Exception) //for example no internet
            {
                return true; //can not download update
            }
        }

        public virtual Release getLatestReleaseVersion()
        {
            return null;
        }

        public virtual string DownloadReleaseVersion(string fileName)
        {
            return "";
        }

        public static Updater GetActiveUpdater(string wwwLatestRelease, bool isBetaVersion = false)
        {
            if(File.Exists(updaterConfigFile))
            {
                return new OfflineUpdater(wwwLatestRelease, isBetaVersion);
            }
            else
            {
                return new GithubUpdater(wwwLatestRelease, isBetaVersion);
            }
        }
    }
}
