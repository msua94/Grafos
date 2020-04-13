using System.Collections.Generic;

namespace Entidades
{
    public class Vertice
    {
        public readonly string Valor;

        public bool YaSeUtilizo { get; set; }

        public bool EstaEnCola { get; set; }

        public bool EsInfinito { get; set; }

        public int DistanciaAcumulada { get; set; }
        private string RutaAcumulada { get; set; }

        public Vertice(string valor)
        {
            Valor = valor;
            YaSeUtilizo = false;
            EstaEnCola = false;
            EsInfinito = true;
            DistanciaAcumulada = 0;
            RutaAcumulada = string.Empty;
        }

        public void ReiniciaRutaAcumulada() {
            RutaAcumulada = string.Empty;
        }

        public string ObtieneRutaAcumulada() {
            return RutaAcumulada;
        }

        public void ActualizaRutaAcumulada(string valor) {
            RutaAcumulada = valor;
        }

        public string GeneraRutaAcumuladaTemporal(string valor)
        {
            return string.Concat(RutaAcumulada, "->", valor);
        }

    }
}
