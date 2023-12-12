using NeoApp.API.Models;

namespace NeoApp.API.Repositories.Interfaces
{
    public interface IMedicoRepositorie
    {
        Task<List<Medico>> BuscarTodosMedicos();
        Task<Medico> BuscarPorId(int id);
        Task<Medico> AdicionarMedico(Medico medico);
        Task<Medico> AtualizarMedico(Medico medico, int id);
        Task<bool> DeletarMedico(int id);
        Task<bool> VerificarExistenciaMedico(int medicoId);
    }
}
