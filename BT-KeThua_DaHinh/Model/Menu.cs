using BT_KeThua_DaHinh.Service;
using System.Text;

public class Menu
{
    private LichSuGiaoDich lichSuGiaoDich = new LichSuGiaoDich();
    private ThanhToanService thanhToan = new ThanhToanService();

    public void HienThi()
    {
        while (true)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Chọn phương thức thanh toán:");
            Console.WriteLine("1. Thanh toán bằng tiền mặt");
            Console.WriteLine("2. Thanh toán bằng thẻ");
            Console.WriteLine("3. Thanh toán online");
            Console.WriteLine("4. Xem lịch sử giao dịch");
            Console.WriteLine("5. Thoát");

            int luaChon = int.Parse(Console.ReadLine());

            if (luaChon == 5) break;
            double soTien = 0;
            if (luaChon >= 1 && luaChon <= 3)
            {
                Console.Write("Nhập số tiền cần thanh toán: ");
                soTien = double.Parse(Console.ReadLine());
            }

            switch (luaChon)
            {
                case 1:
                    thanhToan.ThanhToan(soTien, "tien mat");
                    lichSuGiaoDich.ThemGiaoDich(new GiaoDich { PhuongThuc = "Tiền mặt", SoTien = soTien, ThoiGian = DateTime.Now });
                    break;
                case 2:
                    thanhToan.ThanhToan(soTien, "the");
                    lichSuGiaoDich.ThemGiaoDich(new GiaoDich { PhuongThuc = "Thẻ", SoTien = soTien, ThoiGian = DateTime.Now });
                    break;
                case 3:
                    thanhToan.ThanhToan(soTien, "online");
                    lichSuGiaoDich.ThemGiaoDich(new GiaoDich { PhuongThuc = "Online", SoTien = soTien, ThoiGian = DateTime.Now });
                    break;
                case 4:
                    lichSuGiaoDich.TaiLichSu();
                    lichSuGiaoDich.XemLichSu();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}
