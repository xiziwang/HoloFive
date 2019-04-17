using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {
    private SocketIOManager socketIOManager;

    // Use this for initialization
    void Start () {
        socketIOManager = GameObject.Find("SocketIOCanvas").GetComponent<SocketIOManager>();

    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player2Hand")
        {

            // TODO: Send msg to phone
            socketIOManager.SendMsg();
        }
    }
}
