namespace CadeteNamespace;
using PedidoNamespace;

class Cadete
{
    int id;
    string nombre;
    string direccion;
    string telefono;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public int Id { get => id; set => id = value; }

    public float JornalACobrar()
    {
        return 500f;
    }

}
