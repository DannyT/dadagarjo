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
        
        HubConnection connection = new HubConnection(hubUrl);
        IHubProxy proxy = connection.CreateProxy("RoomHub");

        // subscribe to event
        proxy.Subscribe("SetRoom").Data += data =>
        {
            var _first = JsonUtility.FromJson<Room>(data[0].ToString());
            Debug.Log(_first.RoomName);
        };



        Debug.Log("Connecting... ");
        connection.Start();
        Debug.Log("done. Hit: ");
    }

    private void Connection_Received(string obj)
    {
        Debug.Log("Raw response:");
        Debug.Log(obj);
        mess = JsonUtility.FromJson<Message>(obj);
        Debug.Log("From Hub:");
        Debug.Log(mess.H);
        Debug.Log("From Method:");
        Debug.Log(mess.M);
        Debug.Log("Data:");
        Debug.Log(mess.A);

        if(mess.M.ToLower() == "setroom")
        {
            Debug.Log(((Room)mess.A[0]).RoomName);
        }


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
