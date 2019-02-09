using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour {

    Player player;
    float health;
    


    // Use this for initialization
    void Start () {

        player = FindObjectOfType<Player>();
        
       

    }
	
	// Update is called once per frame
	void Update ()
    {
        health = player.GetHealth();
        HealthRender();

    }

    private void HealthRender()
    {
        if (health < 200)
        {
            Destroy(GameObject.Find("Heart 1"));

        }
        if (health < 100)
        {

            Destroy(GameObject.Find("Heart 2"));

        }
        if (health <= 0)
        {
            Destroy(GameObject.Find("Heart 3"));

        }
    }

}
