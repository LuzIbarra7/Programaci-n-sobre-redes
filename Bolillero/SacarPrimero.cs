namespace BolilleroCore;

public class SacarPrimero : ILogica
{
    public int SacarBolilla(Bolillero bolillero)
    {
        {
            return bolillero.BolillasAdentro[0];
        }
    }
}