namespace MrTechLead;

public static class Console
{
    public static void WriteLine(string message)
    {
        System.Console.WriteLine(message);
    }

    public static void WriteLine(string message, System.ConsoleColor foregroundColor)
    {
        var currentForegroundColor = System.Console.ForegroundColor;
        System.Console.ForegroundColor = foregroundColor;
        System.Console.WriteLine(message);
        System.Console.ForegroundColor = currentForegroundColor;
    }

    public static void WriteLine(string message, System.ConsoleColor foregroundColor, System.ConsoleColor backgroundColor)
    {
        var currentForegroundColor = System.Console.ForegroundColor;
        var currentBackgroundColor = System.Console.BackgroundColor;

        System.Console.ForegroundColor = foregroundColor;
        System.Console.BackgroundColor = backgroundColor;

        System.Console.WriteLine(message);

        System.Console.ForegroundColor = currentForegroundColor;
        System.Console.BackgroundColor = currentBackgroundColor;
    }
}
