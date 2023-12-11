#nullable disable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NeoApp.API.Models
{
    public partial class Medico : IValidatableObject
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do médico é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do médico não pode ter mais de 50 caracteres.")]
        [Unicode(false)]
        [Column("nome_medico")]
        public string NomeMedico { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 255 caracteres.")]
        [Column("password")]
        public string Password { get; set; }

        [InverseProperty("IdMedicoNavigation")]
        [JsonIgnore]
        public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Adicione validações personalizadas aqui, se necessário
            return new List<ValidationResult>();
        }
    }
}
