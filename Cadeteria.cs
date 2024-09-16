namespace CadeteriaNamespace;

using System.Text.Json.Serialization;
using CadeteNamespace;
using PedidoNamespace;

public class Cadeteria
{
    string nombre;
    string telefono;
    float montoPedido = 500f;
    List<Cadete> listadoCadetes;
    List<Pedido> listadoPedidos;
    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }

    // internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    // internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    [JsonPropertyName("nombre")]
    public string Nombre { get => nombre; set => nombre = value; }
    [JsonPropertyName("telefono")]
    public string Telefono { get => telefono; set => telefono = value; }

    public void CargarPedido(string nombre, string direccion, string telefono, string referencia, string obs)
    {

        listadoPedidos.Add(new Pedido(nombre, direccion, telefono, referencia, obs));

    }
    public void ContratarCadete(int id, string nombre, string direccion, string telefono)
    {
        listadoCadetes.Add(new Cadete(id, nombre, direccion, telefono));
    }
    public bool AsignarCadeteAPedido(int id, int num_ped)
    {
        Pedido p = listadoPedidos.Find(ped => ped.Numero_pedido == num_ped);
        Cadete c = listadoCadetes.Find(c => c.Id == id);
        if (p != null && c != null)
        {
            return p.CargaCadete(c);
        }
        return false;
    }
    public string[] MostrarCadetes()
    {
        var consultaNombre = from c in listadoCadetes
                             select $"ID: {c.Id} | Nombre: {c.Nombre} | Direccion: {c.Direccion} | Telefono: {c.Telefono}";
        return consultaNombre.ToArray();
    }
    public float JornalACobrar(int id)
    {
        Cadete cadeteElegido = listadoCadetes.Find(c => c.Id == id);
        if (cadeteElegido != null)
        {
            return montoPedido * listadoPedidos.Count(p => p.Cadete == cadeteElegido && p.Estado == EstadoPedido.Entregado);
        }
        return 0f;
    }
    public bool CambiarEstadoPedido(int num)
    {
        Pedido p = listadoPedidos.FirstOrDefault(p => p.Numero_pedido == num);
        if (p != null)
        {
            return p.CambiarEstado();
        }
        return false;
    }
    //Muestra aquellos pedidos no asignados.
    //También lo que podría hacer es que solamente los pedidos sirvan como un getter y solo sea modificable mediante esta clase.
    public string[] MostrarPedidosNA()
    {
        var consultaPedidos = from p in listadoPedidos
                              where p.Estado == EstadoPedido.NoAsignado
                              select $"Numero pedido: {p.Numero_pedido} | {p.VerDatosCliente()} ";
        return consultaPedidos.ToArray();
    }
    public string[] MostrarPedidosEstado()
    {
        var consultarPedidos = from p in listadoPedidos
                               select $"Numero pedido: {p.Numero_pedido} | Estado: {p.Estado}";
        return consultarPedidos.ToArray();
    }
    //Dado el id de un cadete, retornarme los pedidos sin entregar del cadete.
    public string[] MostrarPedidos(int id)
    {
        var consultarPedidos = from p in listadoPedidos
                               where p.Cadete.Id == id && p.Estado == EstadoPedido.Enviando
                               select $"Numero pedido: {p.Numero_pedido} | {p.VerDatosCliente()}";
        return consultarPedidos.ToArray();
    }

    public string[] MostrarInforme()
    {
        List<string> salida = new List<string>();
        salida.Add("--- INFORME PEDIDOS ---");
        var obtenerID = from cadete in listadoCadetes
                        select new { id = cadete.Id, nombre = cadete.Nombre };
        float plataGanada = 0f;
        foreach (var c in obtenerID)
        {
            var cantidadPedidos = listadoPedidos.Count(p => p.Estado == EstadoPedido.Entregado && p.Cadete.Id == c.id);
            float enviosPromedios = (cantidadPedidos != 0) ? ((float)cantidadPedidos / listadoPedidos.Count(p => p.Estado != EstadoPedido.NoAsignado && p.Cadete.Id == c.id)) : 0;
            float montoGanado = JornalACobrar(c.id);
            salida.Add($"Nombre: {c.nombre} | Monto ganado: {montoGanado} | Envios realizados: {cantidadPedidos} | Envios promedios: {enviosPromedios}");
            plataGanada += montoGanado;
        }
        salida.Add($"Monto total ganado: {plataGanada}");
        return salida.ToArray();
    }
}
