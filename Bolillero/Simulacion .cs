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


public  long SimularConHilos(Bolillero bolillero, List<int> jugada, long cantidadSimulaciones, int cantidadHilos)
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
public async Task<long> SimularConHilosAsync(Bolillero bolillero, List<int> jugada, long cantidadSimulaciones, int cantidadHilos)
    {
        long resutado = await Task<long>.Run(() => SimularConHilos(bolillero, jugada, cantidadSimulaciones, cantidadHilos));
        return resutado;
    }
public async Task<long> SimularParallelAsync(Bolillero bolillero, List<int> jugada, long cantidadSimulaciones, int cantidadHilos)
    {
        var aciertos = new long[cantidadHilos];

        int simulacionesPorHilo = (int)(cantidadSimulaciones / cantidadHilos);
        long sobrantes = cantidadSimulaciones % cantidadHilos;

        var opciones = new ParallelOptions()
        {
            //Cantidad maxima de tareas en paralelo
            MaxDegreeOfParallelism = cantidadHilos
        };

        await Task<long>.Run(() =>
            Parallel.For(0, cantidadHilos, opciones,
            (i) =>
            {
                int simsParaEsteHilo = simulacionesPorHilo + (i < sobrantes ? 1 : 0);
                Bolillero clon = bolillero.CLone();
                aciertos[i] = clon.JugarNVeces(jugada, simsParaEsteHilo);
            })
        );

        return aciertos.Sum();
    }

}

