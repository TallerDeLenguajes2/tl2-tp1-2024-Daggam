using CadeteNamespace;
using CadeteriaNamespace;

namespace AccesoNameSpace;
public abstract class AccesoADatos{
    public abstract Cadeteria? cargarCadeteria(string path);
    public abstract List<Cadete>? cargarCadetes(string path);
}
