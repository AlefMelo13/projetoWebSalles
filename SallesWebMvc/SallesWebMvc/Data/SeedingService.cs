using SallesWebMvc.Models;
using SallesWebMvc.Models.Enums;

namespace SallesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SallesWebMvcContext _context;

        public SeedingService(SallesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SellesRecord.Any())
            {
                return; //Banco de dados já populado
            }

            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Eletronicos");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Livros");

            Seller s1 = new Seller(1, "Alef", "alef@mail.com", new DateTime(1996, 4, 8), 1000, d1);
            Seller s2 = new Seller(1, "Jose", "jose@mail.com", new DateTime(1995, 8, 10), 2000, d1);
            Seller s3 = new Seller(1, "Maria", "maria@mail.com", new DateTime(1998, 5, 25), 3000, d1);
            Seller s4 = new Seller(1, "Karol", "karol@mail.com", new DateTime(1994, 6, 15), 4000, d1);

            SellesRecord sr1 = new SellesRecord(1, new DateTime(2022, 9, 10), 200, SalleStatus.Billed, s1);
            SellesRecord sr2 = new SellesRecord(2, new DateTime(2022, 9, 11), 200, SalleStatus.Billed, s2);
            SellesRecord sr3 = new SellesRecord(3, new DateTime(2022, 9, 12), 200, SalleStatus.Billed, s2);
            SellesRecord sr4 = new SellesRecord(4, new DateTime(2022, 9, 13), 200, SalleStatus.Billed, s2);
            SellesRecord sr5 = new SellesRecord(5, new DateTime(2022, 9, 14), 200, SalleStatus.Billed, s3);
            SellesRecord sr6 = new SellesRecord(6, new DateTime(2022, 9, 14), 200, SalleStatus.Billed, s3);
            SellesRecord sr7 = new SellesRecord(7, new DateTime(2022, 9, 14), 200, SalleStatus.Billed, s3);
            SellesRecord sr8 = new SellesRecord(8, new DateTime(2022, 9, 15), 200, SalleStatus.Billed, s4);
            SellesRecord sr9 = new SellesRecord(9, new DateTime(2022, 9, 15), 200, SalleStatus.Billed, s4);
            SellesRecord sr10 = new SellesRecord(10, new DateTime(2022, 9, 15), 200, SalleStatus.Billed, s4);
            SellesRecord sr11 = new SellesRecord(11, new DateTime(2022, 9, 15), 200, SalleStatus.Billed, s4);
            SellesRecord sr12 = new SellesRecord(12, new DateTime(2022, 9, 16), 200, SalleStatus.Billed, s1);
            SellesRecord sr13 = new SellesRecord(13, new DateTime(2022, 9, 16), 200, SalleStatus.Billed, s1);
            SellesRecord sr14 = new SellesRecord(14, new DateTime(2022, 9, 16), 200, SalleStatus.Billed, s1);
            SellesRecord sr15 = new SellesRecord(15, new DateTime(2022, 9, 16), 200, SalleStatus.Billed, s1);
            SellesRecord sr16 = new SellesRecord(16, new DateTime(2022, 9, 16), 200, SalleStatus.Billed, s1);
            SellesRecord sr17 = new SellesRecord(17, new DateTime(2022, 9, 17), 200, SalleStatus.Billed, s2);
            SellesRecord sr18 = new SellesRecord(18, new DateTime(2022, 9, 17), 200, SalleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4);
            _context.SellesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18);

            _context.SaveChanges();
        }
    }
}
