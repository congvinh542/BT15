public interface IThanhToan
{
    void ThanhToan(double soTien);
}

public class ThanhToanService : IThanhToan
{
    IThanhToan _thanhToanService;
    public ThanhToanService(IThanhToan thanhToanService)
    {
        _thanhToanService = thanhToanService;
    }
    public void ThanhToanTienMat(double soTien)
    {
        Console.WriteLine($"Thanh toán bằng tiền mặt số tiền: {soTien}");
    }

    public void ThanhToan(double soTien)
    {
        int maPin = 9999;
        Console.Write("Nhập mã PIN: ");
        int inputPin = int.Parse(Console.ReadLine());

        if (inputPin == maPin)
        {
            Console.WriteLine($"Thanh toán bằng thẻ số tiền: {soTien}");
        }
        else
        {
            Console.WriteLine("Mã PIN không đúng. Giao dịch thất bại.");
        }
    }

    public void ThanhToanOnline(double soTien)
    {
        int otp = 3045;
        Console.Write("Nhập mã OTP: ");
        int inputOtp = int.Parse(Console.ReadLine());

        if (inputOtp == otp)
        {
            Console.WriteLine($"Thanh toán online số tiền: {soTien}");
        }
        else
        {
            Console.WriteLine("Mã OTP không đúng. Giao dịch thất bại.");
        }
    }
}
