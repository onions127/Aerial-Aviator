using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScrpit : MonoBehaviour
{
    public AudioManger audioManager;
    public Animator animator;

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myRigidbody.transform.position.y > 18 || myRigidbody.transform.position.y < -16)
        {
            birdIsAlive = false;
            audioManager.PlaySFX(audioManager.death);
            logic.gameOver();
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            audioManager.PlaySFX(audioManager.flap);
            animator.SetBool("SpacePressed", true);
        }
        else if(animator.GetBool("SpacePressed"))
        {
            animator.SetBool("SpacePressed", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Doughnut")
        {
            logic.addScore();
            logic.addScore();
            logic.addScore();
            logic.addScore();
            logic.addScore();
        }
        else
        {
            audioManager.PlaySFX(audioManager.death);
            logic.gameOver();
            birdIsAlive = false;
            Destroy(gameObject);
        }

    }
}
