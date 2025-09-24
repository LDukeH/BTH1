using System;
using System.Globalization;

namespace KiemTraNgayThangNam
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int ngay, thang, nam;

            Console.Write("Nhap ngay: ");
            ngay = NhapVaKiemTra();

            Console.Write("Nhap thang: ");
            thang = NhapVaKiemTra();

            Console.Write("Nhap nam: ");
            nam = NhapVaKiemTra();

            bool laNhuan = laNamNhuan(nam);

            //Năm âm là TCN
            bool hopLe = kiemTraHopLe(ngay, thang, nam);
            if (hopLe)
            {
                Console.WriteLine($"Ngay {ngay}/{thang}/{nam} hop le");
            }
            else
            {
                Console.WriteLine($"Ngay {ngay}/{thang}/{nam} khong hop le. Vui long nhap lai!");
            }
        }

        //Ham kiem tra
        private static bool laNamNhuan(int nam)
        {
            return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
        }

        private static bool kiemTraHopLe(int ngay, int thang, int nam)
        {
            bool hopLe = true;
            bool laNhuan = laNamNhuan(nam);
            if (thang < 1 || thang > 12 || ngay < 1 || ngay > 31)
            {
                hopLe = false;
            }
            else
            {
                switch (thang)
                {
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        {
                            if (ngay < 1 || ngay > 30)
                            {
                                hopLe = false;
                            }
                            break;
                        }

                    case 2:
                        {
                            if (laNhuan)
                            {
                                if (ngay > 29)
                                {
                                    hopLe = false;
                                }
                            }
                            else
                            {
                                if (ngay > 28)
                                {
                                    hopLe = false;
                                }
                            }
                            break;
                        }
                }
            }

            return hopLe;
        }

        private static int NhapVaKiemTra()
        {
            int n;
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out n);
                if (isValid) return n;
                Console.WriteLine("Vui long nhap lai!");
            }
        }
    }
}