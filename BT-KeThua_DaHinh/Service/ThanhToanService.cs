using BT_KeThua_DaHinh.Service;
using System.Diagnostics;


public class ThanhToanService : IThanhToan
{
    List<GiaoDich> lichSu = new List<GiaoDich>();
    public void ThanhToan(double soTien, string phuongThuc)
    {

        switch (phuongThuc.Trim().ToLower()){
            case "tien mat":
                {
                    Console.WriteLine($"Thanh toán thành công bằng tiền mặt số tiền: {soTien}Vnđ");
                }
                break;
            case "the":
                {
                    int maPin = 9999;
                    Console.Write("Nhập mã PIN: ");
                    int inputPin = int.Parse(Console.ReadLine());

                    if (inputPin == maPin)
                    {
                        Console.WriteLine($"Thanh toán thành công bằng thẻ số tiền: {soTien}Vnđ");
                    }
                    else
                    {
                        Console.WriteLine("Mã PIN không đúng. Giao dịch thất bại.");
                    }
                }
                break;
            case "online":
                {
                    int otp = 1234;
                    Console.Write("Nhập mã OTP: ");
                    int inputOtp = int.Parse(Console.ReadLine());

                    if (inputOtp == otp)
                    {
                        Console.WriteLine($"Thanh toán online thành công bằng số tiền: {soTien}Vnđ");
                    }
                    else
                    {
                        Console.WriteLine("Mã OTP không đúng. Giao dịch thất bại.");
                    }
                }
                break;
            default:
                break;
        }
    }


    public void Create(string phuongThuc, double soTien)
    {
        var giaoDich = new GiaoDich
        {
            PhuongThuc = phuongThuc,
            SoTien = soTien,
            ThoiGian = DateTime.Now
        };
        lichSu.Add(giaoDich);
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
                Console.WriteLine(@$"
                Lịch sử các giao dịch của bạn:
                Thời gian: {gd.ThoiGian},
                Bằng phương thức: {gd.PhuongThuc},
                Số tiền bạn giao dịch: {gd.SoTien} VND

                ");
            }
        }
    }
}
