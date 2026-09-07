using System;

class NhanVien
{
    private string _maNV;
    private string _hoTen;
    private decimal _luongCoBan;
    private int _soNgayLam;
    private int _soNgayNghiPhep;

    public NhanVien()
    {
        _maNV = "";
        _hoTen = "";
        _luongCoBan = 5000000;
        _soNgayLam = 26;
        _soNgayNghiPhep = 0;
    }

    public NhanVien(string maNV, string hoTen)
    {
        _maNV = maNV;
        _hoTen = hoTen;
        _luongCoBan = 5000000;
        _soNgayLam = 26;
        _soNgayNghiPhep = 0;
    }

    public NhanVien(string maNV, string hoTen, decimal luongCoBan, int soNgayLam, int soNgayNghiPhep)
    {
        _maNV = maNV;
        _hoTen = hoTen;
        LuongCoBan = luongCoBan;
        SoNgayLam = soNgayLam;
        _soNgayNghiPhep = soNgayNghiPhep;
    }

    public NhanVien(string maNV, string hoTen, decimal luong = 5_000_000, int soNgayLam = 26)
    {
        _maNV = maNV;
        _hoTen = hoTen;
        LuongCoBan = luong;
        SoNgayLam = soNgayLam;
        _soNgayNghiPhep = 0;
    }

    public string HoTen
    {
        get { return _hoTen; }
        set { _hoTen = value; }
    }

    public decimal LuongCoBan
    {
        get { return _luongCoBan; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Luong co ban khong duoc nho hon 0!");
            }

            _luongCoBan = value;
        }
    }

    public int SoNgayLam
    {
        get { return _soNgayLam; }
        set
        {
            if (value < 0 || value > 31)
            {
                throw new Exception("So ngay lam phai tu 0 den 31!");
            }

            _soNgayLam = value;
        }
    }

    public decimal LuongThucNhan
    {
        get
        {
            decimal luongTheoNgay = LuongCoBan / 26 * SoNgayLam;
            decimal khauTruBHXH = LuongCoBan * 0.08m;

            return luongTheoNgay - khauTruBHXH;
        }
    }

    public decimal TinhThuong()
    {
        return 0;
    }

    public decimal TinhThuong(decimal heSo)
    {
        return LuongCoBan * heSo;
    }

    public decimal TinhThuong(decimal heSo, bool coPhucLoi)
    {
        decimal tienThuong = LuongCoBan * heSo;

        if (coPhucLoi == true)
        {
            tienThuong += 500000;
        }

        return tienThuong;
    }

    public void HienThiThongTin()
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("Ma NV: " + _maNV);
        Console.WriteLine("Ho ten: " + HoTen);
        Console.WriteLine("Luong co ban: " + LuongCoBan.ToString("N0") + " VNĐ");
        Console.WriteLine("So ngay lam: " + SoNgayLam);
        Console.WriteLine("Luong thuc nhan: " + LuongThucNhan.ToString("N0") + " VNĐ");
        Console.WriteLine("------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        NhanVien nv1 = new NhanVien();

        nv1.HoTen = "Nguyen Van An";
        nv1.LuongCoBan = 8000000;
        nv1.SoNgayLam = 26;

        NhanVien nv2 = new NhanVien(
            "NV002",
            "Tran Van Binh"
        );

        nv2.LuongCoBan = 10000000;
        nv2.SoNgayLam = 24;

        NhanVien nv3 = new NhanVien(
            "NV003",
            "Le Thi Hoa",
            12000000,
            28,
            2
        );

        NhanVien nv4 = new NhanVien(
            maNV: "NV004",
            hoTen: "Pham Van Nam",
            soNgayLam: 20
        );

        Console.WriteLine("===== THONG TIN NHAN VIEN =====");

        nv1.HienThiThongTin();
        nv2.HienThiThongTin();
        nv3.HienThiThongTin();
        nv4.HienThiThongTin();

        Console.WriteLine("\n===== TINH THUONG =====");

        Console.WriteLine("Nhan vien: " + nv1.HoTen);

        Console.WriteLine(
            "TinhThuong(): " +
            nv1.TinhThuong().ToString("N0") + " VNĐ"
        );

        Console.WriteLine(
            "TinhThuong(0.1): " +
            nv1.TinhThuong(0.1m).ToString("N0") + " VNĐ"
        );

        Console.WriteLine(
            "TinhThuong(0.1, true): " +
            nv1.TinhThuong(0.1m, true).ToString("N0") + " VNĐ"
        );

        Console.WriteLine("\n===== SO SANH =====");

        decimal thuong1 = nv1.TinhThuong();
        decimal thuong2 = nv1.TinhThuong(0.1m);
        decimal thuong3 = nv1.TinhThuong(0.1m, true);

        Console.WriteLine("Thuong khong co he so: " +
                          thuong1.ToString("N0") + " VNĐ");

        Console.WriteLine("Thuong co he so 0.1: " +
                          thuong2.ToString("N0") + " VNĐ");

        Console.WriteLine("Thuong co he so 0.1 + phuc loi: " +
                          thuong3.ToString("N0") + " VNĐ");

        Console.WriteLine("\n===== KIEM TRA VALIDATE =====");

        try
        {
            nv1.SoNgayLam = 40;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loi: " + ex.Message);
        }

        try
        {
            nv1.LuongCoBan = -5000000;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loi: " + ex.Message);
        }

        Console.ReadLine();
    }
}