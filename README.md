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


## Scope of the project
- Create different users
- Send Greetings email on successfull registration
- One To One User Chat Service
- Broadcast chat service
- Login / Logout / Registration
- User CRUD [Update Profile, Delete My Account ...]
- Chat Messages CRUD

## Technologies to be used
1. WCF(Windows Communication Foundation) Service in C#
2. C# Console App
3. Windows Forms

## UI 💻
<img src="https://user-images.githubusercontent.com/48133426/108638536-d5373600-74b5-11eb-96e6-5a6ed4ad6f55.jpg" width="45%"></img> <img src="https://user-images.githubusercontent.com/48133426/108638542-d7999000-74b5-11eb-82d8-1340aa6cd97d.jpg" width="45%"></img> <img src="https://user-images.githubusercontent.com/48133426/108638553-dcf6da80-74b5-11eb-8ec1-7626d4866e18.jpg" width="45%"></img> <img src="https://user-images.githubusercontent.com/48133426/108638559-dff1cb00-74b5-11eb-997c-b4aae27dacb2.jpg" width="45%"></img> <img src="https://user-images.githubusercontent.com/48133426/108638563-e4b67f00-74b5-11eb-9442-c937cad2a4db.png" width="45%"></img> <img src="https://user-images.githubusercontent.com/48133426/108638566-e718d900-74b5-11eb-9498-8e9d1c7e1a91.png" width="45%"></img> 

## Live Demo
[Visit Demo](http://bit.ly/soc_project_demo) <br>
[Presentation_Doc](http://bit.ly/soc_project_demo_doc)

---------

```javascript

if (youEnjoyed) {
    starThisRepository();
}

```

-----------

## Thank You
- Author : [Nevil Parmar](https://nevilparmar.me)
