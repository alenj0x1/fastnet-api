## Servicios de la empresa
1. Internet 100MB: $25.99
2. Internet 500MB: $37.99
3. Internet 1GB: $52.99
## Roles de la empresa
1. gestor
2. cajero
## Estados de la cita (atención)

1. waiting: En espera
2. taked: Tomado
3. ended: Finalizada
# Escenarios

## Persona llega a la empresa por primera vez

1. La persona ingresa su numero de cedula.
2. El aplicativo le asigna un turno, pero al no ser un cliente, el turno no posee datos de Cliente y se establece el estado de attention_type como 'information'.
4. El aplicativo le informa al Cajero que la persona no es un cliente. Por lo que el aplicativo no puede mostrarle los datos de cliente al Cajero.
5. Si la persona realiza un contrato, los datos que formule serán tomados para registrar a la persona como Cliente. 
6. El cajero finaliza con la atención y cambia a 'ended: finalizada'.

## Cliente llega a la empresa

1. El cliente ingresa su numero de cedula.
2. El aplicativo le informa, sobre agendar una cita, ver pagos y ver servicios contratados.
3. El cliente agenda una cita para contratar un servicio de internet.
4. El cliente es atendido por el cajero.

## Gestor agrega a un cajero
1. El gestor inicia sesión en el aplicativo.
2. El aplicativo le muestra la opción para agregar nuevos cajeros.
3. El gestor rellena los datos del nuevo cajero.
4. El gestor debe escoger una caja disponible para asignarle al nuevo cajero.
5. El aplicativo al finalizar el registro, le muestra al gestor los datos de inicio de sesión del nuevo cajero (email, contraseña).
6. El nuevo cajero, ahora tiene una caja reservada y está listo para tomar turnos.

## Cajero atiende al cliente
1. Previamente el cliente había solicitado atención. Al hacer esto, se le asigno un turno y su respectiva atención.
2. El cajero toma el turno y la atención pasa al estado de 'taked: Tomado'.
3. El aplicativo le informa al cajero sobre los datos de la atención y el cliente. Es decir, el tipo de servicio que solicitó el cliente y sus respectivos datos.
4. También el aplicativo le muestra al cajero opciones, tales como:
	1. Crear un nuevo contrato.
	2. Realizar cambios en el contrato actual, de poseer un contrato.
	3. Cambiar la forma de pago, en caso de poseer un contrato.
	4. Cancelación del contrato, en caso de poseer un contrato.
	5. Actualizar datos del cliente.
5. El cajero realiza una operación acorde a la opción tomada.
6. El cajero da por finalizada la atención y pasa a estado 'ended: finalizado'.