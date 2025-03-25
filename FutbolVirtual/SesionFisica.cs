namespace FutbolVirtual;

public class SesionFisica : Sesion
{
    public override void AplicarA(Jugador jugador)
    {
        jugador.AplicarEntrenamientoFisico();
    }
}