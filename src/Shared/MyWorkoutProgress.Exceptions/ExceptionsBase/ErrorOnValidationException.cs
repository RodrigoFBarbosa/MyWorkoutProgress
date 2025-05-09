namespace MyWorkoutProgress.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : MyRecipeBookException
{
    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }

    public IList<string> ErrorMessages { get; set; }
}
