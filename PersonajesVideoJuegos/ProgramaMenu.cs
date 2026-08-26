using System;
using System.Collections.Generic;
using System.Text;

namespace PersonajesVideoJuegos
{
    //MENU (representa la clase Cliente)
    public class ProgramaMenu
    {
        private List<Personaje> personajes = new List<Personaje>();

        public void Ejecutar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine();
                Console.WriteLine("========== PERSONAJES RPG - PATRON PROTOTYPE ==========");
                Console.WriteLine("1. Crear plantilla de personaje");
                Console.WriteLine("2. Clonar personaje existente");
                Console.WriteLine("3. Modificar atributos de un personaje");
                Console.WriteLine("4. Listar personajes");
                Console.WriteLine("5. Salir");
                Console.WriteLine("========================================================");

                int opcion = LeerEntero("Seleccione una opcion (1-5): ", 1, 5);

                switch (opcion)
                {
                    case 1: CrearPlantilla(); break;
                    case 2: ClonarPersonaje(); break;
                    case 3: ModificarPersonaje(); break;
                    case 4: ListarPersonajes(); break;
                    case 5: salir = true; Console.WriteLine("Saliendo del programa..."); break;
                }
            }
        }

        private void CrearPlantilla()
        {
            Console.WriteLine("\n--- Crear plantilla de personaje ---");
            Console.WriteLine("1. Guerrero");
            Console.WriteLine("2. Mago");
            int tipo = LeerEntero("Tipo de personaje (1-2): ", 1, 2);

            string nombre = LeerTexto("Ingrese el nombre: ");
            int vida = LeerEntero("Ingrese la vida (mayor a 0): ", 1, int.MaxValue);
            int ataque = LeerEntero("Ingrese el ataque (mayor a 0): ", 1, int.MaxValue);

            Personaje nuevoPersonaje;

            if (tipo == 1)
            {
                int defensa = LeerEntero("Ingrese la defensa (mayor a 0): ", 1, int.MaxValue);
                nuevoPersonaje = new Guerrero { Nombre = nombre, Vida = vida, Ataque = ataque, Defensa = defensa };
            }
            else
            {
                int mana = LeerEntero("Ingrese el mana (mayor a 0): ", 1, int.MaxValue);
                nuevoPersonaje = new Mago { Nombre = nombre, Vida = vida, Ataque = ataque, Mana = mana };
            }

            personajes.Add(nuevoPersonaje);
            Console.WriteLine("Plantilla creada correctamente.");
        }

        private void ClonarPersonaje()
        {
            if (!HayPersonajes()) return;

            ListarPersonajes();
            int indice = LeerEntero($"Ingrese el numero de personaje a clonar (1-{personajes.Count}): ", 1, personajes.Count);

            Personaje original = personajes[indice - 1];
            Personaje copia = (Personaje)original.Clonar(); // <-- Clonacion via Prototype

            Console.WriteLine("Personaje clonado. Puede modificar la copia (dejar igual = no aplica cambios).");

            string? nuevoNombre = LeerTextoOpcional($"Nuevo nombre (Enter para mantener '{copia.Nombre}'): ");
            if (!string.IsNullOrEmpty(nuevoNombre)) copia.Nombre = nuevoNombre;

            int? nuevaVida = LeerEnteroOpcional($"Nueva vida (Enter para mantener {copia.Vida}): ");
            if (nuevaVida.HasValue) copia.Vida = nuevaVida.Value;

            int? nuevoAtaque = LeerEnteroOpcional($"Nuevo ataque (Enter para mantener {copia.Ataque}): ");
            if (nuevoAtaque.HasValue) copia.Ataque = nuevoAtaque.Value;

            personajes.Add(copia);
            Console.WriteLine("Personaje clonado y agregado a la lista.");
        }

        private void ModificarPersonaje()
        {
            if (!HayPersonajes()) return;

            ListarPersonajes();
            int indice = LeerEntero($"Ingrese el numero de personaje a modificar (1-{personajes.Count}): ", 1, personajes.Count);
            Personaje personaje = personajes[indice - 1];

            Console.WriteLine("1. Nombre");
            Console.WriteLine("2. Vida");
            Console.WriteLine("3. Ataque");
            if (personaje is Guerrero) Console.WriteLine("4. Defensa");
            if (personaje is Mago) Console.WriteLine("4. Mana");

            int atributo = LeerEntero("Que atributo desea modificar (1-4): ", 1, 4);

            switch (atributo)
            {
                case 1:
                    personaje.Nombre = LeerTexto("Nuevo nombre: ");
                    break;
                case 2:
                    personaje.Vida = LeerEntero("Nueva vida (mayor a 0): ", 1, int.MaxValue);
                    break;
                case 3:
                    personaje.Ataque = LeerEntero("Nuevo ataque (mayor a 0): ", 1, int.MaxValue);
                    break;
                case 4:
                    if (personaje is Guerrero g) g.Defensa = LeerEntero("Nueva defensa (mayor a 0): ", 1, int.MaxValue);
                    else if (personaje is Mago m) m.Mana = LeerEntero("Nuevo mana (mayor a 0): ", 1, int.MaxValue);
                    break;
            }

            Console.WriteLine("Personaje modificado correctamente.");
        }

        private void ListarPersonajes()
        {
            if (!HayPersonajes()) return;

            Console.WriteLine("\n--- Listado de personajes ---");
            for (int i = 0; i < personajes.Count; i++)
            {
                personajes[i].MostrarInfo(i + 1);
            }
        }

        private bool HayPersonajes()
        {
            if (personajes.Count == 0)
            {
                Console.WriteLine("No hay personajes cargados todavia.");
                return false;
            }
            return true;
        }

        private int LeerEntero(string mensaje, int min, int max)
        {
            int valor;
            bool esValido;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine() ?? string.Empty;

                esValido = int.TryParse(entrada, out valor);

                if (!esValido)
                {
                    Console.WriteLine("Error: debe ingresar un valor numerico entero.");
                }
                else if (valor < min || valor > max)
                {
                    Console.WriteLine($"Error: el valor debe estar entre {min} y {max}.");
                    esValido = false;
                }

            } while (!esValido);

            return valor;
        }

        private string LeerTexto(string mensaje)
        {
            string entrada;
            bool esValido;

            do
            {
                Console.Write(mensaje);
                entrada = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Error: el campo no puede estar vacio.");
                    esValido = false;
                }
                else if (double.TryParse(entrada, out _))
                {
                    Console.WriteLine("Error: debe ingresar texto, no un numero.");
                    esValido = false;
                }
                else
                {
                    esValido = true;
                }

            } while (!esValido);

            return entrada;
        }
                
        private string? LeerTextoOpcional(string mensaje)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(entrada)) return null;

            if (double.TryParse(entrada, out _))
            {
                Console.WriteLine("Error: debe ingresar texto, no un numero. Se mantiene el valor anterior.");
                return null;
            }

            return entrada;
        }
               
        private int? LeerEnteroOpcional(string mensaje)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(entrada)) return null;

            if (int.TryParse(entrada, out int valor)) return valor;

            Console.WriteLine("Error: debe ingresar un numero entero. Se mantiene el valor anterior.");
            return null;
        }
    }
}
