using System;

namespace videojuego
{
    
    public class datos
    {
        private string tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaNacimiento;
        private int edad;
        private double salud;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public double Salud { get => salud; set => salud = value; }
    }

    public class caracteristicas
    {
        private int velocidad; // 1 a10
        private int destreza; // 1 a 5
        private int fuerza; // 1 a10
        private int nivel; // 1 a10
        private int armadura; // 1 a10

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
    }
}