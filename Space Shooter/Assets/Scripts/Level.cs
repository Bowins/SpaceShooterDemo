using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float delayInSeconds = 2f;
    int highScore = 0;

    public int GetHighScore()
    {
        return highScore;
    }

    public void SetHighScore(int x)
    {
        highScore = x;
    }


    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        
        SceneManager.LoadScene("Game");
        highScore = FindObjectOfType<GameSession>().GetScore();
        FindObjectOfType<GameSession>().ResetGame();
    }

    

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
