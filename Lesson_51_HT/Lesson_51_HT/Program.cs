using Lesson_51_HT.Model;
using Lesson_51_HT.Controller;
using Lesson_51_HT.Services;
using System.Linq;

namespace Lesson_51_HT
{
    public partial class Program
    {
        public static void Main(string[] args)
        {

            CustomerController customerController = new();
            ProductController productController = new();
            OrderController orderController = new();

            addDefaultProducts();

            addDefaultCustomers();

            addDefaultOrders();

            // M - With Methods
            // Task #1 Elektronika Kateqoriyasındakı Məhsulları Filtrləyin

            var sorteredProductsWithElectrons = from product in productController.ProductData
                                                where product.CategoryName.Equals(Category.Electronics)
                                                select product;

            //foreach (Product p in sorteredProductsWithElectrons)
            //{
            //    p.ShowInfo();
            //}

            var M_sorteredProductsWithElectrons =
                productController.ProductData.Where(p =>
                p.CategoryName.Equals(Category.Electronics));

            

            //foreach (Product p in M_sorteredProductsWithElectrons)
            //{
            //    p.ShowInfo();
            //}

            // ============================================================ 

            // Task #2 Stokda Olan Məhsulların Qiymət Ümumi Dəyərini Hesablayın.
            // Bütün məhsulların stokdakı ümumi dəyərini (Price × Stock) hesablayın.

            var ProductWholePrices = from p in productController.ProductData
                                     select new
                                     {
                                         ProductID = p.ID,
                                         ProductName = p.Name,
                                         WholePrice = p.Price * p.Quantity
                                     };

            //foreach (var item in ProductWholePrices)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductID}, Name: {item.ProductName}\n" +
            //        $"Whole price: {item.WholePrice}\n" +
            //        $"====================");
            //}

            var M_ProductWholePrices = productController.ProductData.Select(
                p => new {
                    ProductID = p.ID,
                    ProductName = p.Name,
                    WholePrice = p.Price * p.Quantity
                }
            );

            //foreach (var item in M_ProductWholePrices)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductID}, Name: {item.ProductName}\n" +
            //        $"Whole price: {item.WholePrice}\n" +
            //        $"====================");
            //}


            // ============================================================ 

            // Task #3 Müştəri və Onun Sifariş Etdiyi Məhsullar.
            // Müştərinin adını və sifariş etdiyi məhsulun adını qaytaran bir siyahı yaradın.

            var OrderByEmail = from o in orderController.OrdersData
                               where o.Customer.Email.Equals("nigar@mail.ru")
                               select new
                               {
                                   CustomerName = o.Customer.Name,
                                   ProductName = o.Product.Name
                               };

            //foreach (var item in OrderByEmail)
            //{
            //    Console.WriteLine($"Customer: {item.CustomerName}, Email: nigar@mail.ru\n" +
            //        $"Product: {item.ProductName}\n" +
            //        $"====================");
            //}

            var M_OrderByEmail = orderController.OrdersData.Where(o =>
                               o.Customer.Email.Equals("nigar@mail.ru")).Select(
                               o => new
                                {
                                    CustomerName = o.Customer.Name,
                                    ProductName = o.Product.Name
                                }
                                );

            //foreach (var item in M_OrderByEmail)
            //{
            //    Console.WriteLine($"Customer: {item.CustomerName}, Email: nigar@mail.ru\n" +
            //        $"Product: {item.ProductName}\n" +
            //        $"====================");
            //}

            // ============================================================

            // Task #4 Ən Çox Sifariş Edilən Məhsulu Tapın.
            // Ən çox sifariş edilən məhsulun adını və sifariş miqdarını qaytarın.

            var MostSoldProduct =   from p in productController.ProductData
                                    where p.SellCount.Equals(
                                            (from s in productController.ProductData
                                            select s.SellCount).Max())
                                    select new
                                    {
                                        ProductName = p.Name,
                                        SellCount = p.SellCount
                                    };

            //foreach (var item in MostSoldProduct)
            //{
            //    Console.WriteLine($"ProductName: {item.ProductName}\n" +
            //        $"SellCount: {item.SellCount}\n" +
            //        $"====================");
            //}

            var M_MostSoldProduct = productController.ProductData.
                OrderBy(p => p.SellCount). 
                Select(p => new
                {
                    ProductName = p.Name,
                    SellCount = p.SellCount
                }).ToList().
                LastOrDefault();

            //Console.WriteLine($"ProductName: {M_MostSoldProduct.ProductName}\n" +
            //    $"SellCount: {M_MostSoldProduct.SellCount}\n" +
            //    $"====================");

            // ============================================================ 

            // Task #5 Son Bir Həftəlik Sifarişlər.
            // Son bir həftə ərzində verilən bütün sifarişləri qaytarın.

            var LastWeekOrders = from o in orderController.OrdersData
                                 where o.Date >= DateTime.Today.AddDays(-7)
                                 select o;

            //foreach (var item in LastWeekOrders)
            //{
            //    Console.WriteLine($"OrderID: {item.ID}\n" +
            //        $"Date: {item.Date}\n" +
            //        $"====================");
            //}

            var M_LastWeekOrders = orderController.OrdersData.
                Where(o => o.Date >= DateTime.Today.AddDays(-7));

            //foreach (var item in M_LastWeekOrders)
            //{
            //    Console.WriteLine($"OrderID: {item.ID}\n" +
            //        $"Date: {item.Date}\n" +
            //        $"====================");
            //}

            // ============================================================ 


            // Task #6 Stokda Azalan Məhsulları Tapın.
            // Stok miqdarı 5-dən az olan məhsulları tapın.

            var LeftLessFiveQuantity = from p in productController.ProductData
                                       where p.Quantity < 10
                                       select p;

            //foreach (var item in LeftLessFiveQuantity)
            //{
            //    item.ShowInfo();
            //}

            var M_LeftLessFiveQuantity = productController.ProductData.
                                Where(p => p.Quantity < 10);

            //foreach (var item in M_LeftLessFiveQuantity)
            //{
            //    item.ShowInfo();
            //}

            // ============================================================ 

            // Task #7 Məhsulların Kateqoriyalara Görə Qruplanması.
            // Məhsulları kateqoriyalarına görə qruplaşdırın
            // və hər bir qrupda neçə məhsul olduğunu tapın.

            var GroupByCategory = from p in productController.ProductData
                                  group p by p.CategoryName into gp
                                  select new
                                  {
                                      GroupName = gp.Key,
                                      Count = gp.Count()
                                  };

            //foreach (var item in GroupByCategory)
            //{
            //    Console.WriteLine($"Group: {item.GroupName}\n" +
            //        $"Count: {item.Count}\n" +
            //        $"====================");
            //}

            var M_GroupByCategory = productController.ProductData.
                GroupBy(p => p.CategoryName).
                Select(gp => new
                {
                    GroupName = gp.Key,
                    Count = gp.Count()
                }
                );

            //foreach (var item in M_GroupByCategory)
            //{
            //    Console.WriteLine($"Group: {item.GroupName}\n" +
            //        $"Count: {item.Count}\n" +
            //        $"====================");
            //}



            // ============================================================ 


            // Task #8 Müştəri Başına Sifarişlərin Statistikası.
            // Hər bir müştərinin neçə sifariş verdiyini
            // və ümumi sifariş miqdarını qaytarın.

            var CustomerStats = from o in orderController.OrdersData
                                group o by o.Customer into stat
                                select new
                                {
                                    CustomerName = stat.Key.Name,
                                    OrdersCount = (from c in stat
                                                   select c).Count(),
                                    EntireCount = (from c in stat
                                                   select c.Quantity).Sum()
                                };

            //foreach (var item in CustomerStats)
            //{
            //    Console.WriteLine($"Customer: {item.CustomerName}\n" +
            //        $"OrdersCount: {item.OrdersCount}\n" +
            //        $"EntireCount: {item.EntireCount}\n" +
            //        $"====================");
            //}

            var M_CustomerStats = orderController.OrdersData.
                GroupBy(o => o.Customer).
                Select(stat => new
                {
                    CustomerName = stat.Key.Name,
                    OrdersCount = stat.Count(),
                    EntireCount = stat.Select(c => c.Quantity).Sum()
                });

            //foreach (var item in M_CustomerStats)
            //{
            //    Console.WriteLine($"Customer: {item.CustomerName}\n" +
            //        $"OrdersCount: {item.OrdersCount}\n" +
            //        $"EntireCount: {item.EntireCount}\n" +
            //        $"====================");
            //}

            // ============================================================ 


            // Task #9 Ən Bahalı Məhsulu Tapın

            var MostExpensive = from p in productController.ProductData
                                where p.Price.Equals(
                                        (from s in productController.ProductData
                                         select s.Price).Max())
                                select new
                                {
                                    ProductName = p.Name,
                                    Price = p.Price
                                };

            //foreach (var item in MostExpensive)
            //{
            //    Console.WriteLine($"ProductName: {item.ProductName}\n" +
            //        $"SellCount: {item.Price}\n" +
            //        $"====================");
            //}

            var M_MostExpensive = productController.ProductData.
               OrderBy(p => p.Price).
               Select(p => new
               {
                   ProductName = p.Name,
                   Price = p.Price
               }).LastOrDefault();

            //Console.WriteLine($"ProductName: {M_MostExpensive.ProductName}\n" +
            //    $"SellCount: {M_MostExpensive.Price}\n" +
            //    $"====================");


            void addDefaultProducts()
            {
                productController.AddProduct(
                    new Product("MacBook Air M3", 3000, 30, 120, Category.Electronics),
                    new Product("iPhone 15 Pro Max", 1200, 50, 80, Category.Smartphones),
                    new Product("Samsung Galaxy S23 Ultra", 1100, 40, 90, Category.Smartphones),
                    new Product("LG OLED C2 TV", 1800, 25, 60, Category.Electronics),
                    new Product("Sony WH-1000XM5 Headphones", 400, 80, 200, Category.Electronics),
                    new Product("Fitbit Charge 5", 150, 100, 300, Category.ForHealth),
                    new Product("Dyson Air Purifier TP07", 600, 30, 70, Category.ForHealth),
                    new Product("Asus ROG Zephyrus G14", 2200, 20, 40, Category.Electronics),
                    new Product("Dell XPS 13", 1400, 30, 100, Category.Electronics),
                    new Product("Google Pixel 8", 900, 45, 110, Category.Smartphones),
                    new Product("Huawei MatePad Pro", 650, 35, 95, Category.Electronics),
                    new Product("Apple Watch Series 9", 450, 60, 150, Category.ForHealth),
                    new Product("Samsung Galaxy Watch 6", 400, 50, 140, Category.ForHealth),
                    new Product("Philips Avent Baby Monitor", 200, 70, 250, Category.ForBabies),
                    new Product("Graco 4Ever DLX Car Seat", 300, 40, 60, Category.ForBabies),
                    new Product("IKEA Malm Bed Frame", 250, 25, 50, Category.Furniture),
                    new Product("Ashley Furniture Recliner Sofa", 800, 15, 25, Category.Furniture),
                    new Product("Sony PlayStation 5", 500, 10, 15, Category.Electronics),
                    new Product("Xbox Series X", 500, 12, 20, Category.Electronics),
                    new Product("Beats Studio Buds", 150, 90, 180, Category.Electronics),
                    new Product("Nintendo Switch OLED", 350, 30, 45, Category.Electronics),
                    new Product("Garmin Venu 2", 400, 70, 140, Category.ForHealth),
                    new Product("Medela Breast Pump", 300, 50, 120, Category.ForBabies),
                    new Product("Samsung QN90C Smart TV", 2500, 15, 35, Category.Electronics),
                    new Product("HP Pavilion 15 Laptop", 1000, 40, 90, Category.Electronics),
                    new Product("Lenovo ThinkPad X1 Carbon", 1600, 20, 50, Category.Electronics),
                    new Product("Jabra Elite 7 Pro", 200, 60, 130, Category.Electronics),
                    new Product("Eufy RoboVac G30", 300, 40, 100, Category.ForHealth),
                    new Product("Chicco KeyFit Infant Car Seat", 200, 45, 120, Category.ForBabies),
                    new Product("Fisher-Price Baby Jumperoo", 150, 80, 200, Category.ForBabies),
                    new Product("Wayfair L-Shaped Desk", 350, 25, 40, Category.Furniture),
                    new Product("La-Z-Boy Recliner", 900, 10, 20, Category.Furniture),
                    new Product("Dyson Supersonic Hair Dryer", 450, 50, 100, Category.ForHealth),
                    new Product("Canon EOS R50 Camera", 1800, 20, 35, Category.Electronics),
                    new Product("Bose QuietComfort Earbuds", 300, 60, 120, Category.Electronics),
                    new Product("VTech Sit-to-Stand Walker", 50, 100, 300, Category.ForBabies),
                    new Product("Herman Miller Aeron Chair", 1500, 10, 20, Category.Furniture),
                    new Product("Steelcase Leap Chair", 1100, 12, 25, Category.Furniture),
                    new Product("Peloton Bike", 2000, 15, 30, Category.ForHealth),
                    new Product("Samsung Galaxy Tab S9", 800, 25, 75, Category.Electronics),
                    new Product("Microsoft Surface Laptop 5", 1400, 30, 70, Category.Electronics),
                    new Product("Apple AirPods Pro 2", 250, 100, 200, Category.Electronics),
                    new Product("Tommee Tippee Perfect Prep Machine", 130, 80, 250, Category.ForBabies),
                    new Product("Skip Hop Activity Center", 160, 75, 200, Category.ForBabies),
                    new Product("Panasonic Lumix GH6", 2500, 10, 15, Category.Electronics),
                    new Product("Whirlpool Refrigerator", 2000, 5, 10, Category.Furniture),
                    new Product("Philips Hue Starter Kit", 200, 40, 80, Category.Electronics),
                    new Product("Razer Blade 15", 2300, 15, 30, Category.Electronics),
                    new Product("Corsair Gaming Keyboard K95", 200, 60, 150, Category.Electronics),
                    new Product("Tempur-Pedic Mattress", 2000, 10, 15, Category.Furniture),
                    new Product("Logitech MX Master 3S Mouse", 120, 80, 200, Category.Electronics)
                );
            }

            void addDefaultCustomers()
            {
                customerController.AddCustomer(
                        new Customer("Jehun", "Guliev", "jeyhun@mail.ru", "yhbefk$fn",
                            new List<Product>()
                            {
                productController.GetProductByID(10),
                productController.GetProductByID(25),
                productController.GetProductByID(40),
                            }
                                                ),
                        new Customer("Rasim", "Eyvazov", "rasim@mail.ru", "yhbe75hb$fn",
                            new List<Product>()
                            {
                productController.GetProductByID(25),
                productController.GetProductByID(41),
                            }
                        ),
                        new Customer("Leyla", "Aliyeva", "leyla@mail.ru", "lkjsdf82@!",
                            new List<Product>()
                            {
                productController.GetProductByID(5),
                productController.GetProductByID(15),
                productController.GetProductByID(35),
                            }
                        ),
                        new Customer("Emin", "Mammadov", "emin@mail.ru", "abc123!@#",
                            new List<Product>()
                            {
                productController.GetProductByID(7),
                productController.GetProductByID(20),
                productController.GetProductByID(30),
                            }
                        ),
                        new Customer("Aydan", "Huseynova", "aydan@mail.ru", "secure@456",
                            new List<Product>()
                            {
                productController.GetProductByID(12),
                productController.GetProductByID(18),
                productController.GetProductByID(40),
                            }
                        ),
                        new Customer("Orkhan", "Ibrahimov", "orkhan@mail.ru", "password$12",
                            new List<Product>()
                            {
                productController.GetProductByID(9),
                productController.GetProductByID(21),
                productController.GetProductByID(32),
                            }
                        ),
                        new Customer("Nigar", "Kerimova", "nigar@mail.ru", "ng5678%$#",
                            new List<Product>()
                            {
                productController.GetProductByID(3),
                productController.GetProductByID(17),
                productController.GetProductByID(29),
                            }
                        ),
                        new Customer("Vugar", "Aliyev", "vugar@mail.ru", "vgr@2021#",
                            new List<Product>()
                            {
                productController.GetProductByID(1),
                productController.GetProductByID(22),
                productController.GetProductByID(45),
                            }
                        ),
                        new Customer("Aysel", "Safarova", "aysel@mail.ru", "safe1234#",
                            new List<Product>()
                            {
                productController.GetProductByID(4),
                productController.GetProductByID(14),
                productController.GetProductByID(28),
                            }
                        ),
                        new Customer("Elvin", "Rahimov", "elvin@mail.ru", "elvin456$",
                            new List<Product>()
                            {
                productController.GetProductByID(11),
                productController.GetProductByID(23),
                productController.GetProductByID(38),
                            }
                        ),
                        new Customer("Sara", "Mikayilova", "sara@mail.ru", "secure$678",
                            new List<Product>()
                            {
                productController.GetProductByID(2),
                productController.GetProductByID(24),
                productController.GetProductByID(39),
                            }
                        ),
                        new Customer("Kamal", "Hasanov", "kamal@mail.ru", "kamal#2022",
                            new List<Product>()
                            {
                productController.GetProductByID(6),
                productController.GetProductByID(19),
                productController.GetProductByID(44),
                            }
                        ),
                        new Customer("Gulnar", "Salimova", "gulnar@mail.ru", "gulnar!789",
                            new List<Product>()
                            {
                productController.GetProductByID(8),
                productController.GetProductByID(16),
                productController.GetProductByID(33),
                            }
                        ),
                        new Customer("Javid", "Aliyev", "javid@mail.ru", "java@555",
                            new List<Product>()
                            {
                productController.GetProductByID(13),
                productController.GetProductByID(26),
                productController.GetProductByID(41),
                            }
                        ),
                        new Customer("Amina", "Gurbanova", "amina@mail.ru", "amina%345",
                            new List<Product>()
                            {
                productController.GetProductByID(27),
                productController.GetProductByID(36),
                productController.GetProductByID(50),
                            }
                        ),
                        new Customer("Ruslan", "Gasimov", "ruslan@mail.ru", "ruslan@22#",
                            new List<Product>()
                            {
                productController.GetProductByID(31),
                productController.GetProductByID(34),
                productController.GetProductByID(49),
                            }
                        ),
                        new Customer("Fidan", "Abdullayeva", "fidan@mail.ru", "fidan$432",
                            new List<Product>()
                            {
                productController.GetProductByID(28),
                productController.GetProductByID(30),
                productController.GetProductByID(46),
                            }
                        ),
                        new Customer("Kamran", "Ismayilov", "kamran@mail.ru", "kamran&876",
                            new List<Product>()
                            {
                productController.GetProductByID(18),
                productController.GetProductByID(21),
                productController.GetProductByID(42),
                            }
                        ),
                        new Customer("Narmin", "Jafarova", "narmin@mail.ru", "narmin$888",
                            new List<Product>()
                            {
                productController.GetProductByID(15),
                productController.GetProductByID(25),
                productController.GetProductByID(43),
                            }
                        ),
                        new Customer("Farid", "Musayev", "farid@mail.ru", "farid#1234",
                            new List<Product>()
                            {
                productController.GetProductByID(10),
                productController.GetProductByID(20),
                productController.GetProductByID(29),
                            }
                        ),
                        new Customer("Sevda", "Aslanova", "sevda@mail.ru", "sevda$5678",
                            new List<Product>()
                            {
                productController.GetProductByID(19),
                productController.GetProductByID(37),
                productController.GetProductByID(48),
                            }
                        )
                                            );
            }

            void addDefaultOrders()
            {
                orderController.AddOrder
                    (
                        new Order(
                                new DateTime(2023, 12, 25),
                                customerController.GetCustomerByID(1),
                                productController.GetProductByID(10),
                                2
                        ),
                        new Order(
                            new DateTime(2023, 12, 25),
                            customerController.GetCustomerByID(1),
                            productController.GetProductByID(10),
                            2
                        ),
                        new Order(
                            new DateTime(2023, 12, 26),
                            customerController.GetCustomerByID(2),
                            productController.GetProductByID(15),
                            3
                        ),
                        new Order(
                            new DateTime(2023, 12, 27),
                            customerController.GetCustomerByID(3),
                            productController.GetProductByID(25),
                            1
                        ),
                        new Order(
                            new DateTime(2023, 12, 28),
                            customerController.GetCustomerByID(4),
                            productController.GetProductByID(30),
                            4
                        ),
                        new Order(
                            new DateTime(2023, 12, 29),
                            customerController.GetCustomerByID(5),
                            productController.GetProductByID(35),
                            2
                        ),
                        new Order(
                            new DateTime(2023, 12, 30),
                            customerController.GetCustomerByID(6),
                            productController.GetProductByID(40),
                            5
                        ),
                        new Order(
                            new DateTime(2024, 01, 01),
                            customerController.GetCustomerByID(7),
                            productController.GetProductByID(20),
                            1
                        ),
                        new Order(
                            new DateTime(2024, 01, 02),
                            customerController.GetCustomerByID(6),
                            productController.GetProductByID(12),
                            3
                        ),
                        new Order(
                            new DateTime(2024, 01, 03),
                            customerController.GetCustomerByID(9),
                            productController.GetProductByID(45),
                            2
                        ),
                        new Order(
                            new DateTime(2024, 01, 04),
                            customerController.GetCustomerByID(10),
                            productController.GetProductByID(18),
                            4
                        ),
                        new Order(
                            new DateTime(2024, 01, 05),
                            customerController.GetCustomerByID(11),
                            productController.GetProductByID(50),
                            5
                        ),
                        new Order(
                            new DateTime(2024, 01, 06),
                            customerController.GetCustomerByID(12),
                            productController.GetProductByID(14),
                            3
                        ),
                        new Order(
                            new DateTime(2024, 01, 07),
                            customerController.GetCustomerByID(13),
                            productController.GetProductByID(29),
                            1
                        ),
                        new Order(
                            new DateTime(2024, 01, 08),
                            customerController.GetCustomerByID(14),
                            productController.GetProductByID(8),
                            2
                        ),
                        new Order(
                            new DateTime(2024, 01, 09),
                            customerController.GetCustomerByID(15),
                            productController.GetProductByID(38),
                            3
                        ),
                        new Order(
                            new DateTime(2024, 01, 10),
                            customerController.GetCustomerByID(16),
                            productController.GetProductByID(22),
                            4
                        ),
                        new Order(
                            new DateTime(2024, 11, 19),
                            customerController.GetCustomerByID(17),
                            productController.GetProductByID(33),
                            1
                        ),
                        new Order(
                            new DateTime(2024, 11, 20),
                            customerController.GetCustomerByID(18),
                            productController.GetProductByID(26),
                            5
                        ),
                        new Order(
                            new DateTime(2024, 11, 23),
                            customerController.GetCustomerByID(19),
                            productController.GetProductByID(43),
                            2
                        ),
                        new Order(
                            new DateTime(2024, 11, 24),
                            customerController.GetCustomerByID(20),
                            productController.GetProductByID(6),
                            3
                        )

                    );
            }

            Console.ReadLine();
        }
    }
}     



