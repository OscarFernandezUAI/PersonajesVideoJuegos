namespace PersonajesVideoJuegos
{
    // ===================== CLASE ABSTRACTA =====================
    public abstract class Personaje : IPersonaje
    {
        public string Nombre { get; set; } = string.Empty;
        public int Vida { get; set; }
        public int Ataque { get; set; }

        public abstract IPersonaje Clonar();
        public abstract void MostrarInfo(int numero);
    }

}
