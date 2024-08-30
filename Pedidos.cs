namespace PedidoNamespace;
using ClienteNamespace;

enum EstadoPedido
{
    NoAsignado, Enviando, Entregado
}
class Pedidos
{
    static int id = 0;
    int numero_pedido = -1;
    string observacion;
    Cliente cliente;

    EstadoPedido estado;

    public Pedidos(string nombre, string direccion, string telefono, string datos_referencia, string observacion)
    {
        id++;
        numero_pedido = id;
        this.observacion = observacion;
        cliente = new Cliente()
        {
            Nombre = nombre,
            Direccion = direccion,
            Telefono = telefono,
            Datos_referencia_direccion = datos_referencia
        };
        estado = EstadoPedido.Entregado;
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"Nombre: {cliente.Nombre} | Direccion: {cliente.Direccion} | Telefono: {cliente.Telefono} | Referencia: {cliente.Datos_referencia_direccion}");
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine(cliente.Direccion);
    }
}