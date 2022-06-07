using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;

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
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartGame()
    {
        UiManagerController.instance.GameStart();
        ScoreManagerController.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawnerController>().StartSpawingPlatforms();
    }

    public void GameOver()
    {
        UiManagerController.instance.GameOver();
        ScoreManagerController.instance.StopScore();
    }
}
