using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public BirdScript bird;
    public AudioSource scoreSound;
    public AudioSource gameSound;

    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highestScoreText.text = "High Score: " + highScore.ToString();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if(bird.birdIsAlive)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            scoreSound.Play();
        }
        

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if(playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highestScoreText.text = "High Score: " + highScore.ToString();
        }
        else
        {
            highestScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void pauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            scoreText.gameObject.SetActive(false);
            gameSound.Pause();

        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            scoreText.gameObject.SetActive(true);
            gameSound.Play();
        }
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        gameSound.Play();
    }

    public void backtoMainMenu()
    {
        Time.timeScale = 1;
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save(); 
        SceneManager.LoadScene("ScreenTitle");

    }

}
