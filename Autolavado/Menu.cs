using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autolavado
{
    internal class Menu
    {
        public static void MostrarMenu()
        {
            string opcion, servicio;
            bool isValid;
            int iterador, id = 0;
            Cliente seleccionado;
            Servicio aspirado, autolavado, secado, aceite, balanceo;
            aspirado = new Servicio(10);
            autolavado = new Servicio(10);
            secado = new Servicio(10);
            aceite = new Servicio(5);
            balanceo = new Servicio(5);
            Pila pilaBalanceo = new();
            List<Cliente> listaClientes = new();
            Queue<Factura> pagos = new();

            do
            {
                Console.Clear();

                Console.WriteLine("\n MENÚ DE OPCIONES ");
                Console.WriteLine("\n (A) Registrar un cliente");
                Console.WriteLine("\n (B) Modificar datos de un cliente");
                Console.WriteLine("\n (C) Eliminar un cliente");
                Console.WriteLine("\n (D) Asignar cita de un cliente a un servicio");
                Console.WriteLine("\n (E) Atender un cliente en un servicio");
                Console.WriteLine("\n (F) Balancear caucho");
                Console.WriteLine("\n (G) Cancelar una cita de un cliente de un servicio");
                Console.WriteLine("\n (H) Listar los clientes que se encuentran en espera por un servicio");
                Console.WriteLine("\n (I) Consultar datos de un cliente que se encuentra en espera por un servicio");
                Console.WriteLine("\n (J) Pagar y generar factura");
                Console.WriteLine("\n (K) Salir");
                Console.Write("\n Opción: ");
                opcion = Console.ReadLine().ToUpper();

                switch (opcion)
                {
                    case "A":
                        Console.Clear();
                        string nom, ape, ced, tip, mod, pla;
                        id++;

                        do
                        {
                            Console.WriteLine("Ingrese el nombre del cliente: ");
                            nom = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(nom));

                        do
                        {
                            Console.WriteLine("Ingrese el apellido del cliente: ");
                            ape = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(ape));

                        do
                        {
                            Console.WriteLine("Ingrese la cédula del cliente: ");
                            ced = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(ced));

                        do
                        {
                            Console.WriteLine("Ingrese el tipo de vehículo del cliente (auto o camioneta): ");
                            tip = Console.ReadLine().ToLower();
                        } while (string.IsNullOrWhiteSpace(tip) || (tip != "auto" && tip != "camioneta"));

                        do
                        {
                            Console.WriteLine("Ingrese el modelo del vehículo del cliente: ");
                            mod = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(mod));

                        do
                        {
                            Console.WriteLine("Ingrese la placa del vehículo del cliente: ");
                            pla = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(pla));

                        listaClientes.Add(new(id, nom, ape, ced, tip, mod, pla, 0));
                        Console.WriteLine("Registro exitoso. Su ID de membresía es: " + id);
                        Console.ReadKey();
                        break;

                    case "B":
                        Console.Clear();
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            Console.WriteLine("Ingrese el ID de membresía del cliente a modificar: ");
                            isValid = int.TryParse(Console.ReadLine(), out iterador);
                        } while (!isValid);

                        int posición = listaClientes.FindIndex(c => c.GetID() == iterador);
                        if (posición == -1)
                        {
                            Console.WriteLine("No hay clientes con ese ID de membresía.");
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            Console.WriteLine("Ingrese el nuevo nombre del cliente: ");
                            nom = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(nom));

                        do
                        {
                            Console.WriteLine("Ingrese el nuevo apellido del cliente: ");
                            ape = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(ape));

                        do
                        {
                            Console.WriteLine("Ingrese la nueva cédula del cliente: ");
                            ced = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(ced));

                        do
                        {
                            Console.WriteLine("Ingrese el nuevo tipo de vehículo del cliente (auto o camioneta): ");
                            tip = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(tip) || (tip != "auto" && tip != "camioneta"));

                        do
                        {
                            Console.WriteLine("Ingrese el nuevo modelo del vehículo del cliente: ");
                            mod = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(mod));

                        do
                        {
                            Console.WriteLine("Ingrese la nueva placa del vehículo del cliente: ");
                            pla = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(pla));

                        listaClientes[posición] = new(iterador, nom, ape, ced, tip, mod, pla, 0);
                        break;

                    case "C":
                        Console.Clear();
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            Console.WriteLine("Ingrese el ID de membresía del cliente a eliminar: ");
                            isValid = int.TryParse(Console.ReadLine(), out iterador);
                        } while (!isValid);

                        seleccionado = listaClientes.SingleOrDefault(e => e.GetID() == iterador);
                        if (seleccionado == null)
                        {
                            Console.WriteLine("No hay clientes con ese ID de membresía.");
                            Console.ReadKey();
                            return;
                        }

                        if (seleccionado.GetServicio() != 0)
                        {
                            Console.WriteLine("Este cliente ya está haciendo uso de un servicio, asi que no se puede eliminar.");
                            Console.ReadKey();
                            break;
                        }

                        listaClientes.Remove(seleccionado);
                        Console.WriteLine("El cliente {0} {1} ha sido eliminado." , seleccionado.GetNombre(), seleccionado.GetApellido());
                        Console.ReadKey();
                        break;

                    case "D":
                        Console.Clear();
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            Console.WriteLine("Ingrese el ID de membresía del cliente a asignar cita: ");
                            isValid = int.TryParse(Console.ReadLine(), out iterador);
                        } while (!isValid);

                        seleccionado = listaClientes.SingleOrDefault(e => e.GetID() == iterador);
                        if (seleccionado == null)
                        {
                            Console.WriteLine("No hay clientes con ese ID de membresía.");
                            Console.ReadKey();
                            return;
                        }

                        if (seleccionado.GetServicio() != 0)
                        {
                            Console.WriteLine("Este cliente ya está haciendo uso de un servicio.");
                            Console.ReadKey();
                            break;
                        }
                        iterador = listaClientes.FindIndex(c => c == seleccionado);

                        Console.WriteLine("Seleccione un servicio:\n\n");
                        Console.WriteLine("(1) Aspirado\n");
                        Console.WriteLine("(2) Autolavado\n");
                        Console.WriteLine("(3) Secado\n");
                        Console.WriteLine("(4) Cambio de aceite\n");
                        Console.WriteLine("(5) Balanceo\n");
                        Console.Write("\n Opción: ");
                        servicio = Console.ReadLine();

                        switch (servicio)
                        {
                            case "1":
                                if (aspirado.ColaLlena())
                                {
                                    Console.WriteLine("No hay cupos de atención disponibles para aspirado.");
                                    Console.ReadKey();
                                    break;
                                }
                                aspirado.AgendarCita(seleccionado);
                                listaClientes[iterador].SetServicio(1);
                                break;

                            case "2":
                                if (autolavado.ColaLlena())
                                {
                                    Console.WriteLine("No hay cupos de atención disponibles para autolavado.");
                                    Console.ReadKey();
                                    break;
                                }
                                autolavado.AgendarCita(seleccionado);
                                listaClientes[iterador].SetServicio(2);
                                break;

                            case "3":
                                if (secado.ColaLlena())
                                {
                                    Console.WriteLine("No hay cupos de atención disponibles para secado.");
                                    Console.ReadKey();
                                    break;
                                }
                                secado.AgendarCita(seleccionado);
                                listaClientes[iterador].SetServicio(3);
                                break;

                            case "4":
                                if (aceite.ColaLlena())
                                {
                                    Console.WriteLine("No hay cupos de atención disponibles para cambio de aceite.");
                                    Console.ReadKey();
                                    break;
                                }
                                aceite.AgendarCita(seleccionado);
                                listaClientes[iterador].SetServicio(4);
                                break;

                            case "5":
                                if (balanceo.ColaLlena())
                                {
                                    Console.WriteLine("No hay cupos de atención disponibles para balanceo.");
                                    Console.ReadKey();
                                    break;
                                }
                                balanceo.AgendarCita(seleccionado);
                                listaClientes[iterador].SetServicio(5);
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }

                        break;

                    case "E":
                        Console.Clear();
                        string atender;
                        do
                        {
                            Console.WriteLine("Ingrese el servicio del cliente a atender: ");
                            atender = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(atender));


                        seleccionado = null;
                        switch (atender.ToLower())
                        {
                            case "aspirado":
                                seleccionado = aspirado.AtenderCliente();
                                break;

                            case "autolavado":
                                seleccionado = autolavado.AtenderCliente();
                                break;

                            case "secado":
                                seleccionado = secado.AtenderCliente();
                                break;

                            case "cambio de aceite":
                                seleccionado = aceite.AtenderCliente();
                                break;

                            case "balanceo":
                                pilaBalanceo.EntrarPila(balanceo.Cauchos());
                                break;

                            default:
                                Console.WriteLine("Opción inválida");
                                Console.ReadKey();
                                break;
                        }

                        if (seleccionado != null)
                        {
                            Factura nueva = new();
                            iterador = 1;
                            if (pagos.Count > 0 && pagos.Peek().GetID() == seleccionado.GetID())
                                iterador = pagos.Peek().GetItem() + 1;
                            pagos.Enqueue(nueva.RegistrarPago(seleccionado, iterador));
                            iterador = listaClientes.FindIndex(c => c == seleccionado);
                            listaClientes[iterador].SetServicio(0);
                        }
                        break;

                    case "F":
                        Console.Clear();
                        iterador = pilaBalanceo.BalancearCauchos();
                        if (iterador == 1)
                        {
                            Factura nueva = new();
                            iterador = 1;
                            seleccionado = balanceo.AtenderCliente();
                            if (pagos.Count > 1 && pagos.Peek().GetID() == seleccionado.GetID())
                                iterador = pagos.Peek().GetItem() + 1;
                            pagos.Enqueue(nueva.RegistrarPago(seleccionado, iterador));
                            iterador = listaClientes.FindIndex(c => c == seleccionado);
                            listaClientes[iterador].SetServicio(0);
                        }
                        break;

                    case "G":
                        Console.Clear();
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            Console.WriteLine("Ingrese el ID de membresía del cliente a cancelar cita: ");
                            isValid = int.TryParse(Console.ReadLine(), out iterador);
                        } while (!isValid);

                        seleccionado = listaClientes.SingleOrDefault(e => e.GetID() == iterador);
                        if (seleccionado == null)
                        {
                            Console.WriteLine("No hay clientes con ese ID de membresía.");
                            Console.ReadKey();
                            return;
                        }

                        if (seleccionado.GetServicio() == 0)
                        {
                            Console.WriteLine("Este cliente no está haciendo uso de ningún servicio.");
                            Console.ReadKey();
                            break;
                        }

                        switch (seleccionado.GetServicio())
                        {
                            case 1:
                                aspirado.CancelarCita(seleccionado);
                                break;

                            case 2:
                                autolavado.CancelarCita(seleccionado);
                                break;

                            case 3:
                                secado.CancelarCita(seleccionado);
                                break;

                            case 4:
                                aceite.CancelarCita(seleccionado);
                                break;

                            case 5:
                                if (seleccionado.GetID().ToString() == pilaBalanceo.VerIDTope())
                                {
                                    Console.WriteLine("No se pueden cancelar citas de clientes con cauchos de balanceo. ");
                                    Console.ReadKey();
                                    break;
                                }
                                balanceo.CancelarCita(seleccionado);
                                break;
                        }

                        iterador = listaClientes.FindIndex(c => c == seleccionado);
                        listaClientes[iterador].SetServicio(0);
                        break;

                    case "H":
                        Console.Clear();
                        Console.WriteLine("Vehículos en espera por servicio...\n\n");

                        Console.WriteLine("\n► Aspirado:\n");
                        aspirado.ListarClientes();

                        Console.WriteLine("\n► Autolavado:\n");
                        autolavado.ListarClientes();

                        Console.WriteLine("\n► Secado:\n");
                        secado.ListarClientes();

                        Console.WriteLine("\n► Cambio de aceite:\n");
                        aceite.ListarClientes();

                        Console.WriteLine("\n► Balanceo:\n");
                        balanceo.ListarClientes();
                        break;

                    case "I":
                        Console.Clear();
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                            Console.ReadKey();
                            break;
                        }

                        do
                        {
                            Console.WriteLine("Ingrese el ID de membresía del cliente a consultar en un servicio: ");
                            isValid = int.TryParse(Console.ReadLine(), out iterador);
                        } while (!isValid);

                        seleccionado = listaClientes.SingleOrDefault(e => e.GetID() == iterador);
                        if (seleccionado == null)
                        {
                            Console.WriteLine("No hay clientes con ese ID de membresía.");
                            Console.ReadKey();
                            return;
                        }

                        if (seleccionado.GetServicio() == 0)
                        {
                            Console.WriteLine("Este cliente no está haciendo uso de ningún servicio.");
                            Console.ReadKey();
                            break;
                        }

                        servicio = "";
                        switch (seleccionado.GetServicio())
                        {
                            case 1:
                                iterador = aspirado.PosiciónEspera(seleccionado);
                                servicio = "aspirado";
                                break;

                            case 2:
                                iterador = autolavado.PosiciónEspera(seleccionado);
                                servicio = "autolavado";
                                break;

                            case 3:
                                iterador = secado.PosiciónEspera(seleccionado);
                                servicio = "secado";
                                break;

                            case 4:
                                iterador = aceite.PosiciónEspera(seleccionado);
                                servicio = "cambio de aceite";
                                break;

                            case 5:
                                iterador = balanceo.PosiciónEspera(seleccionado);
                                servicio = "balanceo";
                                break;
                        }
                        Console.Write("El cliente está agendado en el servicio de {0} " +
                            "y está en la posición #{1}", servicio, iterador);
                        Console.ReadKey();
                        break;

                    case "J":
                        Console.Clear();
                        if (pagos.Count == 0)
                        {
                            Console.WriteLine("No hay clientes que hayan sido atendidos.");
                            Console.ReadKey();
                            break;
                        }
                        Factura aPagar = pagos.Peek();
                        pagos = aPagar.GenerarFactura(pagos);
                        break;

                    case "K":
                        Console.WriteLine("Salió del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            } while (opcion != "K");
        }
    }
}
