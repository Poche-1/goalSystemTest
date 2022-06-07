public class MainService : IMainService
{
    public string Get()
    {
        return "It's ok!";
    }
}

public interface IMainService
{
    string Get();
}