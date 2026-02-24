using System.Runtime.InteropServices;

namespace VirtualDog
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private Size baseWindowSize;


        public Form1()
        {
            InitializeComponent();
            baseWindowSize = this.ClientSize;

            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;

            Animation.LoadSpriteSheet(Properties.Resources.dog_sheet);
            Animation.StartAnimIdle();

            this.MouseDown += InteractionWithDog;
            dog_picture.MouseDown += InteractionWithDog;
            dog_picture.Paint += dog_picture_Paint;

            Animation.FrameChanged += () =>
            {
                dog_picture.Invalidate();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dog_picture_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            // выставляем скейл
            g.ScaleTransform(dogSize, dogSize);

            // отключаем сглаживания и тд
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // рисуем
            Animation.Draw(g);
        }

        private void InteractionWithDog(object sender, MouseEventArgs e)
        {
            Point windowPos = this.Location;
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                if (this.Location == windowPos)
                    Animation.StartAnimRandomAction();
            }
            else if (e.Button == MouseButtons.Right)
            {
                menu.Show(Cursor.Position);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static float dogSize = 1f;
        private void ChangeSize_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is float size)
            {
                dogSize = size;
                int x = (int)(baseWindowSize.Width * dogSize);
                int y = (int)(baseWindowSize.Height * dogSize);

                this.ClientSize = new Size(x, y);
                dog_picture.Size = new Size(x, y);

                this.Refresh();
                dog_picture.Refresh();
            }
        }
    }
}
