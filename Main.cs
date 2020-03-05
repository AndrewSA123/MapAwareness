using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapAwareness
{
    public partial class Main : Form
    {
        private int InputVal = 1;
        WMPLib.WindowsMediaPlayer wplayer;
        Bitmap bitmap;
        Graphics g;
        string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public Main()
        {
            InitializeComponent();
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = Path.GetFullPath(@"C:\Users\ukknoand\source\repos\MapAwareness\MapAwareness\Assets\Sounds\Sound1.mp3");
            ScreenCapTimer.Enabled = true;
            ScreenCapTimer.Interval = 100;
            bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            g = Graphics.FromImage(bitmap);
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                InputVal = Int32.Parse(IntervalInput.Text);
                PingTimer.Enabled = true;
                PingTimer.Interval = InputVal * 1000;
                PingTimer.Start();
                
            }
            catch(Exception ex)
            {
                InputVal = 1;
            }

            
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            PingTimer.Stop();
            ScreenCapTimer.Stop();
        }

        private void PingTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = (Int32.Parse(label1.Text) + 1).ToString();
            wplayer.controls.play();
        }

        private void ScreenCapTimer_Tick(object sender, EventArgs e)
        {
            g.CopyFromScreen(1620, 800, 0, 0, new Size(1000,1000));
            MapBox.Image = bitmap;
        }

        private void MapCaptureButton_Click(object sender, EventArgs e)
        {
            ScreenCapTimer.Start();
        }
    }
}
