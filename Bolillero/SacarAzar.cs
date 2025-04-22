namespace Bolillero;

public class SacarAzar : ILogica
{
    public int SacarBolilla(Bolillero bolillero)
    {
        private readonly Random _rnd = new Random();
        public int Next(int minValue, int maxValue) => _rnd.Next(minValue, maxValue);
    }
}