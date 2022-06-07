using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject particleSystem;

    [SerializeField]
    float speed;

    bool started;
    public bool gameOver;

    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();

        started = false;
        gameOver = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManagerController.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.black);  // Draw the Ray under the player so it can be visible foe any reson you want 

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))     // Raycast is a line in this case that pointing down of the player and detects if collides with anything   (position of the player,direction of the line,the distance tha line can detect) 
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            GameManagerController.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }

        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            GameObject particle = Instantiate(particleSystem, other.gameObject.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(particle, 1f);
        }
    }
}
