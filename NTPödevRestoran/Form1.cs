using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NTPödevRestoran
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<masa> masalar = new List<masa>();
        string dosyaYolu = "C:\\Users\\Asus\\Desktop\\C#\\NTPödevRestoran\\FaturaYazdır.txt";

        Dictionary<string, int> yemekler = new Dictionary<string, int>()
        {

            { "Mercimek çorbası", 50 },
            { "Ezogelin çorbası", 55 },
            { "Tarhana çorbası", 60 },
            { "İşkembe çorbası", 75 },
            { "Humus", 65 },
            { "Acuka", 60 },
            { "Yoğurtlu meze", 55 },
            { "Patlıcan salatası", 65 },
            { "Zeytinyağlı yaprak sarma", 70 },
            { "Çoban salatası", 50 },
            { "Mevsim salatası", 50 },
            { "Gavurdağı salatası", 60 },
            { "Sigara böreği", 55 },
            { "Paçanga böreği", 75 },
            { "Kalamar tava", 120 },
            { "İçli köfte", 70 },
            { "Adana kebap", 130 },
            { "Döner", 110 },
            { "Izgara köfte", 115 },
            { "Kuzu şiş", 140 },
            { "Tavuk kanat", 105 },
            { "Karnıyarık", 100 },
            { "İmam bayıldı", 90 },
            { "Mücver", 65 },
            { "Bulgur pilavı", 45 },
            { "Pirinç pilavı", 50 },
            { "Mantı", 110 },
            { "Spagetti", 95 },
            { "Levrek ızgara", 150 },
            { "Hamsi tava", 125 },
            { "Karides güveç", 160 }
        };
        Dictionary<string, int> içecekler = new Dictionary<string, int>()
        {
        { "Ayran", 20 },
            { "Şalgam", 20 },
            { "Türk kahvesi", 30 },
            { "Çay", 10 },
            { "Sade soda", 15 },
            { "Limonata", 25 },
            { "Portakal suyu", 30 },
            { "Nar suyu", 35 },
            { "Su", 5 },
            { "Kola", 40 },
            { "Fanta", 30 },
            { "Sprite", 30 },
            { "Ice tea", 30 },
            { "Salep", 35 },
            { "Boza", 30 },
            { "Rakı", 150 },
            { "Bira", 90 },
            { "Şarap", 130 }
        };
        Dictionary<string, int> tatlılar = new Dictionary<string, int>()
        {
           { "Baklava", 70 },
            { "Künefe", 75 },
            { "Sütlaç", 50 },
            { "Kazandibi", 50 },
            { "Revani", 55 },
            { "Şekerpare", 50 },
            { "Lokma", 40 },
            { "Kadayıf", 65 },
            { "Tulumba", 45 },
            { "Aşure", 60 },
            { "Fırın sütlaç", 55 },
            { "Profiterol", 65 },
            { "Trileçe", 70 },
            { "Katmer", 90 },
            { "Dondurma", 50 }

        };
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean dolu = false;
            foreach (masa eleman in masalar)
            {
                if (eleman.MasaNo == Convert.ToInt32(comboBox4.SelectedItem))
                {
                    dolu = true;
                    break;
                }
            }
            masa sipariş = new masa();
            if (dolu)
            {
                MessageBox.Show("Masa dolu, lütfen başka masa seçiniz.");
            }
            else
            {
                try
                {
                    sipariş.MasaNo = Convert.ToInt32(comboBox4.SelectedItem);
                    sipariş.YemekAd = comboBox1.SelectedItem.ToString();
                    sipariş.IçecekAd = comboBox2.SelectedItem.ToString();
                    sipariş.TatlıAd = comboBox3.SelectedItem.ToString();
                    sipariş.YemekAdet = Convert.ToInt32(textBox1.Text);
                    sipariş.İçecekAdet = Convert.ToInt32(textBox2.Text);
                    sipariş.TatlıAdet = Convert.ToInt32(textBox3.Text);

                }
                catch
                {
                    MessageBox.Show("Lütfen Alanları boş geçmeyelim");
                }
            

            foreach (var eleman in yemekler)
            {
                if (eleman.Key == comboBox1.SelectedItem.ToString())
                {
                    sipariş.YemekFiyat = Convert.ToInt32(eleman.Value);
                }
            }
            foreach (var eleman in içecekler)
            {
                if (eleman.Key == comboBox2.SelectedItem.ToString())
                {
                    sipariş.IçecekFiyat = Convert.ToInt32(eleman.Value);
                }

            }
            foreach (var eleman in tatlılar)
            {
                if (eleman.Key == comboBox3.SelectedItem.ToString())
                {
                    sipariş.TatlıFiyat = eleman.Value;
                }
            }

            listBox1.Items.Add("Masa No: " + sipariş.MasaNo);
            listBox1.Items.Add("Yemek:" + sipariş.YemekAd);
            listBox1.Items.Add("Yemek Adeti: " + sipariş.YemekAdet);
            listBox1.Items.Add("Yemek Fiyatı: " + sipariş.YemekFiyat);
            listBox1.Items.Add("İçecek: " + sipariş.IçecekAd);
            listBox1.Items.Add("İçecek Adeti: " + sipariş.İçecekAdet);
            listBox1.Items.Add("İçecek Fiyatı: " + sipariş.IçecekFiyat);
            listBox1.Items.Add("Tatlı: " + sipariş.TatlıAd);
            listBox1.Items.Add("Tatlı Adeti: " + sipariş.TatlıAdet);
            listBox1.Items.Add("Tatlı Fiyatı: " + sipariş.TatlıFiyat);
            double a = sipariş.toplamTutar();
            listBox1.Items.Add("Toplam Tutar: " + a);
            listBox1.Items.Add("******************************************************************");
            sipariş.MasaDurumu = "Sipariş hazırlanıyor";
            masalar.Add(sipariş);
        }}

        private void button3_Click(object sender, EventArgs e)
        {

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            foreach (masa eleman in masalar)
            {
                if (eleman.MasaNo == Convert.ToInt32(comboBox5.SelectedItem))
                {
                    listBox2.Items.Add("Masa No: " + eleman.MasaNo);
                    listBox2.Items.Add("Yemek: " + eleman.YemekAd);
                    listBox2.Items.Add("Yemek Adeti: " + eleman.YemekAdet);
                    listBox2.Items.Add("Yemek Fiyatı: " + eleman.YemekFiyat);
                    listBox2.Items.Add("İçecek: " + eleman.IçecekAd);

                    listBox2.Items.Add("İçecek Adeti: " + eleman.İçecekAdet);
                    listBox2.Items.Add("İçecek Fiyatı: " + eleman.IçecekFiyat);
                    listBox2.Items.Add("Tatlı: " + eleman.TatlıAd);

                    listBox2.Items.Add("Tatlı Adeti: " + eleman.TatlıAdet);
                    listBox2.Items.Add("Tatlı Fiyatı: " + eleman.TatlıFiyat);
                    listBox2.Items.Add("Toplam Tutar: " + eleman.toplamTutar());
                    listBox2.Items.Add("Masa Durumu: " + eleman.MasaDurumu);


                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var eleman in masalar)
            {
                if (eleman.MasaNo == Convert.ToInt32(comboBox5.SelectedItem))
                {
                    using (StreamWriter fatura = new StreamWriter(dosyaYolu))
                    {
                        fatura.WriteLine(eleman.masaSipariş());
                        fatura.Close();
                        MessageBox.Show("Fiş Yazdırıldı");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            foreach (var eleman in masalar)
            {
                if (eleman.MasaNo == Convert.ToInt32(comboBox5.SelectedItem))
                {
                    eleman.MasaDurumu = "Teslim Edildi";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    

