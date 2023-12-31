﻿using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;
using System.Data;

namespace NeoApp.API.Repositories
{
    public class PacienteRepositorie : IPacienteRepositorie
    {
        private readonly ControleConsultaContext _dbContext;
        public PacienteRepositorie(ControleConsultaContext controleConsultaContext) 
        {
            _dbContext = controleConsultaContext;
        }
        public async Task<Paciente> BuscarPorId(int id)
        {
            return await _dbContext.Paciente.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Paciente>> BuscarTodosPacientes()
        {
            return await _dbContext.Paciente.ToListAsync();
        }
        public async Task<Paciente> AdicionarPaciente(Paciente paciente)
        {
            await _dbContext.Paciente.AddAsync(paciente);
            await _dbContext.SaveChangesAsync();

            return paciente;
        }

        public async Task<Paciente> AtualizarPaciente(Paciente paciente, int id)
        {
            Paciente pacientePorId = await BuscarPorId(id);
            if (pacientePorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }
            pacientePorId.NomePaciente = paciente.NomePaciente;

            _dbContext.Paciente.Update(pacientePorId);
            await _dbContext.SaveChangesAsync();

            return pacientePorId;
        }

        public async Task<bool> DeletarPaciente(int id)
        {
            Paciente pacientePorId = await BuscarPorId(id);
            if (pacientePorId == null)
            {
                throw new Exception($"Paciente para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Paciente.Remove(pacientePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Paciente> VerificarCredenciaisPaciente(string userName, string password)
        {
            // Lógica para verificar as credenciais do paciente no banco de dados ou em outro local
            // Retorna true se as credenciais são válidas, false caso contrário
            var paciente = await _dbContext.Paciente
                .Where(x => x.NomePaciente == userName && x.Password == password)
                .FirstOrDefaultAsync();

            return paciente;
        }
    }
}
