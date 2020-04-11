namespace Entidades
{
    public class UnionVertice
    {
        public Vertice VerticeA { get; set; }
        public Vertice VerticeB { get; set; }
        public int Distancia { get; set; }

        public UnionVertice() {
            VerticeA = null;
            VerticeB = null;
            Distancia = 0;
        }

        public UnionVertice(Vertice verticeA, Vertice verticeB, int distancia) {
            VerticeA = verticeA;
            VerticeB = verticeB;
            Distancia = distancia;
        }

        public bool ContieneElVertice(string vertice) {

            if (VerticeA.Valor == vertice || VerticeB.Valor == vertice)
                return true;
            return false;

        }

        public bool ContieneLosVertices(string verticeA, string verticeB)
        {

            if ((VerticeA.Valor == verticeA && VerticeB.Valor == verticeB) ||
                (VerticeA.Valor == verticeB && VerticeB.Valor == verticeA))
                return true;
            return false;

        }

        public Vertice ObtieneVerticeAdyacente(string valor) {

            if (VerticeA.Valor == valor) {
                return VerticeB;
            }
            return VerticeA;
        }

    }
}
