namespace StudentRegistreringsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var selfServiceTerminal = new SelfServiceTerminal();
            selfServiceTerminal.RunApp();
        }
    }
}
