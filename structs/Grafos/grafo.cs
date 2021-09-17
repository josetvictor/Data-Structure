using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Grafos
{
    public class Grafo
    {
        List<Vertice> vertices = new List<Vertice>();
        List<Aresta> arestas = new List<Aresta>();

        ArrayList listaAdjacencia = new ArrayList();

        public Grafo(Vertice v, Aresta a)
        {
            arestas.Add(a);
            vertices.Add(v);
        }

        public Vertice finalVertices(Aresta e) { return null; }
        public Vertice oposto(Vertice v, Aresta e) { return null; }
        public bool eAdjacente(Vertice v, Vertice w) { return false; }
        public Vertice substituir(Vertice v, Vertice x) { return null; }
        public Aresta substituir(Aresta e, Aresta x) { return null; }
        public Vertice inserirVertice(Vertice o) { return null; }
        public Aresta inserirAresta(Vertice v, Vertice w, object o) { return null; }
        public Vertice removeVertice(Vertice v) { return null; }
        public Aresta removeAresta(Aresta e) { return null; }
        public IEnumerator arestasIncidentes(Vertice v){ return null; }
        public IEnumerator Ivertices(){ return vertices.GetEnumerator(); }
        public IEnumerator  Iarestas(){ return arestas.GetEnumerator(); }
        public bool eDirecionado(Aresta e)
        {
            return e.eDirecional();
        }
    }
}
