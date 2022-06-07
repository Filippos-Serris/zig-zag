using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerController : MonoBehaviour
{
    public static ScoreManagerController instance;

    public int score;
    public int highScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void ScoreCounter()
    {
        score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating("ScoreCounter", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("ScoreCounter");

        PlayerPrefs.SetInt("score", score);

        if(PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }

        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
    
}
