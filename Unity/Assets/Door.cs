using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Door : MonoBehaviour {

    public enum DoorState
    {
        Wall,
        Closed,
        Open
    }

    public DoorState State = DoorState.Wall;

	// Use this for initialization
	void Start ()
	{
	    //SetState(DoorState.Wall);
	}

    public void SetState(DoorState state)
    {
        State = state;

        transform.FindChild("Wall").gameObject.SetActive(false);
        transform.FindChild("DoorClosed").gameObject.SetActive(false);
        transform.FindChild("DoorOpen").gameObject.SetActive(false);
        switch (State)
        {
            case DoorState.Wall:
                transform.FindChild("Wall").gameObject.SetActive(true);

                break;
            case DoorState.Closed:
                 transform.FindChild("DoorClosed").gameObject.SetActive(true);
                break;
            case DoorState.Open:
                transform.FindChild("DoorOpen").gameObject.SetActive(true);

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
