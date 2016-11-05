using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour {

    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public Direction Entrance;
    public Direction Exit;

    public bool IsActive = false;
    public bool CanExit = false;

    public bool PlayerIsInRoom = false;

    public Door[] Doors = new Door[4];

    Transform enemyContainer;
    Transform propsContainer;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (!IsActive) return;

        // check number of enemies
	    if (enemyContainer.childCount == 0 && CanExit)
	    {
            if(Doors[(int)Exit].State == Door.DoorState.Closed)
	           Doors[(int)Exit].SetState(Door.DoorState.Open);
	    }

        // Close the door behind the player
        if(PlayerIsInRoom && Doors[(int)Entrance].State == Door.DoorState.Open)
            Doors[(int)Entrance].SetState(Door.DoorState.Closed);
    }

    public void Roll(Direction prevExit)
    {
        enemyContainer = transform.FindChild("Enemies");
        propsContainer = transform.FindChild("Props");

        switch (prevExit)
        {
            case Direction.North:
                Entrance = Direction.South;
                break;
            case Direction.South:
                Entrance = Direction.North;
                break;
            case Direction.East:
                Entrance = Direction.West;
                break;
            case Direction.West:
                Entrance = Direction.East;
                break;
            default:
                throw new ArgumentOutOfRangeException("prevExit", prevExit, null);
        }

        Exit = (Direction)Random.Range(0, 4);
        //while (!(Entrance != Exit && RoomManager.Instance.CanPlaceRoom(Exit)))
        while (Entrance == Exit)
        {
            Exit = (Direction) Random.Range(0, 4);
        }

        Doors[(int) Entrance].SetState(Door.DoorState.Open);
        Doors[(int) Exit].SetState(Door.DoorState.Closed);

        // Enemies
        for(int i=0;i<enemyContainer.childCount; i++)
            if(Random.Range(0,2)==0) Destroy(enemyContainer.GetChild(i).gameObject);

        // Props
        for (int i = 0; i <propsContainer.childCount; i++)
            if (Random.Range(0, 10)<9) Destroy(propsContainer.GetChild(i).gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.GetComponent<Player>())
        {
            PlayerIsInRoom = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.transform.GetComponent<Player>())
        {
            PlayerIsInRoom = false;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.transform.GetComponent<Player>())
        {
            PlayerIsInRoom = true;
        }
    }
}
