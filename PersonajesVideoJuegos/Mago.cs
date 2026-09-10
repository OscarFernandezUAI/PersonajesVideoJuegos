namespace PersonajesVideoJuegos
{    
    public class Mago : Personaje
    {
        public int Mana { get; set; }

        public Mago(string nombre, int vida, int ataque, int mana)
            : base(nombre, vida, ataque)
        {
            Mana = mana;
        }

        public Mago(Mago prototipo) : base(prototipo)
        {
            Mana = prototipo.Mana;
        }

        public override IPersonaje Clonar()
        {
            return new Mago(this);
        }

        public override void MostrarInfo(int numero)
        {
            Console.WriteLine($"[{numero}] Mago -> Nombre: {Nombre} | Vida: {Vida} | Ataque: {Ataque} | Mana: {Mana}");
        }
    }
}
