using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{

    public class ArbolGeneral<T>
    {
        private T dato;
        private List<ArbolGeneral<T>> hijos;
    

    public ArbolGeneral(T dato)
        {
            this.dato = dato;
            this.hijos = new List<ArbolGeneral<T>>();

        }

        public void setear_raiz(T dato) //set al dato del nodo. 
        {
            this.dato = dato;
        }

        public T getDatoRaiz() //retornamos el dato de la raiz.
        {
            return this.dato;
        }

        public List<ArbolGeneral<T>> getHijos()
        {
            return hijos;
        }
       
        public void setHijos(List<ArbolGeneral<T>> l)
        {
             this.hijos=l;
        }

        public void agregarHijo(ArbolGeneral<T> hijo)
        {
            this.getHijos().Add(hijo);
        }

        public void eliminarHijo(ArbolGeneral<T> hijo)
        {
            this.getHijos().Remove(hijo);
        }

        public bool esHoja()
        {
            return this.getHijos().Count == 0;
        }

        public void inorden()
        {
            if (hijos.Count > 0)
            {
                
                hijos[0].inorden(); // Recorrer el primer hijo si existe
            }

           
            Console.Write(this.dato + " "); // Luego imprimir el valor del nodo actual (raíz)

           
            if (hijos.Count > 1)  // Recorrer el segundo hijo si existe
            {
                hijos[1].inorden();
            }


        }

        public void preorden()
        {
            Console.Write(this.dato + " ");//Primero retornamos el dato de la Raiz

           
            foreach (var hijo in hijos) // Luego recorrer recursivamente cada hijo
            {
                hijo.preorden();
            }


        }

        public void postorden()
        {
            
            foreach (var hijo in hijos) // Primero recorrer recursivamente cada hijo
            {
                hijo.postorden();
            }

            
            Console.Write(this.dato + " "); // Luego imprimir el valor del nodo actual
        }

        public void recorridoPorNiveles()
        {
            Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
            cola.encolar(this);

            while (cola.cuantos() > 0)
            {
                ArbolGeneral<T> actual = cola.desencolar();
                Console.Write(actual.dato + " ");

                foreach (var hijo in actual.hijos) // Encolar los hijos del nodo actual
                {
                    cola.encolar(hijo);
                }
            }


        }

        public int contarHojas()
        {
            if (this.esHoja())
            {
                return 1; // Si es hoja, devolvemos 1
            }

            int contador = 0;
            foreach (var hijo in hijos)
            {
                contador += hijo.contarHojas(); // Llamada recursiva para contar las hojas de los hijos
            }

            return contador;
        }

        public void recorridoEntreNiveles(int n, int m)
        {
            if (n >= m) return; // Si n es mayor o igual que m, no hay niveles para recorrer.

            Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
            cola.encolar(this);
            int nivelActual = 0;

            while (cola.cuantos() > 0)
            {
                int cantidadNodosNivel = cola.cuantos();

                for (int i = 0; i < cantidadNodosNivel; i++)
                {
                    ArbolGeneral<T> actual = cola.desencolar();

                    
                    if (nivelActual > n && nivelActual < m) // Si estamos en un nivel que está entre n y m, imprimir el dato
                    {
                        Console.Write(actual.getDatoRaiz() + " ");
                    }

                    
                    foreach (var hijo in actual.getHijos())// Encolar los hijos del nodo actual
                    {
                        cola.encolar(hijo);
                    }
                }

                nivelActual++; // Aumentar el nivel después de procesar todos los nodos de este nivel
            }
        }
    }
}
