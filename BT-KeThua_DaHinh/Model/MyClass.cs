using System.Text;
using System.Text.Json;

public class GiaoDich
{
    public static int Id { get; set; } = 1;
    public string? PhuongThuc { get; set; }
    public double SoTien { get; set; }
    public DateTime? ThoiGian { get; set; }

    public void SetID()
    {
        Id++;
    }
}


public class Product {
    public static int Id { get; set; } = 1;
    public string? MaSanPham { get; set; }
    public string? TenSanPham { get; set; }
    public double GiaGoc { get; set; }

    public void SetID()
    {
        Id++;
    }

    public virtual void HienThiThongTin(Double input)
    {
        Console.WriteLine(@$"
        Mã sản phẩm: {MaSanPham},   
        Tên sản phẩm: {TenSanPham}, 
        Giá gốc: {GiaGoc},
        Giá bán: {GiaGoc * input}");
    }
}

