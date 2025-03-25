


namespace FutbolVirtual;

public class Jugador
{
    public double VisionJuego { get; set; }
    public double VisionCompaneros { get; set; }
    public double Potencica { get; set; }
    public double HabilidadPases { get; set; }
    public ITipoJugador TipoJugador {get; set;}

    internal void AplicarEntrenamientoFisico()
    {
        TipoJugador.AplicarEntrenamientoFisico(this);
    }

    internal void AplicarEntrenamientoLirica()
    {
        TipoJugador.AplicarEntrenamientoLirica(this);
    }

    internal void AplicarEntrenamientoTactico()
    {
        TipoJugador.AplicarEntrenamientoTactico(this);
    }

    public double GetPrecision ()
    {
        return TipoJugador.GetPrecision(this);
    }

    public double GetVisionGeneral ()
    {
        return TipoJugador.Visiongeneral(this);
    }
}
