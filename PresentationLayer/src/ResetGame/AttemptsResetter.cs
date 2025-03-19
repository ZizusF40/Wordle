public class AttemptsResetter : IAttemptsResetter
{
    private readonly AttemptsLogic _attemptsLogic;

    public AttemptsResetter(AttemptsLogic attemptsLogic)
    {
        _attemptsLogic = attemptsLogic;
    }

    public void ResetAttempts(int lives)
    {
        _attemptsLogic.Lives = lives;
    }
}

