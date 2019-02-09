using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    Text scoreText;
    GameSession gameSession;
    Level level;


	// Use this for initialization
	void Start () {

        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
		
	}
	
	// Update is called once per frame
	void Update () {

        scoreText.text = gameSession.GetScore().ToString();
        
		
	}
}
