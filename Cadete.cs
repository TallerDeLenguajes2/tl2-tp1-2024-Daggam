namespace CadeteNamespace;
using PedidoNamespace;

class Cadete
{
    int id;
    string nombre;
    string direccion;
    string telefono;
    List<Pedido> listadoPedidos;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listadoPedidos = new List<Pedido>();
    }

    float jornalACobrar()
    {
        return 500f;
    }
}
