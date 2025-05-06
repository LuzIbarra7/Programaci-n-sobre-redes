namespace BolilleroCore;

public class SacarPrimero : ILogica
{
    public int SacarBolilla(Bolillero bolillero)
    {
        {   //devuelve la primera bolilla del bolillero
            return bolillero.BolillasAdentro[0];
        }
    }
}