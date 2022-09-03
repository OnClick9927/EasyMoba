using IFramework;

namespace EMO.ServerCore.Plugins;

internal class Logger : ILoger
{
    private struct Color : IDisposable
    {
        private ConsoleColor preForegroundColor;
        private ConsoleColor preBackgroundColor;
            
        public Color(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            preForegroundColor = Console.ForegroundColor;
            preBackgroundColor = Console.BackgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        public void Dispose()
        {
            Console.ForegroundColor = preForegroundColor;
            Console.BackgroundColor = preBackgroundColor;
        }
    }


    public void Error(object messages, params object[] paras)
    {
        using (new Color(ConsoleColor.Red, ConsoleColor.Black))
        {
            Console.WriteLine($"[Err] {DateTime.Now:yyyy-MM-dd hh:mm:ss fff}\t{messages}", paras);
        }
    }

    public void Exception(Exception ex)
    {
        throw ex;
    }

    public void Log(object messages, params object[] paras)
    {
        using (new Color(ConsoleColor.White, ConsoleColor.Black))
        {
            Console.WriteLine($"[Log] {DateTime.Now:yyyy-MM-dd hh:mm:ss fff}\t{messages}", paras);
        }
    }

    public void Warn(object messages, params object[] paras)
    {
        using (new Color(ConsoleColor.Yellow, ConsoleColor.Black))
        {
            Console.WriteLine($"[Warn] {DateTime.Now:yyyy-MM-dd hh:mm:ss fff}\t{messages}", paras);
        }
    }
}