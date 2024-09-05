namespace CadeteriaNamespace;
using CadeteNamespace;
using PedidoNamespace;

class Cadeteria
{
    string nombre;
    string telefono;
    List<Cadete> listadoCadetes;
    List<Pedido> listadoPedidos;
    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }

    internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    internal List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public void ContratarCadete(int id, string nombre, string direccion, string telefono)
    {
        listadoCadetes.Add(new Cadete(id, nombre, direccion, telefono));
    }
    public bool AsignarCadeteAPedido(int id, int num_ped){
        Pedido p = listadoPedidos.Find(ped=>ped.Numero_pedido==num_ped);
        Cadete c = listadoCadetes.Find(c=>c.Id == id);
        if(p!=null && c!=null){
            p.Cadete = c;
            p.Estado = EstadoPedido.Enviando;
            return true;
        }
        return false;
    }
    public string[] MostrarCadetes(){
        var consultaNombre = from c in ListadoCadetes
                                 select $"ID: {c.Id} | Nombre: {c.Nombre} | Direccion: {c.Direccion} | Telefono: {c.Telefono}";
        return consultaNombre.ToArray();
    }
    public float JornalACobrar(int id){
        Cadete cadeteElegido = listadoCadetes.Find(c=>c.Id==id);
        if(cadeteElegido!=null){
            
            return cadeteElegido.JornalACobrar()*listadoPedidos.Count(p=>p.Cadete==cadeteElegido && p.Estado==EstadoPedido.Entregado);
        }
        return 0f;
    }
}
