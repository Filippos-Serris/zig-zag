using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerController : MonoBehaviour
{
    [SerializeField]
    GameObject platform;

    [SerializeField]
    GameObject pickUp;

    Vector3 lastPos;

    float platformSize;

    public PlayerController PlayerController;

    // Use this for initialization
    void Start ()
    {
        PlayerController = FindObjectOfType<PlayerController>();

        lastPos = platform.transform.position;              // setting the lastPos to the only existing platform 
        platformSize = platform.transform.localScale.x;     // platformSize set by x or z -> z=2=x 

        for (int i=0; i<10; i++)
        {
            PlatformSpawn();
        }
	}

    public void StartSpawingPlatforms()
    {
        InvokeRepeating("PlatformSpawn", 0.1f, 0.2f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerController.gameOver)
        {
           CancelInvoke("PlatformSpawn");
        }
    }

    void PlatformSpawn()
    {
        int rand = Random.Range(0, 6);

        if (rand < 3)
        {
            SpawnX();
        }

        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;                                // pos is the position of the last platform 
        pos.x += platformSize;                                // setting the position of the new platform in the x direction 
          
        lastPos = pos;                                        // changing the last position to the current position of the platform 

        Instantiate(platform, pos, Quaternion.identity);     // create a clone of the previous platform and place it in pos position by no rotating it "Quaternion.identity" 

        int rand = Random.Range(0, 4);

        if (rand<1)
        {
            Instantiate(pickUp, new Vector3(pos.x, pos.y + 1, pos.z), pickUp.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += platformSize;

        lastPos = pos;

        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);

        if (rand < 1)
        {
            Instantiate(pickUp, new Vector3(pos.x, pos.y + 1, pos.z), pickUp.transform.rotation);
        }
    }
}
