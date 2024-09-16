using System.Data;
using AccesoNameSpace;
using CadeteriaNamespace;
using PedidoNamespace;

Cadeteria cadeteria = null;

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
    cadeteria.CargarPedido(nombre,direccion,telefono,referencia,obs);
}

void asignarPedidos(){
    var pedidosNoAsignados = cadeteria.MostrarPedidosNA();
    if(pedidosNoAsignados.Count() != 0){
        Console.WriteLine("-- PEDIDOS NO ASIGNADOS --");
        foreach(var p in pedidosNoAsignados){
            Console.WriteLine(p);
        }
        Console.WriteLine("Ingrese el numero de pedido a asignar:");
        int numped=-1;
        while(!(int.TryParse(Console.ReadLine(),out numped))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        // if(pedidosNoAsignados.Exists(p=>p.Numero_pedido==numped)){
        var consultaNombre = cadeteria.MostrarCadetes();
        foreach(string info in consultaNombre){
                Console.WriteLine(info);
        }   
        Console.WriteLine("Ingrese el id del cadete al cual desea asignar este pedido:");
        int id=-1;
        while(!(int.TryParse(Console.ReadLine(),out id))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        if(cadeteria.AsignarCadeteAPedido(id,numped)){
            Console.WriteLine("Pedido asignado con éxito.");
        }else{
            Console.WriteLine("El pedido no se puede asignar.");
        }
    }else{
        Console.WriteLine("No hay pedidos para asignar");
    }
    // }else{
        // Console.WriteLine("El pedido no existe.");
    // }
    
    Thread.Sleep(1500);
}

void cambiarEstadoPedido(){
    var pedidos = cadeteria.MostrarPedidosEstado();
    if(pedidos.Count() != 0){
        Console.WriteLine("-- Pedidos Asignados --");
        foreach(var p in pedidos){
            Console.WriteLine(p); 
        }
        Console.WriteLine("Ingrese el numero del pedido al cuál desea cambiar de estado");
        int num_ped;
        while(!(int.TryParse(Console.ReadLine(),out num_ped))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        if(cadeteria.CambiarEstadoPedido(num_ped)){
            Console.WriteLine("El cambio de estado se realizo exitosamente.");
        }else{
            Console.WriteLine("El pedido no existe o no puede cambiarse el estado de dicho pedido.");
        }
    }else{
        Console.WriteLine("No hay pedidos asignados.");
    }
    Thread.Sleep(1000);
}

void cambiarPedido(){
    var cadetesInfo = cadeteria.MostrarCadetes();
    foreach (string c in cadetesInfo) Console.WriteLine(c);
    Console.WriteLine("Ingrese el ID del cadete que desea transferir un pedido:");
    int id1;
    while(!(int.TryParse(Console.ReadLine(),out id1))){
        Console.WriteLine("El valor ingresado no es válido.");
    }
    
    //Obtengo los pedidos no entregados del cadete
    var obtenerPedidos = cadeteria.MostrarPedidos(id1);
    if(obtenerPedidos.Count() != 0){
        foreach( var pedido in obtenerPedidos) Console.WriteLine(pedido);
        int num_pedido;
        Console.WriteLine("Ingrese el numero del pedido que desea transferir: ");
        while(!(int.TryParse(Console.ReadLine(),out num_pedido))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        Console.WriteLine("Ingrese el ID del cadete a asignar el pedido: ");
        int id2;
        while(!(int.TryParse(Console.ReadLine(),out id2))){
            Console.WriteLine("El valor ingresado no es válido.");
        }
        if(cadeteria.AsignarCadeteAPedido(id2,num_pedido)){
            Console.WriteLine("El pedido fue transferido con éxito.");
        }else{
            Console.WriteLine("El pedido no existe, el cadete a asignar el pedido no existe"); //El pedido ya no se puede transferir.
        }
    }else{
        Console.WriteLine("El cadete no existe o no tiene asignado ningún pedido");
    }
    Thread.Sleep(1000);
}


int opcionesFormato=0;
bool continua=false;
Console.WriteLine("¿Desea cargar los datos en CSV o JSON? (1:CSV, 2: JSON)");
while(!(int.TryParse(Console.ReadLine(),out opcionesFormato)) || (opcionesFormato<1 || opcionesFormato>2)){
    Console.WriteLine("El valor ingresado no es válido");
}
if(opcionesFormato==1){
    AccesoCSV csv = new AccesoCSV();
    cadeteria = csv.cargarCadeteria("cadeteria.csv");
    continua = csv.cargarCadetes("cadetes.csv",cadeteria);
}else if(opcionesFormato==2){
    AccesoJSON json = new AccesoJSON();
    cadeteria = json.cargarCadeteria("cadeteria.json");
    continua = json.cargarCadetes("cadetes.json",cadeteria);
}

continua &= cadeteria!=null;

if(continua){
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

    Console.WriteLine("--- INFORME PEDIDOS ---");
    var obtenerID = from cadete in cadeteria.ListadoCadetes
                    select new {id=cadete.Id,nombre=cadete.Nombre};
    float plataGanada=0f;
    foreach (var c in obtenerID)
    {
        var cantidadPedidos = cadeteria.ListadoPedidos.Count(p=>p.Estado==EstadoPedido.Entregado && p.Cadete.Id==c.id);
        float enviosPromedios = (cantidadPedidos !=0) ? ((float) cantidadPedidos/cadeteria.ListadoPedidos.Count(p=>p.Estado!=EstadoPedido.NoAsignado && p.Cadete.Id==c.id)):0;
        float montoGanado = cadeteria.JornalACobrar(c.id);
        Console.WriteLine($"Nombre: {c.nombre} | Monto ganado: {montoGanado} | Envios realizados: {cantidadPedidos} | Envios promedios: {enviosPromedios}");
        plataGanada+=montoGanado;
    }
    Console.WriteLine($"Monto total ganado: {plataGanada}");
}
