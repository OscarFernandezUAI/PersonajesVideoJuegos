namespace PersonajesVideoJuegos
{
    //CONCRETE PROTOTYPE: GUERRERO
    public class Guerrero : Personaje
    {
        public int Defensa { get; set; }

        public override IPersonaje Clonar()
        {            
            return (IPersonaje)this.MemberwiseClone();
        }

        public override void MostrarInfo(int numero)
        {
            Console.WriteLine($"[{numero}] Guerrero -> Nombre: {Nombre} | Vida: {Vida} | Ataque: {Ataque} | Defensa: {Defensa}");
        }
    }

}
