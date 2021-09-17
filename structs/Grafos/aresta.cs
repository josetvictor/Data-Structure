using System;
using System.Collections.Generic;
using System.Text;

namespace data_structs.Grafos
{
    public class Aresta
    {
        private Vertice verticeInicio = new Vertice();
        private Vertice verticeFim = new Vertice();
        private object rotulo;
        private bool isDirecional;

        public Aresta(Vertice verticeInicio, Vertice verticeFim, object? rotulo, bool isDirecional = false)
        {
            this.verticeInicio = verticeInicio;
            this.verticeFim = verticeFim;
            this.rotulo = rotulo;
            this.isDirecional = isDirecional;
        }

        public Vertice getVerticeInicio() => verticeInicio;
        public Vertice getVerticeFim() => verticeFim;
        public object getRotulo() => rotulo;
        public void setRotulo(object newRotulo) => rotulo = newRotulo;
        public bool eDirecional() => isDirecional;
    }
}
