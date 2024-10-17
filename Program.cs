using Newtonsoft.Json;

class Program
{
    public static void Main(string[] args)
    {
        typeof(App).GetMethod(args[0]).Invoke(new App(), null);
    }

    public static void say(object o)
    {
        Console.WriteLine(o);
    }

    public static void print(object o)
    {
        Console.Write(o);
    }

    public static void explain(object o)
    {
        Console.WriteLine(JsonConvert.SerializeObject(o));
    }

    public static void explainf(object o)
    {
        Console.WriteLine(JsonConvert.SerializeObject(o, Formatting.Indented));
    }

    static void _grid(string[][] d)
    {
        var h = d.Length;
        var w = d[0].Length;

        var e = new int[w];
        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < w; j++)
            {
                e[j] = Math.Max(e[j], d[i][j].Length);
            }
        }

        var sp = ' ';
        for (var i = 0; i < h; i++)
        {
            Console.Write(d[i][0].PadLeft(e[0]));
            for (var j = 1; j < w; j++)
            {
                Console.Write(sp);
                Console.Write(d[i][j].PadLeft(e[j]));
            }
            Console.WriteLine();
        }
    }

    public static void grid<T>(T[][] d)
    {
        var h = d.Length;
        var w = d[0].Length;

        var e = new string[h + 1][];
        for (var i = 0; i < h + 1; i++)
        {
            e[i] = new string[w + 1];
        }

        e[0][0] = "";
        for (var i = 0; i < h; i++)
        {
            e[i + 1][0] = "[" + i + "]";
        }
        for (var i = 0; i < w; i++)
        {
            e[0][i + 1] = "[" + i + "]";
        }

        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < w; j++)
            {
                e[i + 1][j + 1] = d[i][j].ToString();
            }
        }

        _grid(e);
    }
}