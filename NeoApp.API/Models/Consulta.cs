#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NeoApp.API.Models
{
    public partial class Consulta : IValidatableObject
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O paciente é obrigatório.")]
        [Column("idPaciente")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "O médico é obrigatório.")]
        [Column("idMedico")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "A data da consulta é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de data inválido.")]
        public DateTime? DataConsulta { get; set; }

        [ForeignKey("IdMedico")]
        [InverseProperty("Consulta")]
        [JsonIgnore]
        public virtual Medico IdMedicoNavigation { get; set; }

        [ForeignKey("IdPaciente")]
        [InverseProperty("Consulta")]
        [JsonIgnore]
        public virtual Paciente IdPacienteNavigation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Adicione validações personalizadas aqui
            if (DataConsulta.HasValue && DataConsulta < DateTime.Now)
            {
                yield return new ValidationResult("A data da consulta deve ser no futuro.", new[] { nameof(DataConsulta) });
            }
        }
    }
}
