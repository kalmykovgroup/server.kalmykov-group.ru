using Google.Protobuf;
using KalmykovGroup.Core;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace KalmykovGroup.Persistence
{
    public class AppDbContext : DbContext
    { 
         

        public DbSet<Product> Products { get; set; }
        public DbSet<Img> Images { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
       /*     Database.EnsureDeleted();
            Database.EnsureCreated();*/
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

          
            modelBuilder.Entity<Unit>().HasIndex(unit => new { unit.Name }).IsUnique();    
            modelBuilder.Entity<Product>().HasIndex(product => new { product.RatingId }).IsUnique();


          /*  modelBuilder.Entity<Unit>().HasData(GetUnitsDefault());

            modelBuilder.Entity<Category>().HasData(GetCategoriesDefault());

            modelBuilder.Entity<Rating>().HasData(GetRatingsDefault());

            modelBuilder.Entity<Img>().HasData(GetImagesDefault());

            modelBuilder.Entity<Product>().HasData(GetProductsDefault());*/


        }



        private Img[] GetImagesDefault()
        {
            List<Img> images = new List<Img>();

            string[] dataSrc = [
                "https://ir.ozone.ru/s3/multimedia-1-h/wc1000/7115866577.jpg",
                "https://ir.ozone.ru/s3/multimedia-z/wc1000/6716608991.jpg",
                "https://ir.ozone.ru/s3/multimedia-c/wc1000/6268098600.jpg",
                "https://ir.ozone.ru/s3/multimedia-v/wc1000/6649160107.jpg",
                "https://ir.ozone.ru/s3/multimedia-5/wc1000/6756650573.jpg",
                "https://ir.ozone.ru/s3/multimedia-1-z/wc1000/7127315747.jpg",
                "https://ir.ozone.ru/s3/multimedia-1/wc1000/6835729753.jpg",
                "https://ir.ozone.ru/s3/multimedia-6/wc1000/6794680758.jpg",
                "https://ir.ozone.ru/s3/multimedia-a/wc1000/6662389546.jpg",
                "https://ir.ozone.ru/s3/multimedia-2/wc1000/6662389646.jpg",
                "https://ir-4.ozone.ru/s3/multimedia-1-8/wc1000/7138588364.jpg",
                "https://ir-4.ozone.ru/s3/multimedia-1-v/wc1000/7100773339.jpg",
                "https://ir-4.ozone.ru/s3/multimedia-o/wc1000/6863018712.jpg",
                "https://ir.ozone.ru/s3/multimedia-f/wc1000/6893300895.jpg",
                "https://ir-4.ozone.ru/s3/multimedia-k/wc1000/6726355724.jpg",
                "https://ir.ozone.ru/s3/multimedia-s/wc1000/6493565752.jpg",
                "https://ir-4.ozone.ru/s3/multimedia-f/wc1000/6468410883.jpg",
                "https://ir.ozone.ru/s3/multimedia-1-u/wc1000/6997928934.jpg",
                "https://ir.ozone.ru/s3/multimedia-v/wc1000/6361889779.jpg",
                "https://ir.ozone.ru/s3/multimedia-1-j/wc1000/6999485815.jpg",
                "https://ir.ozone.ru/s3/multimedia-1-0/wc1000/6933023064.jpg",
                "https://ir-4.ozone.ru/s3/multimedia-r/wc1000/6681975291.jpg",
            ];


            for(int i = 0; i < 22; ++i)
            {
                string guid = Guid.NewGuid().ToString().ToLower();

                Img img = new Img()
                {
                    Id = i + 1,
                    Src = $"/source/products/{i + 1}/{guid}".ToLower(),
                    Name = "150x150",
                    Extension = ".webp",
                    Size = Size._150x150 
                };

                images.Add(img);
                 
                string productPath = $"./Source/Img/Products/{img.Id}";
                string productImg = $"./Source/Img/Products/{img.Id}/{guid}/{img.Name}{img.Extension}";
                 

                if (System.IO.Directory.Exists(productPath))
                {
                    Directory.Delete(productPath, true);
                    Directory.CreateDirectory($"{productPath}/{guid}");
                }
                else
                {
                    Directory.CreateDirectory($"{productPath}/{guid}");
                }

                string newPath = $"{productPath}/{guid}/{img.Name}{img.Extension}";

                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(dataSrc[i], newPath);
                    }
                }
                catch (Exception ex) {
                    
                
                }
               

    
            }

            return images.ToArray();
        }

        private Unit[] GetUnitsDefault()
        {
            return [
                    new Unit(){
                        Id = 1,
                        Name = "Шт."
                    }, 
                ];
        }
        private Category[] GetCategoriesDefault()
        {

            List<string> categoryNames = new List<string>()
            {
               "Родительская категория",
               "Строительство и ремонт",
               "Дом",
               "Дача и сад",
               "Электроника"
            };

            List<Category> categories = new List<Category>();

                for(int i = 0; i < categoryNames.Count; ++i)
                {
                    categories.Add(new Category() {
                        Id = i + 1,
                        ParentId = 1,
                        Name = categoryNames[i]

                    });
                }

            return categories.ToArray();
        }
        private Product[] GetProductsDefault()
        {
            List<(int price, int oldPrice, string name)> data =  new List<(int price, int oldPrice, string name)>()
            {
                (price: 200, oldPrice: 560, name: "Пассатижи"),
                (price: 479300, oldPrice: 480400, name: "Набор профессиональных отверток и бит DEKO SS100 с удобной подставкой (100 предметов)"),
                (price: 1600, oldPrice: 6700, name: "Набор слесарного инстр-та в чем. 72пр. Волат (1/4\", 1/2\", 6 граней) (18530-72) (18530-72)"),
                (price: 1600, oldPrice: 6700, name: "Дрель-шуруповерт с набором инструмента TOTAL THKTHP11282 (с 1-им АКБ, кейс, 128 предметов)"),
                (price: 500, oldPrice: 2200, name: "Клещи (пресс-клещи) для обжима наконечников электропроводов с сечением 0.25-8 мм2 Gross"),
                (price: 116268, oldPrice: 220268, name: "Смартфон Samsung Galaxy Z Fold6 12/256 ГБ, Dual: nano SIM + eSIM, серебристый"),
                (price: 10400, oldPrice: 18900, name: "Перфоратор SDS+ 2.7Дж - 780Вт Makita HR2470"),
                (price: 205, oldPrice: 590, name: "Комбинированные плоскогубцы Gigant 180 мм GCP 180"),
                (price: 320, oldPrice: 730, name: "Диэлектрические пассатижи SHTOK 1000В 180 мм"),
                (price: 350, oldPrice: 420, name: "Мини пассатижи SHTOK 120 мм"),
                (price: 900, oldPrice: 1200, name: "Никелированные пассатижи Inforce 200мм"),
                (price: 2100, oldPrice: 2450, name: "Комплект насадок с ключом-трещоткой (26 предметов) Bosch"),
                (price: 26500, oldPrice: 28300, name: "Набор торцевых головок SAE 3/4"),
                (price: 6950, oldPrice: 6200, name: "Набор инструментов STARTUL 1/4 , 1/2 6 граней 108 предметов PRO Stuttgart PRO-108S"),
                (price: 75550, oldPrice: 79630, name: "Набор трещоток 8100 SC 2 Zyklop 1/2 Wera WE-003645"),
                (price: 25800, oldPrice: 28300, name: "Раскладной ящик с инструментами для механиков IZELTAS металлический, 63 предмета, 190х420х200"),
                (price: 10700, oldPrice: 10800, name: "Перфоратор Ресанта П-32-1400КВ 75/3/6"),
                (price: 15650, oldPrice: 16200, name: "Набор двенадцатигранных торцевых головок IZELTAS 24 предмета 1114006024"),
                (price: 29900, oldPrice: 33900, name: "Бесщеточная дрель-шуруповерт Dewalt 18.0 В XR DCD7771D2"),
                (price: 10900, oldPrice: 16900, name: "Аккумуляторная дрель-шуруповерт Makita DF333DWYE"),
                (price: 15650, oldPrice: 16200, name: "Аккумуляторная дрель-шуруповерт Makita LXT DDF453RFE"),
                (price: 19650, oldPrice: 55200, name: "Дрель Makita DF0300"),
            };

            List<Product> products = new List<Product>();

            for(int i = 0; i < 22; ++i)
            {
                (int price, int oldPrice, string name) = data[i];

                products.Add(new Product()
                {
                    Id = i + 1,
                    RatingId = i + 1,
                    CategoryId = 1,
                    UnitId = 1,
                    ImgId = i + 1,
                    Name = name,
                    Price = price,
                    OldPrice = oldPrice,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            }


            return products.ToArray();
        }

        private Rating[] GetRatingsDefault()
        {
            Random rand = new Random();

            Product[] products  = GetProductsDefault();

            List <Rating> ratings = new List<Rating>(); 

            for(int i = 0; i < products.Length; ++i)
            {
                ratings.Add(new Rating()
                {
                    Id = i + 1,
                    NumberOfReviews = (int)(rand.NextInt64() % 100),
                    Value = Math.Max(Math.Round((rand.NextDouble() * 10 % 5), 1), 1)
                });
            } 
             
            return ratings.ToArray();
        }

    }
}
