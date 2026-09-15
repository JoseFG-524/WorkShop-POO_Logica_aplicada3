namespace Shared;

public static class ConsoleExtension
{
    // Request a text and verify that it is not empty
    public static string GetString(string message)
    {
        string? input;
        do
        {
            Console.Write(message);
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(" Error: El valor ingresado no puede estar vacío.");
            }
        } while (string.IsNullOrEmpty(input));

        return input;
    }

    // Prompt for an integer
    public static int GetInt(string message)
    {
        int number;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            Console.WriteLine(" Error: Ingrese un número entero válido.");
        }
    }

    // Verify that the answer is among the allowed options
    public static string GetValidOptions(string message, List<string> options)
    {
        string? answer;
        do
        {
            Console.Write(message);
            answer = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(answer) || !options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine($" Opción no válida. Ingrese una de las siguientes opciones: [{string.Join(", ", options)}]");
            }
        } while (string.IsNullOrEmpty(answer) || !options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

        return answer;
    }
}