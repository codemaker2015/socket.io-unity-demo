
# socket.io-unity-demo

Socket.IO Client Library for Unity


## Installation

[Download](https://github.com/Rocher0724/socket.io-unity/releases) on release page socket.io-unity.unitypackage and import into Unity.

* Open cmd in server folder and install the following dependencies.

```
  npm install express socket.io@1.7.4
```

## Usage

* Open cmd in server folder and type

```
  node index
```

* Open the code in Unity Editor and click on Play


### unity player settings - other settings - configuration

* Api Compatibility Level : .NET 4.x

* Unity Version: 2019.4.17f1 LTS


```cs
// unity c# code
using System.Collections;
using System.Collections.Generic;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class TestObject : MonoBehaviour {
  private QSocket socket;

  void Start () {
    Debug.Log ("start");
    socket = IO.Socket ("http://localhost:3000");

    socket.On (QSocket.EVENT_CONNECT, () => {
      Debug.Log ("Connected");
      socket.Emit ("chat", "Thank You");
      socket.On ("chat", data => {
         Debug.Log ("Server: " + data);
      });
    });    
  }

  private void OnDestroy () {
    socket.Disconnect ();
  }
}
```



```javascript
// node js code
const app = require('express')();
const http = require('http').createServer(app);
const io = require('socket.io')(http);
app.get('/', (req, res) => {
    res.sendFile(__dirname + '/index.html');
});
io.on('connection', (socket) => {
    console.log('a user connected');
    socket.on('chat', (msg) => {
	console.log("Client: ", msg)
        socket.emit("chat", "Welcome to Rapid Labs");
    });
    socket.on('disconnect', () => {
        console.log('user disconnected');
    });
});
http.listen(3000, () => {
    console.log('Server running at 3000');
});


```



## Features

This library supports all of the features the JS client does, including events, options and upgrading transport.

## Framework Versions

- Mono

- .NET 4.x
    - Unity project setting - Scripting Runtime Version : .NET 4.x Equivalent
    - Unity project setting - Api Compatibility Level : .NET 4.x
    - Unity Editor restart


