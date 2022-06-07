using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManagerController : MonoBehaviour
{
    public static UiManagerController instance;

    [SerializeField]
    GameObject tapText;

    [SerializeField]
    GameObject zigZagPanel;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    Text scoreValueText;

    [SerializeField]
    Text highScoreText;            // start screen high score

    [SerializeField]
    Text bestScoreValueText;      // game over's high score 

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
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void GameStart()
    {
        tapText.SetActive(false);

        zigZagPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        scoreValueText.text = PlayerPrefs.GetInt("score").ToString();
        bestScoreValueText.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);

    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
