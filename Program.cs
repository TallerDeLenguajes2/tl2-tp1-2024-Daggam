using CadeteriaNamespace;
using PedidoNamespace;



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


}

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