using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica3
{
    class Objeto
    {
        /*Nombre del objeto*/
        private string nombre;
        /*valor del objeto*/
        private int valor;
        /*peso del objeto*/
        private int peso;


        /*consturcutor sin parametros*/
        public Objeto()
        {

        }
        /*Constructor parametrizado*/
        public Objeto(string nombre, int valor, int peso)
        {
            this.nombre = nombre;   /*actualiza el nombre*/
            this.valor = valor;     /**/
            this.peso = peso;

        }
        /*actualiza el nombre del objeto*/
        public void Set_nombre(string nombre)
        {
            this.nombre = nombre;
        }
        /*devuelve el nombre del objeto*/
        public string Get_nombre()
        {
            return this.nombre;
        }
        /*actualiza el valor del objeto*/
        public void Set_valor(int valor)
        {
            this.valor = valor;
        }
        /*devuelve el valor del objeto*/
        public int Get_valor()
        {
            return this.valor;
        }
        /*actualiza el peso delp objeto*/
        public void Set_peso(int peso)
        {
            this.peso = peso;
        }
        /*devuelve el peso del objeto*/
        public int Get_peso()
        {
            return this.peso;
        }
    }
}
