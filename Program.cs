class Program
{
    static void Main(string[] args)
    {
        var cowsay = new CowsayWrapper();

        // Use piped input or message from args
        string message = Console.IsInputRedirected
            ? Console.In.ReadToEnd().Trim()
            : "";

        // Everything from args goes to options if we have piped input
        // Otherwise, separate message from options
        string[] options;
        
        if (Console.IsInputRedirected)
        {
            // All args are options when input is piped
            options = args;
        }
        else
        {
            // Find where options start (first arg starting with -)
            int firstOptionIndex = Array.FindIndex(args, a => a.StartsWith("-"));
            
            if (firstOptionIndex == -1)
            {
                // No options, all args are the message
                message = string.Join(" ", args);
                options = Array.Empty<string>();
            }
            else
            {
                // Everything before first option is message
                message = string.Join(" ", args.Take(firstOptionIndex));
                // Everything from first option onwards are options
                options = args.Skip(firstOptionIndex).ToArray();
            }
        }

        Console.Write(cowsay.Run(message, options));
    }
}
