// Recursive updater

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using Microsoft.Win32;
using System.Timers;

namespace proto9909
{
  public class UpgradeAgent
  {
    public class UpdateRegistry
    {
      public string mInstallFolder;
      public DateTime mStartTime;
      public DateTime mLastTime;
      public bool mIsValid;
      public bool mDebug;
      public int mVersionMajor;
      public int mVersionMinor;
      public int mVersionBuild;

      public UpdateRegistry()
      {
        Clear();
        LoadRegistrySettings();
      }

      public void Clear()
      {
        mIsValid = false;
        mInstallFolder = "";
        mStartTime = DateTime.MinValue;
        mLastTime = DateTime.MinValue;
        mDebug = false;
        mVersionMajor = 0;
        mVersionMinor = 0;
        mVersionBuild = 0;
      }

      public int GetRegistryValue(RegistryKey key, string name, int defaultValue)
      {
        object entry = key.GetValue(name);
        if (entry == null)
        {
          LogMessage("registry value is null: " + name);
          return defaultValue;
        }

        return (int)(key.GetValue(name, 0));
      }

      public string GetRegistryValue(RegistryKey key, string name)
      {
        object entry = key.GetValue(name);
        if (entry == null)
        {
          LogMessage("registry value is null: " + name);
          return "";
        }

        return entry.ToString();
      }

      public bool GetVersionInfo(RegistryKey key)
      {
        string line = GetRegistryValue(key, "Product Version");
        if (line.Length == 0)
        {
          LogMessage("registry unable to get version");
          return false;
        }

        string[] section = line.Split('.');
        if (section.Length != 4)
        {
          LogMessage("ERROR: registry version " + line + " is not in the right format");
          return false;
        }

        mVersionMajor = Convert.ToInt32(section[0]);
        mVersionMinor = Convert.ToInt32(section[1]);
        mVersionBuild = Convert.ToInt32(section[2]);

        return true;
      }

      public bool LoadRegistrySettings()
      {
        try
        {
          RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Rackspace\CloudBackup", false);
          string debug_status = GetRegistryValue(key, "Debug");
          if (debug_status == "true" || debug_status == "TRUE" || debug_status == "True" ||
            debug_status == "t" || debug_status == "T" ||
            debug_status == ".T." || debug_status == ".t." ||
            debug_status == "1")
          {
            mDebug = true;
          }
          string folder = GetRegistryValue(key, "Folder");
          if (folder.Length == 0)
          {
            LogMessage("ERROR: could not get install folder information.");
            return false;
          }
          mInstallFolder = folder.ToString().Trim();
          if (mDebug)
          {
            LogMessage("Install folder: " + mInstallFolder);
          }
          string start = GetRegistryValue(key, "Start");
          mStartTime = DateTime.Parse(start);
          string last = GetRegistryValue(key, "Last");
          if (last.Length != 0)
          {
            mLastTime = DateTime.Parse(last);
          }
          if (!GetVersionInfo(key))
          {
            return false;
          }
          mIsValid = true;
          return true;
        }
        catch (System.NullReferenceException e)
        {
          LogException("Null reg reference: " + e);
        }
        catch (System.ArgumentNullException e)
        {
          LogException("Argument reg null: " + e);
        }
        catch (System.ObjectDisposedException e)
        {
          LogException("Object reg disposed: " + e);
        }
        catch (System.Security.SecurityException e)
        {
          LogException("System reg security: " + e);
        }
        catch (System.IO.IOException e)
        {
          LogException("I/O reg: " + e);
        }
        catch (System.UnauthorizedAccessException e)
        {
          LogException("Unauthorized reg access: " + e);
        }
        catch (System.FormatException e)
        {
          LogException("format reg: " + e);
        }
        catch (System.Exception e)
        {
          LogException("reg unknown: " + e);
        }

        Clear();
        return false;
      }

      public void SaveUpdateTime()
      {
        string now = DateTime.Now.ToString();
        Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Rackspace\CloudBackup", "Last", now, RegistryValueKind.String);
      }
    }

    public class Downloader
    {
      public string mAddress;
      public string mStagingFolder;
      public bool mIsValid;
      public Downloader()
      {
        mIsValid = false;
        try
        {
          if (System.Environment.Is64BitOperatingSystem)
          {
            mAddress = "http://build.drivesrvr-dev.com/brett/windows/";
          }
          else
          {
            mAddress = "http://build.drivesrvr-dev.com/brett/windows32/";
          }
          mStagingFolder = System.Environment.GetEnvironmentVariable("TMP");
          mIsValid = true;
          return;
        }
        catch (System.ArgumentNullException e)
        {
          LogException("staging folder null: " + e);
        }
        catch (System.Security.SecurityException e)
        {
          LogException("staging security: " + e);
        }
      }
      public bool GetFile(UpdateRegistry reg, string filename)
      {
        try
        {
          string file_url = mAddress + filename;
          string file_path = mStagingFolder + "\\" + filename;

          LogMessage("downloading: " + file_path);

          using (WebClient browser = new WebClient())
          {
            browser.DownloadFile(file_url, file_path);
            LogMessage("download successful: " + file_path);
          }
          return true;
        }
        catch (System.Net.WebException e)
        {
          LogException("Web: " + e.ToString());
        }
        catch (System.NotSupportedException e)
        {
          LogException("Web: " + e.ToString());
        }
        catch (System.Exception e)
        {
          LogException("Web: " + e.ToString());
        }

        return false;
      }
    }

    public UpgradeAgent()
    {
    }

    public static void LogMessage(string message)
    {
      System.Diagnostics.EventLog.WriteEntry("PROTOv9", message);
    }

    public static void LogException(string message)
    {
      LogMessage("Exception: " + message);
    }

    public static void OnPollForUpgrade(object source, ElapsedEventArgs e)
    {
      PollForUpgrade();
    }

    public static void PollForUpgrade()
    {
      UpdateRegistry reg = new UpdateRegistry();
      if (!reg.mIsValid)
      {
        return;
      }

      DateTime start_time = DateTime.Now.Date.AddMinutes(reg.mStartTime.Minute).AddHours(reg.mStartTime.Hour);
      if (start_time < reg.mLastTime)
      {
        LogMessage("SKIPPING UPDATE: " + start_time + " is earlier than " + reg.mLastTime);
        return;
      }

      Downloader downloader = new Downloader();
      int[] new_version = GetNewVersion(reg, downloader);
      if (new_version.Length != 3)
      {
        return;
      }
      SelfUpdate(reg, downloader, new_version);
    }

    public static int[] GetVersionInfo(UpdateRegistry reg)
    {
      int[] version_info = new int[3];
      version_info[0] = reg.mVersionMajor;
      version_info[1] = reg.mVersionMinor;
      version_info[2] = reg.mVersionBuild;

      if (reg.mDebug)
      {
        LogMessage("version info major: " + version_info[0] + " minor: " + version_info[1] + " build: " + version_info[2]);
      }

      return version_info;
    }

    public static int[] GetVersionInfo(UpdateRegistry reg, string filename)
    {
      int[] version_info = new int[0];
      string[] line = System.IO.File.ReadAllLines(filename);
      if (line.Length < 1)
      {
        LogMessage("ERROR: version file length");
        return version_info;
      }

      string[] section = line[0].Split('.');
      if (section.Length != 3)
      {
        LogMessage("ERROR: " + line[0] + " is not in the right format");
        return version_info;
      }

      version_info = new int[3];
      version_info[0] = Convert.ToInt32(section[0]);
      version_info[1] = Convert.ToInt32(section[1]);
      version_info[2] = Convert.ToInt32(section[2]);

      if (reg.mDebug)
      {
        LogMessage("version info major: " + section[0] + " minor: " + section[1] + " build: " + section[2] + " file name: " + filename);
      }

      return version_info;
    }

    public static int[] GetNewVersion(UpdateRegistry reg, Downloader downloader)
    {
      try
      {
        string file_name = "agent_version.txt";
        if (!downloader.GetFile(reg, file_name))
        {
          LogMessage("ERROR: could not get: " + file_name);
          return new int[0];
        }

        string upgrade_version_file = downloader.mStagingFolder + "\\" + file_name;
        int[] upgrade_version = GetVersionInfo(reg, upgrade_version_file);
        if (upgrade_version.Length == 0)
        {
          LogMessage("ERROR: getting version info from: " + upgrade_version_file);
          return new int[0];
        }

        string installed_version_file = reg.mInstallFolder + file_name;
        int[] installed_version = GetVersionInfo(reg);

        // save the last time we checked for updates
        reg.SaveUpdateTime();

        if (upgrade_version[0] != installed_version[0] ||
          upgrade_version[1] != installed_version[1] ||
          upgrade_version[2] != installed_version[2])
        {
          // NOTE: installed version file is updated by the MSI
          return upgrade_version;
        }

        // NOTE: If we set the time here, we will continue to upgrade until we are current;
        // however, that could also get us into an endless loop, if we mess up the version
        // numbers.
        //reg.SaveUpdateTime();
      }
      catch (System.ArgumentNullException e)
      {
        LogException("version null argument: " + e);
      }
      catch (System.IO.PathTooLongException e)
      {
        LogException("version path: " + e);
      }
      catch (System.IO.DirectoryNotFoundException e)
      {
        LogException("version directory: " + e);
      }
      catch (System.IO.IOException e)
      {
        LogException("version I/O: " + e);
      }
      catch (System.UnauthorizedAccessException e)
      {
        LogException("version unauthorized: " + e);
      }
      catch (System.NotSupportedException e)
      {
        LogException("version not supported: " + e);
      }
      catch (System.Security.SecurityException e)
      {
        LogException("version security: " + e);
      }
      catch (System.FormatException e)
      {
        LogException("version format: " + e);
      }
      catch (System.OverflowException e)
      {
        LogException("version overflow: " + e);
      }
      catch (System.Exception e)
      {
        LogException("version general: " + e);
      }

      return new int[0];
    }

    public static void SelfUpdate(UpdateRegistry reg, Downloader downloader, int[] newVersion)
    {
      try
      {
        LogMessage("INSTALLING Driveclient");
        string version_text = newVersion[0].ToString() + "." + newVersion[1].ToString("00") + "." + newVersion[2].ToString("000000");
        string base_name = "driveclient-setup-" + version_text + ".msi";
        string staged_name = downloader.mStagingFolder + "\\" + base_name;
        if (reg.mDebug)
        {
          LogMessage("stanged name: " + staged_name + " url name: " + base_name);
        }

        downloader.GetFile(reg, base_name);
        ProcessStartInfo proc = new ProcessStartInfo();
        proc.CreateNoWindow = true;
        proc.RedirectStandardError = true;
        proc.RedirectStandardInput = true;
        proc.RedirectStandardOutput = true;
        proc.UseShellExecute = false;
        proc.ErrorDialog = false;
        proc.WindowStyle = ProcessWindowStyle.Hidden;
        proc.FileName = "msiexec.exe";
        proc.Arguments = "/qn /i " + staged_name + " /L*v " + downloader.mStagingFolder + "\\" + base_name + ".log";
        if (reg.mDebug)
        {
          LogMessage("installing with: " + proc.Arguments);
        }

        Process child = new Process();
        child.StartInfo = proc;
        if (child.Start())
        {
          LogMessage("install started: " + proc.Arguments);
        }
        else
        {
          LogMessage("install failed to start: " + proc.Arguments);
        }
      }
      catch (System.Exception e)
      {
        LogException("install general: " + e);
      }
    }

    public static string InterpretErrorCode(int code)
    {
      Dictionary<int, string> er = new Dictionary<int, string>();
      er[0] = "SUCCESS!";
      er[1601] = "The Windows Installer service could not be accessed. Contact your support personnel to verify that the Windows Installer service is properly registered.";
      er[1602] = "User cancel installation.";
      er[1603] = "Fatal error during installation.";
      er[1604] = "Installation suspended, incomplete.";
      er[1605] = "This action is only valid for products that are currently installed.";
      er[1606] = "Feature ID not registered.";
      er[1607] = "Component ID not registered.";
      er[1608] = "Unknown property.";
      er[1609] = "Handle is in an invalid state.";
      er[1610] = "The configuration data for this product is corrupt. Contact your support personnel.";
      er[1611] = "Component qualifier not present.";
      er[1612] = "The installation source for this product is not available. Verify that the source exists and that you can access it.";
      er[1613] = "This installation package cannot be installed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.";
      er[1614] = "Product is un-installed.";
      er[1615] = "SQL query syntax invalid or unsupported.";
      er[1616] = "Record field does not exist.";
      er[1618] = "Another installation is already in progress. Complete that installation before proceeding with this install.";
      er[1619] = "This installation package could not be opened. Verify that the package exists and that you can access it, or contact the application vendor to verify that this is a valid Windows Installer package.";
      er[1620] = "This installation package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer package.";
      er[1621] = "There was an error starting the Windows Installer service user interface. Contact your support personnel.";
      er[1622] = "Error opening installation log file. Verify that the specified log file location exists and is writable.";
      er[1623] = "This language of this installation package is not supported by your system.";
      er[1625] = "This installation is forbidden by system policy. Contact your system administrator.";
      er[1626] = "Function could not be executed.";
      er[1627] = "Function failed during execution.";
      er[1628] = "Invalid or unknown table specified.";
      er[1629] = "Data supplied is of wrong type.";
      er[1630] = "Data of this type is not supported.";
      er[1631] = "The Windows Installer service failed to start. Contact your support personnel.";
      er[1632] = "The temp folder is either full or inaccessible. Verify that the temp folder exists and that you can write to it.";
      er[1633] = "This installation package is not supported on this platform. Contact your application vendor.";
      er[1634] = "Component not used on this machine.";
      er[1624] = "Error applying transforms. Verify that the specified transform paths are valid.";
      er[1635] = "This patch package could not be opened. Verify that the patch package exists and that you can access it, or contact the application vendor to verify that this is a valid Windows Installer patch package.";
      er[1636] = "This patch package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer patch package.";
      er[1637] = "This patch package cannot be processed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.";
      er[1638] = "Another version of this product is already installed. Installation of this version cannot continue. To configure or remove the existing version of this product, use Add/Remove Programs on the Control Panel.";
      er[1639] = "Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.";
      er[3010] = "A restart is required to complete the install. This does not include installs where the ForceReboot action is run. Note that this error will not be available until future version of the installer.";
      if (er.ContainsKey(code))
      {
        return er[code];
      }
      return "unknown error code: " + code;
    }
  }
}
