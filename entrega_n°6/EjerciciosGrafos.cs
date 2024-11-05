using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entrega_n6
{
    public class EjerciciosGrafos
    {
        public List<List<string>> recorridoSeguroMaxFrutales(Grafo<string> bosque, string caperucita, string abuelita, int maxFrutales)
        {
            Vertice<string> inicio = bosque.getVertices().Find(v => v.getDato().Equals(caperucita));
            Vertice<string> destino = bosque.getVertices().Find(v => v.getDato().Equals(abuelita));

            List<string> caminoActual = new List<string>();
            List<List<string>> mejoresCaminos = new List<List<string>>();
            int maxFrutalesEnCamino = 0;

            bool[] visitados = new bool[bosque.getVertices().Count];
            HashSet<Arista<string>> aristasVisitadas = new HashSet<Arista<string>>();

            DFSConFrutales(inicio, destino, maxFrutales, visitados, aristasVisitadas, caminoActual, 0, ref maxFrutalesEnCamino, mejoresCaminos);

            return mejoresCaminos;
        }

        private void DFSConFrutales(Vertice<string> actual, Vertice<string> destino, int maxFrutales,
                                    bool[] visitados, HashSet<Arista<string>> aristasVisitadas, List<string> caminoActual, int frutalesAcumulados,
                                    ref int maxFrutalesEnCamino, List<List<string>> mejoresCaminos)
        {
            visitados[actual.getPosicion() - 1] = true;
            caminoActual.Add(actual.getDato());

            if (actual.Equals(destino))
            {
                if (frutalesAcumulados > maxFrutalesEnCamino)
                {
                    // Se encontró un camino con mayor cantidad de frutales
                    maxFrutalesEnCamino = frutalesAcumulados;
                    mejoresCaminos.Clear(); // Limpiar los caminos previos
                    mejoresCaminos.Add(new List<string>(caminoActual));
                }
                else if (frutalesAcumulados == maxFrutalesEnCamino)
                {
                    // Agregar el camino a la lista si tiene el mismo número máximo de frutales
                    mejoresCaminos.Add(new List<string>(caminoActual));
                }
            }
            else
            {
                foreach (Arista<string> arista in actual.getAdyacentes())
                {
                    Vertice<string> vecino = arista.getDestino();
                    int frutalesEnSendero = arista.getPeso();

                    if (!visitados[vecino.getPosicion() - 1] && frutalesEnSendero <= maxFrutales && !aristasVisitadas.Contains(arista))
                    {
                        aristasVisitadas.Add(arista); // Marcar la arista como visitada
                        DFSConFrutales(vecino, destino, maxFrutales, visitados, aristasVisitadas, caminoActual,
                                       frutalesAcumulados + frutalesEnSendero, ref maxFrutalesEnCamino, mejoresCaminos);
                        aristasVisitadas.Remove(arista); // Desmarcar al retroceder
                    }
                }
            }

            visitados[actual.getPosicion() - 1] = false;
            caminoActual.RemoveAt(caminoActual.Count - 1);
        }

    }
}




