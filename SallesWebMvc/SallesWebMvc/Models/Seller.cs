namespace SallesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department? Department { get; set; }
        public ICollection<SellesRecord> Salles { get; set; } = new List<SellesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSalles(SellesRecord sallesRecord)
        {
            Salles.Add(sallesRecord);
        }

        public void RemoveSalles(SellesRecord sallesRecord)
        {
            Salles.Remove(sallesRecord);
        }

        public double TotalSalles(DateTime initial, DateTime final)
        {
            return Salles.Where(sallesRecord => sallesRecord.Date >= initial && sallesRecord.Date <= final).Sum(sallesRecord => sallesRecord.Amount);
        }
    }
}
