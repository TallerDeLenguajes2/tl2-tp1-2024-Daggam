using CadeteriaNamespace;
using PedidoNamespace;

void comprobarEntradaEntera(ref int a)
{
    while (!(int.TryParse(Console.ReadLine(), out a)))
    {
        Console.WriteLine("La entrada ingresada no es válida.");
    }
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

    if (opcion == 5) break;
}