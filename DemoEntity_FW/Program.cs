using Microsoft.EntityFrameworkCore;

namespace EF
{

public class Program
{
    static void CreadDatabase()
    {
         using var dbcontext = new productDbContext();
            String dbname = dbcontext.Database.GetDbConnection().Database;
           var kq =  dbcontext.Database.EnsureCreated();
            if(kq)
            {
                Console.WriteLine($"tao csdl {dbname} thanh cong");
            }
            else
            {
                Console.WriteLine($"tao csdl {dbname} khong thanh cong");
            }
        }

    static void insertPro()
        {
            using var dbcontext = new productDbContext();
            var product = new object[]
            {
                new Products(){Name="sp3",Provider="Viet Nam"},
                new Products(){Name="sp4",Provider="Viet Nam"},
                new Products(){Name="sp5",Provider="Viet Nam"},
            };
           
            dbcontext.AddRange(product);
            var number_row = dbcontext.SaveChanges();
            Console.WriteLine($"insert {number_row} data row");
        }

    static void Readpro()
        {
            using var dbcontext = new productDbContext();
            // read products bang linq
            var prs = dbcontext.Product.ToList();
            prs.ForEach(p => p.printInfor());

            // truy van LINQ 
            //var query = from pr in dbcontext.Product
            //            where pr.Provider.Contains("Viet Nam")
            //            orderby pr.ProductId
            //            select pr;
            //query.ToList().ForEach(p => p.printInfor());


        }

    static void updaatePro(int id , string name , string provider)
        {
            using var dbcontext = new productDbContext();
            var query =(from pr in dbcontext.Product
                       where pr.ProductId == id
                       select pr).FirstOrDefault();
            if (query != null)
            {
                query.Name = name;
                query.Provider = provider;
                var number_row = dbcontext.SaveChanges();
                Console.WriteLine($"update {number_row} data row");

            }
            else
            {
                Console.WriteLine("ko cap nhap dc sp");
            }
        }

    static void DeletePro(int id)
        {
            using var dbcontext = new productDbContext();
            var query = (from pr in dbcontext.Product
                         where pr.ProductId == id
                         select pr).FirstOrDefault();
            if (query != null)
            {
               dbcontext.Remove(query);
                var number_row = dbcontext.SaveChanges();
                Console.WriteLine($"delete {number_row} data row");

            }
            else
            {
                Console.WriteLine("khong xoa dc sp");
            }
        }
    private static void Main(string[] args)
    {
            //CreadDatabase();
            //insertPro();
            Readpro();
            //updaatePro(4, "tu lanh", "Nhat Ban");
            //DeletePro(5);
        }
    }
}