namespace PersonajesVideoJuegos
{   
    public class Guerrero : Personaje
    {
        public int Defensa { get; set; }

        public Guerrero(string nombre, int vida, int ataque, int defensa)
            : base(nombre, vida, ataque)
        {
            Defensa = defensa;
        }
        public Guerrero(Guerrero prototipo) : base(prototipo)
        {
            Defensa = prototipo.Defensa;
        }

        public override IPersonaje Clonar()
        {
            return new Guerrero(this);
        }

        public override void MostrarInfo(int numero)
        {
            Console.WriteLine($"[{numero}] Guerrero -> Nombre: {Nombre} | Vida: {Vida} | Ataque: {Ataque} | Defensa: {Defensa}");
        }
    }
}
