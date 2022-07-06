namespace videojuego;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Combate
{
    private readonly Personaje[] peleadores;
    private readonly Random random;
    private const int MaximoDanoProvocable = 50000;
    public Personaje Ganador { get; private set; }
    public Personaje Perdedor { get; private set; }

    public Combate(Personaje primerPeleador, Personaje segundoPeleador)
    {
        peleadores = new[] { primerPeleador, segundoPeleador };
        random = new Random();
    }

    public void Pelear()
    {
        int[] orden;
        if (random.Next(0, 2) == 0)
        {
            orden = new[] { 0, 1 };
        }
        else
        {
            orden = new[] { 1, 0 };
        }

        for (int round = 0; round < 3; round++)
        {
            EjecutarRound(orden[0], orden[1]);
            EjecutarRound(orden[1], orden[0]);
        }

        if (peleadores[0].Salud > peleadores[1].Salud)
        {
            Ganador = peleadores[0];
            Perdedor = peleadores[1];
        }
        else
        {
            if (peleadores[0].Salud < peleadores[1].Salud)
            {
                Ganador = peleadores[1];
                Perdedor = peleadores[0];
            }
        }
    }

    private void EjecutarRound(int atacante, int defensor)
    {
        int poder = CalcularPoderDeDisparo(atacante);
        int efectividad = CalcularEfectividadDeDisparo();
        int valorDeAtaque = poder * efectividad;

        int poderDeDefensa = CalcularPoderDeDefensa(defensor);

        int danoProvocado = ((valorDeAtaque * efectividad - poderDeDefensa) / MaximoDanoProvocable) * 100;
        peleadores[defensor].Salud -= danoProvocado;
    }

    private int CalcularPoderDeDisparo(int indice) =>
        peleadores[indice].Destreza * peleadores[indice].Fuerza * peleadores[indice].Nivel;

    private int CalcularEfectividadDeDisparo() => random.Next(1, 101);

    private int CalcularPoderDeDefensa(int indice) =>
        peleadores[indice].Armadura * peleadores[indice].Velocidad;

    

}