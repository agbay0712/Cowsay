using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var cowsay = new CowsayWrapper();

        // Use piped input or message from args
        string message = Console.IsInputRedirected
            ? Console.In.ReadToEnd().Trim()
            : string.Join(" ", args.Where(a => !a.StartsWith("-")));

        // Get cowsay options (flags)
        var options = args.Where(a => a.StartsWith("-")).ToArray();

        Console.Write(cowsay.Run(message, options));
    }
}
