namespace CadeteNamespace;
using PedidoNamespace;

class Cadete
{
    int id;
    string nombre;
    string direccion;
    string telefono;
    List<Pedidos> listadoPedidos;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listadoPedidos = new List<Pedidos>();
    }

    float jornalACobrar()
    {
        return 500f;
    }
}
