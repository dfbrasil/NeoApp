#nullable disable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NeoApp.API.Models
{
    public partial class Paciente : IValidatableObject
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        [Column("nome_paciente")]
        [StringLength(50)]
        [Unicode(false)]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; }

        [InverseProperty("IdPacienteNavigation")]
        [JsonIgnore]
        public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Adicione validações personalizadas aqui
            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult("A senha do paciente é obrigatória.", new[] { nameof(Password) });
            }
        }
    }
}
