using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autolavado
{
    internal class Cliente
    {
        // Atributos
        protected int ID { get; set; }
        protected string Nombre { get; set; }
        protected string Apellido { get; set; }
        protected string Cédula { get; set; }
        protected string Tipo { get; set; }
        protected string Modelo { get; set; }
        protected string Placa { get; set; }
        protected int Servicio { get; set; }

        // Constructores de la clase
        public Cliente() { }

        public Cliente(int id, string nom, string ape, string ced, string tip, string mod, string pla, int serv)
        {
            this.ID = id;
            this.Nombre = nom;
            this.Apellido = ape;
            this.Cédula = ced;
            this.Tipo = tip;
            this.Modelo = mod;
            this.Placa = pla;
            this.Servicio = serv;
        }

        // Métodos de Get Set
        public int GetID()
        {
            return ID;
        }
        public string GetNombre()
        {
            return Nombre;
        }
        public string GetApellido()
        {
            return Apellido;
        }
        public string GetCédula()
        {
            return Cédula;
        }
        public string GetTipo()
        {
            return Tipo;
        }
        public string GetModelo()
        {
            return Modelo;
        }
        public string GetPlaca()
        {
            return Placa;
        }
        public int GetServicio()
        {
            return Servicio;
        }
        public void SetServicio(int servicio)
        {
            Servicio = servicio;
        }
    }
}
