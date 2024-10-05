using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{
    public class Cola<T>
    {

        private List<T> elementos;

        public Cola()
        {
            elementos = new List<T>();
        }

       
        public void encolar(T item)  // Agregar un elemento al final de la cola
        {
            elementos.Add(item);
        }

        
        public T desencolar() // Retorna y elimina el primer elemento de la cola
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("La cola está vacía");
            }

            T valor = elementos[0];
            elementos.RemoveAt(0);
            return valor;
        }

        
        public T tope()  // Obtener el primer elemento sin retirarlo
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("La cola está vacía");
            }
            return elementos[0];
            
        }

        public bool EstaVacia() // true si hay cero elementos, caso contrario false.
        {
            return elementos.Count == 0;
        }

       
        public int cuantos()  // Obtener el número de elementos en la cola
        {
            return elementos.Count; 
        }

        
      
    }
}
