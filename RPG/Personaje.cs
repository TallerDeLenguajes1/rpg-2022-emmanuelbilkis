using videojuego;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Personaje
{
    private int velocidad;
    private int fuerza;
    private int nivel;
    private int armadura;
    private int destreza;

    public string Nombre { get; }
    public Tipo TipoP { get; }
    public string Apodo { get; set; }

    public int Salud { get; set; }
    public DateTime Nacimiento { get; }
    public int Edad { get; }
    public int Velocidad
    {
        get
        {
            return velocidad;
        }
        set
        {
            if (value >= 1 && value <= 10)
            {
                velocidad = value;
            }
        }
    }
    public int Fuerza
    {
        get
        {
            return fuerza;
        }

        set
        {
            if (value >= 1 && value <= 10)
            {
                fuerza = value;
            }
        }
    }
    public int Nivel
    {
        get
        {
            return nivel;
        }

        set
        {
            if (value >= 1 && value <= 10)
            {
                nivel = value;
            }
        }
    }
    public int Armadura
    {
        get
        {
            return armadura;
        }
        set
        {
            if (value >= 1 && value <= 10)
            {
                armadura = value;
            }
        }
    }
    public int Destreza
    {
        get
        {
            return destreza;
        }
        set
        {
            if (value >= 1 && value <= 10)
            {
                destreza = value;
            }
        }
    }


public Personaje (string nombre, Tipo tipo, DateTime nacimiento) // al pasarlo en el constructor como argumentos nadie podra cambiar estos atributos
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre invalido"); // cuando sea nulo o vacio me lanzara nombre invalido
        Nombre = nombre;
        TipoP = tipo;
        Salud = 100;
        Nacimiento = nacimiento;
        Edad =  DateTime.Now.Year - Nacimiento.Year;

        var random = new Random();
        Velocidad = random.Next(1, 11);
        Fuerza = random.Next(1, 11);
        Nivel = random.Next(1, 11);
        Armadura = random.Next(1, 11);
        Destreza = random.Next(1, 6);
    }

    public string DescripcionDeDatos()
    {
        return
            $"Nombre    : {Nombre}" + Environment.NewLine +
            $"Apodo     : {Apodo}" + Environment.NewLine +
            $"Tipo      : {TipoP}" + Environment.NewLine +
            $"Salud     : {Salud}" + Environment.NewLine +
            $"Nacimiento: {Nacimiento}" + Environment.NewLine +
            $"Edad      : {Edad}";
    }

    public string DescripcionDeCaracteristicas()
    {
        return
            $"Velocidad : {Velocidad}" + Environment.NewLine +
            $"Fuerza    : {Fuerza}" + Environment.NewLine +
            $"Nivel     : {Nivel}" + Environment.NewLine +
            $"Armadura  : {Armadura}" + Environment.NewLine +
            $"Destreza  : {Destreza}";
    }


    public string CrearJson(Personaje personaje)
 {
    string jsonString;
    return  jsonString = JsonSerializer.Serialize(personaje);

}

    public void GuardarJson(string nombreArchivo, string formato, Personaje personaje)
    {
        string persStr = CrearJson(personaje);
        FileStream MiArchivo = new FileStream(nombreArchivo + formato, FileMode.Create);
        using (StreamWriter Strwriter = new StreamWriter(MiArchivo))
        {
            Strwriter.WriteLine("{0}", persStr);
            Strwriter.Close();
        }
    }

    public void GuardarCSV(string nombreArchivo, string formato, Personaje personaje)
    {
        string persStr = CrearJson(personaje);
        FileStream MiArchivo = new FileStream(nombreArchivo + formato, FileMode.Create);
        using (StreamWriter Strwriter = new StreamWriter(MiArchivo))
        {
            Strwriter.WriteLine("{0};{1};{2}", personaje.Nombre, personaje.TipoP,personaje.Salud);
            Strwriter.Close();
        }
    }

}