namespace BACnetTest
{
  partial class MainForm
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
      this.TestReadLabel = new System.Windows.Forms.Label();
      this.TestReadPropBtn = new System.Windows.Forms.Button();
      this.BroadcastLabel = new System.Windows.Forms.Label();
      this.DeviceList = new System.Windows.Forms.ListBox();
      this.TestWriteLabel = new System.Windows.Forms.Label();
      this.TestBinaryOffBtn = new System.Windows.Forms.Button();
      this.TestBinaryOnBtn = new System.Windows.Forms.Button();
      this.PCIDAddressText = new System.Windows.Forms.TextBox();
      this.label26 = new System.Windows.Forms.Label();
      this.SerialNumberText = new System.Windows.Forms.TextBox();
      this.SerialNumberCaption = new System.Windows.Forms.Label();
      this.DeviceIDText = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.GetObjectsBtn = new System.Windows.Forms.Button();
      this.ObjectList = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ObjectListLabel = new System.Windows.Forms.Label();
      this.ObjectLabel = new System.Windows.Forms.Label();
      this.PresentValueLabel = new System.Windows.Forms.Label();
      this.ReadPresentValueBtn = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.ServerText = new System.Windows.Forms.TextBox();
      this.DeviceLabel = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // TestReadLabel
      // 
      this.TestReadLabel.AutoSize = true;
      this.TestReadLabel.Location = new System.Drawing.Point(186, 133);
      this.TestReadLabel.Name = "TestReadLabel";
      this.TestReadLabel.Size = new System.Drawing.Size(57, 13);
      this.TestReadLabel.TabIndex = 60;
      this.TestReadLabel.Text = "Test Read";
      // 
      // TestReadPropBtn
      // 
      this.TestReadPropBtn.Location = new System.Drawing.Point(189, 107);
      this.TestReadPropBtn.Name = "TestReadPropBtn";
      this.TestReadPropBtn.Size = new System.Drawing.Size(102, 23);
      this.TestReadPropBtn.TabIndex = 59;
      this.TestReadPropBtn.Text = "Test Read Prop";
      this.TestReadPropBtn.UseVisualStyleBackColor = true;
      this.TestReadPropBtn.Click += new System.EventHandler(this.TestReadPropBtn_Click);
      // 
      // BroadcastLabel
      // 
      this.BroadcastLabel.AutoSize = true;
      this.BroadcastLabel.Location = new System.Drawing.Point(9, 30);
      this.BroadcastLabel.Name = "BroadcastLabel";
      this.BroadcastLabel.Size = new System.Drawing.Size(79, 13);
      this.BroadcastLabel.TabIndex = 58;
      this.BroadcastLabel.Text = "Devices Found";
      // 
      // DeviceList
      // 
      this.DeviceList.FormattingEnabled = true;
      this.DeviceList.Location = new System.Drawing.Point(12, 51);
      this.DeviceList.Name = "DeviceList";
      this.DeviceList.Size = new System.Drawing.Size(155, 329);
      this.DeviceList.TabIndex = 57;
      this.DeviceList.SelectedIndexChanged += new System.EventHandler(this.DeviceList_SelectedIndexChanged);
      // 
      // TestWriteLabel
      // 
      this.TestWriteLabel.AutoSize = true;
      this.TestWriteLabel.Location = new System.Drawing.Point(552, 133);
      this.TestWriteLabel.Name = "TestWriteLabel";
      this.TestWriteLabel.Size = new System.Drawing.Size(56, 13);
      this.TestWriteLabel.TabIndex = 63;
      this.TestWriteLabel.Text = "Test Write";
      // 
      // TestBinaryOffBtn
      // 
      this.TestBinaryOffBtn.Location = new System.Drawing.Point(625, 107);
      this.TestBinaryOffBtn.Name = "TestBinaryOffBtn";
      this.TestBinaryOffBtn.Size = new System.Drawing.Size(64, 23);
      this.TestBinaryOffBtn.TabIndex = 62;
      this.TestBinaryOffBtn.Text = "Test Off";
      this.TestBinaryOffBtn.UseVisualStyleBackColor = true;
      this.TestBinaryOffBtn.Click += new System.EventHandler(this.TestBinaryOffBtn_Click);
      // 
      // TestBinaryOnBtn
      // 
      this.TestBinaryOnBtn.Location = new System.Drawing.Point(555, 107);
      this.TestBinaryOnBtn.Name = "TestBinaryOnBtn";
      this.TestBinaryOnBtn.Size = new System.Drawing.Size(64, 23);
      this.TestBinaryOnBtn.TabIndex = 61;
      this.TestBinaryOnBtn.Text = "Test On";
      this.TestBinaryOnBtn.UseVisualStyleBackColor = true;
      this.TestBinaryOnBtn.Click += new System.EventHandler(this.TestBinaryOnBtn_Click);
      // 
      // PCIDAddressText
      // 
      this.PCIDAddressText.Location = new System.Drawing.Point(271, 264);
      this.PCIDAddressText.Name = "PCIDAddressText";
      this.PCIDAddressText.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.PCIDAddressText.Size = new System.Drawing.Size(89, 20);
      this.PCIDAddressText.TabIndex = 64;
      this.PCIDAddressText.Visible = false;
      // 
      // label26
      // 
      this.label26.AutoSize = true;
      this.label26.Location = new System.Drawing.Point(190, 267);
      this.label26.Name = "label26";
      this.label26.Size = new System.Drawing.Size(75, 13);
      this.label26.TabIndex = 69;
      this.label26.Text = "PC IP Address";
      this.label26.Visible = false;
      // 
      // SerialNumberText
      // 
      this.SerialNumberText.Location = new System.Drawing.Point(271, 332);
      this.SerialNumberText.Name = "SerialNumberText";
      this.SerialNumberText.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.SerialNumberText.Size = new System.Drawing.Size(76, 20);
      this.SerialNumberText.TabIndex = 67;
      this.SerialNumberText.Visible = false;
      // 
      // SerialNumberCaption
      // 
      this.SerialNumberCaption.AutoSize = true;
      this.SerialNumberCaption.Location = new System.Drawing.Point(190, 335);
      this.SerialNumberCaption.Name = "SerialNumberCaption";
      this.SerialNumberCaption.Size = new System.Drawing.Size(43, 13);
      this.SerialNumberCaption.TabIndex = 68;
      this.SerialNumberCaption.Text = "Serial #";
      this.SerialNumberCaption.Visible = false;
      // 
      // DeviceIDText
      // 
      this.DeviceIDText.Location = new System.Drawing.Point(271, 298);
      this.DeviceIDText.Name = "DeviceIDText";
      this.DeviceIDText.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.DeviceIDText.Size = new System.Drawing.Size(58, 20);
      this.DeviceIDText.TabIndex = 66;
      this.DeviceIDText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.DeviceIDText.Visible = false;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(190, 301);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(55, 13);
      this.label10.TabIndex = 65;
      this.label10.Text = "Device ID";
      this.label10.Visible = false;
      // 
      // GetObjectsBtn
      // 
      this.GetObjectsBtn.Location = new System.Drawing.Point(189, 51);
      this.GetObjectsBtn.Name = "GetObjectsBtn";
      this.GetObjectsBtn.Size = new System.Drawing.Size(102, 23);
      this.GetObjectsBtn.TabIndex = 70;
      this.GetObjectsBtn.Text = "Get Objects";
      this.GetObjectsBtn.UseVisualStyleBackColor = true;
      this.GetObjectsBtn.Click += new System.EventHandler(this.GetObjectsBtn_Click);
      // 
      // ObjectList
      // 
      this.ObjectList.FormattingEnabled = true;
      this.ObjectList.Location = new System.Drawing.Point(383, 51);
      this.ObjectList.Name = "ObjectList";
      this.ObjectList.Size = new System.Drawing.Size(155, 329);
      this.ObjectList.TabIndex = 71;
      this.ObjectList.SelectedIndexChanged += new System.EventHandler(this.ObjectList_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(380, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(76, 13);
      this.label1.TabIndex = 72;
      this.label1.Text = "Obejcts Found";
      // 
      // ObjectListLabel
      // 
      this.ObjectListLabel.AutoSize = true;
      this.ObjectListLabel.Location = new System.Drawing.Point(186, 77);
      this.ObjectListLabel.Name = "ObjectListLabel";
      this.ObjectListLabel.Size = new System.Drawing.Size(57, 13);
      this.ObjectListLabel.TabIndex = 73;
      this.ObjectListLabel.Text = "Test Read";
      // 
      // ObjectLabel
      // 
      this.ObjectLabel.AutoSize = true;
      this.ObjectLabel.Location = new System.Drawing.Point(552, 30);
      this.ObjectLabel.Name = "ObjectLabel";
      this.ObjectLabel.Size = new System.Drawing.Size(38, 13);
      this.ObjectLabel.TabIndex = 74;
      this.ObjectLabel.Text = "Object";
      // 
      // PresentValueLabel
      // 
      this.PresentValueLabel.AutoSize = true;
      this.PresentValueLabel.Location = new System.Drawing.Point(552, 77);
      this.PresentValueLabel.Name = "PresentValueLabel";
      this.PresentValueLabel.Size = new System.Drawing.Size(73, 13);
      this.PresentValueLabel.TabIndex = 75;
      this.PresentValueLabel.Text = "Present Value";
      // 
      // ReadPresentValueBtn
      // 
      this.ReadPresentValueBtn.Location = new System.Drawing.Point(555, 51);
      this.ReadPresentValueBtn.Name = "ReadPresentValueBtn";
      this.ReadPresentValueBtn.Size = new System.Drawing.Size(134, 23);
      this.ReadPresentValueBtn.TabIndex = 76;
      this.ReadPresentValueBtn.Text = "Read Present Value";
      this.ReadPresentValueBtn.UseVisualStyleBackColor = true;
      this.ReadPresentValueBtn.Click += new System.EventHandler(this.ReadPresentValueBtn_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 6);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 13);
      this.label2.TabIndex = 77;
      this.label2.Text = "Server";
      // 
      // ServerText
      // 
      this.ServerText.Location = new System.Drawing.Point(59, 5);
      this.ServerText.Name = "ServerText";
      this.ServerText.ReadOnly = true;
      this.ServerText.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.ServerText.Size = new System.Drawing.Size(108, 20);
      this.ServerText.TabIndex = 78;
      // 
      // DeviceLabel
      // 
      this.DeviceLabel.AutoSize = true;
      this.DeviceLabel.Location = new System.Drawing.Point(186, 30);
      this.DeviceLabel.Name = "DeviceLabel";
      this.DeviceLabel.Size = new System.Drawing.Size(55, 13);
      this.DeviceLabel.TabIndex = 79;
      this.DeviceLabel.Text = "Device ID";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(190, 177);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 80;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(708, 391);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.DeviceLabel);
      this.Controls.Add(this.ServerText);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ReadPresentValueBtn);
      this.Controls.Add(this.PresentValueLabel);
      this.Controls.Add(this.ObjectLabel);
      this.Controls.Add(this.ObjectListLabel);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ObjectList);
      this.Controls.Add(this.GetObjectsBtn);
      this.Controls.Add(this.PCIDAddressText);
      this.Controls.Add(this.label26);
      this.Controls.Add(this.SerialNumberText);
      this.Controls.Add(this.SerialNumberCaption);
      this.Controls.Add(this.DeviceIDText);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.TestWriteLabel);
      this.Controls.Add(this.TestBinaryOffBtn);
      this.Controls.Add(this.TestBinaryOnBtn);
      this.Controls.Add(this.TestReadLabel);
      this.Controls.Add(this.TestReadPropBtn);
      this.Controls.Add(this.BroadcastLabel);
      this.Controls.Add(this.DeviceList);
      this.Name = "MainForm";
      this.Text = "BACnet Test";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label TestReadLabel;
    private System.Windows.Forms.Button TestReadPropBtn;
    private System.Windows.Forms.Label BroadcastLabel;
    private System.Windows.Forms.ListBox DeviceList;
    private System.Windows.Forms.Label TestWriteLabel;
    private System.Windows.Forms.Button TestBinaryOffBtn;
    private System.Windows.Forms.Button TestBinaryOnBtn;
    private System.Windows.Forms.TextBox PCIDAddressText;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.TextBox SerialNumberText;
    private System.Windows.Forms.Label SerialNumberCaption;
    private System.Windows.Forms.TextBox DeviceIDText;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Button GetObjectsBtn;
    private System.Windows.Forms.ListBox ObjectList;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label ObjectListLabel;
    private System.Windows.Forms.Label ObjectLabel;
    private System.Windows.Forms.Label PresentValueLabel;
    private System.Windows.Forms.Button ReadPresentValueBtn;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox ServerText;
    private System.Windows.Forms.Label DeviceLabel;
    private System.Windows.Forms.Button button1;
  }
}

