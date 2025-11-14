using System.Diagnostics;

public class CowsayWrapper
{
    public string Run(string message, string[] options)
    {
        var psi = new ProcessStartInfo("cowsay")
        {
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };

        foreach (var opt in options)
            psi.ArgumentList.Add(opt);

        using var process = Process.Start(psi) ?? throw new InvalidOperationException("Failed to start cowsay process.");

        if (!string.IsNullOrWhiteSpace(message))
        {
            process.StandardInput.WriteLine(message);
            process.StandardInput.Close();
        }

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        return string.IsNullOrEmpty(error) ? output : error;
    }
}
