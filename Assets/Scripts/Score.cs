using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreUI;

    public int score = 0;
    public int completeScore = 5;

    public void AddScore()
    {
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }
    private void Update()
    {
        if(score==completeScore)
        {
            SceneManager.LoadScene(1);
        }
    }
}
