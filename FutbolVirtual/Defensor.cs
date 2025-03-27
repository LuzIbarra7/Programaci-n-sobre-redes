namespace FutbolVirtual;

public class Defensor : ITipoJugador
{
    public double quite { get; set; }

    public void AplicarEntrenamientoFisico(Jugador jugador)
    {
        jugador.AplicarEntrenamientoFisico(jugador);
    }

    public void AplicarEntrenamientoLirica(Jugador jugador)
    {
        jugador.AplicarEntrenamientoLirica(jugador);
    }

    public void AplicarEntrenamientoTactico(Jugador jugador)
    {
        jugador.AplicarEntrenamientoTactico(jugador);
    }

    public double GetPrecision(Jugador jugador)
    {
        return jugador.GetPrecision(jugador);
    }

    public double Visiongeneral(Jugador jugador)
    {
        return jugador.GetVisionGeneral(jugador);
    }
}