using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Form1 form1 = null;

        // 导入 SetWindowPos 方法
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;

        public Form2()
        {
            InitializeComponent();
            this.Visible = false;
            this.Hide();
            this.Load += (s, e) =>
            {
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
            };
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Automation.AddAutomationFocusChangedEventHandler(FocusChangedHandler);
        }


        #region 监听全局焦点弹出

        private DateTime _lastFocusChangedTime = DateTime.MinValue;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void BringWindowToFront()
        {
            Form1.flage = true;
            this.WindowState = FormWindowState.Normal; // 恢复窗口状态
            this.Show(); // 确保窗口可见
            SetForegroundWindow(this.Handle); // 强制将窗口置于前台
        }

        private void FocusChangedHandler(object sender, AutomationFocusChangedEventArgs e)
        {
            if (Form1.flage ==true || this.Visible == true) return;
           
            try
            {
                // 防抖：限制触发频率
                if ((DateTime.Now - _lastFocusChangedTime).TotalMilliseconds < 2000)
                    return;
                _lastFocusChangedTime = DateTime.Now;

                AutomationElement focusedElement = AutomationElement.FocusedElement;

                if (focusedElement != null)
                {
                    string elementName = focusedElement.Current.Name;
                    string elementControlType = focusedElement.Current.ControlType.ProgrammaticName;

                    Console.WriteLine($"焦点变化：Name={elementName}, Type={elementControlType}");
                    if (focusedElement.Current.ControlType == ControlType.Edit) // 文本编辑控件类型
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.BringWindowToFront();
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // 移除焦点变化事件监听
            Automation.RemoveAutomationFocusChangedEventHandler(FocusChangedHandler);
            base.OnFormClosed(e);
        }

        //重写关闭事件
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            e.Cancel = true; // 取消 关闭事件
            Form1.flage = false;
            this.Hide(); // 隐藏
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
