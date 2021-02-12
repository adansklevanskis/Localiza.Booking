# .NET Microservices Localiza Booking


.NET Core Localiza Booking application, é um projeto baseado em microsserviços e containers docker.

## Architecture overview

A arquitetura proposta é orientada a microsserviços independentes, cada um com o seu modelo arquitetural. Foram utilizados vários mecanismos arquiteturais dentro de cada serviço, tais como CRUD e padrões DDD. A arquitetura foi elaborado pra atender as comunicações assíncronas entre os vários microsserviços, baseados nos padrões de Event Bus e Eventos de integração.

### Overview de microsserviços
![](img/Microsservicos.png)


### Overview fluxo de reservas de veículos
![](img/booking_vehicle.png)


### Web.MVC

Página web que irá disponibilizar a navegação do Site.

### Simulation.API 

Microserviço de simulação de reservas de carros. Irá fazer um cache da simulação do usuário para que se o usuário sair da página, o mesmo possa continuar de onde simulou, e efetuar a reserva.

### Booking.API 

Microserviço de reserva irá efetivar a reserva do veículo no período solicitado.

### Checklist.API 

Microserviço de checklist do veículo para finalizar a reserva e obter o valor final.

### Vehicles.API 

Microserviço que contém todos os carros disponível para locação de acordo com agenda.

### Event Bus 

Processo async/sync de mensageria para integração desacoplada das API.

## Roadmap

## Identity.Api 

Criação de Api de autenticação/autorização dos usuários descentralizado.

## Utilização do padrão BFF

Utilizar o padrão para API de backend servindo aos frontend. 

## GRPC

Fazer a comunicação interna entre o BFF e os microserviços.O gRPC é um protocolo de comunicação de alta performance, baseado no http/2 e protocolos de buffers.



