using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int points = 0;
    private bool gameRunning = true;
    public Text pointsAfficher;
    private int pointsTot = 0;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        pointsAfficher.text = pointsTot.ToString();

    }

    public void GameOver()
    {
        if (gameRunning)
        {
            gameRunning = false;
            Debug.Log("GAME OVER!");
            Invoke("ReloadGame", 0.1f);
            Time.timeScale = 0.1f;
        }
    }

    private void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void addPoints(int points)
    {
        pointsTot += points;
    }

}
