using static Program;

using System;
using System.Linq;
using System.Collections.Generic;

class App
{
    public static void Main(string[] args)
    {
        new App().main();
    }

    public void main()
    {
        say("hello world.");
        for (var i = 0; i < 10; i++)
        {
            say("i is <" + i + ">.");
        }
        say("exit app.");
    }
}