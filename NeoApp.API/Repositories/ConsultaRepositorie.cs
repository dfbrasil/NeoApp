using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Repositories
{
    public class ConsultaRepositorie : IConsultaRepositorie
    {
        private readonly ControleConsultaContext _dbContext;
        public ConsultaRepositorie(ControleConsultaContext controleConsultaContext)
        {
            _dbContext = controleConsultaContext;
        }
        public async Task<Consulta> BuscarPorId(int id)
        {
            return await _dbContext.Consulta
                .Include(x => x.IdMedicoNavigation)
                .Include(x => x.IdPacienteNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Consulta>> BuscarTodasConsultas()
        {
            return await _dbContext.Consulta
                .Include(x => x.IdMedicoNavigation)
                .Include(x => x.IdPacienteNavigation)
                .ToListAsync();
        }
        public async Task<Consulta> AdicionarConsulta(Consulta consulta)
        {
            await _dbContext.Consulta.AddAsync(consulta);
            await _dbContext.SaveChangesAsync();

            return consulta;
        }

        public async Task<Consulta> AtualizarConsulta(Consulta consulta, int id)
        {
            Consulta consultaPorId = await BuscarPorId(id);
            if (consultaPorId == null)
            {
                throw new Exception($"Consulta para o ID: {id} não foi encontrado no banco de dados.");
            }
            consultaPorId.DataConsulta = consulta.DataConsulta;
            consultaPorId.IdPaciente = consulta.IdPaciente;
            consultaPorId.IdMedico = consulta.IdMedico;

            _dbContext.Consulta.Update(consultaPorId);
            await _dbContext.SaveChangesAsync();

            return consultaPorId;
        }

        public async Task<bool> DeletarConsulta(int id)
        {
            Consulta consultaPorId = await BuscarPorId(id);
            if (consultaPorId == null)
            {
                throw new Exception($"Consulta para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Consulta.Remove(consultaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

       
    }
}
