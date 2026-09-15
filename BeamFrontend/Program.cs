using Shared;
using BeamBackend;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    // Retrieve the beam string using ConsoleExtension
    var vigaInput = ConsoleExtension.GetString("Ingrese la viga: ");

    // Evaluate the beam using the Class Library
    var resultado = EvaluadorViga.Evaluar(vigaInput);

    // Show the result obtained
    Console.WriteLine($" {resultado}");

    // Loop to check if you want to take another test
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");