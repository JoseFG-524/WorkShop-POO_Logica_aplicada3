namespace HorsesBackend;

public class Posicion

{
    //Properties
    public char Columna
    {
        get;
        set;
    }
    public int Fila
    {
        get;
        set;
    }
    public string Original
    {
        get;
        set;
    }
    = string.Empty;

    //constructor
    public Posicion(string pos)
    {
        Original = pos.Trim();
        if (Original.Length >= 2)
        {
            Columna = char.ToUpper(Original[0]);
            int.TryParse(Original.Substring(1), out int fila);
            Fila = fila;
        }
    }

    //Public Methods
    public bool AtacaA(Posicion otra)
    {
        int diffCol = Math.Abs(this.Columna - otra.Columna);
        int diffFila = Math.Abs(this.Fila - otra.Fila);

        return (diffCol == 1 && diffFila == 2) || (diffCol == 2 && diffFila == 1);
    }
}
public class EvaluadorCaballos
{
    public static List<string> ProcesarConflictos(string entrada)
    {
        var resultados = new List<string>();

        if (string.IsNullOrWhiteSpace(entrada))
            return resultados;

        var listaPosiciones = entrada.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(p => new Posicion(p))
                                     .ToList();

        foreach (var caballo in listaPosiciones)
        {
            var conflictos = new List<string>();

            foreach (var otroCaballo in listaPosiciones)
            {
                if (caballo.Original.Equals(otroCaballo.Original, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (caballo.AtacaA(otroCaballo))
                {
                    conflictos.Add($"{otroCaballo.Fila}{otroCaballo.Columna}");
                }
            }

            string posicionFormateada = $"{caballo.Fila}{caballo.Columna}";

            if (conflictos.Count > 0)
            {

                var conflictosOrdenados = conflictos.OrderByDescending(c => c);

                string textoConflictos = string.Join(" ", conflictosOrdenados.Select(c => $"Conflicto con {c}"));
                resultados.Add($"Analizando Caballo en {posicionFormateada} => {textoConflictos}");
            }
            else
            {
                resultados.Add($"Analizando Caballo en {posicionFormateada} =>");
            }
        }

        return resultados;
    }
}