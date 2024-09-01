using System.Data;
using CadeteriaNamespace;
using PedidoNamespace;


Cadeteria cadeteria = null;
List<Pedido> pedidosNoAsignados = new List<Pedido>();

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
    pedidosNoAsignados.Add(new Pedido(nombre,direccion,telefono,referencia,obs));
}

void asignarPedidos(){
    if(pedidosNoAsignados.Count!=0){
        Console.WriteLine("-- PEDIDOS NO ASIGNADOS --");
        foreach(Pedido p in pedidosNoAsignados){
            Console.WriteLine($"Numero pedido: {p.Numero_pedido} | {p.VerDatosCliente()} ");
        }
        Console.WriteLine("Ingrese el numero de pedido a asignar:");
        int numped=-1;
        while(!(int.TryParse(Console.ReadLine(),out numped))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        Pedido pedObtenido = pedidosNoAsignados.Find(p=>p.Numero_pedido==numped);
        if(pedObtenido!=null){
            //Podría crear un metodo en cadeteria que se llame: mostrarCadetes(). 
            var consultaNombre = cadeteria.mostrarCadetes();
            foreach(string info in consultaNombre){
                    Console.WriteLine(info);
            }   
            Console.WriteLine("Ingrese el id del cadete al cual desea asignar este pedido:");
            int id=-1;
            while(!(int.TryParse(Console.ReadLine(),out id))){
                Console.WriteLine("El valor ingresado no es válido.");
            }
            if(cadeteria.AsignarPedido(id,pedObtenido)){
                Console.WriteLine("Pedido asignado con éxito.");
                pedidosNoAsignados.Remove(pedObtenido);
            }else{
                Console.WriteLine("El cadete no existe.");
            }
        }else{
            Console.WriteLine("El pedido no existe.");
        }
    }else{
        Console.WriteLine("No hay pedidos para asignar");
    }
    
    Thread.Sleep(1500);
}

void cambiarEstadoPedido(){
    var obtenerPedidos = from cadete in cadeteria.ListadoCadetes
                         from pedido in cadete.ListadoPedidos
                         select pedido;
    if(obtenerPedidos.Count() != 0){
        Console.WriteLine("-- Pedidos Asignados --");
        foreach(var p in obtenerPedidos){
            Console.WriteLine($"Numero pedido: {p.Numero_pedido} | Estado: {p.Estado}"); 
        }
        Console.WriteLine("Ingrese el numero del pedido al cuál desea cambiar de estado");
        int num_ped;
        while(!(int.TryParse(Console.ReadLine(),out num_ped))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        Pedido pedidoSeleccionado = obtenerPedidos.FirstOrDefault(pedido=>pedido.Numero_pedido==num_ped);
        if(pedidoSeleccionado!=null){
            Console.WriteLine("Ingrese el estado al cual desea cambiar:");
            foreach(var estado in Enum.GetValues(typeof(EstadoPedido))){
                    if(estado.Equals(EstadoPedido.NoAsignado)) continue;
                    Console.WriteLine($"- {estado}");
            }
            EstadoPedido nuevoEstado;
            while(!Enum.TryParse(Console.ReadLine(),true,out nuevoEstado) || nuevoEstado==EstadoPedido.NoAsignado){
                Console.WriteLine("El valor ingresado no es válido.");
            }
            pedidoSeleccionado.Estado=nuevoEstado;
            Console.WriteLine("El cambio de estado se realizo exitosamente.");
        }else{
            Console.WriteLine("No existe un pedido con tal numero.");
        }
    }else{
        Console.WriteLine("No hay pedidos asignados.");
    }
    Thread.Sleep(1000);
}

void cambiarPedido(){
    var cadetesInfo = cadeteria.mostrarCadetes();
    foreach (string c in cadetesInfo) Console.WriteLine(c);
    Console.WriteLine("Ingrese el ID del cadete que desea transferir un pedido:");
    int id1;
    while(!(int.TryParse(Console.ReadLine(),out id1))){
        Console.WriteLine("El valor ingresado no es válido.");
    }
    //Obtengo los pedidos no asignados del cadete.
    var obtenerPedidos = from cadete  in cadeteria.ListadoCadetes
                         where cadete.Id == id1 
                         from pedido in cadete.ListadoPedidos
                         where pedido.Estado == EstadoPedido.Enviando 
                         select pedido;
    if(obtenerPedidos.Count() != 0){
        foreach( var pedido in obtenerPedidos) Console.WriteLine($"Numero pedido: {pedido.Numero_pedido} | {pedido.VerDatosCliente()}");
        int num_pedido;
        Console.WriteLine("Ingrese el numero del pedido que desea transferir: ");
        while(!(int.TryParse(Console.ReadLine(),out num_pedido))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        Console.WriteLine("Ingrese el ID del cadete a asignar el pedido");
        int id2;
        while(!(int.TryParse(Console.ReadLine(),out id2))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        Pedido pedidoTransferir = obtenerPedidos.FirstOrDefault(p=>p.Numero_pedido==num_pedido);
        if(cadeteria.TransferirPedido(id1,id2,pedidoTransferir)){
            Console.WriteLine("El pedido fue transferido con éxito.");
        }else{
            Console.WriteLine("El pedido no existe o el cadete a asignar el pedido no existe.");
        }
    }else{
        Console.WriteLine("El cadete no tiene asignado ningún pedido");
    }
    Thread.Sleep(1000);
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
            cadeteria.ContratarCadete(int.Parse(c[0]),c[1],c[2],c[3]);
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
        Console.Clear();
        switch (opcion)
        {
            case 1:
                crearPedido();
                break;
            case 2:
                asignarPedidos();
                break;
            case 3:
                cambiarEstadoPedido();
                break;
            case 4:
                cambiarPedido();
                break;
            
        }
        if (opcion == 5) break;
    }
}
