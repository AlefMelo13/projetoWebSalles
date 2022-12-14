using System.ComponentModel.DataAnnotations;

namespace SallesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string? Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public decimal TotalSalles(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSalles(initial, final));
        }
    }
}
