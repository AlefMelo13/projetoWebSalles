using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace SallesWebMvc.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Marca")]
        public Marca Marca { get; set; }

        [Display(Name = "Unidade")]
        public string Unidade { get; set; }

        [Display(Name = "Código de Barra")]
        public Int64 CodBarras { get; set; }

        [Display(Name = "Preço")]
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
