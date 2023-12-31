﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json; // Importe esta namespace


namespace NeoApp.API.Models;

public partial class Paciente
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome_paciente")]
    [StringLength(50)]
    [Unicode(false)]
    public string NomePaciente { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [InverseProperty("IdPacienteNavigation")]
    [JsonIgnore]
    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}