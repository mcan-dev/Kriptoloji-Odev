using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptioALGO
{
    public class SifrelemeAlgoritmalari
    {
        // 29 harflik standart Türkçe alfabe
        public static readonly string Alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

        /// <summary>
        /// Kullanıcının girdiği metni Türkçe kurallarına göre büyütür, 
        /// boşluk, noktalama ve sayılardan arındırarak sadece harfleri bırakır.
        /// </summary>
        public static string MetniTemizle(string girdi)
        {
            if (string.IsNullOrEmpty(girdi))
                return "";

            // 1. Adım: Türkçe kurallarına uygun olarak tüm metni BÜYÜK HARF yap
            girdi = girdi.ToUpper(new CultureInfo("tr-TR"));

            StringBuilder temizMetin = new StringBuilder();

            // 2. Adım: Sadece belirlediğimiz alfabede olan karakterleri filtrele
            foreach (char c in girdi)
            {
                // Eğer karakter alfabemizin içinde geçiyorsa (noktalama/boşluk değilse) ekle
                if (Alfabe.Contains(c.ToString()))
                {
                    temizMetin.Append(c);
                }
            }

            return temizMetin.ToString();
        }
        public static string ZigzagSifrele(string metin, int raySayisi)
        {
            // Önce metni kurallara göre temizle
            string islenecekMetin = MetniTemizle(metin);

            // Eğer metin boşsa veya ray sayısı 1 ve daha küçükse işlem yapmaya gerek yok
            if (string.IsNullOrEmpty(islenecekMetin) || raySayisi <= 1)
                return islenecekMetin;

            // Her bir ray (satır) için bir metin tutucu oluşturuyoruz
            StringBuilder[] raylar = new StringBuilder[raySayisi];
            for (int i = 0; i < raySayisi; i++)
            {
                raylar[i] = new StringBuilder();
            }

            int satir = 0;
            bool asagiIniyor = false;

            // Metnin harflerinde tek tek gezin
            foreach (char c in islenecekMetin)
            {
                raylar[satir].Append(c);

                // En üst veya en alt satıra ulaştıysak yön değiştir
                if (satir == 0 || satir == raySayisi - 1)
                {
                    asagiIniyor = !asagiIniyor;
                }

                // Yöne göre satır numarasını artır veya azalt
                satir += asagiIniyor ? 1 : -1;
            }

            // Tüm rayları (satırları) birleştirip sonucu oluştur
            StringBuilder sonuc = new StringBuilder();
            foreach (var ray in raylar)
            {
                sonuc.Append(ray.ToString());
            }

            return sonuc.ToString();
        }
        public static string ZigzagCoz(string sifreliMetin, int raySayisi)
        {
            if (string.IsNullOrEmpty(sifreliMetin) || raySayisi <= 1)
                return sifreliMetin;

            int uzunluk = sifreliMetin.Length;

            // 1. ADIM: Hangi rayda (satırda) kaç harf olması gerektiğini bul (Simülasyon)
            int[] rayUzunluklari = new int[raySayisi];
            int satir = 0;
            bool asagiIniyor = false;

            for (int i = 0; i < uzunluk; i++)
            {
                rayUzunluklari[satir]++;

                if (satir == 0 || satir == raySayisi - 1)
                    asagiIniyor = !asagiIniyor;

                satir += asagiIniyor ? 1 : -1;
            }

            // 2. ADIM: Şifreli metni parçalayarak ait oldukları raylara dağıt
            string[] raylar = new string[raySayisi];
            int index = 0;
            for (int i = 0; i < raySayisi; i++)
            {
                raylar[i] = sifreliMetin.Substring(index, rayUzunluklari[i]);
                index += rayUzunluklari[i];
            }

            // 3. ADIM: Raylardan tekrar zikzak çizerek orijinal metni oku
            StringBuilder sonuc = new StringBuilder();
            satir = 0;
            asagiIniyor = false;
            int[] rayIndex = new int[raySayisi]; // Her rayda kaçıncı harfte kaldığımızı tutar

            for (int i = 0; i < uzunluk; i++)
            {
                // İlgili satırdaki sıradaki harfi al
                sonuc.Append(raylar[satir][rayIndex[satir]]);
                rayIndex[satir]++;

                // Yönü güncelle
                if (satir == 0 || satir == raySayisi - 1)
                    asagiIniyor = !asagiIniyor;

                satir += asagiIniyor ? 1 : -1;
            }

            return sonuc.ToString();
        }
        public static string RotaSifrele(string metin, int sutunSayisi)
        {
            string islenecek = MetniTemizle(metin);

            if (string.IsNullOrEmpty(islenecek) || sutunSayisi <= 1)
                return islenecek;

            // Satır sayısını hesapla (Örn: 10 harf, 3 sütun -> 4 satır gerekir)
            int satirSayisi = (int)Math.Ceiling((double)islenecek.Length / sutunSayisi);
            char[,] matris = new char[satirSayisi, sutunSayisi];
            int index = 0;

            // 1. ADIM: Matrisi satır satır doldur
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (index < islenecek.Length)
                    {
                        matris[i, j] = islenecek[index++];
                    }
                    else
                    {
                        // Metin bittiyse boş kalan hücreleri 'X' ile doldur (Padding)
                        matris[i, j] = 'X';
                    }
                }
            }

            // 2. ADIM: Rotayı izleyerek şifreli metni oluştur
            StringBuilder sonuc = new StringBuilder();

            for (int j = 0; j < sutunSayisi; j++)
            {
                if (j % 2 == 0)
                {
                    // Çift indeksli sütunlar (0, 2, 4...): Yukarıdan aşağıya oku
                    for (int i = 0; i < satirSayisi; i++)
                        sonuc.Append(matris[i, j]);
                }
                else
                {
                    // Tek indeksli sütunlar (1, 3, 5...): Aşağıdan yukarıya oku
                    for (int i = satirSayisi - 1; i >= 0; i--)
                        sonuc.Append(matris[i, j]);
                }
            }

            return sonuc.ToString();
        }
        public static string RotaCoz(string sifreliMetin, int sutunSayisi)
        {
            if (string.IsNullOrEmpty(sifreliMetin) || sutunSayisi <= 1)
                return sifreliMetin;

            // Şifreleme sırasında matrisi X ile doldurduğumuz için 
            // şifreli metnin uzunluğu sütun sayısına tam bölünür.
            int satirSayisi = sifreliMetin.Length / sutunSayisi;
            char[,] matris = new char[satirSayisi, sutunSayisi];
            int index = 0;

            // 1. ADIM: Şifreli metindeki harfleri rotayı izleyerek matrise geri yerleştir
            for (int j = 0; j < sutunSayisi; j++)
            {
                if (j % 2 == 0)
                {
                    // Yukarıdan aşağıya doldur
                    for (int i = 0; i < satirSayisi; i++)
                        matris[i, j] = sifreliMetin[index++];
                }
                else
                {
                    // Aşağıdan yukarıya doldur
                    for (int i = satirSayisi - 1; i >= 0; i--)
                        matris[i, j] = sifreliMetin[index++];
                }
            }

            // 2. ADIM: Matrisi satır satır okuyarak orijinal metni elde et
            StringBuilder sonuc = new StringBuilder();
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    sonuc.Append(matris[i, j]);
                }
            }

            // Not: Metnin sonuna eklediğimiz dolgu 'X' karakterleri sonuçta görünecektir.
            // Klasik kriptografide bu durum normaldir (kullanıcı metnin sonundaki anlamsız X'leri göz ardı eder).
            return sonuc.ToString();
        }
        public static string PermutasyonSifrele(string metin, string anahtarKelime)
        {
            string islenecek = MetniTemizle(metin);
            // Anahtar kelimeyi de aynı kurallarla temizliyoruz (Büyük harf, Türkçe karakter vs.)
            string anahtar = MetniTemizle(anahtarKelime);

            if (string.IsNullOrEmpty(islenecek) || string.IsNullOrEmpty(anahtar))
                return islenecek;

            int sutunSayisi = anahtar.Length;
            int satirSayisi = (int)Math.Ceiling((double)islenecek.Length / sutunSayisi);

            char[,] matris = new char[satirSayisi, sutunSayisi];
            int index = 0;

            // 1. ADIM: Matrisi satır satır doldur (Eksikleri 'X' ile tamamla)
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    if (index < islenecek.Length)
                        matris[i, j] = islenecek[index++];
                    else
                        matris[i, j] = 'X';
                }
            }

            // 2. ADIM: Anahtar kelimenin harflerini alfabetik olarak sırala 
            // ve orijinal indekslerini (hangi sütuna denk geldiklerini) hafızada tut.
            var siraliAnahtar = anahtar
                .Select((harf, i) => new { Harf = harf, OrijinalIndex = i })
                .OrderBy(x => x.Harf)
                .ToList();

            // 3. ADIM: Alfabetik sıraya göre sütunları oku
            StringBuilder sonuc = new StringBuilder();
            foreach (var eleman in siraliAnahtar)
            {
                int okunacakSutun = eleman.OrijinalIndex;
                for (int i = 0; i < satirSayisi; i++)
                {
                    sonuc.Append(matris[i, okunacakSutun]);
                }
            }

            return sonuc.ToString();
        }
        public static string PermutasyonCoz(string sifreliMetin, string anahtarKelime)
        {
            string anahtar = MetniTemizle(anahtarKelime);

            if (string.IsNullOrEmpty(sifreliMetin) || string.IsNullOrEmpty(anahtar))
                return sifreliMetin;

            int sutunSayisi = anahtar.Length;
            // Şifrelerken X ile doldurduğumuz için tam bölünür
            int satirSayisi = sifreliMetin.Length / sutunSayisi;
            char[,] matris = new char[satirSayisi, sutunSayisi];

            var siraliAnahtar = anahtar
                .Select((harf, i) => new { Harf = harf, OrijinalIndex = i })
                .OrderBy(x => x.Harf)
                .ToList();

            int index = 0;

            // 1. ADIM: Şifreli metni sütun sütun matrise geri yerleştir
            foreach (var eleman in siraliAnahtar)
            {
                int yazilacakSutun = eleman.OrijinalIndex;
                for (int i = 0; i < satirSayisi; i++)
                {
                    matris[i, yazilacakSutun] = sifreliMetin[index++];
                }
            }

            // 2. ADIM: Matrisi satır satır okuyarak orijinal metni elde et
            StringBuilder sonuc = new StringBuilder();
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    sonuc.Append(matris[i, j]);
                }
            }

            return sonuc.ToString();
        }
    
        // 1. KAYDIRMALI ŞİFRELEME (CAESAR / SHIFT)
    public static string KaydirmaliSifrele(string metin, int kaydirma)
        {
            string islenecek = MetniTemizle(metin);
            if (string.IsNullOrEmpty(islenecek)) return islenecek;

            StringBuilder sonuc = new StringBuilder();
            int m = Alfabe.Length; // 29

            foreach (char c in islenecek)
            {
                int index = Alfabe.IndexOf(c);

                // (index + kaydirma) mod 29
                int yeniIndex = (index + kaydirma) % m;
                // Negatif sayı ihtimaline karşı mod aritmetiği düzeltmesi
                if (yeniIndex < 0) yeniIndex += m;

                sonuc.Append(Alfabe[yeniIndex]);
            }
            return sonuc.ToString();
        }

        public static string KaydirmaliCoz(string sifreliMetin, int kaydirma)
        {
            if (string.IsNullOrEmpty(sifreliMetin)) return sifreliMetin;

            StringBuilder sonuc = new StringBuilder();
            int m = Alfabe.Length; // 29

            foreach (char c in sifreliMetin)
            {
                int index = Alfabe.IndexOf(c);
                if (index == -1) continue; // Alfabede olmayan karakterleri yoksay

                // (index - kaydirma) mod 29
                int yeniIndex = (index - kaydirma) % m;
                if (yeniIndex < 0) yeniIndex += m;

                sonuc.Append(Alfabe[yeniIndex]);
            }
            return sonuc.ToString();
        }

        // -----------------------------------------------------------------

        // DOĞRUSAL ŞİFRELEME İÇİN YARDIMCI MATEMATİK FONKSİYONU
        // Formül (D(x) = a^-1 (x - b) mod 29) için a'nın çarpmaya göre tersini bulur.
        private static int ModulerTersBul(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1) return x;
            }
            return -1; // Ters bulunamadıysa (Aralarında asal değilse)
        }

        // 2. DOĞRUSAL ŞİFRELEME (AFFINE)
        public static string DogrusalSifrele(string metin, int a, int b)
        {
            string islenecek = MetniTemizle(metin);
            if (string.IsNullOrEmpty(islenecek)) return islenecek;

            StringBuilder sonuc = new StringBuilder();
            int m = Alfabe.Length; // 29

            foreach (char c in islenecek)
            {
                int x = Alfabe.IndexOf(c);

                // Formül: E(x) = (a * x + b) mod 29
                int yeniIndex = (a * x + b) % m;
                if (yeniIndex < 0) yeniIndex += m;

                sonuc.Append(Alfabe[yeniIndex]);
            }
            return sonuc.ToString();
        }

        public static string DogrusalCoz(string sifreliMetin, int a, int b)
        {
            if (string.IsNullOrEmpty(sifreliMetin)) return sifreliMetin;

            int m = Alfabe.Length; // 29
            int aTers = ModulerTersBul(a, m);

            if (aTers == -1)
            {
                throw new ArgumentException($"HATA: 'a' anahtarı ({a}) alfabe uzunluğu ({m}) ile aralarında asal olmalıdır!");
            }

            StringBuilder sonuc = new StringBuilder();

            foreach (char c in sifreliMetin)
            {
                int y = Alfabe.IndexOf(c);
                if (y == -1) continue;

                // Formül: D(y) = a^-1 * (y - b) mod 29
                int x = (aTers * (y - b)) % m;
                if (x < 0) x += m;

                sonuc.Append(Alfabe[x]);
            }
            return sonuc.ToString();
        }

        // -----------------------------------------------------------------

        // 3. YER DEĞİŞTİRME ŞİFRELEME (SUBSTITUTION)
        public static string YerDegistirmeSifrele(string metin, string anahtarAlfabe)
        {
            string islenecek = MetniTemizle(metin);
            string anahtar = MetniTemizle(anahtarAlfabe); // Anahtarı da kurallara uydur

            if (string.IsNullOrEmpty(islenecek)) return islenecek;

            if (anahtar.Length != Alfabe.Length)
            {
                throw new ArgumentException($"Yer değiştirme anahtarı tam {Alfabe.Length} karakter olmalıdır! Sizin girdiğiniz: {anahtar.Length}");
            }

            StringBuilder sonuc = new StringBuilder();
            foreach (char c in islenecek)
            {
                int index = Alfabe.IndexOf(c);
                sonuc.Append(anahtar[index]); // Alfabedeki sırayı, yeni anahtar alfabesinden çeker
            }
            return sonuc.ToString();
        }

        public static string YerDegistirmeCoz(string sifreliMetin, string anahtarAlfabe)
        {
            string anahtar = MetniTemizle(anahtarAlfabe);

            if (string.IsNullOrEmpty(sifreliMetin)) return sifreliMetin;

            if (anahtar.Length != Alfabe.Length)
            {
                throw new ArgumentException($"Yer değiştirme anahtarı tam {Alfabe.Length} karakter olmalıdır!");
            }

            StringBuilder sonuc = new StringBuilder();
            foreach (char c in sifreliMetin)
            {
                int index = anahtar.IndexOf(c); // Bu kez harfi anahtar alfabesinde arıyoruz
                if (index != -1)
                {
                    sonuc.Append(Alfabe[index]); // Orijinal alfabedeki karşılığını yazıyoruz
                }
            }
            return sonuc.ToString();
        }

        // -----------------------------------------------------------------

        // 4. SAYI ANAHTARLI ŞİFRELEME (NUMERIC TRANSPOSITION)
        public static string SayiAnahtarliSifrele(string metin, int[] anahtarDizisi)
        {
            string islenecek = MetniTemizle(metin);
            if (string.IsNullOrEmpty(islenecek) || anahtarDizisi == null || anahtarDizisi.Length == 0)
                return islenecek;

            int sutunSayisi = anahtarDizisi.Length;
            int satirSayisi = (int)Math.Ceiling((double)islenecek.Length / sutunSayisi);

            char[,] matris = new char[satirSayisi, sutunSayisi];
            int index = 0;

            // Matrisi satır satır doldur (Eksikleri X ile tamamla)
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    matris[i, j] = index < islenecek.Length ? islenecek[index++] : 'X';
                }
            }

            StringBuilder sonuc = new StringBuilder();

            // Anahtar dizisindeki sayı sırasına göre sütunları oku (Örn: 1, 2, 3...)
            for (int k = 0; k < sutunSayisi; k++)
            {
                // Array.IndexOf ile "k+1" (yani sırasıyla 1, 2, 3...) sayısının kaçıncı sütunda olduğunu buluyoruz
                int okunacakSutun = Array.IndexOf(anahtarDizisi, k + 1);

                if (okunacakSutun == -1)
                    throw new ArgumentException("Sayı anahtarı 1'den başlayarak ardışık tam sayıları içermelidir. (Örn: 3,1,4,2)");

                for (int i = 0; i < satirSayisi; i++)
                {
                    sonuc.Append(matris[i, okunacakSutun]);
                }
            }
            return sonuc.ToString();
        }

        public static string SayiAnahtarliCoz(string sifreliMetin, int[] anahtarDizisi)
        {
            if (string.IsNullOrEmpty(sifreliMetin) || anahtarDizisi == null || anahtarDizisi.Length == 0)
                return sifreliMetin;

            int sutunSayisi = anahtarDizisi.Length;
            int satirSayisi = sifreliMetin.Length / sutunSayisi;

            char[,] matris = new char[satirSayisi, sutunSayisi];
            int index = 0;

            
            for (int k = 0; k < sutunSayisi; k++)
            {
                int doldurulacakSutun = Array.IndexOf(anahtarDizisi, k + 1);

                for (int i = 0; i < satirSayisi; i++)
                {
                    if (index < sifreliMetin.Length)
                        matris[i, doldurulacakSutun] = sifreliMetin[index++];
                }
            }

            StringBuilder sonuc = new StringBuilder();
            for (int i = 0; i < satirSayisi; i++)
            {
                for (int j = 0; j < sutunSayisi; j++)
                {
                    sonuc.Append(matris[i, j]);
                }
            }

            return sonuc.ToString();
        }
        public static string VigenereSifrele(string metin, string anahtar)
        {
            string islenecek = MetniTemizle(metin);
            string temizAnahtar = MetniTemizle(anahtar);
            if (string.IsNullOrEmpty(islenecek) || string.IsNullOrEmpty(temizAnahtar)) return islenecek;

            StringBuilder sonuc = new StringBuilder();
            int m = Alfabe.Length; // 29

            for (int i = 0; i < islenecek.Length; i++)
            {
                int p = Alfabe.IndexOf(islenecek[i]);
                int k = Alfabe.IndexOf(temizAnahtar[i % temizAnahtar.Length]);
                int yeniIndex = (p + k) % m;
                sonuc.Append(Alfabe[yeniIndex]);
            }
            return sonuc.ToString();
        }

        public static string VigenereCoz(string sifreliMetin, string anahtar)
        {
            string temizAnahtar = MetniTemizle(anahtar);
            if (string.IsNullOrEmpty(sifreliMetin) || string.IsNullOrEmpty(temizAnahtar)) return sifreliMetin;

            StringBuilder sonuc = new StringBuilder();
            int m = Alfabe.Length;

            for (int i = 0; i < sifreliMetin.Length; i++)
            {
                int c = Alfabe.IndexOf(sifreliMetin[i]);
                int k = Alfabe.IndexOf(temizAnahtar[i % temizAnahtar.Length]);
                int yeniIndex = (c - k + m) % m;
                sonuc.Append(Alfabe[yeniIndex]);
            }
            return sonuc.ToString();
        }
        // 5x6'lık matris oluşturma yardımcı metodu
        private static char[,] MatrisOlustur(string anahtar)
        {
            string temizAnahtar = MetniTemizle(anahtar);
            string dolguAlfabe = Alfabe + "Q"; // 29 harf + 1 dolgu = 30
            string matrisKarakterleri = "";

            // Anahtardaki benzersiz karakterleri ekle
            foreach (char c in temizAnahtar)
                if (!matrisKarakterleri.Contains(c)) matrisKarakterleri += c;

            // Kalan harfleri alfabeden tamamla
            foreach (char c in dolguAlfabe)
                if (!matrisKarakterleri.Contains(c)) matrisKarakterleri += c;

            char[,] matris = new char[5, 6];
            for (int i = 0; i < 30; i++)
                matris[i / 6, i % 6] = matrisKarakterleri[i];

            return matris;
        }

        public static string DortKareSifrele(string metin, string anahtar1, string anahtar2)
        {
            string islenecek = MetniTemizle(metin);
            if (islenecek.Length % 2 != 0) islenecek += "X";

            var m1 = MatrisOlustur(""); // Sol Üst (Düz Alfabe)
            var m2 = MatrisOlustur(anahtar1); // Sağ Üst
            var m3 = MatrisOlustur(anahtar2); // Sol Alt
            var m4 = MatrisOlustur(""); // Sağ Alt (Düz Alfabe)

            StringBuilder sonuc = new StringBuilder();
            for (int i = 0; i < islenecek.Length; i += 2)
            {
                char a = islenecek[i], b = islenecek[i + 1];
                int r1 = -1, c1 = -1, r2 = -1, c2 = -1;

                // Koordinatları bul (m1 ve m4 üzerinde)
                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 6; c++)
                    {
                        if (m1[r, c] == a) { r1 = r; c1 = c; }
                        if (m4[r, c] == b) { r2 = r; c2 = c; }
                    }

                // Çapraz eşleme: m2[r1, c2] ve m3[r2, c1]
                sonuc.Append(m2[r1, c2]);
                sonuc.Append(m3[r2, c1]);
            }
            return sonuc.ToString();
        }
        public static string DortKareCoz(string sifreliMetin, string anahtar1, string anahtar2)
        {
            if (string.IsNullOrEmpty(sifreliMetin)) return "";

            // Matrisleri şifrelemedekiyle aynı sırada oluşturuyoruz
            var m1 = MatrisOlustur("");       // Sol Üst (Standart Alfabe)
            var m2 = MatrisOlustur(anahtar1); // Sağ Üst
            var m3 = MatrisOlustur(anahtar2); // Sol Alt
            var m4 = MatrisOlustur("");       // Sağ Alt (Standart Alfabe)

            StringBuilder sonuc = new StringBuilder();

            // Harfleri ikişerli gruplar halinde işle
            for (int i = 0; i < sifreliMetin.Length; i += 2)
            {
                char c1 = sifreliMetin[i];
                char c2 = sifreliMetin[i + 1];

                int r1 = -1, col1 = -1, r2 = -1, col2 = -1;

                // Şifreli 1. harfi m2 (Sağ Üst) matrisinde ara
                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 6; c++)
                        if (m2[r, c] == c1) { r1 = r; col1 = c; }

                // Şifreli 2. harfi m3 (Sol Alt) matrisinde ara
                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 6; c++)
                        if (m3[r, c] == c2) { r2 = r; col2 = c; }

                // Eğer harfler matrislerde bulunduysa (r1 ve r2 -1 değilse)
                if (r1 != -1 && r2 != -1)
                {
                    // Orijinal harfler: 
                    // 1. harf m1'in satırı(r1) ve m3'ün sütunundan(col2) gelir (Çapraz Mantığı)
                    // Aslında şifreleme mantığının tam tersi:
                    sonuc.Append(m1[r1, col2]);
                    sonuc.Append(m4[r2, col1]);
                }
            }
            return sonuc.ToString();
        }
        
        public static string HillSifrele(string metin, int a, int b, int c, int d)
        {
            string islenecek = MetniTemizle(metin);
            if (islenecek.Length % 2 != 0) islenecek += "X";

            StringBuilder sonuc = new StringBuilder();
            int m = Alfabe.Length;

            for (int i = 0; i < islenecek.Length; i += 2)
            {
                int p1 = Alfabe.IndexOf(islenecek[i]);
                int p2 = Alfabe.IndexOf(islenecek[i + 1]);

                int c1 = (a * p1 + b * p2) % m;
                int c2 = (c * p1 + d * p2) % m;

                sonuc.Append(Alfabe[c1]);
                sonuc.Append(Alfabe[c2]);
            }
            return sonuc.ToString();
        }
        public static string HillCoz(string sifreliMetin, int a, int b, int c, int d)
        {
            int m = Alfabe.Length; // 29

            // 1. Determinant: (a*d - b*c) mod 29
            int det = (a * d - b * c) % m;
            if (det < 0) det += m;

            // 2. Determinantın mod 29'daki tersini bul (ModulerTersBul metodunu kullanır)
            int detTers = ModulerTersBul(det, m);
            if (detTers == -1)
                throw new Exception("Bu matrisin tersi yok, bu yüzden şifre çözülemez!");

            // 3. Ters matris elemanlarını (Adjoint üzerinden) hesapla
            int a_inv = (d * detTers) % m;
            int b_inv = (-b * detTers) % m;
            if (b_inv < 0) b_inv += m;
            int c_inv = (-c * detTers) % m;
            if (c_inv < 0) c_inv += m;
            int d_inv = (a * detTers) % m;

            // 4. Bulunan ters matrisle HillSifrele'yi çağırarak metni çöz
            return HillSifrele(sifreliMetin, a_inv, b_inv, c_inv, d_inv);
        }
    }
}
