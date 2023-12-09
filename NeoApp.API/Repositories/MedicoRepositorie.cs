using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;
using NeoApp.API.Repositories.Interfaces;

namespace NeoApp.API.Repositories
{
    public class MedicoRepositorie : IMedicoRepositorie
    {
        private readonly ControleConsultaContext _dbContext;
        
        public MedicoRepositorie(ControleConsultaContext controleConsultaContext)
        {
            _dbContext = controleConsultaContext;
        }
        public async Task<Medico> BuscarPorId(int id)
        {
            return await _dbContext.Medico.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Medico>> BuscarTodosMedicos()
        {
            return await _dbContext.Medico.ToListAsync();
        }
        public async Task<Medico> AdicionarMedico(Medico medico)
        {
            await _dbContext.Medico.AddAsync(medico);
            await _dbContext.SaveChangesAsync();

            return medico ;
        }

        public async Task<Medico> AtualizarMedico(Medico medico, int id)
        {
            Medico medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }
            medicoPorId.NomeMedico = medico.NomeMedico;

            _dbContext.Medico.Update(medicoPorId);
            await _dbContext.SaveChangesAsync();

            return medicoPorId;
        }

        public async Task<bool> DeletarMedico(int id)
        {
            Medico medicoPorId = await BuscarPorId(id);
            if (medicoPorId == null)
            {
                throw new Exception($"Médico para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Medico.Remove(medicoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
