namespace FutbolVirtual;

public interface ITipoJugador
{

    void AplicarEntrenamientoFisico(Jugador jugador);
    void AplicarEntrenamientoLirica(Jugador jugador);
    void AplicarEntrenamientoTactico(Jugador jugador);
    double GetPrecision(Jugador jugador);
    double Visiongeneral(Jugador jugador);
}