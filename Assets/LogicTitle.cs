using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicTitle : MonoBehaviour
{
    public GameObject startGameObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void startGame()
    {
        startGameObject.SetActive(false);
        SceneManager.LoadScene("SampleScene");

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}



