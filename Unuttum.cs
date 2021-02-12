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
    public partial class Unuttum : Form
    {
        public Unuttum()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Maroon;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Maroon;
        }
        DbOgrenciOtomasyonuEntities db=new DbOgrenciOtomasyonuEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            string tut="0";
            if (textBox1.Text != "Kullanıcı Adınız..." && textBox2.Text != "Güvenlik Cevabınız..." && textBox1.Text != "" && textBox2.Text != "" && textBox1.Text != null && textBox2.Text != null)
            {
                var veri = (from item in db.Kullanicilars where (item.kullaniciadi == textBox1.Text && item.guvenliksorusu == textBox2.Text && item.guvenliksorusu != null && item.kullaniciadi != null) select item).FirstOrDefault();
                if (veri != null)
                {
                    tut = veri.parola;
                    MessageBox.Show("Parolanız: " + tut, "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timer1.Start();
                }
                else MessageBox.Show("Kullanıcı Bulunamadı...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Alan/Alanlar Boş Geçilemez...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frm = new Login();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.01;
                this.Top--;
            }
            else
            {
                this.Close();
                Form frm = new Login();
                frm.Show();
                timer1.Enabled = false;
            }
        }

        private void Unuttum_Load(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.01;
                this.Top++;

            }
            else
            {
                
                timer2.Stop();
            }
        }
    }
}
