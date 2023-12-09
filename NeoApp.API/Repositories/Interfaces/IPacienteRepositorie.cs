using NeoApp.API.Models;

namespace NeoApp.API.Repositories.Interfaces
{
    public interface IPacienteRepositorie
    {
        Task<List<Paciente>> BuscarTodosPacientes();
        Task<Paciente> BuscarPorId(int id);
        Task<Paciente> AdicionarPaciente(Paciente paciente);
        Task<Paciente> AtualizarPaciente(Paciente paciente, int id);
        Task<bool> DeletarPaciente(int id);
    }
}
