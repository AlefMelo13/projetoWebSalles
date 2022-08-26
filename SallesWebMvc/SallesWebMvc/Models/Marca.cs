namespace SallesWebMvc.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Marca()
        {
        }

        public Marca(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
