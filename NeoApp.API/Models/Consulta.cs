﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace NeoApp.API.Models;

public partial class Consulta
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("idPaciente")]
    public int? IdPaciente { get; set; }

    [Column("idMedico")]
    public int? IdMedico { get; set; }

    [Column("dataConsulta", TypeName = "datetime")]
    public DateTime? DataConsulta { get; set; }

    [ForeignKey("IdMedico")]
    [InverseProperty("Consulta")]
    [JsonIgnore]
    public virtual Medico IdMedicoNavigation { get; set; }

    [ForeignKey("IdPaciente")]
    [InverseProperty("Consulta")]
    [JsonIgnore]
    public virtual Paciente IdPacienteNavigation { get; set; }
}