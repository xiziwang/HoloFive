using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player2Hand")
        {

            // TODO: Send msg to phone
            Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        }
    }
}
