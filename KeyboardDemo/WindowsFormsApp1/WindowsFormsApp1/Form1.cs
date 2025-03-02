using System;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        // 模拟键盘API 键值用byte最准确
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        // 导入 SetWindowPos 方法
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;

        public static bool flage = false;

        public Form1()
        {
            InitializeComponent();
            // 设置窗体为可拉伸
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true; // 允许最大化
            // 设置窗口始终置顶
            this.Load += (s, e) =>
            {
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
            };
            this.Visible = false;
            //this.Hide();
            flage = true;
        }

        // 重写CreateParams避免窗体抢占焦点
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_EX_TOOLWINDOW = 0x00000080; // 避免显示在任务栏上

                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;//| WS_EX_TOOLWINDOW
                return cp;
            }
        }


        #region 设置按键


        private void btnQ_Click_1(object sender, EventArgs e)
        {
            keybd_event(Keys.Q, 0, 0, 0);
            keybd_event(Keys.Q, 0, 2, 0);
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.W, 0, 0, 0);
            keybd_event(Keys.W, 0, 2, 0);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.E, 0, 0, 0);
            keybd_event(Keys.E, 0, 2, 0);
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.R, 0, 0, 0);
            keybd_event(Keys.R, 0, 2, 0);
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.T, 0, 0, 0);
            keybd_event(Keys.T, 0, 2, 0);
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.Y, 0, 0, 0);
            keybd_event(Keys.Y, 0, 2, 0);
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.U, 0, 0, 0);
            keybd_event(Keys.U, 0, 2, 0);
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.I, 0, 0, 0);
            keybd_event(Keys.I, 0, 2, 0);
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.O, 0, 0, 0);
            keybd_event(Keys.O, 0, 2, 0);
        }

        private void BtnP_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.P, 0, 0, 0);
            keybd_event(Keys.P, 0, 2, 0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.Back, 0, 0, 0);
            keybd_event(Keys.Back, 0, 2, 0);
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.A, 0, 0, 0);
            keybd_event(Keys.A, 0, 2, 0);
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.S, 0, 0, 0);
            keybd_event(Keys.S, 0, 2, 0);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.D, 0, 0, 0);
            keybd_event(Keys.D, 0, 2, 0);
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.F, 0, 0, 0);
            keybd_event(Keys.F, 0, 2, 0);
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.G, 0, 0, 0);
            keybd_event(Keys.G, 0, 2, 0);
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.H, 0, 0, 0);
            keybd_event(Keys.H, 0, 2, 0);
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.J, 0, 0, 0);
            keybd_event(Keys.J, 0, 2, 0);
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.K, 0, 0, 0);
            keybd_event(Keys.K, 0, 2, 0);
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.L, 0, 0, 0);
            keybd_event(Keys.L, 0, 2, 0);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.Enter, 0, 0, 0);
            keybd_event(Keys.Enter, 0, 2, 0);
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.Z, 0, 0, 0);
            keybd_event(Keys.Z, 0, 2, 0);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.X, 0, 0, 0);
            keybd_event(Keys.X, 0, 2, 0);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.C, 0, 0, 0);
            keybd_event(Keys.C, 0, 2, 0);
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.V, 0, 2, 0);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.B, 0, 0, 0);
            keybd_event(Keys.B, 0, 2, 0);
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.N, 0, 0, 0);
            keybd_event(Keys.N, 0, 2, 0);
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.M, 0, 0, 0);
            keybd_event(Keys.M, 0, 2, 0);
        }
        private bool isHoldingShift = false;

        private void btnRightShift_Click(object sender, EventArgs e)
        {
            //// 切换Shift状态
            //isHoldingShift = !isHoldingShift;

            //if (isHoldingShift)
            //{
            //    // 按下Shift
            //    Task.Run(() =>
            //    {
            //        keybd_event(Keys.ShiftKey, 0, 0, 0); // 持续按下Shift
            //        while (isHoldingShift)
            //        {
            //            Thread.Sleep(50); // 防止过快占用CPU
            //        }
            //    });
            //}
            //else
            //{
            //    // 释放Shift
            //    keybd_event(Keys.ShiftKey, 0, 2, 0); // 释放Shift
            //}

            keybd_event(Keys.ShiftKey, 0, 0, 0); // 持续按下Shift

            keybd_event(Keys.ShiftKey, 0, 2, 0); // 释放Shift
        }

        private void btnCapsLock_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.CapsLock, 0, 0, 0);
            keybd_event(Keys.CapsLock, 0, 2, 0);
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            // 按下 Shift 键
            keybd_event(Keys.ShiftKey, 0, 0, 0);
            //LCONTROL
            // 按下 Ctrl 键
            keybd_event(Keys.LControlKey, 0, 0, 0);

            // 释放 Ctrl 键
            keybd_event(Keys.LControlKey, 0, 2, 0);
            // 释放 Shift 键
            keybd_event(Keys.ShiftKey, 0, 2, 0);

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad7, 0, 0, 0);
            keybd_event(Keys.NumPad7, 0, 2, 0);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad8, 0, 0, 0);
            keybd_event(Keys.NumPad8, 0, 2, 0);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad9, 0, 0, 0);
            keybd_event(Keys.NumPad9, 0, 2, 0);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad4, 0, 0, 0);
            keybd_event(Keys.NumPad4, 0, 2, 0);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad5, 0, 0, 0);
            keybd_event(Keys.NumPad5, 0, 2, 0);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad6, 0, 0, 0);
            keybd_event(Keys.NumPad6, 0, 2, 0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad1, 0, 0, 0);
            keybd_event(Keys.NumPad1, 0, 2, 0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad2, 0, 0, 0);
            keybd_event(Keys.NumPad2, 0, 2, 0);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad3, 0, 0, 0);
            keybd_event(Keys.NumPad3, 0, 2, 0);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.NumPad0, 0, 0, 0);
            keybd_event(Keys.NumPad0, 0, 2, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.Decimal, 0, 0, 0);
            keybd_event(Keys.Decimal, 0, 2, 0);
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            flage = false;
            //base.OnFormClosing(e);
            this.Hide();
        }
    }
}


