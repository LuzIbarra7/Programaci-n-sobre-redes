namespace FutbolVirtual;

public class Atacante : ITipoJugador
{
    public double anotacion { get; set; }

    public void AplicarEntrenamientoFisico(Jugador jugador)
    {
        jugador.Potencia =+ 1;
        jugador.HabilidadPases =+ 0.5;
    }

    public void AplicarEntrenamientoLirica(Jugador jugador)
    {
        jugador.HabilidadPases =+ 1;
        anotacion =+ 0.5;
    }

    public void AplicarEntrenamientoTactico(Jugador jugador)
    {
        jugador.HabilidadPases =+ 0.5;
        jugador.VisionJuego =+ 0.5;
        jugador.VisionCompaneros =+ 0.5;
    }

    public double GetPrecision(Jugador jugador)
    {
        return 3 * anotacion + jugador.HabilidadPases;
    }

    public double Visiongeneral(Jugador jugador)
    {
        return jugador.VisionJuego + jugador.HabilidadPases;
    }
}