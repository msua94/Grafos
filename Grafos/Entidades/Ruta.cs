namespace Entidades
{
    public class Ruta
    {
        private string ValorInicio { get; set; }
        private string ValorDestino { get; set; }
        private string RutaMasCorta { get; set; }

        public Ruta(string valorInicio, string valorDestino, string rutaMasCorta)
        {
            ValorInicio = valorInicio;
            ValorDestino = valorDestino;
            RutaMasCorta = rutaMasCorta;
        }

        public string ObtieneRutaMasCorta()
        {
            string resultado = string.Concat($"De {ValorInicio} a {ValorDestino} ",
                                             "la ruta más corta es: ",
                                             $"{ValorInicio}{RutaMasCorta}");
            return resultado;
        }

    }
}
