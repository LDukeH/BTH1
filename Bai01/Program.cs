using System;

namespace Mang
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu cua mang: ");
            int soLuong = NhapVaKiemTra();

            int[] arr = new int[soLuong];
            for (int i = 0; i < soLuong; i++)
            {
                Console.Write($"Nhap phan tu thu {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            //a) Tong so le
            TongSoLe(arr, soLuong);

            //b) Dem so nguyen to
            DemSoNguyenTo(arr, soLuong);

            //c) So chinh phuong nho nhat
            SoChinhPhuongNhoNhat(arr, soLuong);
        }

        //Ham tinh tong so le
        private static void TongSoLe(int[] arr, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    tong += arr[i];
                }
            }
            Console.WriteLine($"Tong cac so le trong mang la: {tong}");
        }

        //Ham dem so nguyen to
        private static void DemSoNguyenTo(int[] arr, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (LaSoNguyenTo(arr[i]))
                {
                    count++;
                }
            }
            Console.WriteLine($"So luong so nguyen to trong mang la: {count}");
        }

        //Ham tim so chinh phuong nho nhat
        private static void SoChinhPhuongNhoNhat(int[] arr, int n)
        {
            int min = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < min && LaSoChinhPhuong(arr[i]))
                {
                    min = arr[i];
                }
            }

            if (min == int.MaxValue)
            {
                min = -1;
            }
            Console.WriteLine($"So chinh phuong nho nhat la: {min}");
        }

        //Cac ham kiem tra
        private static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % 2 == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool LaSoChinhPhuong(int n)
        {
            int temp = (int)Math.Sqrt(n);
            if (temp * temp == n)
            {
                return true;
            }
            return false;
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