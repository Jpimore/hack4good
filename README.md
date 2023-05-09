# Hackathon For Good: La Región de AWS en España al Servicio de la Sociedad

## Descripción del Proyecto

Una breve descripción de:
¿Qué problema estamos tratando de resolver? 

- Durante el proceso de acogida de nuevos usuarios, los Voluntarios de la Cruz Roja (VCR) utilizan formularios protocolarios que priorizan la captura de datos. Sin embargo, estos formularios obstaculizan la comunicación espontánea, empática y humana ademas de no proveer ningún valor inmediato durante este primer contacto. Lo cual nos motivó a trabajar en este reto.

¿Cuál es la solución propuesta? 
- Se ha diseñado una app movil, con la que podriamos grabar y transcribir las entrevistas, ademas de digitalizar los documentos. Tambien optimizar la extraccion de datos para optimizar los procesos de Cruz roja.  

Descripción de la Solución

Hemos diseñado una app movil, para que se pueda ejecutar desde cualquier dispositivo. Siendo una interfaz lo mas basica posible, en la que grabamos la entrevista , capturamos las imagenes que necesitamos y enviamos toda esta informacion a un data lake(S3). Pudiendo extraer la informacion necesaria a traves de servicios de IA y ofreciendo informacion util a la persona de Cruz roja a traves de Modelos de LLM. Con la optencion de datos tambien podemos cuadrar los datos que tiene Cruz Roja de voluntarios para saber cuales son sus necesidades y que recursos humanos tiene.
Realizando asi un "matching " entre recursos y necesidades a traves de los datos.Ademas como valor añadido, a traves de servicios como bedrock podemos enviar la informacion obtenida para ofrecer al entrevistador informacion util sobre el caso que esta tratando(informacion cultural, historias, algo que haga mas facil la situacion).Tambien hay que añadir que al tener a disposicion estos datos se pueden generar dashboards sobre la situacion de las personas en base de la informacion recibida.



## Diagrama de Arquitectura

![aws(1)](https://github.com/GmausDev/hack4good/assets/50465630/a4123c16-152b-4924-b9fe-ff55cbf5e9d9)


## Descripción Técnica

Una visión general de:

**¿Qué tipo de arquitectura habéis planteado?** Se ha planteado una arquitectura con Microservicios y eventos, no se ha planteado DDD o Hexagonal por tiempo en cuanto al planteamiento se desarrollado en base a generar poco acoplamiento puediendo añadir mas herramientas o quitar funcionalidades, en la capa externa tenemos un front simple que captura datos usando IAM para autentificacion y autorizacion, pudiendo añadir distintos roles.Una vez capturamos los datos, usamos S3 con "Land-zone", para genera triggers en base a los eventos de insercion de objetos creando asi los eventos de transcripcion. Usando la misma metodologia gestionamos esos datos con comprehend y almacenamos los datos para su futura explotacion.En cuanto al codigo dispuesto no es ni mucho menos lo que se puede esperar en el back , deberiamos utilizar correctamente patrones factory para la creacion del cliente y un arquitectura del tipo CQRS para poder tener un sistema escalable. Entregamos una muestra de front y poco del back ya que hemos querido darle tiempo a la arquitectura, en resumen tendriamos un front que interactua con la API, para enviar los datos y para pedir informacion sobre lo datos pedidos(Basicamente un POST y un GET). Cuando insertamos los datos en S3 , tenemos un trigger del evento de insercion el cual lanza un lambda para generar un job de transcribe a traves del sdk de .net. Este job deja todo la informacion en otro S3 para que otro trigger usando el mismo metodo anterior envie los datos generados a Comprehend el cual extrae datos y analiza lo que necesitemos, mas adelante estos datos se dejan en S3 y son procesados por una lambda que los envia a una Base de datos para su explotacion ya sea Dynamo o usar un Elastic, tambien lo enviamos a una maquina EC2 con graviton donde se encuentra el modelo LLM, ya sea GPT-2 el cual disponemos u otro modelo mas adelante Bedrock, para pasar toda la informacion obtenida y dar informacion interesante al entrevistador, poemas, datos sobre la ciudad o situacion de la que huye el usuario para que entienda mas el contexto. La idea es que con todos estos datos de usuarios podamos generar reportes que puedan dar algo de informacion sobre las acciones de cruz roja y sus actividades. Tambien con esta informacion podriamos almacenar los datos de los voluntarios para asi tener un "matching" sobre necesidades y recurso humano.


**¿Qué tecnologías AWS se han utilizado?**

Amazon S3, Cloudfront, Cognito IAM, EC2 con Graviton, lambda, Elastic, Dynamo, Comprehend, Bedrock, Transcribe.
## Demo Vídeo




https://github.com/GmausDev/hack4good/assets/50465630/bfe57633-a7f8-48ad-a459-4ed52ac8afa8



## Team Members
Jorge Quevedo Duran - jorque3@hotmail.com
Cristian - cristiansc2@gmail.com
Jaime - jalpimo@gmail.com

