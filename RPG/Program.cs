using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace videojuego;

class Program
{
    static void Main(string[] args)
    {
        int index, maximo;
        string texto;

        var creadorDePersonajes = new CreadorDePersonajes();
        var personajesCreados = new List<Personaje>();
        bool salir = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("==== Juego =====");
            Console.WriteLine("1) Crear personaje");
            Console.WriteLine("2) Mostrar datos de personaje");
            Console.WriteLine("3) Mostrar características de personaje");
            Console.WriteLine("4) Combate");
            Console.WriteLine("5) Guardar Jugadores Json");
            Console.WriteLine("6) Combate");

            Console.WriteLine("7) Salir");
            Console.WriteLine();
            Console.Write("Ingrese opcion: ");

            string i = Console.ReadLine().Trim();
            switch (i)
            {
                case "1":
                    var personaje = creadorDePersonajes.Crear();
                    personajesCreados.Add(personaje);
                    Console.WriteLine($"Se ha creado el personaje {personaje.Nombre}");
                    break;

                case "2":
                    maximo = personajesCreados.Count - 1;
                    Console.Write($"Mostrar datos de cuál personaje (0..{maximo})? ");
                    index = int.Parse(Console.ReadLine());
                    if (index >= 0 && index <= maximo)
                    {
                        texto = personajesCreados[index].DescripcionDeDatos();
                        Console.WriteLine(texto);
                    }
                    else
                    {
                        Console.WriteLine("Número de personaje inválido.");
                    }
                    break;

                case "3":
                    maximo = personajesCreados.Count - 1;
                    Console.Write($"Mostrar caracteristicas de cuál personaje (0..{maximo})? ");
                    index = int.Parse(Console.ReadLine());
                    if (index >= 0 && index <= maximo)
                    {
                        texto = personajesCreados[index].DescripcionDeCaracteristicas();
                        Console.WriteLine(texto);
                    }
                    else
                    {
                        Console.WriteLine("Número de personaje inválido.");
                    }
                    break;

                case "4":
                    maximo = personajesCreados.Count - 1;
                    Console.Write($"Elija al primer combatiente (0..{maximo}) ");
                    int primero = int.Parse(Console.ReadLine());
                    Console.Write($"Elija al segundo combatiente (0..{maximo}) ");
                    int segundo = int.Parse(Console.ReadLine());

                    if (primero == segundo)
                    {
                        Console.WriteLine($"{personajesCreados[primero].Nombre} no puede pelear consigo mismo");
                    }
                    else
                    {
                        var primerCombatiente = personajesCreados[primero];
                        var segundoCombatiente = personajesCreados[segundo];
                        var combate = new Combate(primerCombatiente, segundoCombatiente);
                        combate.Pelear();
                        if (combate.Ganador is null)
                        {
                            Console.WriteLine($"La pelea entre {primerCombatiente.Nombre} y {segundoCombatiente.Nombre} terminó en empate");
                        }
                        else
                        {
                            Console.WriteLine($"Ganó {combate.Ganador.Nombre}");
                            combate.Ganador.GuardarCSV("Ganadores", ".csv",combate.Ganador);
                          
                        }
                    }
                    break;
                    
                case "5":

                    foreach (var personajeX in personajesCreados)
                    {
                        string perstr = personajeX.CrearJson(personajeX);
                        personajeX.GuardarJson("Jugadores", ".json", personajeX);    
                    }

                    break;

                case "7":
                    salir = true;
                    break;
            }

        } while (! salir);
    }
}
