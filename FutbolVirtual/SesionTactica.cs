namespace FutbolVirtual;

public class SesionTactica : Sesion
{
    public override void AplicarA(Jugador jugador)
    {
        jugador.AplicarEntrenamientoTactico(jugador);
    }
}