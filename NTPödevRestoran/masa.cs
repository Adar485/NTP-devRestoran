using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTPödevRestoran
{
    interface Isipariş
    {
        string masaSipariş();
    }
    interface Iyazdırılabilir
    {
        double toplamTutar();
    }

    class masa : Isipariş, Iyazdırılabilir
    {
        private string masaDurumu = "Sipariş alınmadı";
        private int masaNo;
        private string yemekAd;
        private string içecekAd;
        private int yemekFiyat;
        private int içecekFiyat;
        private string tatlıAd;
        private int tatlıFiyat;
        private int yemekAdet;
        private int içecekAdet;
        private int tatlıAdet;
        private double toplamtutar;


        public int MasaNo
        {
            get { return masaNo; }
            set
            {
                if (value < 18 && value > 0)
                {
                    masaNo = value;
                }
            }
        }
        public string MasaDurumu { get => masaDurumu; set => masaDurumu = value; }
        public string YemekAd { get => yemekAd; set => yemekAd = value; }
        public string IçecekAd { get => içecekAd; set => içecekAd = value; }
        public string TatlıAd { get => tatlıAd; set => tatlıAd = value; }
        public int YemekFiyat { get => yemekFiyat; set => yemekFiyat = value; }
        public int IçecekFiyat { get => içecekFiyat; set => içecekFiyat = value; }
        public int TatlıFiyat { get => tatlıFiyat; set => tatlıFiyat = value; }

        public int YemekAdet
        {
            get { return yemekAdet; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Yemek adeti 0'dan küçük olamaz.");
                }
                else { yemekAdet = value; }
            }
        }
        public int İçecekAdet
        {
            get { return içecekAdet; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("İçecek adeti 0'dan küçük olamaz.");
                }
                else { içecekAdet = value; }
            }
        }
        public int TatlıAdet
        {
            get { return tatlıAdet; }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("Tatlı adeti sıfırdan küçük olamaz");
                }
                else { tatlıAdet = value; }

            }
        }
        public string masaSipariş()
        {
            return ("Masa No: " + MasaNo + "\n" +
                    "Yemek Adı: " + YemekAd + "\n" +
                    "Yemek Fiyatı: " + YemekFiyat + "\n" +
                    "İçecek Adı: " + IçecekAd + "\n" +
                    "İçecek Fiyatı: " + IçecekFiyat + "\n" +
                    "Tatlı Adı: " + TatlıAd + "\n" +
                    "Tatlı Fiyatı: " + TatlıFiyat + "\n" +
                    "Yemek Adeti: " + YemekAdet + "\n" +
                    "İçecek Adeti: " + İçecekAdet + "\n" +
                    "Tatlı Adeti: " + TatlıAdet + "\n" +
                    "Toplam Tutar: " + toplamTutar());
        }
        public double toplamTutar()
        {
            toplamtutar = (YemekFiyat * YemekAdet) + (IçecekFiyat * İçecekAdet) + (TatlıFiyat * TatlıAdet);
            return toplamtutar;
        }
    }
}
