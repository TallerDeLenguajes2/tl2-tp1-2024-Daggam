namespace CadeteriaNamespace;
using CadeteNamespace;
using PedidoNamespace;

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

    internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public void ContratarCadete(int id, string nombre, string direccion, string telefono)
    {
        listadoCadetes.Add(new Cadete(id, nombre, direccion, telefono));
    }
    public bool AsignarPedido(int id, Pedido pedido){
        Cadete c = listadoCadetes.Find(c=>c.Id == id);
        if(c!=null){
            pedido.Estado = EstadoPedido.Enviando;
            c.ListadoPedidos.Add(pedido);
            
            return true;
        }
        return false;
    }
    public string[] mostrarCadetes(){
        var consultaNombre = from c in ListadoCadetes
                                 select $"ID: {c.Id} | Nombre: {c.Nombre} | Direccion: {c.Direccion} | Telefono: {c.Telefono}";
        return consultaNombre.ToArray();
    }
    public bool ExisteCadete(int id){
        return listadoCadetes.Exists(c=>c.Id ==id);
    }
    //En lugar de retornar un string de pedidos, podemos retornar los pedidos.
    public List<string> mostrarPedido(int id){
        Cadete c = listadoCadetes.Find(p=>p.Id==id);
        if(c!=null){
            var obtenerPedidos = from pedidos in c.ListadoPedidos
                                select $"Numero de pedido: {pedidos.Numero_pedido} | " + pedidos.VerDatosCliente();
            return obtenerPedidos.ToList();
        }
        return new List<string>();
    }
    // public Pedido? obtenerPedido(int id,int num_pedido){
    //     Cadete c = listadoCadetes.Find(c=>c.Id==id);
    //     if(c!=null){
    //         Pedido p = c.ListadoPedidos.Find(p=>p.Numero_pedido==num_pedido);
    //     }
    // }
    public bool TransferirPedido(int emisorId,int receptorId, Pedido pedido){
        Cadete emisor = listadoCadetes.Find(c=>c.Id==emisorId);
        Cadete receptor = listadoCadetes.Find(c=>c.Id==receptorId);
        if(emisor!=null && receptor!=null && pedido != null && emisor.ListadoPedidos.Remove(pedido)){
            receptor.ListadoPedidos.Add(pedido);
            return true;
        }
        return false;
    }
}
