using UnityEngine;

public class BirdScript : MonoBehaviour
{


    public Rigidbody2D myRigidbody2D;
    public float flapStrength = 10;
    public LogicScript Logic;
    public bool birdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody2D.linearVelocity = Vector2.up * flapStrength;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.gameOver();   
        birdIsAlive = false; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Logic.gameOver();
            birdIsAlive = false;
        }
    }
}
