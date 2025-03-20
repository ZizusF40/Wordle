public class AttemptsResetter : IAttemptsResetter
{
    private readonly IAttemptsLogic _attemptsLogic;

    public AttemptsResetter(IAttemptsLogic attemptsLogic)
    {
        _attemptsLogic = attemptsLogic;
    }

    public void ResetAttempts(int lives)
    {
        _attemptsLogic.Lives = lives;
    }
}

