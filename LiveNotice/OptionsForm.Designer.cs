namespace LiveNotice {
  partial class OptionsForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
      this.label1 = new System.Windows.Forms.Label();
      this.listenUidsTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.querySpanSelector = new System.Windows.Forms.NumericUpDown();
      this.autoLaunchCheckBox = new System.Windows.Forms.CheckBox();
      this.saveButton = new System.Windows.Forms.Button();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItem_SwitchListen = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.querySpanSelector)).BeginInit();
      this.notifyIconContextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(158, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "监听主播（uid，换行分隔）";
      // 
      // listenUidsTextBox
      // 
      this.listenUidsTextBox.Location = new System.Drawing.Point(12, 29);
      this.listenUidsTextBox.Multiline = true;
      this.listenUidsTextBox.Name = "listenUidsTextBox";
      this.listenUidsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.listenUidsTextBox.Size = new System.Drawing.Size(188, 200);
      this.listenUidsTextBox.TabIndex = 1;
      this.listenUidsTextBox.WordWrap = false;
      this.listenUidsTextBox.TextChanged += new System.EventHandler(this.optionValueChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 245);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(92, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "查询间隔（秒）";
      // 
      // querySpanSelector
      // 
      this.querySpanSelector.Location = new System.Drawing.Point(110, 243);
      this.querySpanSelector.Maximum = new decimal(new int[] {
            2147483,
            0,
            0,
            0});
      this.querySpanSelector.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.querySpanSelector.Name = "querySpanSelector";
      this.querySpanSelector.Size = new System.Drawing.Size(90, 23);
      this.querySpanSelector.TabIndex = 3;
      this.querySpanSelector.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.querySpanSelector.ValueChanged += new System.EventHandler(this.optionValueChanged);
      // 
      // autoLaunchCheckBox
      // 
      this.autoLaunchCheckBox.AutoSize = true;
      this.autoLaunchCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.autoLaunchCheckBox.Location = new System.Drawing.Point(12, 277);
      this.autoLaunchCheckBox.Name = "autoLaunchCheckBox";
      this.autoLaunchCheckBox.Size = new System.Drawing.Size(75, 21);
      this.autoLaunchCheckBox.TabIndex = 4;
      this.autoLaunchCheckBox.Text = "开机启动";
      this.autoLaunchCheckBox.UseVisualStyleBackColor = true;
      this.autoLaunchCheckBox.CheckedChanged += new System.EventHandler(this.optionValueChanged);
      // 
      // saveButton
      // 
      this.saveButton.Location = new System.Drawing.Point(125, 275);
      this.saveButton.Name = "saveButton";
      this.saveButton.Size = new System.Drawing.Size(75, 23);
      this.saveButton.TabIndex = 5;
      this.saveButton.Text = "保存设置";
      this.saveButton.UseVisualStyleBackColor = true;
      this.saveButton.Click += new System.EventHandler(this.saveOptions);
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "开播通知";
      this.notifyIcon.Visible = true;
      this.notifyIcon.DoubleClick += new System.EventHandler(this.showOptions);
      // 
      // notifyIconContextMenu
      // 
      this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_SwitchListen,
            this.ToolStripMenuItem_Show,
            this.ToolStripMenuItem_Exit});
      this.notifyIconContextMenu.Name = "notifyIconContextMenu";
      this.notifyIconContextMenu.Size = new System.Drawing.Size(125, 70);
      // 
      // ToolStripMenuItem_SwitchListen
      // 
      this.ToolStripMenuItem_SwitchListen.Name = "ToolStripMenuItem_SwitchListen";
      this.ToolStripMenuItem_SwitchListen.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItem_SwitchListen.Text = "停止监听";
      this.ToolStripMenuItem_SwitchListen.Click += new System.EventHandler(this.switchListen);
      // 
      // ToolStripMenuItem_Show
      // 
      this.ToolStripMenuItem_Show.Name = "ToolStripMenuItem_Show";
      this.ToolStripMenuItem_Show.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItem_Show.Text = "设置";
      this.ToolStripMenuItem_Show.Click += new System.EventHandler(this.showOptions);
      // 
      // ToolStripMenuItem_Exit
      // 
      this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
      this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItem_Exit.Text = "退出";
      this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.exit);
      // 
      // OptionsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(212, 309);
      this.Controls.Add(this.saveButton);
      this.Controls.Add(this.autoLaunchCheckBox);
      this.Controls.Add(this.querySpanSelector);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.listenUidsTextBox);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.ImeMode = System.Windows.Forms.ImeMode.Off;
      this.MaximizeBox = false;
      this.Name = "OptionsForm";
      this.Text = "设置";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
      this.Shown += new System.EventHandler(this.firstShown);
      this.VisibleChanged += new System.EventHandler(this.onVisibleChanged);
      ((System.ComponentModel.ISupportInitialize)(this.querySpanSelector)).EndInit();
      this.notifyIconContextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox listenUidsTextBox;
    private Label label2;
    private NumericUpDown querySpanSelector;
    private CheckBox autoLaunchCheckBox;
    private Button saveButton;
    private NotifyIcon notifyIcon;
    private ContextMenuStrip notifyIconContextMenu;
    private ToolStripMenuItem ToolStripMenuItem_SwitchListen;
    private ToolStripMenuItem ToolStripMenuItem_Show;
    private ToolStripMenuItem ToolStripMenuItem_Exit;
  }
}