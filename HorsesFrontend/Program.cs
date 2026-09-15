using Shared;
using HorsesBackend;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Capture the entered positions using ConsoleExtension
    var entrada = ConsoleExtension.GetString("Ingrese ubicación de los caballos: ");

    // Process the positions using the Class Library
    var reporte = EvaluadorCaballos.ProcesarConflictos(entrada);

    // Print the lines of conflict
    foreach (var linea in reporte)
    {
        Console.WriteLine(linea);
    }

    // Loop to repeat or exit
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");