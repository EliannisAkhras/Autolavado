using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autolavado
{
    internal class Servicio
    {
        // Atributos
        protected int Inicio { get; set; }
        protected int Fin { get; set; }
        protected int Cantidad { get; set; }
        protected int Máximo { get; set; }
        protected Cliente[] Clientes { get; set; }

        // Constructor de la clase
        public Servicio(int max)
        {
            Inicio = 0;
            Fin = max - 1;
            Cantidad = 0;
            Máximo = max;
            Clientes = new Cliente[max];
        }

        // Métodos de Colas
        private int Siguiente(int r)
        {
            return (r + 1) % Máximo;
        }
        private int Anterior(int r)
        {
            return (r - 1) % Máximo;
        }
        public bool ColaVacía()
        {
            return Cantidad == 0;
        }
        public bool ColaLlena()
        {
            return Cantidad == Máximo;
        }

        // Métodos de Citas
        public void AgendarCita(Cliente cliente)
        {
            Fin = Siguiente(Fin);
            Clientes[Fin] = cliente;
            Cantidad++;
            Console.WriteLine("Se ha agendado una cita para {0} {1} en el servicio seleccionado.",
                cliente.GetNombre(), cliente.GetApellido());
            Console.ReadKey();
        }

        public Cliente AtenderCliente()
        {
            if (ColaVacía())
            {
                Console.WriteLine("No hay clientes en espera en este servicio.");
                Console.ReadKey();
                return null;
            }

            Cliente atendido = Clientes[Inicio];
            Console.WriteLine("Se ha completado el servicio de {0} {1}.",
                atendido.GetNombre(), atendido.GetApellido());
            Console.ReadKey();
            Inicio = Siguiente(Inicio);
            Cantidad--;
            return atendido;
        }

        public int Cauchos()
        {
            return Clientes[Inicio].GetID();
        }

        public void CancelarCita(Cliente cliente)
        {
            int posición = Array.FindIndex(Clientes, c => c == cliente);

            List<Cliente> quitador = new(Clientes);
            quitador.Remove(cliente);
            Clientes = quitador.ToArray();

            Inicio = Siguiente(Inicio);
            Fin = Anterior(Fin);
            Cantidad--;
            Console.WriteLine("Se ha cancelado la cita de {0} {1}.",
                cliente.GetNombre(), cliente.GetApellido());
            Console.ReadKey();
        }

        public void ListarClientes()
        {
            if (!ColaVacía())
            {
                int cont = 1;

                if (Inicio <= Fin)
                    for (int i = Inicio; i <= Fin; i++, cont++)
                    {
                        Console.WriteLine("\n - Cliente {0}: {1} {2}",
                            cont, Clientes[i].GetNombre(), Clientes[i].GetApellido());
                        Console.WriteLine("\n ID Membresía: {0}", Clientes[i].GetID());
                        Console.WriteLine("\n Cédula de Identidad: {0}", Clientes[i].GetCédula());
                        Console.WriteLine("\n Tipo de Vehículo: {0}", Clientes[i].GetTipo());
                        Console.WriteLine("\n Modelo del Vehículo: {0}", Clientes[i].GetModelo());
                        Console.WriteLine("\n Placa del Vehículo: {0}", Clientes[i].GetPlaca());
                    }

                else
                {
                    for (int i = Inicio; i <= Máximo; i++, cont++)
                    {
                        Console.WriteLine("\n - Cliente {0}: {1} {2}",
                            cont, Clientes[i].GetNombre(), Clientes[i].GetApellido());
                        Console.WriteLine("\n ID Membresía: {0}", Clientes[i].GetID());
                        Console.WriteLine("\n Cédula de Identidad: {0}", Clientes[i].GetCédula());
                        Console.WriteLine("\n Tipo de Vehículo: {0}", Clientes[i].GetTipo());
                        Console.WriteLine("\n Modelo del Vehículo: {0}", Clientes[i].GetModelo());
                        Console.WriteLine("\n Placa del Vehículo: {0}", Clientes[i].GetPlaca());
                    }

                    for (int i = 0; i <= Fin; i++, cont++)
                    {
                        Console.WriteLine("\n - Cliente {0}: {1} {2}",
                            cont, Clientes[i].GetNombre(), Clientes[i].GetApellido());
                        Console.WriteLine("\n ID Membresía: {0}", Clientes[i].GetID());
                        Console.WriteLine("\n Cédula de Identidad: {0}", Clientes[i].GetCédula());
                        Console.WriteLine("\n Tipo de Vehículo: {0}", Clientes[i].GetTipo());
                        Console.WriteLine("\n Modelo del Vehículo: {0}", Clientes[i].GetModelo());
                        Console.WriteLine("\n Placa del Vehículo: {0}", Clientes[i].GetPlaca());
                    }
                }
            }

            else
                Console.WriteLine("No hay clientes en espera por este servicio.");
            Console.ReadKey();


        }

        public int PosiciónEspera(Cliente cliente)
        {
            return Array.FindIndex(Clientes, c => c == cliente) + 1;
        }
    }
}
