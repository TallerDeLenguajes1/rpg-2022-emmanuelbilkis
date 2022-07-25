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

    [JsonPropertyName("nombre")]
    public string Nombre { get; }
    [JsonPropertyName("tipoP")]
    public Tipo TipoP { get; }
    [JsonPropertyName("apodo")]
    public string Apodo { get; set; }
    [JsonPropertyName("salud")]
    public int Salud { get; set; }
    [JsonPropertyName("nacimiento")]
    public DateTime Nacimiento { get; }
    [JsonPropertyName("edad")]
    public int Edad { get; }
    [JsonPropertyName("velocidad")]
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
    [JsonPropertyName("fuerza")]
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
    [JsonPropertyName("nivel")]
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
    [JsonPropertyName("armadura")]
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
    [JsonPropertyName("destreza")]
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

[JsonConstructor]
public Personaje()
{
        Nombre = "sdadasd";
        Apodo = "gege";
        TipoP = Tipo.Arquero;;
        Salud = 100;
        Nacimiento = DateTime.UtcNow;
        Edad =  DateTime.Now.Year - (Nacimiento.Year - 25000);

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

}