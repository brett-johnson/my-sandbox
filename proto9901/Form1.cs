using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace proto9901
{
  public partial class FormMessageInject : Form
  {
    string mLastError;
    CloudQueueTools.IdentityResult mResult;
    CloudQueueTools.ConnectionSettings mSettings;
    public string mIdentityServer;
    public string mQueueServer;
    RegistryKey mKey;
    const string IdentityServerKey = "IdentityServer";
    const string QueueServerKey = "QueueServer";
    const string ApiKeyKey = "API Key";
    const string UserNameKey = "User Name";
    const string QueueNameKey = "Last Queue";
    const string LastMessageKey = "Last Message";
    const string TimeToLiveKey = "Last TTL";

    public FormMessageInject()
    {
      InitializeComponent();
      CloudQueueTools.DisableCertChecking();
      try
      {
        mKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Rackspace\\CloudQueue");
        mIdentityServer = mKey.GetValue(IdentityServerKey).ToString();
        mQueueServer = mKey.GetValue(QueueServerKey).ToString();
        this.textBoxApiKey.Text = mKey.GetValue(ApiKeyKey).ToString();
        this.textBoxUserName.Text = mKey.GetValue(UserNameKey).ToString();
        this.textBoxQueue.Text = mKey.GetValue(QueueNameKey).ToString();
        this.textBoxMessage.Text = mKey.GetValue(LastMessageKey).ToString();
        this.textBoxMessage.Text = mKey.GetValue(LastMessageKey).ToString();
        maskedTextBoxTtl.Text = mKey.GetValue(TimeToLiveKey).ToString();
      }
      catch (System.Exception e)
      {
        mLastError = e.ToString();
        mKey.SetValue(IdentityServerKey, "https://identity.api.rackspacecloud.com/v2.0/tokens/");
        mKey.SetValue(QueueServerKey, "https://preview.queue.api.rackspacecloud.com:443/v1/queues/QQQQQQQQQQ/messages");
      }
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
      // Authenticate (if necessary), then do the rest of the request
      if (checkBoxAuthenticate.Checked)
      {
        string uri = mIdentityServer;
        mResult = CloudQueueTools.AuthenticateIdentity(uri, textBoxUserName.Text, textBoxApiKey.Text);

        this.textBoxResults.Text = mResult.reply;

        if (mResult.token.Length == 0)
        {
          MessageBox.Show("Failed to authenticate!", "Authentication Failure", MessageBoxButtons.OK);
          return;
        }

        textBoxAuthToken.Text = mResult.token;
        textBoxTenantId.Text = mResult.tenant;
        textBoxExpiration.Text = mResult.expires.ToString();
        checkBoxAuthenticate.Checked = false;
      }

      // the rest of the request: send the actual message to the queue
      if ((this.textBoxMessage.Text.Length > 0) && (textBoxAuthToken.Text.Length > 0))
      {
        mSettings.q = this.textBoxQueue.Text;
        mSettings.token = mResult.token;
        mSettings.tenant = mResult.tenant;
        mSettings.url = mQueueServer;
        string reply = CloudQueueTools.InsertMessageIntoQueue(mSettings, this.textBoxMessage.Text);
        if (textBoxResults.Text.Length > 0)
        {
          textBoxResults.Text = textBoxResults.Text + "\n\n\n\n" + reply;
        }
        else
        {
          textBoxResults.Text = reply;
        }
      }
    }

    private void checkBoxAuthenticate_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBoxAuthenticate.Checked)
      {
        this.textBoxAuthToken.Text = "";
        this.textBoxExpiration.Text = "";
        this.textBoxTenantId.Text = "";
      }
    }

    private void textBoxUserName_TextChanged(object sender, EventArgs e)
    {
      mKey.SetValue(UserNameKey, textBoxUserName.Text);
    }

    private void textBoxApiKey_TextChanged(object sender, EventArgs e)
    {
      mKey.SetValue(ApiKeyKey, textBoxApiKey.Text);
    }

    private void textBoxQueue_TextChanged(object sender, EventArgs e)
    {
      mKey.SetValue(QueueNameKey, textBoxQueue.Text);
    }

    private void textBoxMessage_TextChanged(object sender, EventArgs e)
    {
      mKey.SetValue(LastMessageKey, textBoxMessage.Text);
    }

    private void maskedTextBoxTtl_TextChanged(object sender, EventArgs e)
    {
      mKey.SetValue(TimeToLiveKey, maskedTextBoxTtl.Text);
    }
  }
}
