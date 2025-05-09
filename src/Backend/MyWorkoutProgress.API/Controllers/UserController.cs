using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkoutProgress.Application.UseCases.User.Register;
using MyWorkoutProgress.Communication.Requests;
using MyWorkoutProgress.Communication.Responses;

namespace MyWorkoutProgress.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromServices]IRegisterUserUseCase useCase,
        [FromBody]RequestRegisterUserJson  request)
    {
        var result = await useCase.Execute(request);

        return Created(string.Empty, result);
    }
}
