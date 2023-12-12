
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class CustomOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
        {
            if (controllerActionDescriptor.ControllerName.Contains("Consulta"))
            {
                if (controllerActionDescriptor.ActionName.Contains("BuscaTodasConsultas"))
                {
                    operation.Summary = "Obtém todas as consultas";
                    operation.Description = "Esta operação retorna todas as consultas disponíveis.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("BuscarPorId"))
                {
                    operation.Summary = "Obtém uma consulta por ID";
                    operation.Description = "Esta operação retorna uma consulta específica com base no ID fornecido.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("AdicionarConsulta"))
                {
                    operation.Summary = "Adiciona uma nova consulta";
                    operation.Description = "Esta operação adiciona uma nova consulta.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("AtualizarConsulta"))
                {
                    operation.Summary = "Atualiza uma consulta existente";
                    operation.Description = "Esta operação atualiza uma consulta existente.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("DeletarConsulta"))
                {
                    operation.Summary = "Deleta uma consulta existente";
                    operation.Description = "Esta operação deleta uma consulta existente.";
                }
            }
            else if (controllerActionDescriptor.ControllerName.Contains("Medico"))
            {
                if (controllerActionDescriptor.ActionName.Contains("BuscarTodosMedicos"))
                {
                    operation.Summary = "Obtém todos os médicos";
                    operation.Description = "Esta operação retorna todos os médicos disponíveis.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("BuscarPorId"))
                {
                    operation.Summary = "Obtém um médico por ID";
                    operation.Description = "Esta operação retorna um médico específico com base no ID fornecido.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Cadastrar"))
                {
                    operation.Summary = "Cadastra um novo médico";
                    operation.Description = "Esta operação cadastra um novo médico.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Atualizar"))
                {
                    operation.Summary = "Atualiza um médico existente";
                    operation.Description = "Esta operação atualiza um médico existente.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Apagar"))
                {
                    operation.Summary = "Apaga um médico existente";
                    operation.Description = "Esta operação apaga um médico existente.";
                }
            }
            else if (controllerActionDescriptor.ControllerName.Contains("Paciente"))
            {
                if (controllerActionDescriptor.ActionName.Contains("BuscaTodosPacientes"))
                {
                    operation.Summary = "Obtém todos os pacientes";
                    operation.Description = "Esta operação retorna todos os pacientes disponíveis.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("BuscarPorId"))
                {
                    operation.Summary = "Obtém um paciente por ID";
                    operation.Description = "Esta operação retorna um paciente específico com base no ID fornecido.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Cadastrar"))
                {
                    operation.Summary = "Cadastra um novo paciente";
                    operation.Description = "Esta operação cadastra um novo paciente.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Atualizar"))
                {
                    operation.Summary = "Atualiza um paciente existente";
                    operation.Description = "Esta operação atualiza um paciente existente.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Apagar"))
                {
                    operation.Summary = "Apaga um paciente existente";
                    operation.Description = "Esta operação apaga um paciente existente.";
                }
                else if (controllerActionDescriptor.ActionName.Contains("Auth"))
                {
                    operation.Summary = "Autenticação de usuário";
                    operation.Description = "Esta operação autentica um usuário com base no nome de usuário, senha e tipo de usuário fornecidos. Retorna um token de acesso se a autenticação for bem-sucedida.";
                }
            }
        }
    }
}
