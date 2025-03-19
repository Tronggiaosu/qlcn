using QLCongNo.View.Core;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QLCongNo.View
{
    /// <summary>
    /// Main form of the application.
    /// </summary>
    public partial class FrmDialog : Form
    {
        /// <summary>
        /// DB context for the application.
        /// </summary>
        public CAPNUOC_TNCEntities db { get; set; }

        protected const int BORDER_SIZE = 2;
        private Size _formSize; // Keep form size when it is minimized and restored.

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmDialog"/> class.
        /// </summary>
        public FrmDialog()
        {
            InitializeComponent();

            var designSize = this.ClientSize;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Size = designSize;
            this.Padding = new Padding(BORDER_SIZE);
            this.StartPosition = FormStartPosition.CenterScreen;
            RegisterEvent();
        }

        /// <summary>
        /// Handles the Load event of the form.
        /// </summary>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _formSize = this.ClientSize;
            //WindowState = FormWindowState.Maximized;
            PnlMain.Focus();
        }

        /// <summary>
        /// Registers the event handlers for the form controls.
        /// </summary>
        private void RegisterEvent()
        {
            Load += FrmMain_Load;
            Resize += FrmMain_Resize;
            PnlTitle.MouseDown += PnlTitle_MouseDown;
            BtnClose.Click += BtnClose_Click;
            BtnMinimize.Click += GetBtnMinimize_Click;
            BtnMaximize.Click += BtnMaximize_Click;
        }

        #region "Common form controls"

        /// <summary>
        /// Handles the Resize event of the form.
        /// </summary>
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        /// <summary>
        /// Adjusts the form's padding and location based on its state.
        /// </summary>
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;

                case FormWindowState.Normal:
                    if (this.Padding.Top != BORDER_SIZE)
                        this.Padding = new Padding(BORDER_SIZE);
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnMaximize control.
        /// </summary>
        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Normal:
                    _formSize = this.ClientSize;
                    this.WindowState = FormWindowState.Maximized;
                    break;

                case FormWindowState.Maximized:
                    this.WindowState = FormWindowState.Normal;
                    this.Size = _formSize;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnMinimize control.
        /// </summary>
        private void GetBtnMinimize_Click(object sender, EventArgs e)
        {
            _formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles the Click event of the BtnClose control.
        /// </summary>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Draggable form"

        /// <summary>
        /// Handles the MouseDown event of the PnlTitle control to enable dragging the form.
        /// </summary>
        private void PnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            releaseCapture();
            sendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Releases the mouse capture.
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void releaseCapture();

        /// <summary>
        /// Sends a message to the specified window.
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void sendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        #endregion "Draggable form"

        /// <summary>
        /// Overrides the WndProc method to handle custom window messages.
        /// </summary>
        /// <param name="m">The Windows Message to process.</param>
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020;
            const int SC_RESTORE = 0xF120;
            const int WM_NCHITTEST = 0x0084;
            const int resizeAreaSize = 10;

            #region Form Resize

            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal && (int)m.Result == HTCLIENT)
                {
                    Point screenPoint = new Point(m.LParam.ToInt32());
                    Point clientPoint = this.PointToClient(screenPoint);

                    if (clientPoint.Y <= resizeAreaSize)
                    {
                        if (clientPoint.X <= resizeAreaSize)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                            m.Result = (IntPtr)HTTOP;
                        else
                            m.Result = (IntPtr)HTTOPRIGHT;
                    }
                    else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize))
                    {
                        if (clientPoint.X <= resizeAreaSize)
                            m.Result = (IntPtr)HTLEFT;
                        else if (clientPoint.X > (this.Width - resizeAreaSize))
                            m.Result = (IntPtr)HTRIGHT;
                    }
                    else
                    {
                        if (clientPoint.X <= resizeAreaSize)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                            m.Result = (IntPtr)HTBOTTOM;
                        else
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                    }
                }
                return;
            }

            #endregion Form Resize

            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE)
                    _formSize = this.ClientSize;
                if (wParam == SC_RESTORE)
                    this.Size = _formSize;
            }
            base.WndProc(ref m);
        }

        #endregion "Common form controls"

        /// <summary>
        /// Handles the Load event of the form.
        /// </summary>
        private void FormLoad(object sender, EventArgs e)
        {
            LblTitle.Text = "";
        }

        /// <summary>
        /// Shows a dialog with a new instance of the specified user control.
        /// </summary>
        /// <typeparam name="T">The type of the user control.</typeparam>
        /// <returns>The dialog result.</returns>
        public DialogResult ShowDialog<T>() where T : NovUserControl, new()
        {
            return ShowDialog(new T());
        }

        /// <summary>
        /// Shows a dialog with the specified user control.
        /// </summary>
        /// <typeparam name="T">The type of the user control.</typeparam>
        /// <param name="InnerControl">The user control to display.</param>
        /// <returns>The dialog result.</returns>
        public DialogResult ShowDialog<T>(T InnerControl) where T : NovUserControl
        {
            PnlMain.Controls.Clear();
            PnlMain.Controls.Add(InnerControl);
            InnerControl.Dock = DockStyle.Fill;
            return this.ShowDialog();
        }
    }
}