// Wrapper app to call the real updater.
//
// Requires a reference to the updater service project, so it
// can call the UpdateAgent class.
//

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

namespace proto9904
{
  class Program
  {
    static void Main(string[] args)
    {
      Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Rackspace\CloudBackup", "Product Version", "0.0.0.0", RegistryValueKind.String);
      Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Rackspace\CloudBackup", "Folder", "C:\\Program Files\\Driveclient\\", RegistryValueKind.String);
      Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Rackspace\CloudBackup", "Start", "2000-01-01 00:00:01", RegistryValueKind.String);
      proto9909.UpgradeAgent.PollForUpgrade();
    }
  }
}
