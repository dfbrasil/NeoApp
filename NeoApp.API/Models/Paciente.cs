#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NeoApp.API.Models
{
    public partial class Paciente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public Paciente()
        {
            Id = 0; // Ou qualquer valor padrão desejado
        }
        [Column("nome_paciente")]
        [StringLength(50)]
        [Required(ErrorMessage = "O campo NomePaciente é obrigatório.")]
        public string NomePaciente { get; set; }

        [InverseProperty("IdPacienteNavigation")]
        [JsonIgnore]
        public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

        public bool ValidarNome()
        {
            return !string.IsNullOrWhiteSpace(NomePaciente) && NomePaciente.Length > 1;
        }
    }
}
