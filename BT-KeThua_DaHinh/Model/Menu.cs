using BT_KeThua_DaHinh.Service;
using System.Text;

public class Menu
{
    private ProductService productService = new ProductService();
    private ThanhToanService thanhToan = new ThanhToanService();
    public void HienThi()
    {
        while (true)
        {
            productService.LoadFile();
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Chọn bài tập:\n1. Thanh toán.\n2. Quản lý bán hàng.");
            int chon = int.Parse(Console.ReadLine());
            if(chon == 1)
            {
               while(true)
                {
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
                            thanhToan.Create( "Tiền mặt",soTien);
                            break;
                        case 2:
                            thanhToan.ThanhToan(soTien, "the");
                            thanhToan.Create("Thẻ", soTien);
                            break;
                        case 3:
                            thanhToan.ThanhToan(soTien, "online");
                            thanhToan.Create("Thanh toán online", soTien);
                            break;
                        case 4:
                            thanhToan.XemLichSu();
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ.");
                            break;
                    }
                }
            }else if(chon == 2)
            {
                while(true)
                {
                    Console.WriteLine("Chọn chức năng:");
                    Console.WriteLine("1. Thêm sản phẩm vào danh sách.");
                    Console.WriteLine("2. Hiển thị danh sách sản phẩm.");
                    Console.WriteLine("3. Tính tổng doanh thu dự kiến.");
                    Console.WriteLine("4. Xóa sản phẩm khỏi danh sách theo mã.");
                    Console.WriteLine("5. Thoát");
                int luaChon = int.Parse(Console.ReadLine());

                if (luaChon == 5) break;

                switch (luaChon)
                {
                    case 1:
                            productService.Create();
                        break;
                    case 2:
                            productService.HienThiThongTin();
                        break;
                    case 3:
                            productService.TongDoanhThuDuKien();
                        break;
                    case 4:
                            productService.DeleteProduct();
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
                }
            }
        }
    }
}
