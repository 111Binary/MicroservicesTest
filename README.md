Microservices Demo 
==================

Dockerized microservices architecture that follows CQRS pattern  with Event Sourcing
the solution used the following tools

 - .NetCore 2.1
 - MongoDB
 - RabbitMQ
 - Docker


 ![Alt text](MicroservicesArchitecture.png?raw=true "Dockerized microservices architecture")

 ### Table of contents

You can insert a table of contents using the marker `[TOC]`:

[TOC]

 ## Getting Started
 below is the problem and proposed solution

 Problem
-------------
set of customers want to track thier vehicles using a high avilable system that they can relay on.
they agreed that vehicles will have a tracking device that will send a signal once every minute.
in case the vehicle faild to contact the server the vehicle is considered offline.


Solution
---------------
the solution every point for vehicles will have heavy load and another point that will be used by customers will have low traffic.
we need to seprate them inorder to be able to scale both aggregates separatly, but how they will communicate ???
there is many solutions here but we will follow microservices architecture and CQRS pattern

the solution have the following

- ApiGateway : to handle Queries only, also handle Events to keep Query data consistant
- ApiGateway.Command: to handle Commands and publish commands to Queue
- Ping:microservice to handle the ping command and do some processing and may raise Events for other services to handle
- UI : angular client that reads data and raise commands using Http commands only


ApiGateway has its own totally isolated database to keep queries data only for client application.
ApiGateway.Command doesn't have any database just recieves command and publish the command to Queue
Ping has its own isolated database to keep its business data

 Analysis
-------------
 below is sequence digram and life cycle of Ping Command that will be issues from Vehicles:

```sequence
Vehicle->Command: hey, I am connected
Command->Queue: Ping Command
Command-->Vehicle: Accepted
Queue-->Ping Microservice:Ping Command
Note right of Ping Microservice: Process/Save
Ping Microservice->Queue:Ping received event
Queue-->Query:Ping received event
Note right of Query:Save Data
```


### Prerequisites

to run and build this solution you will need the following software installed and configured

```
* [Visual Studio Community 2017](https://www.visualstudio.com/downloads/) - to run and build the solution
* [Docker](https://www.docker.com/) - to dockerize the solution	
* [Docker toolbox](https://docs.docker.com/toolbox/toolbox_install_windows/) - to make deployment easy ;)
```
## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Give examples
```

### Installing

download the source file to your machine and open your Command Line.

run the following Commands in exact order

```
cd {Path to solution rootFolder}
```
now you are at the solution root folder run the following command and wait until the command process ends 

```
docker-compose build
```
that will build our solution projects and dockerize the solution based on docker-compose.yml, that might take some time but wait until the process ends.

then run the following command

```
docker-compose run start_dependencies
```

the above command will download rabbitMQ and mongoDB images if it doesn't exist on your machine, and start containers for them,
this is a work around to wait for rabbitMQ container until rabbitMQ listen to the configured port.

```
docker-compose up
```
the above command will start our solution in Docker enviroment


## End Points
the following section list the system endpoints

End point                    | port     | Usage
-----------------------------|----------|-------
ApiGateway (Queries)         | 8091     | to recieve queries from UI clients and send back query results
ApiGateway.Command(Commands) | 8090     | to revieve commands from UI clients
UI                           | 8080     | system UI that used queries and commands api gateways


## Authors

* **Mohamed Abduljawad** - *Initial work*

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License
