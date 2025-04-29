namespace BolilleroCore;

public class Simulacion
{
    public long SimularSinHilos(Bolillero original, List<int> jugada, long cantidad)
    {
        long aciertos = 0;

        for (long i = 0; i < cantidad; i++)
        {
            Bolillero clon = (Bolillero)original.CLone();

            if (clon.Jugar(jugada))
                aciertos++;
        }

        return aciertos;
    }



        public static long SimularConHilos(Bolillero original, List<int> jugada, long cantidadSimulaciones, int cantidadHilos)
    {
        long aciertos = 0;

        var contador = new object();

        void SimularEnHilo(long inicio, long fin)
        {
            for (long i = inicio; i < fin; i++)
            {
                Bolillero clon = (Bolillero)original.CLone(); 
                if (clon.Jugar(jugada)) 
                {
                    
                    lock (contador)
                    {
                        aciertos++;
                    }
                }
            }
        }

        // Calcular el número de simulaciones por hilo
        long simulacionesPorHilo = cantidadSimulaciones / cantidadHilos;
        long sobrantes = cantidadSimulaciones % cantidadHilos; // Si no es divisible, repartir el sobrante

        var tareas = new List<Task>();

        // Crear las tareas para cada hilo
        for (int i = 0; i < cantidadHilos; i++)
        {
            // Calcular los rangos de simulaciones que manejará cada hilo
            long inicio = i * simulacionesPorHilo;
            long fin = inicio + simulacionesPorHilo + (i < sobrantes ? 1 : 0);

            // Asignar la tarea a un hilo
            var tarea = Task.Run(() => SimularEnHilo(inicio, fin));
            tareas.Add(tarea);
        }

        // Esperar a que todos los hilos terminen
        Task.WhenAll(tareas).Wait();

        return aciertos;
    }
}

