
namespace QuizBattle.Domain;

public  class Question
{
    public Question(Choice[] choices, string correctAnswerCode)
    {
        Choices = choices.ToList();
        CorrectAnswerCode = correctAnswerCode;
        EnsureValid();
    }

    public List<Choice> Choices { get; }
    public string CorrectAnswerCode { get; }

    private void EnsureValid()
    {
        if (Choices is null)
        {
            throw new DomainException("Choices must not be null");
        }

        if (!Choices.Any())
        {
            throw new DomainException("Choices must not be empty.");
        }

        if (string.IsNullOrWhiteSpace(CorrectAnswerCode))
        {
            throw new DomainException("CorrectAnswerCode must not be null or whitespace.");
        }
    }
}
