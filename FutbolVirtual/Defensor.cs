namespace FutbolVirtual;

public class Defensor : ITipoJugador
{
    public double quite { get; set; }

    public void AplicarEntrenamientoFisico(Jugador jugador)
    {
        jugador.Potencia =+ 1;
        jugador.HabilidadPases =+ 0.5;
        quite =+ 0.5;
    }

    public void AplicarEntrenamientoLirica(Jugador jugador)
    {
        jugador.HabilidadPases =+ 1;
        jugador.VisionJuego =+ 0.5;
    }

    public void AplicarEntrenamientoTactico(Jugador jugador)
    {
        jugador.VisionJuego =+ 0.5;
        jugador.VisionCompaneros =+ 1;
    }

    public double GetPrecision(Jugador jugador)
    {
        return 3 * quite + jugador.HabilidadPases;
    }

    public double Visiongeneral(Jugador jugador)
    {
        return jugador.VisionCompaneros + jugador.VisionJuego;
    }
}