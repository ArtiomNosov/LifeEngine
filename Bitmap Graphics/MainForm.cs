using LifeOhLife;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace Bitmap_Graphics
{
    public partial class Engine : Form
    {
        Life sl = new Life();
        static Bitmap drawingSurface = new Bitmap(1920, 1080);
        Graphics GFX = Graphics.FromImage(drawingSurface);
        Thread myThread;
        bool isActive = false;


        public Engine()
        {
            InitializeComponent();
        }

        public void refreshField()
        {
            int x = 640, y = 360;

            GFX.FillRectangle(Brushes.Black, 0, 0, x * 3, y * 3);
            string field = sl.GetRectangle(0, 0, x, y);
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    if (field[i * y + j] == 'x')
                        GFX.FillRectangle(Brushes.White, i * 3, j * 3, 3, 3);

            pictureBox1.Image = drawingSurface;
        }

        public void StartRefreshField()
        {
            while (isActive)
            {
                sl.Run(1);
                refreshField();
                Thread.Sleep(300);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isActive = true;
            myThread = new Thread(StartRefreshField);
            myThread.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            isActive = false;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var rand = new Random();
            sl.GenerateRandomField((int)rand.NextInt64(9999999), 0.5);
            refreshField();
        }
    }
}