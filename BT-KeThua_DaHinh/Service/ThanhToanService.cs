using BT_KeThua_DaHinh.Service;
using System.Diagnostics;


public class ThanhToanService : IThanhToan
{
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
}
