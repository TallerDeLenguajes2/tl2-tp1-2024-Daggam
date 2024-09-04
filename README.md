# Sistema de Cadeteria - TP1

Una empresa de cadetería necesita implementar un sistema para asignar pedidos a sus 
cadetes y poder luego saber cuántos pedidos despachó cada uno para poder así pagarles su
correspondiente jornal ($500 por cada pedido Entregado)

#### ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?

- Pedido tiene una relación de composición con Cliente.
- Pedido tiene una relación de agregación con Cadete.
- Cadeteria tiene una relación de composición con Cadete.

#### ¿Qué métodos considera que deberia tener la clase Cadetería y la clase Cadete?

Cadetería podría tener los siguientes metodos:
- ContratarCadete: Crea una instancia de cadete y lo agrega a ListadoCadetes.
- AsignarPedido: Dado un id de cadete y un pedido, le asigna un pedido a un cadete.
- MostrarCadetes: Muestra todos los cadetes.
- MostrarPedido: Muestra todos los pedidos dado un id de cadete.
- TransferirPedido: dado dos id de cadetes y un pedido, transfiere un pedido de un cadete a otro.
- 
Los cadetes podría tener métodos que ayuden a cadetería, tal como:
- verPedidos: Muestra el contenido de ListadoPedidos
- agregarPedido: Agrega un pedido a ListadoPedidos
- quitarPedido: Dado un numero de pedido, quita un pedido de ListadoPedidos.

#### Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedadaes y métodos deberían ser públicos y cuáles privados.

Las propiedades tienen que considerarse privadas para el uso de la clase, y la forma de comunicarse con las demás clases
tendría que ser con el uso de los campos, por lo que estos últimos tendrán que ser públicos. 

Los métodos que vayamos a utilizar, dependiendo de su uso (si son utilizados solo por la clase misma o también la utilizan otras clases) serán públicos o privados.

#### ¿Cómo diseñaria los constructores de cada una de las clases?

- **Cadete(id,nombre,direccion,telefono)**: Además se inicializa el ListadoPedidos.
- **Cadeteria(nombre,telefono)**: Inicializo el listadoCadetes.
- **Pedido(nombre,direccion,telefono,datos_referencia,observacion)**: Pongo un valor inicial al estado.
- **Cliente()**: No hago constructor de cliente.

#### ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?

Podría haber cambiado la manera en la que se asignan los pedidos. Los Pedidos no son tomados por un Cadete, sino por una Cadetería.
La clase pedido se modificaría para conocer a que cadete fue asignado y la cadeteria se encargaria de gestionarlo.
El problema es que presenta restricciones como el hecho de que el cadete pierde libertades para rechazar o aceptar pedidos, ya que la cadeteria decide a quién asignar un pedido
y a quién quitarselo.
