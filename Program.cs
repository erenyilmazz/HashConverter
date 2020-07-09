using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Hash_Converter
{
    class Program
    {

        

        static string Md5hash(string input)
        {

            MD5CryptoServiceProvider md5Hashh = new MD5CryptoServiceProvider();


            byte[] data = md5Hashh.ComputeHash(Encoding.Default.GetBytes(input));


            StringBuilder sBuilder = new StringBuilder();


            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }


            return sBuilder.ToString();
        }


        private static void txtyaz()
        {

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string masaustu = desktop + @"\Hash.txt";

            FileStream fileS = new FileStream(masaustu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter streamW = new StreamWriter(fileS);
            streamW.WriteLine("Hashlar Bu TXT Belgesi Altında Kayıt Altına Alınacaktır.");
            streamW.WriteLine(" ");

            streamW.Flush();

            streamW.Close();
            fileS.Close();

            

            

            


        }


        

        static void Main()
        {

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string masaustu = desktop + @"\Hash.txt";
            txtyaz();

            
            string secim;
            string sifrelenecek, sifrelenmis;

            while (true)
            {
                
                Console.WriteLine("Hash Dönüştürücüye Hoşgeldiniz.");
                Console.WriteLine("Metninizi hangi hash türüne dönüştürmek istersiniz?");
                Console.WriteLine("1. MD5");
                Console.WriteLine("2. SHA-1");
                Console.WriteLine("3. BASE64");
                Console.WriteLine("Çıkış Yapmak İçin 'q' Tuşuna Basınız.");
                Console.WriteLine("Programmer: 'Rozzz'");
                Console.WriteLine("");

                Console.Write("Seçim: ");

                secim = Console.ReadLine();

                if (secim == "1")
                {
                    Console.WriteLine("");

                    Console.Write("Md5 Hash Türüne Dönüştürülecek değeri Giriniz: ");
                    sifrelenecek = Console.ReadLine();

                    string hash = Md5hash(sifrelenecek);

                    Console.WriteLine("Md5'e dönüştürülecek olan '" + sifrelenecek + "' değerinin Dönüşümü Şu Şekildedir: " + hash);
                    File.AppendAllText(masaustu, "Md5'e dönüştürülecek olan '" + sifrelenecek + "' değerinin Dönüşümü Şu Şekildedir: " + hash + Environment.NewLine);

                    Console.WriteLine("Md5 Dönüşüm İşlemi Tamamlanmıştır.");
                    Console.WriteLine("Dönüşümün Sonucu Masaüstünde Bulunan 'Hash' İsimli Metin Belgesine Kaydedilmiştir.");
                    Console.WriteLine("");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("");



                }
                else if (secim == "2")
                {

                    SHA1 sha1 = new SHA1CryptoServiceProvider();
                    Console.Write("SHA-1 Hash Türüne Dönüştürülecek Veriyi Giriniz: ");
                    sifrelenecek = Console.ReadLine();

                    var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(sifrelenecek));
                    sifrelenmis= string.Concat(hash.Select(b => b.ToString("x2")));

                    
                    Console.WriteLine("SHA-1'e dönüştürülecek olan '" + sifrelenecek + "'değerinin dönüşümü şu şekildedir: " + sifrelenmis);
                    File.AppendAllText(masaustu, "SHA-1'e dönüştürülecek olan '" + sifrelenecek + "'değerinin dönüşümü şu şekildedir: " + sifrelenmis + Environment.NewLine);

                    Console.WriteLine("SHA-1 Dönüşüm İşlemi Tamamlanmıştır.");
                    Console.WriteLine("Dönüşümün Sonucu Masaüsünde Bulunan 'Hash' İsimli Metin Belgesine Kaydedilmiştir.");
                    Console.WriteLine("");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("");


                }
                else if (secim == "3")
                {
                    Console.Write("BASE64 Hash Türüne Dönüştürülecek Veriyi Giriniz: ");
                    sifrelenecek = Console.ReadLine();
                    byte[] veri = System.Text.ASCIIEncoding.ASCII.GetBytes(sifrelenecek);
                    sifrelenmis = System.Convert.ToBase64String(veri);
                    Console.WriteLine("BASE64'e dönüştürülecek olan '" + sifrelenecek + "' değerinin dönüşümü şu şekildedir: " + sifrelenmis);
                    File.AppendAllText(masaustu, "BASE64'e dönüştürülecek olan '" + sifrelenecek + "'değerinin dönüşümü şu şekildedir: " + sifrelenmis + Environment.NewLine);

                    Console.WriteLine("BASE64 Dönüşüm İşlemi Tamamlanmıştır.");
                    Console.WriteLine("Dönüşümün Sonucu Masaüsünde Bulunan 'Hash' İsimli Metin Belgesine Kaydedilmiştir.");
                    Console.WriteLine("");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("");



                }
                else if (secim == "q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("Yanlış Tuşlama Yaptınız.");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("");
                }



            }

            
            
            
            
            
        }
    }

}