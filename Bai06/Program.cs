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

            Console.Write($"Nhap hang can xoa (0-{n}): ");
            int k = NhapVaKiemTra();

            int[,] maTran = TaoMaTran(n, m);
            InMaTran(maTran);

            //
            PhanTuLonNhat(maTran);
            PhanTuNhoNhat(maTran);

            //
            HangCoTongLonNhat(maTran);
            TongCacSoKhongPhaiSoNguyenTo(maTran);

            //
            maTran = XoaMotHang(maTran, k);
            Console.WriteLine($"\nSau khi xoa hang {k}: ");
            InMaTran(maTran);

            //
            maTran = XoaCotCoPhanTuLonNhat(maTran);
            Console.WriteLine("\nSau khi xoa cot: ");
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

        //a) Xuất ma trận
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

        //b. Tìm phần tử lớn nhất/nhỏ nhất
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

        //c) Tìm dòng có tổng lớn nhất
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

            Console.WriteLine($"\nHang co tong lon nhat la hang: {hangMax}");
        }

        //d) Tính tổng các số không phải là số nguyên tố
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
            Console.WriteLine($"\nTong cac so khong phai so nguyen to trong ma tran la: {tong}\n");
        }

        //e) Xóa dòng thứ k trong ma trận
        private static int[,] XoaMotHang(int[,] maTran, int hangCanXoa)
        {
            int soHang = maTran.GetLength(0);
            int soCot = maTran.GetLength(1);
            int k = hangCanXoa - 1; // Chuyen ve chi so bat dau tu 0

            if (k < 0 || k >= soHang)
            {
                Console.WriteLine("So hang can xoa khong hop le!");
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

        //f) Xóa cột chứa phần tử lớn nhất trong ma trận
        private static int[,] XoaCotCoPhanTuLonNhat(int[,] maTran)
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