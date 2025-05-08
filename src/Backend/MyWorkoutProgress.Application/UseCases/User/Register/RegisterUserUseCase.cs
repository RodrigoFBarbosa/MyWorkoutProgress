using MyWorkoutProgress.Communication.Requests;
using MyWorkoutProgress.Communication.Responses;

namespace MyWorkoutProgress.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute (RequestRegisterUserJson request)
    {
        // validate request

        // mapping entity request

        // password's cryptography

        // save changes DB

        return new ResponseRegisteredUserJson { Name = request.Name, };
    }
}
