using BunifuAnimatorNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
        bool kontrol1 = true,kontrol2=true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuProgressBar1.Value < 100)
            {
                bunifuProgressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                timer2.Start();
                timer2.Enabled = true;
            }
            
            i++;
        }
        int i = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            i--;
            if (bunifuProgressBar1.Value == 0)
            {
                
                timer2.Stop();
                timer2.Enabled = false;
                this.Close();
                Form frm = new Login();
                frm.Show();
                
            }
            if (bunifuProgressBar1.Value > 0)
            {
                 bunifuProgressBar1.Value--;
            }
            
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            BunifuTransition transition = new BunifuTransition();
            transition.TimeStep = 0.003f;
            transition.MaxAnimationTime = 25000;
            transition.HideSync(panel1, false, BunifuAnimatorNS.Animation.Mosaic);
        }

        private void Giris_Activated(object sender, EventArgs e)
        {
            BunifuTransition transition = new BunifuTransition();
            transition.TimeStep = 0.003f;
            transition.MaxAnimationTime = 25000;
            transition.ShowSync(panel1, false, BunifuAnimatorNS.Animation.Particles);

        }
    }
}
