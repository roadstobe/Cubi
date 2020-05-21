using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelUI;
    public Text scoreUI;
    bool gameHasEnded = false;

    public float restartTime;

    public Transform playerTransform;

    

    void Update(){
        scoreUI.text = playerTransform.position.z.ToString("0");
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("RestartGame", restartTime);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        panelUI.SetActive(true);
    }
}
