﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBoxTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (FindObjectOfType<DarkRoomTransition>())
            {
                FindObjectOfType<DarkRoomTransition>().PlayerEnterDarkBox();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (FindObjectOfType<DarkRoomTransition>())
            {
                FindObjectOfType<DarkRoomTransition>().PlayerExitDarkBox();
            }
        }
    }
}
