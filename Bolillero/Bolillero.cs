namespace BolilleroCore;

public class Bolillero : IClonable
{
    public List<int> BolillasAdentro { get; set; }
    public List<int> BolillasAfuera { get; set; }
    ILogica Logica;
    public Bolillero(int cantidadBolillas, ILogica logica)
    {
        BolillasAdentro = new List<int>();
        BolillasAfuera = new List<int>();

        for (int numero = 0; numero < cantidadBolillas; BolillasAdentro.Add(numero++)) ;

        Logica = logica;
    }
    private Bolillero(Bolillero original)
    {
        BolillasAdentro = new List<int>(original.BolillasAdentro);
        BolillasAfuera = new List<int>(original.BolillasAfuera);
        Logica = original.Logica;
    }
    public int SacarBolillas()
    {
        int bolilla = Logica.SacarBolilla(this);
        BolillasAfuera.Add(bolilla);
        BolillasAdentro.Remove(bolilla);

        return bolilla;
    }

    public int JugarNVeces(List<int> jugada, int cantidad)
    {
        if (cantidad < 0)
        {
            throw new ArgumentException("La cantidad de veces a jugar debe ser no negativa.", nameof(cantidad));
        }

        int aciertos = 0;
        for (int i = 0; i < cantidad; i++)
        {
            ReIngresarBolillas();
            if (Jugar(jugada))
            {
                aciertos++;
            }
        }
        return aciertos;
    }

    public bool Jugar(IList<int> jugada)
    {
        foreach (var objetivo in jugada)
        {
            int numero = SacarBolillas();
            if (numero != objetivo)
            {
                ReIngresarBolillas();
                return false;
            }
        }

        ReIngresarBolillas();

        return true;
    }


    public void ReIngresarBolillas()
    {
        BolillasAdentro.AddRange(BolillasAfuera);
        BolillasAfuera.Clear();
        BolillasAdentro.Sort();
    }



    public Bolillero CLone() => new Bolillero(this);
}

public interface ILogica
{
    int SacarBolilla(Bolillero bolillero);
}
