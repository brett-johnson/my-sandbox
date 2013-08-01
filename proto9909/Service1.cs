// Recursive updater

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

namespace proto9909
{
  public partial class Service1 : ServiceBase
  {
    System.Timers.Timer mTimer;

    public Service1()
    {
      InitializeComponent();
    }

    protected override void OnStart(string[] args)
    {
      mTimer = new System.Timers.Timer();
      mTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnPollForUpgrade);
      mTimer.Interval = 1000 * 60 * 5; // every 5 minutes
      mTimer.Interval = 1000 * 15; // every 15 seconds
      mTimer.Enabled = true;
    }

    protected override void OnStop()
    {
    }

    public static void LogMessage(string message)
    {
      System.Diagnostics.EventLog.WriteEntry("PROTOv8", message);
    }

    public static void LogException(string message)
    {
      LogMessage("Exception: " + message);
    }

    public static void OnPollForUpgrade(object source, ElapsedEventArgs e)
    {
      UpgradeAgent.OnPollForUpgrade(source, e);
    }
  }
}
