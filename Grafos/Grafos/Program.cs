using Entidades;
using Logica;
using System;
using System.Collections.Generic;

namespace Grafos
{
    class Program
    {
        static void Main(string[] args)
        {
            Vertice verticeA = new Vertice("A");
            Vertice verticeB = new Vertice("B");
            Vertice verticeC = new Vertice("C");
            Vertice verticeD = new Vertice("D");
            Vertice verticeE = new Vertice("E");
            Vertice verticeF = new Vertice("F");

            List<UnionVertice> unionesDeVertices = new List<UnionVertice> {
                new UnionVertice(verticeA, verticeD, 4),
                new UnionVertice(verticeA, verticeC, 2),
                new UnionVertice(verticeC, verticeB, 1),
                new UnionVertice(verticeB, verticeE, 2),
                new UnionVertice(verticeD, verticeE, 12),
                new UnionVertice(verticeD, verticeF, 5),
                new UnionVertice(verticeE, verticeF, 6)
            };

            BuscadorRuta buscador = new BuscadorRuta();

            List<Vertice> vertices = buscador.BuscaLasDistanciasMasCortas(verticeD, unionesDeVertices);

            foreach (Vertice vertice in vertices) {
                Console.WriteLine($"Vertice {vertice.Valor} : {vertice.DistanciaAcumulada}");
            }

            Console.ReadLine();
        }
    }
}
