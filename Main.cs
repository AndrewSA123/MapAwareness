using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapAwareness
{
    public partial class Main : Form
    {
        private int InputVal = 1;
        WMPLib.WindowsMediaPlayer wplayer;

        public Main()
        {
            InitializeComponent();
             wplayer = new WMPLib.WindowsMediaPlayer();
             wplayer.URL = @"C:\Users\ukknoand\source\repos\MapAwareness\MapAwareness\Assets\Sounds\Sound1.mp3";
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
        }

        private void PingTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = (Int32.Parse(label1.Text) + 1).ToString();
            wplayer.controls.play();
        }
    }
}
