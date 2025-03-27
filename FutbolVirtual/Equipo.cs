namespace FutbolVirtual;

public class Equipo
{
    List<Jugador> jugadores {get; set;} = new List<Jugador> ();
    List<Sesion> sesiones {get; set;} = new List<Sesion> ();
    public double Potencia()
        => jugadores.Select(j => j.Potencia)
            .OrderDescending()
            .Take(2)
            .Sum();

public void Sesion(List<Jugador> jugadores, List<Sesion> sesiones)
    {
        this.jugadores = jugadores;
        this.sesiones = sesiones;
    }
    public void Entrenar()
    {
        foreach (var jugador in jugadores)
        {
            foreach (var sesion in sesiones)
            {
                sesion.AplicarA(jugador);
            }
        }
    }


}