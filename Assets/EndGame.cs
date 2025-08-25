using UnityEngine;

public class EndGame : MonoBehaviour
{

    public LogicScript Logic;
    public BirdScript Bird;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            Logic.gameOver();
            Bird.birdIsAlive = false;



    }
}
