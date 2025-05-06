namespace BolilleroCore;

public class Simulacion
{
    public long SimularSinHilos(Bolillero original, List<int> jugada, long cantidad)
    {
        long aciertos = 0;

        for (long i = 0; i < cantidad; i++)
        {
            Bolillero clon = (Bolillero)original.CLone();
            //si la jugada de clon es igual a la jugada 
            if (clon.Jugar(jugada))
                aciertos++;
        }

        return aciertos;
    }


public static long SimularConHilos(Bolillero bolillero, List<int> jugada, long cantidadSimulaciones, int cantidadHilos)
{   //Divide el total de la simulaciones por la cantiad de hilo
    long simulacionesPorHilo = cantidadSimulaciones / cantidadHilos;
    //Devuelve el sobrante de la division anterior
    long sobrantes = cantidadSimulaciones % cantidadHilos;

    //Por cada hilo crea una tarea nueva de tipo long
    Task<long>[] tareas = new Task<long>[cantidadHilos];

    for (int i = 0; i < cantidadHilos; i++)
    {   
        long simulacionesParaEsteHilo = simulacionesPorHilo + (i < sobrantes ? 1 : 0);
        //se crea la tarea con el numero que tenga
        tareas[i] = Task.Run(() =>
        {
            long aciertos = 0;
            Bolillero clon = (Bolillero)bolillero.CLone(); // Clonamos solo una vez por hilo

            for (long j = 0; j < simulacionesParaEsteHilo; j++)
            {
                if (clon.Jugar(jugada))
                    aciertos++;
            }

            return aciertos;
        });
    }
    //Espera que termine tareas
    Task.WaitAll(tareas);
    // Suma los resultados de las tareas
    long totalAciertos = tareas.Sum(t => t.Result);
    return totalAciertos;
}
}

