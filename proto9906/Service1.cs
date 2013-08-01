using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Net;
using Microsoft.Win32;
using System.Timers;

namespace proto9906
{
  public partial class Service1 : ServiceBase
  {
    Thread mWorker;

    public Service1()
    {
      InitializeComponent();

    }

    protected override void OnStart(string[] args)
    {
      mWorker = new Thread(OnPollForUpgrade);
      mWorker.Name = "PollForUpgrade";
      mWorker.IsBackground = false;
      mWorker.Start();
    }

    protected override void OnStop()
    {
      mWorker.Join();
    }

    public static void OnPollForUpgrade()
    {
      //
      //
      //
      // TODO: TRY COPYING THIS MSI TO ONE OF THE BOXES WITH ADMINISTRATOR LOGIN AND SEE IF IT EXECUTES FROM THERE
      //
      //
      // REPLACE THE PACKAGE, START, WRITE "SUCCESS!" TO EVENT LOG, AND UNINSTALL SELF
      System.Diagnostics.EventLog.WriteEntry("DUMMYSERVICE", "SUCCESS!");
      //string location = System.Environment.GetEnvironmentVariable("TMP");
      //string msi = location + "\\dummy.msi";
      //ProcessStartInfo proc = new ProcessStartInfo();
      //proc.CreateNoWindow = true;
      //proc.RedirectStandardError = true;
      //proc.RedirectStandardInput = true;
      //proc.RedirectStandardOutput = true;
      //proc.UseShellExecute = false;
      //proc.ErrorDialog = false;
      //proc.WindowStyle = ProcessWindowStyle.Hidden;
      //proc.FileName = "msiexec.exe";
      //proc.Arguments = "/qn /x /l* %tmp%\\DUMMYMSI.log " + msi;
      //Process child = new Process();
      //child.StartInfo = proc;
      //if (child.Start())
      //{
      //  System.Diagnostics.EventLog.WriteEntry("DUMMYSERVICE", "proc started");
      //}
      //else
      //{
      //  System.Diagnostics.EventLog.WriteEntry("DUMMYSERVICE", "proc failed to start");
      //}
    }
  }
}
