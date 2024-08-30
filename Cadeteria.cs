namespace CadeteriaNamespace;
using CadeteNamespace;

class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
    }

    public void contratarCadete(int id, string nombre, string direccion, string telefono)
    {
        listadoCadetes.Add(new Cadete(id, nombre, direccion, telefono));
    }
}
