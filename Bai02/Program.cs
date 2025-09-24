using System;

namespace Tong
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Nhap vao so nguyen duong n: ");

            int soN = NhapVaKiemTra();

            if (soN <= 0)
            {
                Console.WriteLine("Vui long nhap mot so nguyen duong");
                return;
            }

            long tong = 0;
            for (int i = 0; i < soN; i++)
            {
                if (LaSoNguyenTo(i))
                {
                    tong += i;
                }
            }

            Console.WriteLine($"Tong cac so nguyen to < n: {tong}");
        }

        //Ham kiem tra
        private static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int NhapVaKiemTra()
        {
            int n;
            while (true)
            {
                bool isValid = int.TryParse(Console.ReadLine(), out n);

                if (isValid && n > 0) return n;
                Console.WriteLine("Vui long nhap lai!");
            }
        }
    }
}