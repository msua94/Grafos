using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class BuscadorRuta
    {
        private Vertice VerticeActual = null;
        private List<Vertice> Adyacentes = null;
        private Queue<Vertice> ColaPendientes = new Queue<Vertice>();
        private List<UnionVertice> Uniones = null;
        private List<UnionVertice> UnionesAdyacentes = null;
        private List<Vertice> VerticesCalculados = null;        

        public List<Vertice> BuscaLasRutasMenores(Vertice verticeInicial, List<UnionVertice> uniones) {
            Uniones = uniones;
            VerticesCalculados = new List<Vertice>();
            verticeInicial.EstaEnCola = true;
            ColaPendientes.Enqueue(verticeInicial);
            EjecutaColaDePendientes();
            return VerticesCalculados;
        }

        private void BuscaLosAdyacentes() {

            Adyacentes = new List<Vertice>();
            UnionesAdyacentes = new List<UnionVertice>();
            foreach (UnionVertice union in Uniones) {
                if (union.ContieneElVertice(VerticeActual.Valor))
                {
                    var adyacente = union.ObtieneVerticeAdyacente(VerticeActual.Valor);
                    // Solo los adyacentes que no han sido utilizados como verticeActual
                    if (!adyacente.YaSeUtilizo)
                    {
                        Adyacentes.Add(adyacente);
                        UnionesAdyacentes.Add(union);
                    }
                }
            }
        }

        private void CalculaDistanciaDijkstra(Vertice adyacente, int distanciaEntreVertices) {
            var nuevoAcumulado = VerticeActual.DistanciaAcumulada + distanciaEntreVertices;
            if (adyacente.EsInfinito)
            {
                adyacente.DistanciaAcumulada = nuevoAcumulado;
                adyacente.EsInfinito = false;
            }
            else
            {
                if(adyacente.DistanciaAcumulada > nuevoAcumulado)
                {
                    adyacente.DistanciaAcumulada = nuevoAcumulado;
                }
            }
        }

        private void ActualizaDistanciaDeAdyacentes()
        {
            foreach (Vertice adyacente in Adyacentes) {
                foreach (UnionVertice union in UnionesAdyacentes) {
                    if (union.ContieneLosVertices(VerticeActual.Valor, adyacente.Valor)) {
                        CalculaDistanciaDijkstra(adyacente, union.Distancia);
                    }
                }
            }
        }

        private void AgregaLosAdyacentesEnColaPendientes()
        {
            foreach(Vertice adyacente in Adyacentes)
            {   
                //Si ya está en la cola no se agrega
                if (!adyacente.EstaEnCola) {
                    adyacente.EstaEnCola = true;
                    ColaPendientes.Enqueue(adyacente);
                }                
            }
        }

        private Vertice ObtieneElPendienteMenor()
        {
            var cantidadPendientes = ColaPendientes.Count - 1;

            var verticeMenor = ColaPendientes.Dequeue();

            while (cantidadPendientes > 0)
            {
                var verticeActual = ColaPendientes.Dequeue();
                if (verticeMenor.DistanciaAcumulada > verticeActual.DistanciaAcumulada)
                {
                    ColaPendientes.Enqueue(verticeMenor);
                    verticeMenor = verticeActual;
                }
                else
                {
                    ColaPendientes.Enqueue(verticeActual);
                }

                cantidadPendientes -= 1;
            }

            return verticeMenor;
        }

        private void EjecutaColaDePendientes() {
            if (ColaPendientes.Count > 0)
            {
                VerticeActual = ObtieneElPendienteMenor();
                BuscaLosAdyacentes();
                ActualizaDistanciaDeAdyacentes();
                AgregaLosAdyacentesEnColaPendientes();
                VerticeActual.YaSeUtilizo = true;
                VerticesCalculados.Add(VerticeActual);
                EjecutaColaDePendientes();
            }
        }        
    }
}
