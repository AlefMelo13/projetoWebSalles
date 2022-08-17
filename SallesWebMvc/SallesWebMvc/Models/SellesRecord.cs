using SallesWebMvc.Models.Enums;

namespace SallesWebMvc.Models
{
    public class SellesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SalleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SellesRecord()
        {
        }

        public SellesRecord(int id, DateTime date, double amount, SalleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
