using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace videojuego;

class Program
{
    static void Main(string[] args)
    {
        int index;
        string texto;

        var creadorDePersonajes = new CreadorDePersonajes();
        var personajesCreados = new List<Personaje>();
       // var personajesCreados2 = new List<Personaje>();
        var ganadores = new List<Personaje>();
        bool salir = false;

        do
        {
            Console.WriteLine();
            Console.WriteLine("==== Juego =====");
            Console.WriteLine("1) Crear personaje");
            Console.WriteLine("2) Mostrar datos de personaje");
            Console.WriteLine("3) Mostrar características de personaje");
            Console.WriteLine("4) Combate");
            Console.WriteLine("5) Guardar ganadores CSV");
            Console.WriteLine("6) Mostrar ganadores CSV");
            Console.WriteLine("7) Guardar jugadores Json");
            Console.WriteLine("8) Elegir desde Json");
            Console.WriteLine("9) Salir");
            Console.WriteLine();
            Console.Write("Ingrese opcion: ");
            string i = Console.ReadLine()!;
            

            switch (i)
            {
                case "1":
                    var personaje = creadorDePersonajes.Crear();
                    personajesCreados.Add(personaje);
                    Console.WriteLine($"Se ha creado el personaje {personaje.Nombre}");
                    break;

                case "2":
                    int maximo = personajesCreados.Count - 1;
                    Console.Write($"Mostrar datos de cuál personaje (0..{maximo})? ");
                    index = int.Parse(Console.ReadLine()!);
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
                    index = int.Parse(Console.ReadLine()!);
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

                     int _maximo = personajesCreados.Count - 1;
                    Console.Write($"Elija al primer combatiente (0..{_maximo}) ");
                    int primero = int.Parse(Console.ReadLine()!);
                    Console.Write($"Elija al segundo combatiente (0..{_maximo}) ");
                    int segundo = int.Parse(Console.ReadLine()!);

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
                            ganadores.Add(combate.Ganador);
                        }
                    }

                    break;
                    
                case "5":

                            guardarGanadoresCSV("ganadores",".csv",ganadores);     

                    break;
                case "6":
                            MostrarGanadoresCSV("ganadores",".csv");
                    break;
                
                 case "7":
                            guardarJson("jugadores",".json",personajesCreados);
                    break;

                case "8":
                          var personajesCreados2 = Deserializar(@"C:\Users\user\Desktop\tallerteoriastp\Taller\Videojuego\rpg-2022-emmanuelbilkis\RPG\jugadores.json"); 
                          personajesCreados.AddRange(personajesCreados2);
                          Console.WriteLine("El archivo json esta cargaado en el sistema, ahora puede elegir los personajes desde el combate");

                    break;

                case "9":

                    salir = true;
                    break;
            }

        } while (! salir);
    }

    public static void guardarJson(string nombre, string extension, List<Personaje> listaPersonajes)
    {
            var options = new JsonSerializerOptions
            {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
            };

            FileStream miArchivo = new FileStream(nombre + extension, FileMode.OpenOrCreate);
            string jsonString = JsonSerializer.Serialize(listaPersonajes, options);

            using (StreamWriter strwriter = new StreamWriter(miArchivo))
            {
                    strwriter.WriteLine(jsonString);
                    strwriter.Close();   
            }  
            
    }

    public static List<Personaje> Deserializar(string ruta)
    { 
        string textoJson = File.ReadAllText(ruta);
        var nuevaLista = JsonSerializer.Deserialize<List<Personaje>>(textoJson)!;
        //var nuevalista = nuevaLista.First();
        return nuevaLista;
    }

    public static void guardarGanadoresCSV(string nombre, string extension, List<Personaje> ganadores)
    {

            FileStream miArchivo = new FileStream(nombre + extension, FileMode.OpenOrCreate);

            using (StreamWriter strwriter = new StreamWriter(miArchivo))
            {

                    foreach (var ganadorX in ganadores)
                    {
                        strwriter.WriteLine("{0},{2},{3}", ganadorX.Nombre, ganadorX.Edad, ganadorX.Nacimiento);    
                    }
                    
                    strwriter.Close();   
            }  
    }

    public static void MostrarGanadoresCSV(string nombre, string extension)
    {

            FileStream miArchivo = new FileStream(nombre + extension, FileMode.Open);

            using (StreamReader strread = new StreamReader(miArchivo))
            {
                string ganadores = strread.ReadToEnd();
                Console.WriteLine(ganadores);
                strread.Close();   
            }  
    }
}

