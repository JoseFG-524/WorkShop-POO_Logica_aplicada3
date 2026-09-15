namespace BeamBackend;

public class EvaluadorViga

{
    public static string Evaluar(string entrada)
    {
        if (string.IsNullOrEmpty(entrada))
            return "La viga está mal construida!";

        char baseChar = entrada[0];
        int capacidadBase;

        switch (baseChar)
        {
            case '%': capacidadBase = 10; break;
            case '&': capacidadBase = 30; break;
            case '#': capacidadBase = 90; break;
            default: return "La viga está mal construida!";
        }

        string cuerpo = entrada.Substring(1);
        int pesoTotal = 0;
        int contadorLargueros = 0;
        bool previaEsConexion = false;

        foreach (char c in cuerpo)
        {
            if (c == '=')
            {
                contadorLargueros++;
                pesoTotal += 1; // Each crossbar weighs 1 unit
                previaEsConexion = false;
            }
            else if (c == '*')
            {
                if (previaEsConexion)
                    return "La viga está mal construida!";

                // The connection weighs twice as much as the number of stringers preceding it
                pesoTotal += contadorLargueros * 2;

                contadorLargueros = 0;
                previaEsConexion = true;
            }
            else
            {
                return "La viga está mal construida!";
            }
        }

        if (pesoTotal <= capacidadBase)
            return "La viga soporta el peso!";
        else
            return "La viga NO soporta el peso!";
    }
}