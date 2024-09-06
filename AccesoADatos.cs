using CadeteriaNamespace;

namespace AccesoNameSpace;
public abstract class AccesoADatos{
    public abstract Cadeteria cargarCadeteria(string path);
    public abstract bool cargarCadetes(string path, Cadeteria cadeteria);
}
