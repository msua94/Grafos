namespace Entidades
{
    public class Distancia
    {
        private string ValorInicio { get; set; }
        private string ValorDestino { get; set; }
        private int DistanciaMasCorta { get; set; }

        public Distancia(string valorInicio, string valorDestino, int distanciaMasCorta) {
            ValorInicio = valorInicio;
            ValorDestino = valorDestino;
            DistanciaMasCorta = distanciaMasCorta;
        }

        public string ObtieneDistanciaMasCorta() {
            string resultado = $"{ValorInicio} -> {ValorDestino} : {DistanciaMasCorta}";
            return resultado;
        }

    }
}
