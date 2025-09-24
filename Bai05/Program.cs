using System;
using System.Globalization;

namespace NgayTrongTuan
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Nhap vao ngay: ");
            int ngay = NhapVaKiemTra();
            Console.Write("Nhap vao thang: ");
            int thang = NhapVaKiemTra();
            Console.Write("Nhap vao nam: ");
            int nam = NhapVaKiemTra();

            DateTime date = new DateTime(nam, thang, ngay);
            string dayOfWeek = date.DayOfWeek.ToString();

            string ngayTiengViet = layTenNgayTrongTuan(dayOfWeek);

            Console.WriteLine($"Ngay {ngay}/{thang}/{nam} la: {ngayTiengViet}");
        }

        //Tra ve ten ngay trong tuan bang tieng viet
        private static string layTenNgayTrongTuan(string dayOfWeek)
        {
            string ngayTiengViet = "";
            switch (dayOfWeek)
            {
                case "Sunday":
                    ngayTiengViet = "Chu Nhat";
                    break;

                case "Monday":
                    ngayTiengViet = "Thu Hai";
                    break;

                case "Tuesday":
                    ngayTiengViet = "Thu Ba";
                    break;

                case "Wednesday":
                    ngayTiengViet = "Thu Tu";
                    break;

                case "Thursday":
                    ngayTiengViet = "Thu Nam";
                    break;

                case "Friday":
                    ngayTiengViet = "Thu Sau";
                    break;

                case "Saturday":
                    ngayTiengViet = "Thu Bay";
                    break;
            }

            return ngayTiengViet;
        }

        //Ham kiem tra
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