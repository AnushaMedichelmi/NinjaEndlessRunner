using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public GameObject winPage;
    public float time;
    public GameObject gameOver;
    public bool isGameWin = false;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = score.ToString();
        time = time + Time.deltaTime;
        if ((time > 3f) )
        {
            gameOver.SetActive(true);
        }
    }
    public void Score(int scoreValue)
    {
        score = score + scoreValue;
        if(score > 30 )
        {
            winPage.SetActive(true);
            isGameWin = true;

        }
        Debug.Log(score);
    }
}