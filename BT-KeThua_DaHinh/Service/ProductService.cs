using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BT_KeThua_DaHinh.Service
{
    public class ProductService : IProductService
    {

        List<GiaoDich> lichSu = new List<GiaoDich>();
        List<Product> products = new List<Product>();

        public void TinhGia(double giaBan,string category)
        {
            Product product = new Product();
            Console.OutputEncoding = Encoding.UTF8;
            switch (category.Trim().ToLower())
            {
                case "dien tu":
                    {
                        Console.WriteLine("Mời bạn nhập vào % thuế bảo hành");
                        double thue = double.Parse(Console.ReadLine()) / 100;
                        product.HienThiThongTin(thue);
                    }
                    break;
                case "thoi trang":
                    {
                        Console.WriteLine("Mời bạn nhập vào % gía giảm theo mùa");
                        double thue = double.Parse(Console.ReadLine()) / 100;
                        product.HienThiThongTin(thue);
                    }
                    break;
                case "thuc pham":
                    {
                        Console.WriteLine("Mời bạn nhập vào phí vận chuyển");
                        double thue = double.Parse(Console.ReadLine()) / 100;
                        product.HienThiThongTin(thue);
                    }
                    break;
                default:
                    break;
            }
        }
        public void Create()
        {
            var product = new Product();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Mời bạn nhập mã sản phẩm: ");
            product.MaSanPham = Console.ReadLine();
            Console.WriteLine("Mời bạn nhập tên sản phẩm: ");
            product.TenSanPham = Console.ReadLine();
            Console.WriteLine("Mời bạn nhập giá góc sản phẩm: ");
            product.GiaGoc = double.Parse(Console.ReadLine());

            if(product != null)
            {
                products = new List<Product>();
            }
            products.Add(product);
            SaveFile();
        }

        public void DeleteProduct()
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Mời bạn nhập mã sản phẩm cần xóa: ");
            var code = Console.ReadLine();
            var listSP = this.products.FirstOrDefault(p => p.MaSanPham?.Trim().ToLower() == code);
            if (listSP != null)
            {
                products.Remove(listSP);
                Console.WriteLine($"Xóa thành công sản phẩm có mã: {code}");
                SaveFile();
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sản phẩm có mã: {code}");
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

        public void TongDoanhThuDuKien()
        {
            var result = 0;
            foreach(var pd in products)
            {

            }
        }

        public void SaveFile()
        {
            string directoryPath = "./Json";
            string filePathGD = $"{directoryPath}/lichSuGiaoDich.json";
            string filePathSP = $"{directoryPath}/product.json";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string lichSuGiaoDich = JsonSerializer.Serialize(this.lichSu);
            string products = JsonSerializer.Serialize(this.products);


            File.WriteAllText(filePathGD, lichSuGiaoDich);
            File.WriteAllText(filePathSP, products);
        }

        public void LoadFile()
        {
            var giaoDich = File.ReadAllText("./Json/lichSuGiaoDich.json");
            var product = File.ReadAllText("./Json/product.json");

            this.lichSu = JsonSerializer.Deserialize<List<GiaoDich>>(giaoDich);
            this.products = JsonSerializer.Deserialize<List<Product>>(product);
        }
    }
}
