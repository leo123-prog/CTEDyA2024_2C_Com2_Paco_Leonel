using System;
using System.Collections.Generic;

namespace ejercicio1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Creo el arbol y sus respectivos arbol-nodo (subArbol).
            ArbolGeneral<int> a = new ArbolGeneral<int>(1);
            ArbolGeneral<int> b = new ArbolGeneral<int>(2);
            ArbolGeneral<int> c = new ArbolGeneral<int>(3);
            ArbolGeneral<int> d = new ArbolGeneral<int>(4);
            ArbolGeneral<int> e = new ArbolGeneral<int>(5);
            ArbolGeneral<int> f = new ArbolGeneral<int>(6);
            ArbolGeneral<int> g = new ArbolGeneral<int>(7);

            a.agregarHijo(b); //Al agregar al arbol dentro de la lista del arbol raiz
                              //creamos la relacion-union, y si con cada subArbol y sus hijos. 
            a.agregarHijo(c);

            b.agregarHijo(d);

            c.agregarHijo(e);
            c.agregarHijo(f);

            e.agregarHijo(g);

         
            (nuevo(a)).recorridoPorNiveles();// se hace uso del metodo nuevo(ArbolGeneral<int> arbol),
                                             // y a su vez se utiliza el recorrido Por Niveles 
                                             //para que imprima los valores del arbol y verificar
                                             //el correcto funcionamiento del metodo "nuevo(a)".
          
                              
         

        }
        //Metodo solicitado. 
        public static ArbolGeneral<int> nuevo(ArbolGeneral<int> arbol)
        {
   
            ArbolGeneral<int> nuevoArbol = new ArbolGeneral<int>(arbol.getDatoRaiz());

          
            if (arbol.getHijos().Count > 0)
            {
                ArbolGeneral<int> hijoIzquierdo = arbol.getHijos()[0];

                int nuevoValorIzquierdo = arbol.getDatoRaiz() + hijoIzquierdo.getDatoRaiz();

                ArbolGeneral<int> nuevoHijoIzquierdo = new ArbolGeneral<int>(nuevoValorIzquierdo);

                // Recursión para seguir aplicando la lógica a los hijos
                nuevoHijoIzquierdo.setHijos(nuevo(hijoIzquierdo).getHijos());

                // Agregar el nuevo hijo izquierdo al nuevo árbol
                nuevoArbol.agregarHijo(nuevoHijoIzquierdo);
            }

            // Verificar si tiene hijo derecho (posición 1 en la lista)
            if (arbol.getHijos().Count > 1)
            {
                ArbolGeneral<int> hijoDerecho = arbol.getHijos()[1];

                // Copiar el hijo derecho tal cual (sin suma)
                ArbolGeneral<int> nuevoHijoDerecho = nuevo(hijoDerecho);

                // Agregar el nuevo hijo derecho al nuevo árbol
                nuevoArbol.agregarHijo(nuevoHijoDerecho);
            }

            return nuevoArbol;
        }





    }
}
