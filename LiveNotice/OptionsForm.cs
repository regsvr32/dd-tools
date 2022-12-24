using Microsoft.Toolkit.Uwp.Notifications;
using System.Text.RegularExpressions;

namespace LiveNotice {
  record Options(string[] listenUids, int querySpanSeconds, bool autoLaunch);

  public partial class OptionsForm : Form {
    bool fullClose = false;
    bool modified = false;

    public OptionsForm() {
      InitializeComponent();
      Opacity = 0;
    }

    void optionValueChanged(object sender, EventArgs e) {
      modified = true;
    }

    void saveOptions(object sender, EventArgs e) {
      if (modified) {
        if (listenUidsTextBox.Lines.Any(uid => Regex.IsMatch(uid, @"\D"))) {
          MessageBox.Show("uid仅限输入数字");
          return;
        }
        Program.setOptions(new Options(listenUidsTextBox.Lines, (int)querySpanSelector.Value, autoLaunchCheckBox.Checked));
        modified = false;
      }
      Hide();
    }

    void formClosing(object sender, FormClosingEventArgs e) {
      if (fullClose) { return; }
      e.Cancel = true;
      if (modified) {
        var result = MessageBox.Show("改动的设置项不会保存，放弃修改并关闭窗口？", "", MessageBoxButtons.YesNo);
        if (result == DialogResult.No) { return; }
      }
      Hide();
    }

    void showOptions(object sender, EventArgs e) {
      Show();
    }

    void exit(object sender, EventArgs e) {
      Program.stopListen();
      ToastNotificationManagerCompat.Uninstall();
      fullClose = true;
      Close();
    }

    void switchListen(object sender, EventArgs e) {
      if (Program.listening) {
        Program.stopListen();
        ToolStripMenuItem_SwitchListen.Text = "开始监听";
      } else {
        Program.startListen();
        ToolStripMenuItem_SwitchListen.Text = "停止监听";
      }
    }

    void firstShown(object sender, EventArgs e) {
      if (Program.muteLaunch) { Hide(); }
      Opacity = 1;
    }

    void onVisibleChanged(object sender, EventArgs e) {
      if (!Visible) { return; }
      var options = Program.options;
      listenUidsTextBox.Lines = (string[])options.listenUids.Clone();
      querySpanSelector.Value = options.querySpanSeconds;
      autoLaunchCheckBox.Checked = options.autoLaunch;
      modified = false;
    }
  }
}