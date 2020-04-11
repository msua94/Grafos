using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class BuscadorRuta
    {

        private Queue<Vertice> ColaPendientes = new Queue<Vertice>();
        private List<UnionVertice> Uniones = null;
        private List<UnionVertice> UnionesAdyacentes = null;
        private List<Vertice> VerticesCalculados = null;
        private Vertice VerticeActual = null;
        private List<Vertice> Adyacentes = null;

        public List<Vertice> BuscaLasRutasMenores(Vertice verticeInicial, List<UnionVertice> uniones) {
            Uniones = uniones;
            VerticesCalculados = new List<Vertice>();
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
                    // No puede estar en cola de pendientes y no tiene que haber sido utilizado
                    if ((!adyacente.EstaEnCola) && (!adyacente.YaSeUtilizo))
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
                adyacente.EstaEnCola = true;
                ColaPendientes.Enqueue(adyacente);
            }
        }

        private void EjecutaColaDePendientes() {

            if (ColaPendientes.Count > 0) {

                VerticeActual = ColaPendientes.Dequeue();
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
