namespace FutbolVirtual;

public class SesionLirica : Sesion
{
    public override void AplicarA(Jugador jugador)
    {
        jugador.AplicarEntrenamientoLirica(jugador);
    }
}