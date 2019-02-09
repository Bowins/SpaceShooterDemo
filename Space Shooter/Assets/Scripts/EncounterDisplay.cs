using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterDisplay : MonoBehaviour {

    Text levelText;
    GameSession gameSession;
    Level level;
    float score;


    // Use this for initialization
    void Start()
    {

        levelText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();

    }

    // Update is called once per frame
    void Update()

    {
        EncounterUICheck();
    }

    private void EncounterUICheck()
    {
        score = gameSession.GetScore();
        if (score < 5000)
        {
            levelText.text = "Ensign";
        }
        else if (score >= 5000 && score < 10000)
        {
            levelText.text = "Officer";
        }
        else if (score >= 10000 && score < 15000)
        {
            levelText.text = "Lieutenant";
        }
        else if (score >= 15000 && score < 25000)
        {
            levelText.text = "Captain";
        }
        else if (score >= 25000 && score < 40000)
        {
            levelText.text = "Commander";
        }
        else
        {
            levelText.text = "Admiral General";
        }
    }
}
