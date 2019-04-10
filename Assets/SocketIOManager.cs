using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocketIOManager : MonoBehaviour {
    public GameObject playerIDInputFieldText;
    public GameObject serverIPAddressInputFieldText;
    public GameObject statusText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConnectServer()
    {
        string playerIDInput = playerIDInputFieldText.GetComponent<Text>().text;
        string serverIPAddress = "ws://" + serverIPAddressInputFieldText.GetComponent<Text>().text + ":8080/socket.io/?EIO=4&transport=websocket";
        Debug.Log(serverIPAddress);
        // TODO: connect to the server

        // TODO: change status text
}
}
