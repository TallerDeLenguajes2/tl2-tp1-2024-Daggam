namespace ClienteNamespace;
class Cliente
{
    string nombre;
    string direccion;
    string telefono;
    string datos_referencia_direccion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string Datos_referencia_direccion { get => datos_referencia_direccion; set => datos_referencia_direccion = value; }
}