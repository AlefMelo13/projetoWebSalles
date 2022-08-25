using System.ComponentModel.DataAnnotations;

namespace SallesWebMvc.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Informe a Marca")]
        public Marca Marca { get; set; }

        [Display(Name = "Unidade")]
        [Required(ErrorMessage = "Informe a Unidade")]
        public string Unidade { get; set; }

        [Display(Name = "Código de Barra")]
        [Required(ErrorMessage = "Informe o Código de Barras")]
        public Int64 CodBarras { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Informe o Preço")]
        public decimal Preco { get; set; }

        public Produto()
        {
        }

        public Produto(int id, string descricao, Marca marca, string unidade, Int64 codBarras, decimal preco)
        {
            Id = id;
            Descricao = descricao;
            Marca = marca;
            Unidade = unidade;
            CodBarras = codBarras;
            Preco = preco;
        }


    }
}
