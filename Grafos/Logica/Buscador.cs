using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public abstract class Buscador
    {
        protected string ValorVerticeInicial = null;
        protected Vertice VerticeActual = null;
        protected List<Vertice> Adyacentes = null;
        protected Queue<Vertice> ColaPendientes = new Queue<Vertice>();
        protected List<UnionVertice> Uniones = null;
        protected List<UnionVertice> UnionesAdyacentes = null;

        protected void ReiniciaPropiedadesDeBusqueda(List<UnionVertice> uniones)
        {
            foreach (UnionVertice union in uniones) {
                union.ReiniciaPropiedadesDeBusqueda();
            }
        }

        protected void BuscaLosAdyacentes() {

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

        protected void CalculaDistanciaDijkstra(Vertice adyacente, int distanciaEntreVertices) {
            var nuevaDistancia = VerticeActual.DistanciaAcumulada + distanciaEntreVertices;
            var nuevaRuta = VerticeActual.GeneraRutaAcumuladaTemporal(adyacente.Valor);
            if (adyacente.EsInfinito)
            {
                adyacente.DistanciaAcumulada = nuevaDistancia;
                adyacente.ActualizaRutaAcumulada(nuevaRuta);
                adyacente.EsInfinito = false;
            }
            else
            {
                if(adyacente.DistanciaAcumulada > nuevaDistancia)
                {
                    adyacente.DistanciaAcumulada = nuevaDistancia;
                    adyacente.ActualizaRutaAcumulada(nuevaRuta);
                }
            }
        }

        protected void ActualizaVerticesAdyacentes()
        {
            foreach (Vertice adyacente in Adyacentes) {
                foreach (UnionVertice union in UnionesAdyacentes) {
                    if (union.ContieneLosVertices(VerticeActual.Valor, adyacente.Valor)) {
                        CalculaDistanciaDijkstra(adyacente, union.Distancia);
                    }
                }
            }
        }

        protected void AgregaLosAdyacentesEnColaPendientes()
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

        protected Vertice ObtieneElPendienteMenor()
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

        protected abstract void EjecutaColaDePendientes();       
    }
}
