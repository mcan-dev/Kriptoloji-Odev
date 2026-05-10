using System.Net.Mail;
using System.Net;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System.Numerics;
using System;
using System.Linq;
using System.Windows.Forms;

namespace cryptioALGO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbYontem.Items.Add("Zigzag Þifreleme");
            cmbYontem.Items.Add("Rota Þifreleme");
            cmbYontem.Items.Add("Permütasyon Þifreleme");
            // cmbYontem.Items.Add("kaydýrmalý Þifreleme");
            cmbYontem.Items.Add("Doðrusal Þifreleme");
            cmbYontem.Items.Add("Yer Deðiþtirme Þifreleme"); // Yazým düzenlendi
            cmbYontem.Items.Add("Sayý Anahtarlý Þifreleme");
            cmbYontem.Items.Add("Vigenere Þifreleme");
            cmbYontem.Items.Add("Dört Kare Þifreleme");
            cmbYontem.Items.Add("Hill Þifreleme");

            // 1. DÜZELTME: RSA ComboBox'a eklendi
            cmbYontem.Items.Add("RSA Þifreleme");

            if (cmbYontem.Items.Count > 0)
                cmbYontem.SelectedIndex = 0;
        }

        private void btnSifrele_Click(object sender, EventArgs e)
        {
            try
            {
                string girdi = txtGirdi.Text;

                if (cmbYontem.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen önce bir þifreleme yöntemi seçin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string secilenYontem = cmbYontem.SelectedItem.ToString();
                string anahtar = txtAnahtar1.Text;
                string sonuc = "";

                switch (secilenYontem)
                {
                    // --- SENÝN ALGORÝTMALARIN ---
                    case "Zigzag Þifreleme":
                        int ray = Convert.ToInt32(anahtar);
                        sonuc = SifrelemeAlgoritmalari.ZigzagSifrele(girdi, ray);
                        break;

                    case "Rota Þifreleme":
                        int sutun = Convert.ToInt32(anahtar);
                        sonuc = SifrelemeAlgoritmalari.RotaSifrele(girdi, sutun);
                        break;

                    case "Permütasyon Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.PermutasyonSifrele(girdi, anahtar);
                        break;

                    // --- ARKADAÞININ ALGORÝTMALARI ---
                    case "Kaydýrmalý Þifreleme":
                        int kaydirma = Convert.ToInt32(anahtar);
                        sonuc = SifrelemeAlgoritmalari.KaydirmaliSifrele(girdi, kaydirma);
                        break;

                    case "Doðrusal Þifreleme":
                        int a = Convert.ToInt32(anahtar);
                        int b = Convert.ToInt32(txtAnahtar2.Text);
                        sonuc = SifrelemeAlgoritmalari.DogrusalSifrele(girdi, a, b);
                        break;

                    case "Yer Deðiþtirme Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.YerDegistirmeSifrele(girdi, anahtar);
                        break;

                    case "Sayý Anahtarlý Þifreleme":
                        int[] sayiAnahtari = anahtar.Split(',').Select(int.Parse).ToArray();
                        sonuc = SifrelemeAlgoritmalari.SayiAnahtarliSifrele(girdi, sayiAnahtari);
                        break;

                    case "Vigenere Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.VigenereSifrele(girdi, anahtar);
                        break;

                    case "Dört Kare Þifreleme":
                        string anahtar2 = txtAnahtar2.Text;
                        sonuc = SifrelemeAlgoritmalari.DortKareSifrele(girdi, anahtar, anahtar2);
                        break;

                    case "Hill Þifreleme":
                        int[] h = anahtar.Split(',').Select(int.Parse).ToArray();
                        if (h.Length != 4) throw new Exception("Hill için 4 sayý girin (Örn: 3,2,5,7)");
                        sonuc = SifrelemeAlgoritmalari.HillSifrele(girdi, h[0], h[1], h[2], h[3]);
                        break;

                    // 2. DÜZELTME: RSA Þifreleme case'i eklendi
                    case "RSA Þifreleme":
                        int e_anahtar = Convert.ToInt32(anahtar);
                        int n_anahtar = Convert.ToInt32(txtAnahtar2.Text);
                        sonuc = SifrelemeAlgoritmalari.RsaSifrele(girdi, e_anahtar, n_anahtar);
                        break;

                    default:
                        MessageBox.Show("Lütfen geçerli bir yöntem seçin.");
                        return;
                }

                txtCikti.Text = sonuc;
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen seçtiðiniz yönteme uygun bir anahtar girin!\nSayý beklenen yere harf veya yanlýþ formatta (Örn: Sayý Anahtarlý için virgül kullanýlmamasý) giriþ yaptýnýz.", "Anahtar Format Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEpostaGonder_Click(object sender, EventArgs e)
        {
            string sifreliMetin = txtCikti.Text;
            string aliciMail = txtAliciMail.Text;

            if (string.IsNullOrEmpty(sifreliMetin) || string.IsNullOrEmpty(aliciMail))
            {
                MessageBox.Show("Lütfen önce bir metni þifreleyin ve alýcý e-posta adresini girin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string gonderenMail = "mustafacanunal25@gmail.com";
                string uygulamaSifresi = "rgzl bezj sazx psxl";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(gonderenMail, uygulamaSifresi);

                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress(gonderenMail);
                mesaj.To.Add(aliciMail);
                mesaj.Subject = "Kripto Odev - Gizli Mesaj";
                mesaj.Body = sifreliMetin;

                client.Send(mesaj);
                MessageBox.Show("Þifreli metin baþarýyla hedefe gönderildi!", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("E-posta gönderilirken bir hata oluþtu. Ýnternet baðlantýnýzý ve Uygulama Þifrenizi kontrol edin.\nDetay: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            try
            {
                string girdi = txtGirdi.Text;

                string secilenYontem = cmbYontem.SelectedItem != null ? cmbYontem.SelectedItem.ToString() : "";
                string anahtar = txtAnahtar1.Text;
                string sonuc = "";

                if (string.IsNullOrEmpty(girdi))
                {
                    MessageBox.Show("Lütfen çözülecek þifreli metni 'Girdi Metni' alanýna yazýn veya yapýþtýrýn.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (secilenYontem)
                {
                    case "Zigzag Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.ZigzagCoz(girdi, Convert.ToInt32(anahtar));
                        break;
                    case "Rota Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.RotaCoz(girdi, Convert.ToInt32(anahtar));
                        break;
                    case "Permütasyon Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.PermutasyonCoz(girdi, anahtar);
                        break;
                    case "Kaydýrmalý Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.KaydirmaliCoz(girdi, Convert.ToInt32(anahtar));
                        break;
                    case "Doðrusal Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.DogrusalCoz(girdi, Convert.ToInt32(anahtar), Convert.ToInt32(txtAnahtar2.Text));
                        break;
                    case "Yer Deðiþtirme Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.YerDegistirmeCoz(girdi, anahtar);
                        break;
                    case "Sayý Anahtarlý Þifreleme":
                        int[] sayiAnahtari = anahtar.Split(',').Select(int.Parse).ToArray();
                        sonuc = SifrelemeAlgoritmalari.SayiAnahtarliCoz(girdi, sayiAnahtari);
                        break;
                    case "Vigenere Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.VigenereCoz(girdi, anahtar);
                        break;
                    case "Dört Kare Þifreleme":
                        sonuc = SifrelemeAlgoritmalari.DortKareCoz(girdi, anahtar, txtAnahtar2.Text);
                        break;
                    case "Hill Þifreleme":
                        int[] hc = anahtar.Split(',').Select(int.Parse).ToArray();
                        sonuc = SifrelemeAlgoritmalari.HillCoz(girdi, hc[0], hc[1], hc[2], hc[3]);
                        break;
                    case "RSA Þifreleme":
                        int d_anahtar = Convert.ToInt32(anahtar); // Çözmek için d (gizli anahtar) gerekir
                        int n_mod = Convert.ToInt32(txtAnahtar2.Text);
                        sonuc = SifrelemeAlgoritmalari.RsaCoz(girdi, d_anahtar, n_mod);
                        break;

                    default:
                        MessageBox.Show("Lütfen geçerli bir yöntem seçin.");
                        return;
                }

                txtCikti.Text = sonuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen anahtarý doðru formatta girdiðinizden emin olun.\nHata Detayý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}