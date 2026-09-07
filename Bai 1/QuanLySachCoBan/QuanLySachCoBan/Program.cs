namespace QuanLySachCoBan
{
    internal class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;
        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            _maSach = maSach;
            _tenSach = tenSach;
            _tacGia = tacGia;
            _namXuatBan = namXuatBan;
            _giaBan = giaBan;
        }
        public Sach()
        {
            _maSach = "";
            _tenSach = "";
            _tacGia = "";
            _namXuatBan = 1900;
            _giaBan = 0.0;
        }
        public string maSach
        {
            get { return _maSach; }
        }
        public string tenSach
        {
            get { return _tenSach; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Ten sach khong duoc de rong");
                }
                _tenSach = value;
            }

        }  
        public int namXuatBan
        {
            get { return _namXuatBan; }
            set
            {
                int namHienTai = DateTime.Now.Year;
                if (value<1900 || value > namHienTai)
                {
                    throw new Exception("Thoi gian phia tu 1900 den " + namHienTai);
                }
                _namXuatBan = value;
            }
        }
        public double GiaBan
        {
            get { return _giaBan; }
        }
        public void hienThiThongTin()
        {
            Console.WriteLine("Ten sach: " + _tenSach);
            Console.WriteLine("Ma sach: " + _maSach);
            Console.WriteLine("Tac gia: "+  _giaBan);
            Console.WriteLine("Nam xuat ban: " + _namXuatBan);
            Console.WriteLine("Gia ban: " + _giaBan +"VND");
            Console.WriteLine("------------------------------");
        }
        public override string ToString()
        {
            return maSach + "_" + tenSach + "_" + _tacGia + "_" + namXuatBan + "_" + GiaBan.ToString("VND") + "_"; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sach sach1 = new Sach(
                "S010",
                "Free Fire Max",
                "Bac Gau",
                2020,
                200000
             );
            Sach sach2 = new Sach();
            sach2.tenSach = "LienQuanMobile";
            sach2.namXuatBan = 2021;

            Sach sach3 = new Sach("S003", "SQL Server", "Trần Văn B", 2024, 150000)
            {
                tenSach = "SQL Server co ban",
                namXuatBan = 2024
            };
            Console.WriteLine("===== DANH SÁCH SÁCH =====");

            sach1.hienThiThongTin();
            sach2.hienThiThongTin();
            sach3.hienThiThongTin();
            Console.WriteLine("\n===== KIỂM TRA VALIDATE =====");

            try
            {
                sach1.namXuatBan = 1800;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
            }
            Console.WriteLine("MSSV: 6551071039");

            Console.ReadLine();
        }
    }
}
