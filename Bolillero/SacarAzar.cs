using BolilleroCore;
public class SacarAzar : ILogica
{
    private readonly Random _rnd = new Random();

    public int SacarBolilla(Bolillero bolillero)
    {
        int indice = _rnd.Next(0,bolillero.BolillasAdentro.Count);
        return bolillero.BolillasAdentro[indice];
    }
}