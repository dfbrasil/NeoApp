using NeoApp.API.Models;

namespace NeoApp.API.Repositories.Interfaces
{
    public interface IConsultaRepositorie
    {
        Task<List<Consulta>> BuscarTodasConsultas();
        Task<Consulta> BuscarPorId(int id);
        Task<Consulta> AdicionarConsulta(Consulta consulta);
        Task<Consulta> AtualizarConsulta(Consulta consulta, int id);
        Task<bool> DeletarConsulta(int id);
        Task<bool> VerificarExistenciaConsulta(int consultaId);

    }
}
