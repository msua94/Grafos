using Entidades;
using System.Collections.Generic;

namespace Logica
{
    public class BuscadorRutas : Buscador
    {

        private List<Ruta> RutasMasCortas = null;
        public List<Ruta> BuscaLasRutasMasCortas(Vertice verticeInicial, List<UnionVertice> uniones)
        {
            ReiniciaPropiedadesDeBusqueda(uniones);
            ValorVerticeInicial = verticeInicial.Valor;
            Uniones = uniones;
            RutasMasCortas = new List<Ruta>();
            verticeInicial.EstaEnCola = true;
            ColaPendientes.Enqueue(verticeInicial);
            EjecutaColaDePendientes();
            return RutasMasCortas;
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
                RutasMasCortas.Add(new Ruta(ValorVerticeInicial, VerticeActual.Valor, VerticeActual.ObtieneRutaAcumulada()));
                EjecutaColaDePendientes();
            }
        }

    }
}
