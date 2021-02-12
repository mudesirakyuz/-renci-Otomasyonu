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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DbOgrenciOtomasyonuEntities db = new DbOgrenciOtomasyonuEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool kullanicidogrula(string kAdi, string kParola)
        {
            var sorgu = from item in db.Kullanicilars
                        where item.kullaniciadi == kAdi && item.parola == kParola
                  select item;
            if (sorgu.Any()) return true;
            else return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Kullanıcı Adınız..." && textBox2.Text != "Parolanız..." && textBox1.Text != "" && textBox2.Text != "" && textBox1.Text != null && textBox2.Text != null)
            {
                if (kullanicidogrula(textBox1.Text, textBox2.Text) == true)
                {
                    MessageBox.Show("Giriş Başarılı...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timer1.Start();
                }
                else MessageBox.Show("Kullanıcı adı veya şifre yanlış...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Alan/Alanlar Boş Geçilemez...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form frm = new Unuttum();
            frm.Show();
            this.Hide();
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
                Form frm = new Anasayfa();
                frm.Show();
                this.Hide();
                timer1.Enabled = false;
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form frm = new YeniKayit();
            frm.Show();
            this.Hide();
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

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
