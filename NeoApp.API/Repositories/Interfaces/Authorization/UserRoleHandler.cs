using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NeoApp.API.Authorization
{
    public class UserRoleHandler : AuthorizationHandler<UserRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRoleRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                var role = context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value;

                // Adicionar lógica para verificar as permissões com base no papel (role) do usuário
                // Exemplo: Verificar se o usuário é "Paciente" ou "Medico"

                if (role == "Paciente" || role == "Medico")
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
