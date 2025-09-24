using System;

namespace MaTran
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Nhap so hang: ");
            int n = NhapVaKiemTra();

            Console.Write("Nhap so cot: ");
            int m = NhapVaKiemTra();

            int[,] maTran = TaoMaTran(n, m);
            InMaTran(maTran);

            //
            PhanTuLonNhat(maTran);
            PhanTuNhoNhat(maTran);

            //
            HangCoTongLonNhat(maTran);
            TongCacSoKhongPhaiSoNguyenTo(maTran);

            //
            maTran = XoaMotHang(maTran);
            Console.WriteLine("Sau khi xoa: ");
            InMaTran(maTran);

            //
            maTran = XoaCotCoTongCaoNhat(maTran);
            Console.WriteLine("Sau khi xoa: ");
            InMaTran(maTran);
        }

        //Ham tao ma tran
        private static int[,] TaoMaTran(int soHang, int soCot)
        {
            int[,] maTran = new int[soHang, soCot];
            Random rand = new Random();
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    maTran[i, j] = rand.Next(int.MinValue, int.MaxValue); // Gia tri ngau nhien
                }
            }
            return maTran;
        }

        //Ham in ma tran
        private static void InMaTran(int[,] maTran)
        {
            Console.WriteLine("================= Ma Tran =================");
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    Console.Write(maTran[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("===========================================\n");
        }

        //Cac ham tim kiem
        private static void PhanTuLonNhat(int[,] maTran)
        {
            int max = int.MinValue;
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    if (maTran[i, j] > max)
                    {
                        max = maTran[i, j];
                    }
                }
            }
            Console.WriteLine($"Phan tu lon nhat trong ma tran la: {max}");
        }

        private static void PhanTuNhoNhat(int[,] maTran)
        {
            int min = int.MaxValue;
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    if (maTran[i, j] < min)
                    {
                        min = maTran[i, j];
                    }
                }
            }
            Console.WriteLine($"Phan tu nho nhat trong ma tran la: {min}");
        }

        //Ham tim hang co tong lon nhat
        private static void HangCoTongLonNhat(int[,] maTran)
        {
            long maxSum = int.MinValue;
            int hangMax = -1;

            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);

            for (int i = 0; i < soHang; i++)
            {
                long currentSum = 0;
                for (int j = 0; j < soCot; j++)
                {
                    currentSum += maTran[i, j];
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    hangMax = i;
                }
            }

            Console.WriteLine($"\nHang co tong lon nhat la hang {hangMax} voi tong la: {maxSum}");
        }

        //Ham tinh tong cac so khong phai so nguyen to
        private static void TongCacSoKhongPhaiSoNguyenTo(int[,] maTran)
        {
            long tong = 0;
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    if (!LaSoNguyenTo(maTran[i, j]))
                    {
                        tong += maTran[i, j];
                    }
                }
            }
            Console.WriteLine($"\nTong cac so khong phai so nguyen to trong ma tran la: {tong}");
        }

        //Ham xoa mot hang
        private static int[,] XoaMotHang(int[,] maTran)
        {
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);

            Console.Write($"\nNhap vao hang can xoa (1-{soHang}): ");
            int k = NhapVaKiemTra() - 1;

            if (k < 0 || k >= soHang)
            {
                Console.WriteLine("Hang khong hop le!");
                return maTran;
            }

            int[,] maTranMoi = new int[soHang - 1, soCot];
            int rowCnt = 0;

            for (int i = 0; i < soHang; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < soCot; j++)
                {
                    maTranMoi[rowCnt, j] = maTran[i, j];
                }
                rowCnt++;
            }

            return maTranMoi;
        }

        //Ham xoa cot co phan tu lon nhat
        private static int[,] XoaCotCoTongCaoNhat(int[,] maTran)
        {
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);

            long max = int.MinValue;
            int cotMax = -1;

            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    if (maTran[i, j] > max)
                    {
                        max = maTran[i, j];
                        cotMax = j;
                    }
                }
            }

            int[,] maTranMoi = new int[soHang, soCot - 1];
            int colCnt = 0;

            for (int j = 0; j < soCot; j++)
            {
                if (j == cotMax) continue;
                for (int i = 0; i < soHang; i++)
                {
                    maTranMoi[i, colCnt] = maTran[i, j];
                }
                colCnt++;
            }

            return maTranMoi;
        }

        //Ham kiem tra
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