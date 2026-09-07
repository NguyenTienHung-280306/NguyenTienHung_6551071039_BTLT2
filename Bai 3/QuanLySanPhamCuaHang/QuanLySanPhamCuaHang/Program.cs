using System;
using System.Collections.Generic;

class SanPham
{
    private string _maSP;
    private string _tenSP;
    private decimal _gia;
    private int _soLuongTon;

    public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
    {
        _maSP = maSP;
        _tenSP = tenSP;
        _gia = gia;
        _soLuongTon = soLuongTon;
    }

    public string MaSP
    {
        get { return _maSP; }
        set { _maSP = value; }
    }

    public string TenSP
    {
        get { return _tenSP; }
        set { _tenSP = value; }
    }

    public decimal Gia
    {
        get { return _gia; }
        set { _gia = value; }
    }

    public int SoLuongTon
    {
        get { return _soLuongTon; }
        set { _soLuongTon = value; }
    }

    public virtual decimal TinhGiaBan()
    {
        return _gia;
    }

    public virtual string MoTa()
    {
        return "Ma SP: " + _maSP +
               ", Ten SP: " + _tenSP +
               ", Gia: " + _gia.ToString("N0") +
               ", So luong ton: " + _soLuongTon;
    }
}

class SanPhamThucPham : SanPham
{
    private DateTime _ngayHetHan;
    private int _nhietDoBAoquan;

    public SanPhamThucPham(
        string maSP,
        string tenSP,
        decimal gia,
        int soLuongTon,
        DateTime ngayHetHan,
        int nhietDoBAoquan)
        : base(maSP, tenSP, gia, soLuongTon)
    {
        _ngayHetHan = ngayHetHan;
        _nhietDoBAoquan = nhietDoBAoquan;
    }

    public DateTime NgayHetHan
    {
        get { return _ngayHetHan; }
        set { _ngayHetHan = value; }
    }

    public int NhietDoBAoquan
    {
        get { return _nhietDoBAoquan; }
        set { _nhietDoBAoquan = value; }
    }

    public override decimal TinhGiaBan()
    {
        TimeSpan khoangCach = _ngayHetHan.Date - DateTime.Now.Date;

        if (khoangCach.TotalDays <= 3 && khoangCach.TotalDays >= 0)
        {
            return Gia * 0.7m;
        }

        return Gia;
    }

    public override string MoTa()
    {
        return "Thuc pham - Ma SP: " + MaSP +
               ", Ten SP: " + TenSP +
               ", Gia ban: " + TinhGiaBan().ToString("N0") +
               ", Han su dung: " + _ngayHetHan.ToString("dd/MM/yyyy") +
               ", Nhiet do bao quan: " + _nhietDoBAoquan + " do C";
    }
}

class SanPhamDienTu : SanPham
{
    private int _baoHanhThang;
    private string _hangSanXuat;

    public SanPhamDienTu(
        string maSP,
        string tenSP,
        decimal gia,
        int soLuongTon,
        int baoHanhThang,
        string hangSanXuat)
        : base(maSP, tenSP, gia, soLuongTon)
    {
        _baoHanhThang = baoHanhThang;
        _hangSanXuat = hangSanXuat;
    }

    public int BaoHanhThang
    {
        get { return _baoHanhThang; }
        set { _baoHanhThang = value; }
    }

    public string HangSanXuat
    {
        get { return _hangSanXuat; }
        set { _hangSanXuat = value; }
    }

    public override decimal TinhGiaBan()
    {
        if (_baoHanhThang > 12)
        {
            return Gia * 1.1m;
        }

        return Gia;
    }

    public override string MoTa()
    {
        return "Dien tu - Ma SP: " + MaSP +
               ", Ten SP: " + TenSP +
               ", Gia ban: " + TinhGiaBan().ToString("N0") +
               ", Bao hanh: " + _baoHanhThang + " thang" +
               ", Hang san xuat: " + _hangSanXuat;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<SanPham> danhSach = new List<SanPham>();

        danhSach.Add(new SanPham(
            "SP001",
            "But bi",
            5000,
            100
        ));

        danhSach.Add(new SanPhamThucPham(
            "TP001",
            "Sua tuoi",
            30000,
            50,
            DateTime.Now.AddDays(2),
            4
        ));

        danhSach.Add(new SanPhamThucPham(
            "TP002",
            "Banh ngot",
            20000,
            30,
            DateTime.Now.AddDays(10),
            5
        ));

        danhSach.Add(new SanPhamDienTu(
            "DT001",
            "Laptop",
            20000000,
            10,
            24,
            "Dell"
        ));

        danhSach.Add(new SanPhamDienTu(
            "DT002",
            "Chuot may tinh",
            500000,
            20,
            12,
            "Logitech"
        ));

        decimal tongGiaTriKho = 0;

        Console.WriteLine("===== DANH SACH SAN PHAM =====");

        foreach (SanPham sp in danhSach)
        {
            Console.WriteLine(sp.MoTa());
            Console.WriteLine("Gia ban: " + sp.TinhGiaBan().ToString("N0") + " VNĐ");
            Console.WriteLine();

            tongGiaTriKho += sp.Gia * sp.SoLuongTon;
        }

        Console.WriteLine("===== TONG GIA TRI KHO =====");
        Console.WriteLine(tongGiaTriKho.ToString("N0") + " VNĐ");

        Console.ReadLine();
    }
}