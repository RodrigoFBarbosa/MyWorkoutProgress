using MyWorkoutProgress.Communication.Requests;
using MyWorkoutProgress.Communication.Responses;

namespace MyWorkoutProgress.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
