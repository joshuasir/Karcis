# Karcis App
an online booking event system in form of Web App which implement microservice .NET technology. There 2 roles user and admin where user can look for event choose the ticket type and amount for the event. User need to signup and verify their email to book tickets. After ordering a ticket(s) user can check in their history tab and can choose to pay. Admin can then check the user payment and validate the order.

Features
Dynamic event
![image](https://user-images.githubusercontent.com/71873035/174487437-7e3034a0-f608-4c14-b5ae-0f10dc5c7fbf.png)

Register, Login, and Email validation
![image](https://user-images.githubusercontent.com/71873035/174487430-f0e3b1f9-d759-4ede-a198-89842f54c9a9.png)

![image](https://user-images.githubusercontent.com/71873035/174487426-81b1fe0d-5d99-4008-abb9-83cca0f6a4fc.png)


Post a booking order
![image](https://user-images.githubusercontent.com/71873035/174487416-c44257de-9de5-47f8-9b33-18017e7a06c6.png)


Virtual Account Payment
![image](https://user-images.githubusercontent.com/71873035/174487405-ee58efbb-afc3-4ac4-a7e0-fbde8b37738d.png)


Cancel a booking
![image](https://user-images.githubusercontent.com/71873035/174487392-70d56b92-fe1e-4409-891e-042b8a91e491.png)
![image](https://user-images.githubusercontent.com/71873035/174487398-5827496b-59fc-4aa0-a0c5-28c140e3a429.png)


Accept or Decline order via admin role
![image](https://user-images.githubusercontent.com/71873035/174487391-b46f61ba-c043-43fd-aab7-3deddb03e3a4.png)
![image](https://user-images.githubusercontent.com/71873035/174487386-3f1bebcb-2b41-4cfb-902d-8aa592c80efa.png)


Dokumentasi API App Karcis.com

![image](https://user-images.githubusercontent.com/71873035/174487378-3ae8b9db-bbbe-4c68-b658-d0dafd3b9135.png)

Database skema


for security we used jwt security token for verifying user for each request with bcrypt encryption. For the API design pattern consist of Model, Helper, and Service where Model includes the model representation of Entity in the database, service as the service layer receiving the request, and helper contains our business logic for querying the data. The API used LINQ technology to do data manipulation to reduce the weight on the database server/
