namespace SallesWebMvc.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Marca> Marcas { get; set; }
    }
}
