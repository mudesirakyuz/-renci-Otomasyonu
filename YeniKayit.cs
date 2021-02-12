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
    public partial class YeniKayit : Form
    {
        public YeniKayit()
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

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Maroon;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
            textBox4.ForeColor = Color.Maroon;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form frm = new Login();
            frm.Show();
        }
        DbOgrenciOtomasyonuEntities db = new DbOgrenciOtomasyonuEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Kullanıcı Adınız..." && textBox2.Text != "Parolanız..." && textBox3.Text != "Tekrar Parolanız..." && textBox4.Text != "Güvenlik Cevabınız..." && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox2.Text == textBox3.Text)
            {
                try
                {
                    Kullanicilars user = new Kullanicilars();
                    user.kullaniciadi = textBox1.Text;
                    user.parola = textBox2.Text;
                    user.guvenliksorusu = textBox4.Text;
                    db.Kullanicilars.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Kayıt Başarılı.\nAilemize Hoşgeldiniz...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    timer1.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("İstedğiniz Kullanıcı Adı Alınmış.\nLütfen Başka Bir Kullanıcı Adı Belirleyin...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else MessageBox.Show("Alan/Alanlar boş geçilemez veya Parolalar uyuşmuyor...", "[ Bilgi ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void YeniKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
