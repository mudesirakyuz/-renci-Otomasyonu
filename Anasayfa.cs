using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OgrenciOtomasyonu.Entity;
using System.Data.Entity;
using System.Xml;

namespace OgrenciOtomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        DbOgrenciOtomasyonuEntities db = new DbOgrenciOtomasyonuEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbOgrenciOtomasyonuDataSet1.Bolumlers' table. You can move, or remove it, as needed.
            this.bolumlersTableAdapter.Fill(this.dbOgrenciOtomasyonuDataSet1.Bolumlers);
            // TODO: This line of code loads data into the 'dbOgrenciOtomasyonuDataSet.Siniflars' table. You can move, or remove it, as needed.
            this.siniflarsTableAdapter.Fill(this.dbOgrenciOtomasyonuDataSet.Siniflars);

            //Context cnt = new Context();
            //cnt.Database.Create();

            dataGridView1.BackgroundColor = Color.FromArgb(242, 177, 153);
            ogrencilericek();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Visible = radioButton3.Visible = radioButton4.Visible = true;
            radioButton6.Visible = radioButton7.Visible = radioButton8.Visible = false;
            radioButton10.Visible = radioButton11.Visible = radioButton12.Visible = false;

            radioButton6.Checked = radioButton7.Checked = radioButton8.Checked = false;
            radioButton10.Checked = radioButton11.Checked = radioButton12.Checked = false;

            button1.Enabled = false;
            button1.Text = "+ EKLE +";

            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;

            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Visible = radioButton3.Visible = radioButton4.Visible = false;
            radioButton6.Visible = radioButton7.Visible = radioButton8.Visible = true;
            radioButton10.Visible = radioButton11.Visible = radioButton12.Visible = false;

            radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
            radioButton10.Checked = radioButton11.Checked = radioButton12.Checked = false;

            button1.Enabled = false;
            button1.Text = "↘↗ GÜNCELLE ↘↗";

            textBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox6.Enabled = true;

            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Visible = radioButton3.Visible = radioButton4.Visible = false;
            radioButton6.Visible = radioButton7.Visible = radioButton8.Visible = false;
            radioButton10.Visible = radioButton11.Visible = radioButton12.Visible = true;

            radioButton2.Checked = radioButton3.Checked = radioButton4.Checked = false;
            radioButton6.Checked = radioButton7.Checked = radioButton8.Checked = false;

            button1.Enabled = false;
            button1.Text = "✘ SİL ✘";

            textBox1.Enabled = true;
            textBox4.Enabled = true;
            textBox6.Enabled = true;

            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            button1.Enabled = false;

            

            lblkontrol1.Text = "";
            lblkontrol2.Text = "";
            lblkontrol3.Text = "";

            if (radioButton1.Checked)//-----------------INSERT-----------------
            {
                if (radioButton2.Checked)//Öğrenci Tablosu
                {
                    Ogrencilers ogr = new Ogrencilers();
                    ogr.ograd = textBox2.Text;
                    ogr.ogrsoyad = textBox3.Text;
                    ogr.Siniflar_sinifid = int.Parse(comboBox1.SelectedValue.ToString());
                    db.Ogrencilers.Add(ogr);
                    db.SaveChanges();
                    MessageBox.Show("Yeni (öğrenci) başarıyla eklendi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ogrencilericek();
                }
                else if (radioButton3.Checked)//Sınıf Tablosu
                {
                    Siniflars snf = new Siniflars();
                    snf.sinifad = textBox5.Text;
                    snf.Bolumler_bolumid = int.Parse(comboBox2.SelectedValue.ToString());
                    db.Siniflars.Add(snf);
                    db.SaveChanges();
                    MessageBox.Show("Yeni (sınıf) başarıyla eklendi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    siniflaricek();
                }
                else if (radioButton4.Checked)//Bölüm Tablosu
                {
                    Bolumlers blm = new Bolumlers();
                    blm.bolumad = textBox7.Text;
                    db.Bolumlers.Add(blm);
                    db.SaveChanges();
                    MessageBox.Show("Yeni (bölüm) başarıyla eklendi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bolumlericek();
                }
            }
            else if (radioButton5.Checked)//-----------------UPDATE-----------------
            {
                if (radioButton6.Checked)//Öğrenci Tablosu
                {
                    var veri = db.Ogrencilers.Find(int.Parse(textBox1.Text));
                    veri.ograd = textBox2.Text;
                    veri.ogrsoyad = textBox3.Text;
                    veri.Siniflar_sinifid = int.Parse(comboBox1.SelectedValue.ToString());
                    db.SaveChanges();
                    MessageBox.Show("Belirtilen (öğrenci) başarıyla güncellendi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ogrencilericek();
                }
                else if (radioButton7.Checked)//Sınıf Tablosu
                {
                    var veri = db.Siniflars.Find(int.Parse(textBox4.Text));
                    veri.sinifad = textBox5.Text;
                    veri.Bolumler_bolumid = int.Parse(comboBox2.SelectedValue.ToString());
                    db.SaveChanges();
                    MessageBox.Show("Belirtilen (sınıf) başarıyla güncellendi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    siniflaricek();
                }
                else if (radioButton8.Checked)//Bölüm Tablosu
                {
                    var veri = db.Bolumlers.Find(int.Parse(textBox6.Text));
                    veri.bolumad = textBox7.Text;
                    db.SaveChanges();
                    MessageBox.Show("Belirtilen (bölüm) başarıyla güncellendi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bolumlericek();
                }
            }
            else if (radioButton9.Checked)//-----------------DELETE-----------------
            {
                if (radioButton10.Checked)//Öğrenci Tablosu
                {
                    if (DialogResult.Yes == MessageBox.Show("Belirtilen (Öğrenciyi) Silmek İstediğinize Emin Misiniz?...", "-[ Bilgi ]-", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        var veri = db.Ogrencilers.Find(int.Parse(textBox1.Text));
                        db.Ogrencilers.Remove(veri);
                        db.SaveChanges();
                        MessageBox.Show("Belirtilen (öğrenci) başarıyla silindi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ogrencilericek();
                    }
                }
                else if (radioButton11.Checked)//Sınıf Tablosu
                {
                    if (DialogResult.Yes == MessageBox.Show("Belirtilen (Sınıfı) Silmek İstediğinize Emin Misiniz?...", "-[ Bilgi ]-", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        var veri = db.Siniflars.Find(int.Parse(textBox4.Text));
                        db.Siniflars.Remove(veri);
                        db.SaveChanges();
                        MessageBox.Show("Belirtilen (sınıf) başarıyla silindi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        siniflaricek();
                    }
                }
                else if (radioButton12.Checked)//Bölüm Tablosu
                {
                    if (DialogResult.Yes == MessageBox.Show("Belirtilen (Bölümü) Silmek İstediğinize Emin Misiniz?...", "-[ Bilgi ]-", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        var veri = db.Bolumlers.Find(int.Parse(textBox6.Text));
                        db.Bolumlers.Remove(veri);
                        db.SaveChanges();
                        MessageBox.Show("Belirtilen (bölüm) başarıyla silindi...", "-[ Bilgi ]-", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bolumlericek();
                    }
                }
            }

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            comboBox1.Enabled = true;

            ogrencilericek();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            comboBox2.Enabled = true;

            siniflaricek();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            bolumlericek();
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            comboBox1.Enabled = true;

            lblkontrol2.Text = "";
            lblkontrol3.Text = "";
            lblkontrol1.Text = "Güncellemek İstediğiniz (Öğrencinin) ID'sini giriniz...";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            ogrencilericek();
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;

            comboBox2.Enabled = true;

            lblkontrol1.Text = "";
            lblkontrol3.Text = "";
            lblkontrol2.Text = "Güncellemek İstediğiniz (Sınıfın) ID'sini giriniz...";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            siniflaricek();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;

            lblkontrol1.Text = "";
            lblkontrol2.Text = "";
            lblkontrol3.Text = "Güncellemek İstediğiniz (Bölümün) ID'sini giriniz...";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            bolumlericek();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;

            lblkontrol2.Text = "";
            lblkontrol3.Text = "";
            lblkontrol1.Text = "Silmek İstediğiniz (Öğrencinin) ID'sini giriniz...";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            ogrencilericek();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            groupBox5.Enabled = false;

            lblkontrol1.Text = "";
            lblkontrol3.Text = "";
            lblkontrol2.Text = "Silmek İstediğiniz (Sınıfın) ID'sini giriniz...";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            siniflaricek();
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;

            lblkontrol1.Text = "";
            lblkontrol2.Text = "";
            lblkontrol3.Text = "Silmek İstediğiniz (Bölünün) ID'sini giriniz...";

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

            bolumlericek();
        }


        void ogrencilericek()
        {
            var veriler = from table1 in db.Ogrencilers
                          join table2 in db.Siniflars
                          on table1.Siniflar_sinifid equals table2.sinifid
                          select new
                          {

                              ID = table1.ogrid,
                              AD = table1.ograd,
                              SOYAD = table1.ogrsoyad,
                              SINIF = table2.sinifad
                          };
            dataGridView1.DataSource = veriler.ToList();
            lblcount.Text = veriler.Count().ToString();
        }
        void siniflaricek()
        {
            var veriler = from table1 in db.Siniflars
                          join table2 in db.Bolumlers
                          on table1.Bolumler_bolumid equals table2.bolumid
                          select new
                          {
                              ID = table1.sinifid,
                              SINIF = table1.sinifad,
                              BÖLÜM = table2.bolumad
                          };
            dataGridView1.DataSource = veriler.ToList();
            lblcount.Text = veriler.Count().ToString();
        }
        void bolumlericek()
        {
            var veriler = from item in db.Bolumlers
                          select new
                          {
                              ID = item.bolumid,
                              BOLUM = item.bolumad
                          };
            dataGridView1.DataSource = veriler.ToList();
            lblcount.Text = veriler.Count().ToString();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton6.Checked || radioButton10.Checked)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            else if (radioButton7.Checked || radioButton11.Checked)
            {
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            else if (radioButton8.Checked || radioButton12.Checked)
            {
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox1.Text != null)
            {
                try
                {
                    int id = int.Parse(textBox1.Text);
                    if (db.Ogrencilers.Find(id) != null)
                    {
                        var veri = db.Ogrencilers.Find(id);
                        textBox2.Text = veri.ograd.ToString();
                        textBox3.Text = veri.ogrsoyad.ToString();
                        int a = int.Parse(veri.Siniflar_sinifid.ToString());

                        var veri2 = db.Siniflars.Find(a);
                        comboBox1.Text = veri2.sinifad;
                    }
                    else MessageBox.Show("Aradığınız ID'ye ait kayıt bulunamadı...");
                }
                catch (Exception)
                {
                }

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "" || textBox4.Text != null)
            {
                try
                {
                    int id = int.Parse(textBox4.Text);
                    if (db.Siniflars.Find(id) != null)
                    {
                        var veri = db.Siniflars.Find(id);
                        textBox5.Text = veri.sinifad;
                        int a = int.Parse(veri.Bolumler_bolumid.ToString());

                        var veri2 = db.Bolumlers.Find(a);
                        comboBox2.Text = veri2.bolumad;
                    }
                    else MessageBox.Show("Aradığınız ID'ye ait kayıt bulunamadı...");
                }
                catch (Exception)
                {
                }

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "" || textBox6.Text != null)
            {
                try
                {
                    int id = int.Parse(textBox6.Text);
                    if (db.Bolumlers.Find(id) != null)
                    {
                        var veri = db.Bolumlers.Find(id);
                        textBox7.Text = veri.bolumad;
                    }
                    else MessageBox.Show("Aradığınız ID'ye ait kayıt bulunamadı...");
                }
                catch (Exception)
                {
                }

            }
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            groupBox9.Enabled = true;
            groupBox10.Enabled = false;
            groupBox11.Enabled = false;

            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;

            ogrencilericek();
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            groupBox9.Enabled = false;
            groupBox10.Enabled = true;
            groupBox11.Enabled = false;

            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;

            siniflaricek();
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            groupBox9.Enabled = false;
            groupBox10.Enabled = false;
            groupBox11.Enabled = true;

            textBox8.Text = null;
            textBox9.Text = null;
            textBox10.Text = null;
            textBox11.Text = null;
            textBox12.Text = null;
            textBox13.Text = null;

            bolumlericek();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox8.Text;

            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       where table1.ograd.Contains(aranan)
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };

            dataGridView1.DataSource = veri.ToList();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox9.Text;

            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       where table1.ogrsoyad.Contains(aranan)
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };

            dataGridView1.DataSource = veri.ToList();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox10.Text;

            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       where table2.sinifad.Contains(aranan)
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };

            dataGridView1.DataSource = veri.ToList();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox11.Text;

            var veri = from table1 in db.Siniflars
                       join table2 in db.Bolumlers
                       on table1.Bolumler_bolumid equals table2.bolumid
                       where table1.sinifad.Contains(aranan)
                       select new
                       {
                           ID = table1.sinifid,
                           SINIF = table1.sinifad,
                           BÖLÜM = table2.bolumad
                       };

            dataGridView1.DataSource = veri.ToList();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox12.Text;

            var veri = from table1 in db.Siniflars
                       join table2 in db.Bolumlers
                       on table1.Bolumler_bolumid equals table2.bolumid
                       where table2.bolumad.Contains(aranan)
                       select new
                       {
                           ID = table1.sinifid,
                           SINIF = table1.sinifad,
                           BÖLÜM = table2.bolumad
                       };

            dataGridView1.DataSource = veri.ToList();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            string aranan = textBox13.Text;

            var veri = from item in db.Bolumlers
                       where item.bolumad.Contains(aranan)
                       select new
                       {
                           ID = item.bolumid,
                           BOLUM = item.bolumad
                       };

            dataGridView1.DataSource = veri.ToList();
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };
            dataGridView1.DataSource = veri.OrderBy(x => x.AD).ToList();
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };
            dataGridView1.DataSource = veri.OrderByDescending(x => x.AD).ToList();
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };
            dataGridView1.DataSource = veri.OrderBy(x => x.SOYAD).ToList();
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            var veri = from table1 in db.Ogrencilers
                       join table2 in db.Siniflars
                       on table1.Siniflar_sinifid equals table2.sinifid
                       select new
                       {
                           ID = table1.ogrid,
                           AD = table1.ograd,
                           SOYAD = table1.ogrsoyad,
                           SINIF = table2.sinifad
                       };
            dataGridView1.DataSource = veri.OrderByDescending(x => x.SOYAD).ToList();
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            var veri = from table1 in db.Bolumlers
                       select new
                       {
                           ID = table1.bolumid,
                           AD = table1.bolumad,
                       };
            dataGridView1.DataSource = veri.OrderBy(x => x.AD).ToList();
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            var veri = from table1 in db.Bolumlers
                       select new
                       {
                           ID = table1.bolumid,
                           AD = table1.bolumad,
                       };
            dataGridView1.DataSource = veri.OrderByDescending(x => x.AD).ToList();
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            /*var veriler = db.Ogrencilers.OrderBy(x => x.Siniflar_sinifid).GroupBy(y => y.Siniflar_sinifid).Select(z => new
            {
                SINIF = z.OrderBy(d => d.Siniflar_sinifid == z.Key),
                TOPLAM = z.Count()
            }).ToList();*/

            var veri = (from table1 in db.Siniflars
                        join table2 in db.Ogrencilers
                        on table1.sinifid equals table2.Siniflar_sinifid into tut
                        select new
                        {
                            SINIF = table1.sinifad,
                            MEVCUDU = tut.Count()
                        }).OrderByDescending(z=>z.MEVCUDU).ToList();
            dataGridView1.DataSource = veri;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            var veri = (from table1 in db.Bolumlers
                        join table2 in db.Siniflars
                        on table1.bolumid equals table2.Bolumler_bolumid into tut
                        select new
                        {
                            BÖLÜM = table1.bolumad,
                            ADET = tut.Count()
                        }).OrderByDescending(z => z.ADET).ToList();
            dataGridView1.DataSource = veri;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            var veri = (from table1 in db.Bolumlers
                        from table2 in db.Siniflars
                        from table3 in db.Ogrencilers
                        where table1.bolumid == table2.Bolumler_bolumid && table2.sinifid == table3.Siniflar_sinifid
                        select new
                        {
                            BÖLÜM = table1.bolumad,
                        }).OrderBy(x => x.BÖLÜM).GroupBy(z => z.BÖLÜM).Select(t => new
                        {
                            BÖLÜM = t.Key,
                            SAYI = t.Count()
                        });

            dataGridView1.DataSource = veri.ToList();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblcount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Anasayfa();
            frm.Show();
            this.Hide();
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
