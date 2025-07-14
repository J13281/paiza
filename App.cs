using static Program;

class App
{
    System.Collections.IEnumerator _data = string.Empty.GetEnumerator();

    public static void Main(string[] args)
    {
        new App().main();
    }

    public void main()
    {
        say("hello world.");
    }

    long num()
    {
        return long.Parse(str());
    }

    string str()
    {
        if (_data.MoveNext())
        {
            return (string)_data.Current;
        }
        else
        {
            _data = Console.ReadLine().Split().GetEnumerator();
            return str();
        }
    }
}