using CadeteriaNamespace;
using PedidoNamespace;


Cadeteria cadeteria;
List<Pedidos> PedidosNoAsignados = new List<Pedidos>();

void crearPedido()
{
    Console.WriteLine("--- Datos Cliente ---\nIngresa el nombre: ");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingresa la direccion: ");
    string direccion = Console.ReadLine();
    Console.WriteLine("Ingrese la telefono: ");
    string telefono = Console.ReadLine();
    Console.WriteLine("Ingrese la referencia: ");
    string referencia = Console.ReadLine();
    Console.WriteLine("Alguna observación sobre el pedido:");
    string obs = Console.ReadLine();
    
}

bool cargarArchivosCSV(){
    string path = "cadeteria.csv";
    string path2 = "cadetes.csv";
    if(File.Exists(path) && File.Exists(path2)){
        //Carga de Cadeteria.csv
        string[] lineas = File.ReadAllLines(path);
        var obtenerCadeteria = from linea in lineas 
                               let campos = linea.Split(',') 
                               select new Cadeteria(campos[0],campos[1]);
        cadeteria = obtenerCadeteria.ToList()[0];
        //Carga de cadetes.
        string[] lineas2 = File.ReadAllLines(path2);
        var obtenerCadetes = from linea in lineas2
                             let campos = linea.Split(',')
                             select campos;
        foreach(var c in obtenerCadetes){
            cadeteria.contratarCadete(int.Parse(c[0]),c[1],c[2],c[3]);
        }
        return true;
    }else{
        Console.WriteLine("Los archivos csv no se cargaron correctamente");
    }
    return false;
}

if(cargarArchivosCSV()){
    while (true)
    {
        Console.Clear();
        Console.WriteLine("-- MENU --");
        Console.WriteLine("1. Dar alta pedidos.");
        Console.WriteLine("2. Asignar un pedido a cadete.");
        Console.WriteLine("3. Cambiar estado a un pedido.");
        Console.WriteLine("4. Reasignar pedido.");
        Console.WriteLine("5. Salir.");
        Console.WriteLine("Ingresa un numero: ");
        int opcion;
        while (!(int.TryParse(Console.ReadLine(), out opcion)) || (opcion < 1 || opcion > 5))
        {
            Console.WriteLine("La entrada ingresada no es válida.");
        }
        switch (opcion)
        {
            case 1:
                
                break;
        }
        if (opcion == 5) break;
    }
}
