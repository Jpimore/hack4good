# Hackathon For Good: La Región de AWS en España al Servicio de la Sociedad

## Descripción del Proyecto
Durante el proceso de acogida de nuevos usuarios, los Voluntarios de la Cruz Roja (VCR) utilizan formularios protocolarios que priorizan la captura de datos. Sin embargo, estos formularios obstaculizan la comunicación espontánea, empática y humana ademas de no proveer ningún valor inmediato durante este primer contacto. Lo cual nos motivó a trabajar en este reto.

Inspirados por esta necesidad, desarrollamos una appmovil que sustituye los artesanales formularios por una interfaz que no solo automatiza la captura y estructura de datos mediante la voz, sino que también los interpreta en tiempo real para proveer feedback sobre el contexto cultural del usuario, permitiendo al entrevistador crear un ambiente humano, empático y familiar durante la acogida, lo que hace única nuestra solución.

App-rakis no solo resalta por su singularidad, sino también por su gran potencial de escalabilidad e interoperabilidad. La captura de información estructurada funda las bases para la creación de un lago de datos en la nube, que será analizado en tiempo real por nuestra IA para proveer información útil que permitirá a los VCR tener herramientas para interactuar de forma más cercana con los usuarios, identificar factores de riesgo y sugerir conductas que impacten al usuario desde la primera entrevista.






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

