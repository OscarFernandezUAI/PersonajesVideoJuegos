namespace PersonajesVideoJuegos
{
    //CONCRETE MAGO
    public class Mago : Personaje
    {
        public int Mana { get; set; }

        public override IPersonaje Clonar()
        {
            return (IPersonaje)this.MemberwiseClone();
        }

        public override void MostrarInfo(int numero)
        {
            Console.WriteLine($"[{numero}] Mago -> Nombre: {Nombre} | Vida: {Vida} | Ataque: {Ataque} | Mana: {Mana}");
        }
    }

}
