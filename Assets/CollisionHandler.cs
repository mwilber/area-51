using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        HandleSaucerCollision();
    }

    void HandleSaucerCollision() {
        print("COLLISION!");
        SendMessage("OnSaucerCollision");
    }
}
