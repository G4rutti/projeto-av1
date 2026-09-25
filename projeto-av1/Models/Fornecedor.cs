using System.ComponentModel.DataAnnotations;

namespace projeto_av1.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a razão social")]
        [MaxLength(150)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CNPJ")]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ tem 14 números (sem ponto, barra ou traço)")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Informe a cidade")]
        public string Cidade { get; set; } = string.Empty;
    }
}
