using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autolavado
{
     class Factura : Cliente //herencia con cliente.
     { 
        // Atributos
        protected int Item { get; set; }
        protected string Compra { get; set; }
        protected float Monto { get; set; }

        // Constructores de la clase
        public Factura() { }

        // Métodos de Get Set
        private void SetComprador(Cliente comprador)
        {
            this.ID = comprador.GetID();
            this.Nombre = comprador.GetNombre();
            this.Apellido = comprador.GetApellido();
            this.Cédula = comprador.GetCédula();
            this.Tipo = comprador.GetTipo();
            this.Modelo = comprador.GetModelo();
            this.Placa = comprador.GetPlaca();
            this.Servicio = comprador.GetServicio();
        }
        public int GetItem()
        {
            return Item;
        }
        private void SetItem(int item)
        {
            Item = item;
        }
        public string GetCompra()
        {
            return Compra;
        }
        private void SetCompra(string compra)
        {
            Compra = compra;
        }
        public float GetMonto()
        {
            return Monto;
        }
        private void SetMonto(float monto)
        {
            Monto = monto;
        }

        //Métodos de Pago
        public Factura RegistrarPago(Cliente comprador, int item)
        {
            string servicio = "", vehículo = comprador.GetTipo();
            float monto = 0;

            switch (comprador.GetServicio())
            {
                case 1:
                    servicio = "Aspirado        ";
                    if (vehículo == "auto") monto = 4;
                    else monto = 6;
                    break;

                case 2:
                    servicio = "Autolavado      ";
                    if (vehículo == "auto") monto = 6;
                    else monto = 10;
                    break;

                case 3:
                    servicio = "Secado          ";
                    if (vehículo == "auto") monto = 4;
                    else monto = 5;
                    break;

                case 4:
                    servicio = "Cambio de aceite";
                    if (vehículo == "auto") monto = 15;
                    else monto = 20;
                    break;

                case 5:
                    servicio = "Balanceo        ";
                    if (vehículo == "auto") monto = 25;
                    else monto = 35;
                    break;
            }

            SetComprador(comprador);
            SetCompra(servicio);
            SetMonto(monto);
            SetItem(item);

            return this;
        }

        public Queue<Factura> GenerarFactura(Queue<Factura> pagos)
        {
            Queue<Factura> nuevosPagos = new();
            float total = 0;
            int compradorID = pagos.Peek().GetID();
            Console.WriteLine("Cliente: {0} {1}\tCédula: {2}\tPlaca: {3}\tVehículo: {4}",
                GetNombre(), GetApellido(), GetCédula(), GetPlaca(), GetModelo());
            Console.WriteLine("\n  Ítem\t\tServicio\t\tMonto\n");

            do
            {
                Factura comprador = pagos.Dequeue();

                if (comprador.GetID() == compradorID)
                {
                    Console.WriteLine("  {0}\t\t{1}\t\t{2}\n", comprador.GetItem(),
                        comprador.GetCompra(), comprador.GetMonto());
                    total += comprador.GetMonto();
                }
                else
                    nuevosPagos.Enqueue(comprador);
            } while (pagos.Count > 0);

            Console.WriteLine("\t\t\t\t\tTotal: " + total);
            Console.ReadKey();
            return nuevosPagos;
        }
    }
}
