
namespace FutbolVirtual;

public class Jugador
{
    public double VisionJuego { get; set; }
    public double VisionCompaneros { get; set; }
    public double Potencia { get; set; }
    public double HabilidadPases { get; set; }
    public ITipoJugador TipoJugador {get; set;}

    internal void AplicarEntrenamientoFisico(Jugador jugador)
    {
        TipoJugador.AplicarEntrenamientoFisico(this);
    }

    internal void AplicarEntrenamientoLirica(Jugador jugador)
    {
        TipoJugador.AplicarEntrenamientoLirica(this);
    }

    internal void AplicarEntrenamientoTactico(Jugador jugador)
    {
        TipoJugador.AplicarEntrenamientoTactico(this);
    }

    public double GetPrecision (Jugador jugador)
    {
        return TipoJugador.GetPrecision(this);
    }

    public double GetVisionGeneral (Jugador jugador)
    {
        return TipoJugador.Visiongeneral(this);
    }
}
