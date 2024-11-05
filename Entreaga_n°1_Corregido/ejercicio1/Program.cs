using System;
using System.Collections.Generic;

namespace ejercicio1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Creo el arbol y sus respectivos arbol-nodo (subArbol).
            ArbolBinario<int> a = new ArbolBinario<int>(1);
            ArbolBinario<int> b = new ArbolBinario<int>(2);
            ArbolBinario<int> c = new ArbolBinario<int>(3);
            ArbolBinario<int> d = new ArbolBinario<int>(4);
            ArbolBinario<int> e = new ArbolBinario<int>(5);
            ArbolBinario<int> f = new ArbolBinario<int>(6);
            ArbolBinario<int> g = new ArbolBinario<int>(7);

            a.agregarHijoIzquierdo(b); 
                                        //creamos la relacion-union, entre los nodos. 
            a.agregarHijoDerecho(c);


            b.agregarHijoIzquierdo(d);

            c.agregarHijoIzquierdo(e);
            c.agregarHijoDerecho(f);

            e.agregarHijoIzquierdo(g);

         
            (nuevo(a)).recorridoPorNiveles();// se hace uso del metodo nuevo(ArbolGeneral<int> arbol),
                                             // y a su vez se utiliza el recorrido Por Niveles 
                                             //para que imprima los valores del arbol y verificar
                                             //el correcto funcionamiento del metodo "nuevo(a)".
          
              
        }

        //Se corrigio la estructura empleada para Arbol(hijoIzquierdo e hijoDerecho). Los recorridos
        //preOrden, inOrden, postOrden: se resolvieron de manera recursiva para cumplir 
        //los requisitos. Debido a las peticiones del metodo "nuevo" que dan una complejidad
        //que evita una resolucion de manera recursiva directa y eficiente, insistiendo
        //en una solucion recursiva claro, se tuvo que obtar por una resolucion Iterativa
        //en el metodo "nuevo".
        public static ArbolBinario<int> nuevo(ArbolBinario<int> arbol)
        {
            // Caso base: Si el árbol original es null, retornamos null
            if (arbol == null)
            {
                return null;
            }

            // Crear la raíz del nuevo árbol
            ArbolBinario<int> nuevoArbol = new ArbolBinario<int>(arbol.getDatoRaiz());

            // Crear colas para realizar el recorrido de ambos árboles simultáneamente
            Cola<(ArbolBinario<int>, ArbolBinario<int>)> cola = new Cola<(ArbolBinario<int>, ArbolBinario<int>)>();
            cola.encolar((arbol, nuevoArbol));

            // Bucle para procesar cada nodo en el árbol original
            while (!cola.EstaVacia())
            {
                var (nodoOriginal, nodoNuevo) = cola.desencolar();

                // Procesamos el hijo izquierdo
                if (nodoOriginal.getHijoIzquierdo() != null)
                {
                    // Calculamos el valor del nuevo hijo izquierdo como la suma del nodo padre y el hijo izquierdo original
                    int nuevoValorIzquierdo = nodoOriginal.getDatoRaiz() + nodoOriginal.getHijoIzquierdo().getDatoRaiz();
                    ArbolBinario<int> nuevoHijoIzquierdo = new ArbolBinario<int>(nuevoValorIzquierdo);

                    // Lo agregamos al nuevo árbol y encolamos el par para el siguiente nivel
                    nodoNuevo.agregarHijoIzquierdo(nuevoHijoIzquierdo);
                    cola.encolar((nodoOriginal.getHijoIzquierdo(), nuevoHijoIzquierdo));
                }

                // Procesamos el hijo derecho
                if (nodoOriginal.getHijoDerecho() != null)
                {
                    // El hijo derecho se copia directamente
                    ArbolBinario<int> nuevoHijoDerecho = new ArbolBinario<int>(nodoOriginal.getHijoDerecho().getDatoRaiz());
                    nodoNuevo.agregarHijoDerecho(nuevoHijoDerecho);

                    // Encolamos el par para el siguiente nivel
                    cola.encolar((nodoOriginal.getHijoDerecho(), nuevoHijoDerecho));
                }
            }

            return nuevoArbol;
        }







    }
}
