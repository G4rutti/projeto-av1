using System.ComponentModel.DataAnnotations;

namespace projeto_av1.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe um telefone para contato")]
        public string Telefone { get; set; } = string.Empty;

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Cliente desde")]
        public DateTime DataCadastro { get; set; } = DateTime.Today;
    }
}
