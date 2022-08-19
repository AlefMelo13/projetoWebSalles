using System.ComponentModel.DataAnnotations;

namespace SallesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Tamanho deve ser entre {2} e {1}")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o E-mail")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Informe a Data de Nascimento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Salário Base")]
        [Required(ErrorMessage = "Informe o Salário Base")]
        public decimal BaseSalary { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SellesRecord> Salles { get; set; } = new List<SellesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, decimal baseSalary, Department department)
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

        public decimal TotalSalles(DateTime initial, DateTime final)
        {
            return Salles.Where(sallesRecord => sallesRecord.Date >= initial && sallesRecord.Date <= final).Sum(sallesRecord => sallesRecord.Amount);
        }
    }
}
