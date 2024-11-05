using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace entrega_n6
{ 
//   Para resolver el ejercicio se uso una variante de exploracion de grafo DFS, 
//        como resultado, el algoritmo entrega los caminos posibles, y resalta en la 
//        siguiente linea el mas correcto. 
    class program
    {
        public static void Main(string[] args)
        {
            // Crear el grafo del bosque
            Grafo<string> bosque = new Grafo<string>();

            // Crear los vértices (claros)
            Vertice<string> caperucita = new Vertice<string>("Casa de Caperucita");
            Vertice<string> abuelita = new Vertice<string>("Casa de la Abuelita");
            Vertice<string> claro1 = new Vertice<string>("Claro 1");
            Vertice<string> claro2 = new Vertice<string>("Claro 2");
            Vertice<string> claro3 = new Vertice<string>("Claro 3");
            Vertice<string> claro4 = new Vertice<string>("Claro 4");
            Vertice<string> claro5 = new Vertice<string>("Claro 5");
            Vertice<string> claro6 = new Vertice<string>("Claro 6");

            // Agregar vértices al grafo
            bosque.agregarVertice(caperucita);
            bosque.agregarVertice(abuelita);
            bosque.agregarVertice(claro1);
            bosque.agregarVertice(claro2);
            bosque.agregarVertice(claro3);
            bosque.agregarVertice(claro4);
            bosque.agregarVertice(claro5);
            bosque.agregarVertice(claro6);

            // Crear las aristas (senderos con cantidad de frutales como peso)
            bosque.conectar(caperucita, claro1, 10);
            bosque.conectar(caperucita, claro2, 15);
            bosque.conectar(caperucita, claro4, 8);
            bosque.conectar(claro1, claro3, 5);
            bosque.conectar(claro2, claro3, 20);
            bosque.conectar(claro2, claro4, 38);
            bosque.conectar(claro2, claro6, 30);
            bosque.conectar(claro3, claro5, 3);
            bosque.conectar(claro4, claro6, 45);
            bosque.conectar(claro5, claro6, 7);
            bosque.conectar(claro6, abuelita, 15);
            bosque.conectar(claro5, abuelita, 35);

            // Parámetro de frutales máximos para un sendero seguro
            int maxFrutales = 30;

            // Ejecutar el algoritmo de recorrido seguro con el mayor número de frutales
            EjerciciosGrafos ejercicios = new EjerciciosGrafos();
            List<List<string>> caminosSeguros = ejercicios.recorridoSeguroMaxFrutales(bosque, "Casa de Caperucita", "Casa de la Abuelita", maxFrutales);

            // Imprimir el camino o caminos seguros con la mayor cantidad de frutales
            Console.WriteLine("Caminos seguros con la mayor cantidad de frutales:");
            foreach (var camino in caminosSeguros)
            {
                Console.WriteLine(string.Join(" -> ", camino));
            }
        }
    }
    
}

