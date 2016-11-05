using Assets.Scripts.Models;
using Newtonsoft.Json.Linq;
using SignalR.Client._20;
using SignalR.Client._20.Hubs;
using System;
using UnityEngine;

public class SocketController : MonoBehaviour
{

    public GameController _gc;

    //private WebSocket ws;
    private HubConnection connection;
    public Message mess;

    // Use this for initialization
    public void Init(string hubUrl)
    {
        _gc = this.GetComponent<GameController>();

        connection = new HubConnection(hubUrl);
        IHubProxy proxy = connection.CreateProxy("roomHub");
        connection.Closed += Connection_Closed;
        connection.Received += Connection_Received;

        Debug.Log("Trying to connect");
        connection.Start();

        Debug.Log("Invoking \"Hello\"");
        proxy.Invoke("hello");
    }

    private void Connection_Received(string obj)
    {
        Debug.Log("Raw response:");
        Debug.Log(obj);
        JsonUtility.FromJsonOverwrite(obj, mess);
        Debug.Log("From Hub:");
        Debug.Log(mess.H);
        Debug.Log("From Method:");
        Debug.Log(mess.M);
        Debug.Log("Data:");
        Debug.Log(mess.A);
    }

    private void SocketController_Data(object[] obj)
    {
        Debug.Log(obj);
    }

    private void Connection_Closed()
    {
        Debug.Log("HubConnection closed");
    }

    private void OpenedSocket(object sender, EventArgs e)
    {
        Debug.Log("OpenedSocket");
    }

    private void Send(int type, Room data)
    {

    }
}
