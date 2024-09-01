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
}
