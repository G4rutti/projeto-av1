using System.ComponentModel.DataAnnotations;

namespace projeto_av1.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O produto precisa de um nome")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(300)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Preço tem que ser maior que zero")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Range(0, 100000, ErrorMessage = "Quantidade inválida")]
        [Display(Name = "Qtd. em estoque")]
        public int Estoque { get; set; }

        [Display(Name = "À venda")]
        public bool Ativo { get; set; } = true;
    }
}
