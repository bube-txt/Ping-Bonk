using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject deathMenuUI;
    [SerializeField] private GameObject ball;
   
    // Update is called once per frame
    void Update()
    {
        bool isDead = ball.GetComponent<Ball>().IsDead();
        if (isDead)
        {
            deathMenuUI.SetActive(true);
            Debug.Log("is dead!!!");
        } 
    }
    public void LevelRestart()
    {
        SceneManager.LoadScene(1);
    }
    public void Pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void Quite()
    {
        pauseMenuUI.SetActive(false);
        deathMenuUI.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
