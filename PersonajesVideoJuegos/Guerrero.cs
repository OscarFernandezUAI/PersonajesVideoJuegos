namespace PersonajesVideoJuegos
{
    // ===================== CONCRETE PROTOTYPE: GUERRERO =====================
    public class Guerrero : Personaje
    {
        public int Defensa { get; set; }

        public override IPersonaje Clonar()
        {
            // MemberwiseClone hace una copia superficial (shallow copy).
            // Como todos los atributos son tipos simples (string/int),
            // en este caso alcanza sin riesgo de referencias compartidas.
            return (IPersonaje)this.MemberwiseClone();
        }

        public override void MostrarInfo(int numero)
        {
            Console.WriteLine($"[{numero}] Guerrero -> Nombre: {Nombre} | Vida: {Vida} | Ataque: {Ataque} | Defensa: {Defensa}");
        }
    }

}
