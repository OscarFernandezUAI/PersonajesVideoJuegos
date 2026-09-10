namespace PersonajesVideoJuegos
{    
    public abstract class Personaje : IPersonaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }

        protected Personaje(string nombre, int vida, int ataque)
        {
            Nombre = nombre;
            Vida = vida;
            Ataque = ataque;
        }
        protected Personaje(Personaje prototipo)
        {
            Nombre = prototipo.Nombre;
            Vida = prototipo.Vida;
            Ataque = prototipo.Ataque;
        }

        public abstract IPersonaje Clonar();
        public abstract void MostrarInfo(int numero);
    }
}