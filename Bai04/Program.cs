namespace NgayTrongThang
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Nhap vao thang: ");
            int thang = NhapVaKiemTra();

            Console.Write("Nhap vao nam: ");
            int nam = NhapVaKiemTra();

            int soNgay = TimSoNgay(thang, nam);

            if (soNgay == 0) return;
            Console.WriteLine($"Thang {thang} nam {nam} co so ngay la: {soNgay}");
        }

        //Ham tim so ngay
        private static int TimSoNgay(int thang, int nam)
        {
            bool laNhuan = laNamNhuan(nam);
            int soNgay = 0;

            if (thang < 1 || thang > 12 || nam == 0)
            {
                Console.WriteLine("Nam, thang khong hop le!");
                return 0;
            }

            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    soNgay = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    soNgay = 30;
                    break;

                case 2:
                    {
                        if (laNhuan)
                        {
                            soNgay = 29;
                        }
                        else
                        {
                            soNgay = 28;
                        }
                        break;
                    }
            }
            return soNgay;
        }

        //Ham kiem tra
        private static bool laNamNhuan(int nam)
        {
            return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
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