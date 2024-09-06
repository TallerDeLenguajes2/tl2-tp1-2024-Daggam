namespace PedidoNamespace;

using CadeteNamespace;
using ClienteNamespace;

enum EstadoPedido
{
    NoAsignado, Enviando, Entregado
}
class Pedido
{
    static int id = 0;
    int numero_pedido = -1;
    string observacion;
    Cliente cliente;
    EstadoPedido estado;
    Cadete cadete;
    public Pedido(string nombre, string direccion, string telefono, string datos_referencia, string observacion)
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
        estado = EstadoPedido.NoAsignado;
    }

    public int Numero_pedido { get => numero_pedido; set => numero_pedido = value; }
    internal EstadoPedido Estado { get => estado; set => estado = value; }
    internal Cadete Cadete { get => cadete; set => cadete = value; }

    public string VerDatosCliente()
    {
        return $"Nombre: {cliente.Nombre} | Direccion: {cliente.Direccion} | Telefono: {cliente.Telefono} | Referencia: {cliente.Datos_referencia_direccion}";
    }

    public string VerDireccionCliente()
    {
        return cliente.Direccion;
    }
}