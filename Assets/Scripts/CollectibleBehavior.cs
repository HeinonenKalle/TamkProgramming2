﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehavior : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
