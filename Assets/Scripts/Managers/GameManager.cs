using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool isPause = false;

    public string settings;
    public string mainmenu;

    GameObject[] enemies;
    GameObject Player;
    public Text enemyCounterText;
    public Text playerHealthText;

    public Canvas canvas;

    Health playerHealth;
    PlayerControl player;

    void Start()
    {
        playerHealth = GetComponent<Health>();
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        player = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            PauseGame();
        
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            UnPauseGame();
        }

        Level();
       
    }

    void PauseGame()
    {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
    }

    void UnPauseGame()
    {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
    }

    public void ResumeGame()
    {
        UnPauseGame();
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitMainMenu()
    {
        SceneManager.LoadScene(mainmenu);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnemyCounter()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyCounterText.text =  enemies.Length.ToString() ;
    }   

    public void PlayerHealthCounter()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealthText.text = player.health.ToString();
        Debug.Log(player.health);
    
    }

    public void Level()
    {
        EnemyCounter();

        if (enemies.Length == 0)
        {
            Scene scence = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scence.buildIndex + 1);
        
        }
           
    
    }

    public void RestartGameButton()
    { 
        Scene scence = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scence.name);
       
    }

    public void Skip()
    {
            Scene scence = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level 1");

 
    }

    
   
}
