public interface IAttemptsLogic
{
    int Lives { get; set; }
}

public class AttemptsLogic : IAttemptsLogic
{
    public int Lives { get; set; } = 0; // max 6
}
