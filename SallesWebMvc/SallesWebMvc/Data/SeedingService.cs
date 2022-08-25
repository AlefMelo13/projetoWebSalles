using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SallesWebMvc.Models;
using SallesWebMvc.Models.Enums;

namespace SallesWebMvc.Data
{
    public static class SeedingService
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new SallesWebMvcContext(serviceProvider.GetRequiredService<DbContextOptions<SallesWebMvcContext>>()))
            {

                if (context.Department.Any() || context.Seller.Any() || context.SellesRecord.Any() || context.Marca.Any() || context.Produto.Any())
                {
                    return; //Banco de dados já populado
                }


                Department d1 = new Department(1, "Computadores");
                Department d2 = new Department(2, "Eletronicos");
                Department d3 = new Department(3, "Fashion");
                Department d4 = new Department(4, "Livros");

                Seller s1 = new Seller(1, "Alef", "alef@mail.com", new DateTime(1996, 4, 8), 1000, d1);
                Seller s2 = new Seller(2, "Jose", "jose@mail.com", new DateTime(1995, 8, 10), 2000, d2);
                Seller s3 = new Seller(3, "Maria", "maria@mail.com", new DateTime(1998, 5, 25), 3000, d3);
                Seller s4 = new Seller(4, "Karol", "karol@mail.com", new DateTime(1994, 6, 15), 4000, d4);

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

                Marca m1 = new Marca(1, "Padrão");
                Marca m2 = new Marca(2, "Microsoft");
                Marca m3 = new Marca(3, "Multilaser");
                Marca m4 = new Marca(4, "Lacoste");
                Marca m5 = new Marca(5, "LG");
                Marca m6 = new Marca(6, "Dell");
                Marca m7 = new Marca(7, "Viva");
                Marca m8 = new Marca(8, "Motorola");

                Produto p1 = new Produto(1, "Computador i3", m6, "UN", 789123521, 1399);
                Produto p2 = new Produto(2, "Notebook", m2, "UN", 789123521, 2599);
                Produto p3 = new Produto(3, "Tablet", m5, "UN", 789123521, 399);
                Produto p4 = new Produto(4, "Mouse", m6, "UN", 789123521, 99);
                Produto p5 = new Produto(5, "Celular", m1, "UN", 789123521, 899);
                Produto p6 = new Produto(6, "MotoG", m8, "UN", 789123521, 999);
                Produto p7 = new Produto(7, "Tablet", m8, "UN", 789123521, 599);
                Produto p8 = new Produto(8, "Computador i3", m3, "UN", 789152161, 1799);
                Produto p9 = new Produto(9, "Computador i5", m6, "UN", 789152151, 2199);
                Produto p10 = new Produto(10, "Computador i5", m3, "UN", 782354552, 2399);
                Produto p11 = new Produto(11, "Protetor Solar", m7, "UN", 789114553, 39);
                Produto p12 = new Produto(12, "Perfume", m7, "UN", 789123154, 150);
                Produto p13 = new Produto(13, "Hidratante", m7, "UN", 789314555, 29);
                Produto p14 = new Produto(14, "Creme P/ Mãos", m7, "UN", 789314556, 19);
                Produto p15 = new Produto(15, "Monitor 18''", m3, "UN", 789154557, 599);
                Produto p16 = new Produto(16, "Monitor 19''", m3, "UN", 789154558, 699);
                Produto p17 = new Produto(17, "Monitor 15''", m3, "UN", 789154559, 499);
                Produto p18 = new Produto(18, "Teclado Sem Fio", m6, "UN", 782214560, 99);
                Produto p19 = new Produto(19, "Mouse Sem Fio", m6, "UN", 789154540, 59);
                Produto p20 = new Produto(20, "Kit Teclado e Mouse Sem Fio", m2, "UN", 789154541, 199);
                Produto p21 = new Produto(21, "Mini PC", m6, "UN", 789354542, 2899);
                Produto p22 = new Produto(22, "Creme P/ Pés", m7, "UN", 789122543, 69);
                Produto p23 = new Produto(23, "Computador i3", m6, "UN", 789154542, 1199);
                Produto p24 = new Produto(24, "Moto Edge", m8, "UN", 789123543, 1299);

                context.Marca.AddRange(m1, m2, m3, m4, m5, m6, m7);
                context.Produto.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24);
                context.Department.AddRange(d1, d2, d3, d4);
                context.Seller.AddRange(s1, s2, s3, s4);
                context.SellesRecord.AddRange(sr1, sr2, sr3, sr4, sr5, sr6, sr7, sr8, sr9, sr10, sr11, sr12, sr13, sr14, sr15, sr16, sr17, sr18);

                context.SaveChanges();
            }
        }
    }
}