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

        List<Product> products = new List<Product>();
        List<GiaoDich> lichSu = new List<GiaoDich>();

        public void TinhGia(double giaGoc,double thue, int category, string code)
        {
            var product = products.FirstOrDefault(p => p.MaSanPham == code);

            if (category == 1)
            {
                product.GiaBan = giaGoc + (giaGoc * thue);
            }else if (category == 2)
            {
                product.GiaBan = giaGoc + (giaGoc - thue);
            }else if(category == 3)
            {
                product.GiaBan = giaGoc + thue;
            }
        }
        public void Create()
        {
            var product = new Product();

            Console.WriteLine("Mời bạn chọn loại sản phẩm: ");
            Console.WriteLine("1. Điện tử\n2. Thời trang\n3. Thực phẩm");
            int opption = int.Parse(Console.ReadLine());
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Mời bạn nhập mã sản phẩm: ");
            product.MaSanPham = Console.ReadLine();
            Console.WriteLine("Mời bạn nhập tên sản phẩm: ");
            product.TenSanPham = Console.ReadLine();
            Console.WriteLine("Mời bạn nhập giá gốc sản phẩm: ");
            product.GiaGoc = double.Parse(Console.ReadLine());
            if (product != null)
            {
                products = new List<Product>();
            }
            products.Add(product);
            switch (opption)
            {
                case 1:
                    {
                        Console.WriteLine("Mời bạn nhập vào % thuế bảo hành");
                        double thue = double.Parse(Console.ReadLine()) / 100;
                        TinhGia(product.GiaGoc, thue, 1, product.MaSanPham);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Mời bạn nhập vào % gía giảm theo mùa");
                        double thue = double.Parse(Console.ReadLine()) / 100;
                        TinhGia(product.GiaGoc, thue, 2, product.MaSanPham);
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Mời bạn nhập vào phí vận chuyển");
                        double thue = double.Parse(Console.ReadLine()) / 100;
                        TinhGia(product.GiaGoc, thue, 3, product.MaSanPham);
                    }
                    break;
                default:
                    break;
            }
            SaveFile();
        }

        public virtual void HienThiThongTin()
        {
            foreach(var product in products)
            {
                Console.WriteLine(@$"
                Mã sản phẩm: {product.MaSanPham},   
                Tên sản phẩm: {product.TenSanPham}, 
                Giá gốc: {product.GiaGoc},
                Giá bán: {product.GiaBan}");
            }
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

        public void TongDoanhThuDuKien()
        {
            double result = 0;
            foreach(var pd in products)
            {
                result += pd.GiaBan;
            }
            Console.WriteLine($"Tổng doanh thu dự kiến là {result}");
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
