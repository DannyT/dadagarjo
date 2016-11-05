using Assets.Scripts.Models;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour
{

    public GameObject[] gameObjects;

    private SocketController _sc;

    private Room _nextRoom;

    public string socketUrl = "http://dadagarjo.azurewebsites.net";

    void Start()
    {
        _sc = this.GetComponent<SocketController>();
        _sc.Init(socketUrl);
    }
    
    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

    public void setNextRoom(Room room)
    {
        _nextRoom = room;
    }
}
