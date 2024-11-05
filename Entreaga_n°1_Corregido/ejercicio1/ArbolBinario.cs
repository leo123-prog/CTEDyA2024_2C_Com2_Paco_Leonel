using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{

    public class ArbolBinario<T>
    {
        
        private T dato;
        private ArbolBinario<T> hijoIzquierdo;
        private ArbolBinario<T> hijoDerecho;


        public ArbolBinario(T dato)
        {
            this.dato = dato;

        }

        public void setear_raiz(T dato) //set al dato del nodo. 
        {
            this.dato = dato;
        }

       
         //retornamos el dato de la raiz.
        public T getDatoRaiz()
        {
            return this.dato;
        }

        public ArbolBinario<T> getHijoIzquierdo()
        {
            return this.hijoIzquierdo;
        }

        public ArbolBinario<T> getHijoDerecho()
        {
            return this.hijoDerecho;
        }


        public void agregarHijoIzquierdo(ArbolBinario<T> hijo)
        {
            this.hijoIzquierdo = hijo;
        }

        public void agregarHijoDerecho(ArbolBinario<T> hijo)
        {
            this.hijoDerecho = hijo;
        }


        public void eliminarHijoIzquierdo()
        {
            this.hijoIzquierdo = null;
        }

        public void eliminarHijoDerecho()
        {
            this.hijoDerecho = null;
        }

        public bool esHoja()
        {
            return this.hijoIzquierdo == null && this.hijoDerecho == null;
        }
        public void inorden()
        {
            if (this.hijoIzquierdo != null)
                this.hijoIzquierdo.inorden();

            Console.Write(this.dato + " ");

            if (this.hijoDerecho != null)
                this.hijoDerecho.inorden();

        }

        public void preorden()
        {
            Console.Write(this.dato + " ");

            if (this.hijoIzquierdo != null)
                this.hijoIzquierdo.preorden();


            if (this.hijoDerecho != null)
                this.hijoDerecho.preorden();

        }

        public void postorden()
        {

            if (this.hijoIzquierdo != null) 
            this.hijoIzquierdo.postorden();

            if (this.hijoDerecho != null) 
            this.hijoDerecho.postorden();

            Console.Write(this.dato + " ");
        }

        public void recorridoPorNiveles()
        {
            Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
            cola.encolar(this); // Empezamos con la raíz

            while (cola.cuantos() > 0)
            {
                ArbolBinario<T> actual = cola.desencolar();
                Console.Write(actual.getDatoRaiz()+" "); // Procesamos el nodo actual

                // Agregamos el hijo izquierdo si existe
                if (actual.getHijoIzquierdo() != null)
                {
                    cola.encolar(actual.getHijoIzquierdo());
                }

                // Agregamos el hijo derecho si existe
                if (actual.getHijoDerecho() != null)
                {
                    cola.encolar(actual.getHijoDerecho());
                }


            }
        }
        public int contarHojas()
        {
            if (this.esHoja())
            {
                return 1; // Si el nodo es hoja, devolvemos 1
            }

            int contador = 0;

            // Llamada recursiva al hijo izquierdo si existe
            if (this.getHijoIzquierdo() != null)
            {
                contador += this.getHijoIzquierdo().contarHojas();
            }

            // Llamada recursiva al hijo derecho si existe
            if (this.getHijoDerecho() != null)
            {
                contador += this.getHijoDerecho().contarHojas();
            }

            return contador;
        }

        public void recorridoEntreNiveles(int n, int m)
        {

            if (n > m || n < 0)
            {
                Console.WriteLine("Rango de niveles inválido.");
                return;
            }

            Cola<(ArbolBinario<T>, int)> cola = new Cola<(ArbolBinario<T>, int)>();
            cola.encolar((this, 0)); // Empezamos con la raíz en el nivel 0

            while (cola.cuantos() > 0)
            {
                var (nodoActual, nivel) = cola.desencolar();

                // Si estamos dentro del rango, imprimimos el dato
                if (nivel >= n && nivel <= m)
                {
                    Console.WriteLine(nodoActual.getDatoRaiz());
                }

                // Si el nivel actual es mayor que 'm', salimos, ya que no quedan niveles válidos por recorrer
                if (nivel > m)
                {
                    break;
                }

                // Agregar hijos al siguiente nivel
                if (nodoActual.getHijoIzquierdo() != null)
                {
                    cola.encolar((nodoActual.getHijoIzquierdo(), nivel + 1));
                }

                if (nodoActual.getHijoDerecho() != null)
                {
                    cola.encolar((nodoActual.getHijoDerecho(), nivel + 1));
                }
            }
        }
    
    }
}
