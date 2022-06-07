using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    Vector3 offset;   // Distance between camera and player 

    [SerializeField]
    float lerpRate;   

    public PlayerController PlayerController;

	// Use this for initialization
	void Start ()
    {
        offset = target.transform.position - transform.position;

        PlayerController = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!PlayerController.gameOver)
        {
            Follow();
        }
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position - offset;

        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);    // Moves from a to b with a rate 

        transform.position = pos;
    }
}
