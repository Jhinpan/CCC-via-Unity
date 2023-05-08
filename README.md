# Task: Implement a Chat-based Content Creation App in Unity
## Skill needed: 
Unity, Python, C#, Socket, Json
## Introduction:
We will be creating a content creation app using Unity, which will have basic chatbot functionality. The app will consist of two components: a client built in Unity and a server built in Python. The client and server will communicate with each other through a socket connection.

---

## Step 1 (Done):
### Requiremnt: 
  Setting up the connection - To begin, we will establish a connection between the Unity client and the Python server. This connection will allow them to exchange messages with each other. Think of the Unity app as the "client" and the Python app as the "server." The socket connection will enable them to send and receive messages seamlessly.
### Implementation: 
  By adding the C#connect.cs as the client script for a cube in the unity and a python script server.py, we realize the seamless connection between unity and python which can be seen as we can make the cube in the unity constantly moving and reporting through both console terminal.
  
--- 

## Step 2: (Done)
### Requirement:
  Building the Unity user interface - In Unity, we will implement the user interface (UI) where the user can interact with the app. The UI will include a text input field where the user can enter the name of an object they want to create in the scene. For example, they might enter "spheres" or "cubes."
### Implementation:
  Implement a input field under a canvas and adjust it according to the instruction from online. And also write an readInput.cs to this text input field that can reflect what the user input through the unity console
  
 ---
 
 ## Step 3:
 ### Requirement:
  Adding interactivity and chatbot functionality - To make the app more interactive, we will implement a chatbot feature. After the user enters the name of an object, the application will prompt the user to specify the desired color and size of the object. This interaction will take place within the Unity app. Once the user provides the color and size information, the application will create the object accordingly in the scene. Furthermore, the application will convert the object data into JSON format and send it to the server. The server, implemented in Python, will receive the JSON data and process it accordingly.
