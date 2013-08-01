namespace proto9901
{
  partial class FormMessageInject
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageInject));
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.textBoxUserName = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.textBoxAuthToken = new System.Windows.Forms.TextBox();
      this.textBoxTenantId = new System.Windows.Forms.TextBox();
      this.textBoxExpiration = new System.Windows.Forms.TextBox();
      this.textBoxQueue = new System.Windows.Forms.TextBox();
      this.textBoxMessage = new System.Windows.Forms.TextBox();
      this.textBoxResults = new System.Windows.Forms.TextBox();
      this.buttonSend = new System.Windows.Forms.Button();
      this.checkBoxAuthenticate = new System.Windows.Forms.CheckBox();
      this.textBoxApiKey = new System.Windows.Forms.TextBox();
      this.maskedTextBoxTtl = new System.Windows.Forms.MaskedTextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(4, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(60, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "User Name";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(204, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "API Key";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(4, 50);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(63, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Auth Token";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(281, 53);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Tenant ID";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(428, 53);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 13);
      this.label5.TabIndex = 9;
      this.label5.Text = "Expiration";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(4, 86);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(39, 13);
      this.label6.TabIndex = 11;
      this.label6.Text = "Queue";
      // 
      // textBoxUserName
      // 
      this.textBoxUserName.Location = new System.Drawing.Point(73, 12);
      this.textBoxUserName.Name = "textBoxUserName";
      this.textBoxUserName.Size = new System.Drawing.Size(116, 20);
      this.textBoxUserName.TabIndex = 1;
      this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(291, 86);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(27, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "TTL";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(4, 121);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(87, 13);
      this.label8.TabIndex = 17;
      this.label8.Text = "Message (JSON)";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(307, 121);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(42, 13);
      this.label9.TabIndex = 19;
      this.label9.Text = "Results";
      // 
      // textBoxAuthToken
      // 
      this.textBoxAuthToken.Enabled = false;
      this.textBoxAuthToken.Location = new System.Drawing.Point(73, 50);
      this.textBoxAuthToken.Name = "textBoxAuthToken";
      this.textBoxAuthToken.Size = new System.Drawing.Size(202, 20);
      this.textBoxAuthToken.TabIndex = 6;
      // 
      // textBoxTenantId
      // 
      this.textBoxTenantId.Enabled = false;
      this.textBoxTenantId.Location = new System.Drawing.Point(352, 50);
      this.textBoxTenantId.Name = "textBoxTenantId";
      this.textBoxTenantId.Size = new System.Drawing.Size(59, 20);
      this.textBoxTenantId.TabIndex = 8;
      // 
      // textBoxExpiration
      // 
      this.textBoxExpiration.Enabled = false;
      this.textBoxExpiration.Location = new System.Drawing.Point(487, 50);
      this.textBoxExpiration.Name = "textBoxExpiration";
      this.textBoxExpiration.Size = new System.Drawing.Size(125, 20);
      this.textBoxExpiration.TabIndex = 10;
      // 
      // textBoxQueue
      // 
      this.textBoxQueue.Location = new System.Drawing.Point(73, 86);
      this.textBoxQueue.Name = "textBoxQueue";
      this.textBoxQueue.Size = new System.Drawing.Size(202, 20);
      this.textBoxQueue.TabIndex = 12;
      this.textBoxQueue.TextChanged += new System.EventHandler(this.textBoxQueue_TextChanged);
      // 
      // textBoxMessage
      // 
      this.textBoxMessage.AcceptsReturn = true;
      this.textBoxMessage.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxMessage.Location = new System.Drawing.Point(7, 149);
      this.textBoxMessage.Multiline = true;
      this.textBoxMessage.Name = "textBoxMessage";
      this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBoxMessage.Size = new System.Drawing.Size(285, 281);
      this.textBoxMessage.TabIndex = 18;
      this.textBoxMessage.TextChanged += new System.EventHandler(this.textBoxMessage_TextChanged);
      // 
      // textBoxResults
      // 
      this.textBoxResults.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBoxResults.Location = new System.Drawing.Point(310, 149);
      this.textBoxResults.MaxLength = 65535;
      this.textBoxResults.Multiline = true;
      this.textBoxResults.Name = "textBoxResults";
      this.textBoxResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBoxResults.Size = new System.Drawing.Size(302, 281);
      this.textBoxResults.TabIndex = 20;
      // 
      // buttonSend
      // 
      this.buttonSend.Location = new System.Drawing.Point(538, 10);
      this.buttonSend.Name = "buttonSend";
      this.buttonSend.Size = new System.Drawing.Size(75, 23);
      this.buttonSend.TabIndex = 4;
      this.buttonSend.Text = "Send";
      this.buttonSend.UseVisualStyleBackColor = true;
      this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
      // 
      // checkBoxAuthenticate
      // 
      this.checkBoxAuthenticate.AutoSize = true;
      this.checkBoxAuthenticate.Checked = true;
      this.checkBoxAuthenticate.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxAuthenticate.Location = new System.Drawing.Point(526, 88);
      this.checkBoxAuthenticate.Name = "checkBoxAuthenticate";
      this.checkBoxAuthenticate.Size = new System.Drawing.Size(86, 17);
      this.checkBoxAuthenticate.TabIndex = 16;
      this.checkBoxAuthenticate.Text = "Authenticate";
      this.checkBoxAuthenticate.UseVisualStyleBackColor = true;
      this.checkBoxAuthenticate.CheckedChanged += new System.EventHandler(this.checkBoxAuthenticate_CheckedChanged);
      // 
      // textBoxApiKey
      // 
      this.textBoxApiKey.Location = new System.Drawing.Point(264, 12);
      this.textBoxApiKey.Name = "textBoxApiKey";
      this.textBoxApiKey.PasswordChar = '*';
      this.textBoxApiKey.Size = new System.Drawing.Size(247, 20);
      this.textBoxApiKey.TabIndex = 3;
      this.textBoxApiKey.TextChanged += new System.EventHandler(this.textBoxApiKey_TextChanged);
      // 
      // maskedTextBoxTtl
      // 
      this.maskedTextBoxTtl.Location = new System.Drawing.Point(334, 83);
      this.maskedTextBoxTtl.Mask = "00000";
      this.maskedTextBoxTtl.Name = "maskedTextBoxTtl";
      this.maskedTextBoxTtl.Size = new System.Drawing.Size(77, 20);
      this.maskedTextBoxTtl.TabIndex = 14;
      this.maskedTextBoxTtl.ValidatingType = typeof(int);
      this.maskedTextBoxTtl.TextAlignChanged += new System.EventHandler(this.maskedTextBoxTtl_TextChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(468, 84);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(43, 23);
      this.button1.TabIndex = 15;
      this.button1.Text = "URLs";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // FormMessageInject
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(624, 442);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.maskedTextBoxTtl);
      this.Controls.Add(this.textBoxApiKey);
      this.Controls.Add(this.checkBoxAuthenticate);
      this.Controls.Add(this.buttonSend);
      this.Controls.Add(this.textBoxResults);
      this.Controls.Add(this.textBoxMessage);
      this.Controls.Add(this.textBoxQueue);
      this.Controls.Add(this.textBoxExpiration);
      this.Controls.Add(this.textBoxTenantId);
      this.Controls.Add(this.textBoxAuthToken);
      this.Controls.Add(this.textBoxUserName);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FormMessageInject";
      this.Text = "Cloud Queue Message Injection";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox textBoxUserName;
    private System.Windows.Forms.TextBox textBoxAuthToken;
    private System.Windows.Forms.TextBox textBoxTenantId;
    private System.Windows.Forms.TextBox textBoxExpiration;
    private System.Windows.Forms.TextBox textBoxQueue;
    private System.Windows.Forms.TextBox textBoxMessage;
    private System.Windows.Forms.TextBox textBoxResults;
    private System.Windows.Forms.Button buttonSend;
    private System.Windows.Forms.CheckBox checkBoxAuthenticate;
    private System.Windows.Forms.TextBox textBoxApiKey;
    private System.Windows.Forms.MaskedTextBox maskedTextBoxTtl;
    private System.Windows.Forms.Button button1;
  }
}

