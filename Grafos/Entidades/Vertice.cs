namespace Entidades
{
    public class Vertice
    {
        public string Valor { get; set; }

        public bool YaSeUtilizo { get; set; }

        public bool EstaEnCola { get; set; }

        public bool EsInfinito { get; set; }

        public int DistanciaAcumulada { get; set; }

        public Vertice() {
            Valor = null;
            YaSeUtilizo = false;
            EstaEnCola = false;
            EsInfinito = true;
            DistanciaAcumulada = 0;
        }

        public Vertice(string valor)
        {
            Valor = valor;
            YaSeUtilizo = false;
            EstaEnCola = false;
            EsInfinito = true;
            DistanciaAcumulada = 0;
        }

    }
}
