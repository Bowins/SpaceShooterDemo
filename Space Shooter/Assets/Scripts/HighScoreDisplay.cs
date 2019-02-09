using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {

    Text scoreText;
    GameSession gameSession;
    Level level;


    // Use this for initialization
    void Start()
    {

        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameSession.GetScore() > level.GetHighScore())
        {
            level.SetHighScore(gameSession.GetScore());
            scoreText.text = level.GetHighScore().ToString();
        }


    }
}
