using System.Runtime.InteropServices;

namespace keyboards
{
    public partial class Form1 : Form
    {
        // ģ�����API ��ֵ��byte��׼ȷ
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        // ���� SetWindowPos ����
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;

        public Form1()
        {
            InitializeComponent();

            // ���ô���ʼ���ö�
            this.Load += (s, e) =>
            {
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_NOACTIVATE);
            };
        }

        // ��дCreateParams���ⴰ����ռ����
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_NOACTIVATE = 0x08000000;
                const int WS_EX_TOOLWINDOW = 0x00000080; // ������ʾ����������

                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                return cp;
            }
        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            keybd_event(Keys.Q, 0, 0, 0);
            keybd_event(Keys.Q, 0, 2, 0);
        }


    }
}
