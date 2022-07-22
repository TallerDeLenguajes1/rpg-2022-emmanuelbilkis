namespace videojuego
{    
 public class CreadorDePersonajes
 {
    private readonly List<string> nombres;
    private readonly List<Personaje> personajesListos;
    private readonly Random random;

    public CreadorDePersonajes()
    {
        random = new Random();
        nombres = new()
        {
            "Gandalf",
            "Legolas",
            "Gimli",
            "Raistlin",
            "Tanis",
            "Drizzt",
            "Goldmoon",
            "Riverwind",
            "Sturm",
            "Frodo"
        };
    }


    public Personaje Crear()
    {
        string nombre = ElegirNombre();
        Tipo tipo = ElegirTipo();
        DateTime nacimiento = ElegirNacimiento();
        Personaje nuevo = new Personaje(nombre, tipo, nacimiento);
        return nuevo ;
    }

    private DateTime ElegirNacimiento()
    {
        int anio = random.Next(1, 301);
        var fecha = DateTime.Now.AddYears(-anio);
        return (fecha);
    }

    private Tipo ElegirTipo()
    {
        var tipos = Enum.GetValues<Tipo>();
        int indice = random.Next(0, tipos.Length);
        return tipos[indice];
    }

    private string ElegirNombre()
    {
        int indice = random.Next(0, nombres.Count);
        var nombreElegido = nombres[indice];
        nombres.RemoveAt(indice);
        return nombreElegido;
    }


 }

}