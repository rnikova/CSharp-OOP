namespace CommandPattern.Core
{
    public interface ICommandInterpreter
    {
        string Read(string inputLine);
    }
}
