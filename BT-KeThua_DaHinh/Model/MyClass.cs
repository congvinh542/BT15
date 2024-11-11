using System.Text.Json;

public class GiaoDich
{
    public string PhuongThuc { get; set; }
    public double SoTien { get; set; }
    public DateTime ThoiGian { get; set; }
}

public class LichSuGiaoDich
{
    private List<GiaoDich> lichSu = new List<GiaoDich>();

    public void ThemGiaoDich(GiaoDich giaoDich)
    {
        lichSu.Add(giaoDich);
        File.WriteAllText("lichSuGiaoDich.json", JsonSerializer.Serialize(lichSu));
    }

    public void XemLichSu()
    {
        if (lichSu.Count == 0)
        {
            Console.WriteLine("Chưa có giao dịch nào.");
        }
        else
        {
            foreach (var gd in lichSu)
            {
                Console.WriteLine($"{gd.ThoiGian}: {gd.PhuongThuc} - {gd.SoTien} VND");
            }
        }
    }

    public void TaiLichSu()
    {
        var json = File.ReadAllText("lichSuGiaoDich.json");
        lichSu = JsonSerializer.Deserialize<List<GiaoDich>>(json) ?? new List<GiaoDich>();
    }
}
