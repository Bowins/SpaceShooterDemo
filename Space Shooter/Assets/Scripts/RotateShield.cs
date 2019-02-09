using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShield : MonoBehaviour {
    Player player;

	// Use this for initialization
	void Start () {

        player = FindObjectOfType<Player>();
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(player.GetHealth() <= 100)
        {
            Destroy(gameObject);
        }
	}
}
