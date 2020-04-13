using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class BuscadorDistancias : Buscador
    {
        
        private List<Distancia> DistanciasMasCortas = null;
        public List<Distancia> BuscaLasDistanciasMasCortas(Vertice verticeInicial, List<UnionVertice> uniones)
        {
            ReiniciaPropiedadesDeBusqueda(uniones);
            ValorVerticeInicial = verticeInicial.Valor;
            Uniones = uniones;
            DistanciasMasCortas = new List<Distancia>();
            verticeInicial.EstaEnCola = true;
            ColaPendientes.Enqueue(verticeInicial);
            EjecutaColaDePendientes();
            return DistanciasMasCortas;
        }

        protected override void EjecutaColaDePendientes()
        {
            if (ColaPendientes.Count > 0)
            {
                VerticeActual = ObtieneElPendienteMenor();
                BuscaLosAdyacentes();
                ActualizaVerticesAdyacentes();
                AgregaLosAdyacentesEnColaPendientes();
                VerticeActual.YaSeUtilizo = true;
                DistanciasMasCortas.Add(new Distancia(ValorVerticeInicial,VerticeActual.Valor,VerticeActual.DistanciaAcumulada));
                EjecutaColaDePendientes();
            }
        }

    }
}
