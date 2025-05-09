using MyWorkoutProgress.Communication.Requests;
using MyWorkoutProgress.Communication.Responses;
using MyWorkoutProgress.Domain.Repositories.User;
using MyWorkoutProgress.Exceptions;
using MyWorkoutProgress.Exceptions.ExceptionsBase;

namespace MyWorkoutProgress.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;

    public RegisterUserUseCase(IUserWriteOnlyRepository writeOnlyRepository, IUserReadOnlyRepository readOnlyRepository)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
    }

    public async Task<ResponseRegisteredUserJson> Execute (RequestRegisterUserJson request)
    {
        await Validate(request);

        // mapping entity request

        // password's cryptography

        // save changes DB

        return new ResponseRegisteredUserJson { Name = request.Name, };
    }

    public async Task Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        var emailExist = await _readOnlyRepository.ExistActiveUserWithEmail(request.Email);

        if (emailExist)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_REGISTERED));
        
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);    
        }
    }
}
