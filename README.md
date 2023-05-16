# Hackathon For Good: La Región de AWS en España al Servicio de la Sociedad

## Descripción del Proyecto
Durante el proceso de acogida de nuevos usuarios, los Voluntarios de la Cruz Roja (VCR) utilizan formularios protocolarios que priorizan la captura de datos. Sin embargo, estos formularios obstaculizan la comunicación espontánea, empática y humana ademas de no proveer ningún valor inmediato durante este primer contacto. Lo cual nos motivó a trabajar en este reto.

Inspirados por esta necesidad, desarrollamos una appmovil que sustituye los artesanales formularios por una interfaz que no solo automatiza la captura y estructura de datos mediante la voz, sino que también los interpreta en tiempo real para proveer feedback sobre el contexto cultural del usuario, permitiendo al entrevistador crear un ambiente humano, empático y familiar durante la acogida, lo que hace única nuestra solución.

App-rakis no solo resalta por su singularidad, sino también por su gran potencial de escalabilidad e interoperabilidad. La captura de información estructurada funda las bases para la creación de un lago de datos en la nube, que será analizado en tiempo real por nuestra IA para proveer información útil que permitirá a los VCR tener herramientas para interactuar de forma más cercana con los usuarios, identificar factores de riesgo y sugerir conductas que impacten al usuario desde la primera entrevista.






## Diagrama de Arquitectura

![aws(1)(1)](https://github.com/GmausDev/hack4good/assets/50465630/ede837f9-5038-45d2-999e-7e3195e80367)

## Descripción Técnica

Una visión general de:
**¿Qué tipo de arquitectura habéis planteado?** 

Se ha planteado una arquitectura basada en microservicios y eventos, con el objetivo de generar poco acoplamiento y permitir la adición o eliminación de herramientas y funcionalidades. 
No se ha considerado el uso de DDD o Hexagonal debido a limitaciones de tiempo.

### Capa externa

- Front-end simple que captura datos
  - Utiliza IAM para autenticación y autorización
  - Permite añadir distintos roles

### Captura y procesamiento de datos

- Uso de S3 con "Land-zone"
  - Genera triggers basados en eventos de inserción de objetos
  - Crea eventos de transcripción
- Gestión de datos con Comprehend
  - Almacenamiento de datos para futura explotación

### Código y patrones de diseño

- Código back-end no óptimo (por ahora)
  - Se recomienda utilizar patrones factory para la creación del cliente
  - Implementación de arquitectura CQRS para escalabilidad

## Interacción entre capas

- Front-end interactúa con la API
  - Envío de datos (POST)
  - Solicitud de información (GET)

### Procesamiento de datos en AWS

1. Inserción de datos en S3
   - Trigger de evento de inserción lanza una función Lambda
   - Lambda genera un trabajo de transcripción con el SDK de .NET
2. Transcripción almacenada en otro S3
   - Trigger envía datos a Comprehend para extracción y análisis
3. Datos almacenados en S3
   - Procesados por Lambda y enviados a una base de datos (DynamoDB o Elastic)
   - Enviados a una instancia EC2 con Graviton y modelo LLM (GPT-2 o Bedrock)

El objetivo de la arquitectura es generar informes que proporcionen información sobre las acciones de Cruz Roja y sus actividades, y almacenar los datos de los voluntarios para hacer un "matching" sobre necesidades y recursos humanos.

### Objetivos

- Proporcionar información relevante al entrevistador (poemas, datos sobre la ciudad, contexto)
- Generar reportes sobre acciones de Cruz Roja y sus actividades
- Almacenar datos de voluntarios para realizar "matching" entre necesidades y recursos humanos


**¿Qué tecnologías AWS se han utilizado?**

Amazon S3, Cloudfront, Cognito IAM, EC2 con Graviton, lambda, Elastic, Dynamo, Comprehend, Bedrock, Transcribe.
## Demo Vídeo

https://youtu.be/CYlPNVv009E




## Team Members
Jorge Quevedo Duran - jorque3@hotmail.com
Cristian - cristiansc2@gmail.com
Jaime - jalpimo@gmail.com

