![Logo](https://user-images.githubusercontent.com/48133426/108637853-81771d80-74b2-11eb-8bca-c891660e59a6.jpg)

## WCF-ChatApplication
Multi-user Chat application.

It supports 2 modes: <br>
1. Broadcast Mode
- Users in a network can broadcast their msgs among themselves. 
- Uses TCP Dual binding protocol.
- Implemented using WCF duplex service, where users send their msg to the server , and server, in turn, forwards their messages to all the users in a network using Client Callback

2. One-One Chat Mode
- Implemented using WCF Callback mechanism

**NOTE:** All of these modes work in real-time updates.

## Implementation Details:
The project solution contains 3 projects. <br>
![solution](https://user-images.githubusercontent.com/48133426/108638225-2d6d3880-74b4-11eb-8047-b4096ec9089f.jpg)

1. ChatServiceLibrary 
  - WCF Service Library 
  - The library contains 3 major services
    1. User Service
		- Deals with user CRUD service operations
    2. Broadcast Service
    - Deals with Broadcast message service operations
    3. One-One Chat Service
    - Deals with a one-one chat message service operations

2. ChatServiceHost 
- Console based host application

3. WindowsClient
- Multi-Screen Windows forms type Client application
