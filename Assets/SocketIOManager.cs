using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using BestHTTP;
using BestHTTP.SocketIO;

public class SocketIOManager : MonoBehaviour {
    public GameObject playerIDInputFieldText;
    public GameObject serverIPAddressInputFieldText;
    public GameObject statusText;
    private SocketManager manager;
    public bool isConnected;

    // Use this for initialization
    void Start () {
        isConnected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConnectServer()
    {
        string serverIPAddress = "http://" + serverIPAddressInputFieldText.GetComponent<Text>().text + ":8080/socket.io/";
        Debug.Log(serverIPAddress);
        // TODO: connect to the server
        try{
            manager = new SocketManager(new Uri(serverIPAddress));
            statusText.GetComponent<Text>().text = "Status: Connected";
            isConnected = true;
        }
        catch
        {
            Debug.Log("An Error");
        }

        // TODO: change status text
    }
    
    public void SendMsg()
    {
        string playerIDInput = playerIDInputFieldText.GetComponent<Text>().text;
        manager.Socket.Emit("message", playerIDInput, "");
    }
}
