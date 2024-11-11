public class Menu
{
    private LichSuGiaoDich lichSuGiaoDich = new LichSuGiaoDich();
    private ThanhToanService thanhToanService = new ThanhToanService();

    public void HienThi()
    {
        lichSuGiaoDich.TaiLichSu();

        while (true)
        {
            Console.WriteLine("\nChọn phương thức thanh toán:");
            Console.WriteLine("1. Thanh toán bằng tiền mặt");
            Console.WriteLine("2. Thanh toán bằng thẻ");
            Console.WriteLine("3. Thanh toán online");
            Console.WriteLine("4. Xem lịch sử giao dịch");
            Console.WriteLine("5. Thoát");

            int luaChon = int.Parse(Console.ReadLine());

            Console.Write("Nhập số tiền cần thanh toán: ");
            double soTien = double.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    thanhToanService.ThanhToanTienMat(soTien);
                    lichSuGiaoDich.ThemGiaoDich(new GiaoDich { PhuongThuc = "Tiền mặt", SoTien = soTien, ThoiGian = DateTime.Now });
                    break;
                case 2:
                    if (thanhToanService.ThanhToanTheNganHang(soTien))
                    {
                        lichSuGiaoDich.ThemGiaoDich(new GiaoDich { PhuongThuc = "Thẻ", SoTien = soTien, ThoiGian = DateTime.Now });
                    }
                    break;
                case 3:
                    if (thanhToanService.ThanhToanOnline(soTien))
                    {
                        lichSuGiaoDich.ThemGiaoDich(new GiaoDich { PhuongThuc = "Online", SoTien = soTien, ThoiGian = DateTime.Now });
                    }
                    break;
                case 4:
                    lichSuGiaoDich.XemLichSu();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}
