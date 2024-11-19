using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autolavado
{
    internal class Pila
    {
        // Atributos
        protected int Tope { get; set; }
        protected string[] Cauchos { get; set; }

        // Constructor de la clase
        public Pila()
        {
            this.Tope = -1;
            this.Cauchos = new string[4];
        }

        // Métodos de Pilas
        public bool PilaVacía()
        {
            return Tope == -1;
        }

        public string VerIDTope()
        {
            return Cauchos[Tope].Remove(Cauchos[Tope].Length-1);
        }

        // Métodos de Cauchos
        public void EntrarPila(int id)
        {
            if (!PilaVacía())
            {
                Console.WriteLine("No se pueden balancear más cauchos.");
                Console.ReadKey();
                return;
            }

            Tope = 3;
            for (int i = 0; i < 4; i++)
                Cauchos[i] = id.ToString() + (i + 1);
            Console.WriteLine("Se añadieron los cauchos del cliente con ID #{0} al proceso de balaceo.", id);
            Console.ReadKey();
        }

        public int BalancearCauchos()
        {
            if (PilaVacía())
            {
                Console.WriteLine("No hay cauchos para balancear.");
                Console.ReadKey();
                return 0;
            }

            int nCaucho = int.Parse(Cauchos[Tope].Last().ToString());
            Console.WriteLine("Se balanceó el caucho #{0} del vehículo.", nCaucho);
            Console.ReadKey();
            Tope--;
            return nCaucho;
        }
    }
}
