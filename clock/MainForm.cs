using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock {
  public partial class MainForm : Form {
    
    [DllImport("winmm.dll")]
    private static extern int mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

    private static readonly SoundPlayer sp = new SoundPlayer(Properties.Resources.sound);

    public MainForm() {
      InitializeComponent();
      Icon = Icon.ExtractAssociatedIcon(Process.GetCurrentProcess().MainModule.FileName);
    }

    private void CheckTimeAndPlay(bool debug = false) {
      var dt = DateTime.Now;
      btnSay.Text = dt.ToString("HH:mm:ss");
      if (!debug && (dt.Minute != 0 || dt.Second != 0)) return;
      
      if (!btnSay.Enabled) return;
      SetButtonEnable(false);

      var task = new Task(() => {
        var hr = dt.Hour > 12 ? dt.Hour - 12 : dt.Hour;
        for (var i = 0; i < hr; i++) {
          mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
          lock (sp) sp.PlaySync();
          mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);
        }
      });
      task.ContinueWith(task1 => {
        SetButtonEnable(true);
      });
      task.Start();
    }

    private static void InvokeIfRequired(ISynchronizeInvoke obj, MethodInvoker action, params object[] args) {
      if (obj.InvokeRequired)
        obj.Invoke(action, args);
      else
        action();
    }

    private void SetButtonEnable(bool value) {
      InvokeIfRequired(this, () => {
        btnSay.Enabled = value;
      });
    }

    private void btnSay_Click(object sender, EventArgs e) {
      CheckTimeAndPlay(true);
    }

    private void btnSay_Resize(object sender, EventArgs e) {
      btnSay.Font = new Font(btnSay.Font.FontFamily, (float)btnSay.Height / 2);
    }

    private void tickTackTimer_Tick(object sender, EventArgs e) {
      CheckTimeAndPlay();
    }

    private bool DoSnap(int pos, int edge) {
      const int snapDist = 50;
      var delta = Math.Abs(pos - edge);
      return delta <= snapDist;
    }

    private void MainForm_ResizeEnd(object sender, EventArgs e) {
      var scn = Screen.FromPoint(Location);
      if (DoSnap(Left, scn.WorkingArea.Left)) Left = scn.WorkingArea.Left;
      if (DoSnap(Top, scn.WorkingArea.Top)) Top = scn.WorkingArea.Top;
      if (DoSnap(scn.WorkingArea.Right, Right)) Left = scn.WorkingArea.Right - Width;
      if (DoSnap(scn.WorkingArea.Bottom, Bottom)) Top = scn.WorkingArea.Bottom - Height;
    }
  }
}
