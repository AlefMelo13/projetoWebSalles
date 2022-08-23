using SallesWebMvc.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SallesWebMvc.Models
{
    public class SellesRecord
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime Date { get; set; }

        [Display(Name = "Valor da Venda")]
        public decimal Amount { get; set; }
        public SalleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SellesRecord()
        {
        }

        public SellesRecord(int id, DateTime date, decimal amount, SalleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
