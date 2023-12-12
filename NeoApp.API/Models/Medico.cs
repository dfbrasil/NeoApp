using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NeoApp.API.Models
{
    public partial class Medico
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public Medico()
        {
            Id = 0;
        }
        [Required(ErrorMessage = "O campo 'Nome do Médico' é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo 'Nome do Médico' não pode ter mais de 50 caracteres.")]
        [Column("nome_medico")]
        [Unicode(false)]
        public string NomeMedico { get; set; }

        [InverseProperty("IdMedicoNavigation")]
        [JsonIgnore]
        public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

        public bool ValidarNome()
        {
            return !string.IsNullOrWhiteSpace(NomeMedico) && NomeMedico.Length > 1;
        }
    }
}
