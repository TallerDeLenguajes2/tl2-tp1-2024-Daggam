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

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public int Id { get => id; set => id = value; }
    internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    float jornalACobrar()
    {
        return 500f;
    }
}
