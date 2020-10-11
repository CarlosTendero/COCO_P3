using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica3
{
    class Program
    {
        static void Main(string[] args)
        {

            /*No fraccionables*/

            Objeto[] objetos_mochilas = { new Objeto("A", 2, 1), new Objeto("B", 4, 2), new Objeto("C", 6, 4), new Objeto("D", 12, 5), new Objeto("E", 14, 7), new Objeto("F",16,8) };
            int capmax = 8; /*peso maximo*/

            int[,] T = new int[objetos_mochilas.GetLength(0),capmax+1];     /*tabla T donde se guardan losvalores de los objetos en relacion al peso*/
            int[,] E = new int[objetos_mochilas.GetLength(0),capmax+1];     /*tabla E donde se guardan los estados*/

            int[] S = new int[objetos_mochilas.GetLength(0)];

            /*Se muestran los objetos*/

            Console.Write("Nombre: ");
            for (int i = 0; i < objetos_mochilas.GetLength(0); i++)
                Console.Write("\t " + objetos_mochilas[i].Get_nombre());            /*Nombres*/
            Console.WriteLine();
            Console.Write("Valor:\t ");
            for (int i = 0; i < objetos_mochilas.GetLength(0); i++)
                Console.Write("\t " + objetos_mochilas[i].Get_valor());             /*Valor*/
            Console.WriteLine();
            Console.Write("Peso: \t");
            for (int i = 0; i < objetos_mochilas.GetLength(0); i++)
                Console.Write("\t " + objetos_mochilas[i].Get_peso() + "kg");       /*Peso*/


            Console.WriteLine("\n\n\n\n");


            
            /*Valor de la mochila*/

            /*Se cargan las tablas T y E*/
            ProblemaMochilaValor(capmax, objetos_mochilas, ref T, ref E);
            /*Se muestra la tabla T*/
            Console.WriteLine("Valor de la mochila: ");
            for (int i = 0; i < T.GetLength(0); i++)
            {
                Console.Write("[" + i + "]");
                for (int j = 0; j <= capmax; j++)
                {
                    Console.Write("\t " + T[i, j]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\n\n\n\n");
            /*Se muestra la tabla E*/
            Console.WriteLine("Estados: ");
            for (int i = 0; i < E.GetLength(0); i++)
            {
                Console.Write("[" + i + "]");
                for (int j = 0; j <= capmax; j++)
                {
                    Console.Write("\t " + E[i, j]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine();
            /*Se muestra el valor y el peso*/
            Console.WriteLine("Mochila con P = " + capmax + " Y valor = " + T[objetos_mochilas.GetLength(0)-1, capmax] + "\n");


            /* Vemos los objetos de la mochila */

            ObjetosDentro(capmax, objetos_mochilas, ref E, ref S);
            /*Se muestran los objetos*/
            for(int i = 0; i < S.GetLength(0); i++)
            {
                if(S[i] == 1)
                {
                    Console.WriteLine("Objeto " + objetos_mochilas[i].Get_nombre() + " de peso = " + objetos_mochilas[i].Get_peso() + " y valor = " + objetos_mochilas[i].Get_valor());
                }
            }

            Console.ReadKey();
            /*Estados*/
        }
        /*  Funcion : ObjetosDentro
         *  Descripcion: Funcion que a traves de la tabla de estados es capaz de llenar la mochila en funcion del valor de la forma mas optima posible
         *  Entrada:
         *  int capacidad: variable de tipo int, es la la capacidad maxima que tiene la mochila para almacenar
         *  Objeto[] objetos : array de objetos
         *  ref int [,] E: tabla de estados de los objetos de la mochila
         *  ref int [] S: tabla donde se almacen valores 1 o 0 que indica si el objeto se va a introducir dentro de la mochila o no 
         */
        static void ObjetosDentro(int capacidad, Objeto[] objetos, ref int[,] E, ref int[] S)
        {

            int i = 0;  

            for (i = 0; i < objetos.GetLength(0) - 1; i++) {
                S[i] = 0;       /*inicializamos el veector S a 0*/
            }

            while(i != 0 || capacidad != 0) /**/
            {
                if (E[i,capacidad] == 0)    /*No esta*/
                {
                    i = i - 1;
                }
                else                       /*Si esta*/
                {
                    S[i] = 1;
                    capacidad = capacidad - objetos[i].Get_peso();  /*actuliza la capacidad*/
                }
            }

        }
        /*  Funcion: ProblemaMochilaValor
         *  Descripcion: Carga las tablas T y E
         *  Entradas:
         *  int capacidad: variable int que guarda la capacidad maxima de la mochila
         *  Objeto[] objetos: array de objetos a alamcenar en la mochila
         *  ref int [,] T: Tabla donde se guardan los valores de los objetos en relacion al peso
         *  ref int [,] E: Tabla de estados
         * 
         */
        static void ProblemaMochilaValor(int capacidad, Objeto[] objetos, ref int[,] T, ref int[,] E)
        {
            int total_objetos = objetos.GetLength(0);       /*total de objetos*/
            T = new int[total_objetos, capacidad + 1];      /*Tabla T*/
            E = new int[total_objetos, capacidad + 1];      /*Tabla E*/

            for (int i = 0; i < total_objetos; i++)
                T[i, 0] = 0;    /*columna 0*/
            for (int j = 1; j <= capacidad; j++)    /* Fila 0 */
            {
                T[0, j] = objetos[0].Get_valor();
                E[0, j] = 1;
            }
            for (int i = 1; i < total_objetos; i++)
            {
                for (int j = 1; j <= capacidad; j++)
                {
                    if (objetos[i].Get_peso() > j)
                    {
                        T[i, j] = T[i - 1, j];  /*copiar anteriores*/
                        E[i, j] = 0;
                    }
                    else
                    {
                        if (T[i - 1, j] > T[i - 1, j - objetos[i].Get_peso()] + objetos[i].Get_valor())
                            T[i, j] = T[i - 1, j];
                        else
                            T[i, j] =  T[i-1, j - objetos[i].Get_peso()] + objetos[i].Get_valor();

                        E[i, j] = (T[i, j] == T[i - 1, j]) ? 0 : 1;
                    }
                }
            }

        }

    }
}
