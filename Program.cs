using Newtonsoft.Json;

class Lib
{
    void uf_merge(int[] d, int i, int j)
    {
        d[uf_root(d, Math.Max(i, j))] = uf_root(d, Math.Min(i, j));
    }

    int uf_root(int[] d, int i)
    {
        if (d[i] == i)
        {
            return i;
        }
        else
        {
            return d[i] = uf_root(d, d[i]);
        }
    }

    int heap_pop(List<int> d)
    {
        var x = d[0];
        d[0] = d[d.Count - 1];
        d.RemoveAt(d.Count - 1);
        var n = 0;
        while (true)
        {
            var l = n * 2 + 1;
            var r = n * 2 + 2;
            if (r < d.Count)
            {
                if (d[l] < d[r])
                {
                    if (d[l] < d[n])
                    {
                        (d[l], d[n]) = (d[n], d[l]); ;
                        n = l;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (d[r] < d[n])
                    {
                        (d[r], d[n]) = (d[n], d[r]);
                        n = r;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else if (l < d.Count)
            {
                if (d[l] < d[n])
                {
                    (d[n], d[l]) = (d[l], d[n]);
                    n = l;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
        return x;
    }

    void heap_push(List<int> d, int x)
    {
        d.Add(x);
        var n = d.Count - 1;
        while (n < d.Count)
        {
            var m = (n - 1) / 2;
            if (d[n] < d[m])
            {
                (d[n], d[m]) = (d[m], d[n]);
                n = m;
            }
            else
            {
                return;
            }
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        typeof(App).GetMethod(args[0]).Invoke(new App(), null);
    }

    public static void push<T, U>(Dictionary<T, List<U>> d, T t, U u)
    {
        if (d.TryGetValue(t, out var v))
        {
            v.Add(u);
        }
        else
        {
            d[t] = new List<U> { u };
        }
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

    public static void grid(bool[][] d)
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
                e[i + 1][j + 1] = d[i][j] ? "o" : "x";
            }
        }

        _grid(e);
    }

    public static void cell(long[,] d)
    {
        var h = d.GetLength(0);
        var w = d.GetLength(1);

        var e = new string[h + 1, w + 1];
        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < w; j++)
            {
                e[i + 1, j + 1] =
                    d[i, j] <= int.MinValue ? "-inf" :
                    int.MaxValue <= d[i, j] ? "inf" :
                    d[i, j].ToString();
            }
        }

        e[0, 0] = string.Empty;
        for (var i = 0; i < h; i++)
        {
            e[i + 1, 0] = $"[{i}]";
        }
        for (var j = 0; j < w; j++)
        {
            e[0, j + 1] = $"[{j}]";
        }

        var max = new int[w + 1];
        for (var i = 0; i < h + 1; i++)
        {
            for (var j = 0; j < w + 1; j++)
            {
                max[j] = Math.Max(max[j], e[i, j].Length);
            }
        }

        for (var i = 0; i < h + 1; i++)
        {
            for (var j = 0; j < w + 1; j++)
            {
                e[i, j] = e[i, j].PadLeft(max[j]);
            }
        }

        for (var i = 0; i < h + 1; i++)
        {
            for (var j = 0; j < w + 1; j++)
            {
                if (0 < j) Console.Write(" ");
                Console.Write(e[i, j]);
            }
            Console.WriteLine();
        }
    }

    int lower(int[] d, int x, int left, int right)
    {
        if (left == right)
        {
            return left;
        }
        var mid = (left + right) / 2;
        if (x <= d[mid])
        {
            return lower(d, x, left, mid);
        }
        else
        {
            return lower(d, x, mid + 1, right);
        }
    }
}

static class Heap
{
    public static void push(List<int> d, int x)
    {
        d.Add(x);
        rec1(d, d.Count - 1);
    }

    public static int pop(List<int> d)
    {
        var x = d[0];
        d[0] = d[d.Count - 1];
        d.RemoveAt(d.Count - 1);
        rec2(d, 0);
        return x;
    }

    static void rec1(List<int> d, int i)
    {
        if (i < d.Count)
        {
            var j = (i - 1) / 2;
            if (d[i] < d[j])
            {
                (d[i], d[j]) = (d[j], d[i]);
                rec1(d, j);
            }
        }
    }

    static void rec2(List<int> d, int i)
    {
        var j = i * 2 + 1;
        var k = i * 2 + 2;
        if (k < d.Count)
        {
            if (d[j] < d[k])
            {
                if (d[j] < d[i])
                {
                    (d[j], d[i]) = (d[i], d[j]);
                    rec2(d, j);
                }
            }
            else
            {
                if (d[k] < d[i])
                {
                    (d[k], d[i]) = (d[i], d[k]);
                    rec2(d, k);
                }
            }
        }
        else if (j < d.Count)
        {
            if (d[j] < d[i])
            {
                (d[j], d[i]) = (d[i], d[j]);
                rec2(d, j);
            }
        }
    }
}