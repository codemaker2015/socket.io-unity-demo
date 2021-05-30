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