using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSupport : MonoBehaviour {

    Level level;
    GameSession gameSession;

    // Use this for initialization
    void Start () {

         level = FindObjectOfType<Level>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("joystick button 0")){
            level.LoadGame();
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Application.Quit();
        }

    }
}
