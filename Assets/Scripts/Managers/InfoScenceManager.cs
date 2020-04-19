using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoScenceManager : MonoBehaviour
{

    private GameObject[] images;
    private int i = 0;
    private int length;
    public bool isImgOn;

    public Canvas canvas;

    bool isPause = false;

    void Start()
    {
        images = GameObject.FindGameObjectsWithTag("Image");

        for (int j = 0; j < images.Length; j++)
        {
            images[j].SetActive(false);
        
        }
            isImgOn = false;
           
    }

    
    void Update()
    {
        

            if (Input.GetKeyDown (KeyCode.Space)) {
 
             if (isImgOn == true) {

                 images[i - 1].SetActive(false);
                 isImgOn = false;
                 images[i].SetActive(false);
             }
 
             else {

                 images[i].SetActive(true);
                 isImgOn = true;
                 i++;
               
             }
             
         }

            if (i == (images.Length) && isImgOn == false)
            {

                Scene scence = SceneManager.GetActiveScene();
                SceneManager.LoadScene("Level 1");
            
            }

            if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
            {
                PauseGame();

            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
            {
                UnPauseGame();
            }
        
    }

   public  bool Key(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
             return false;
        if (Input.GetKeyDown(keyCode))
            return true;

        return false;
    }

   public void Skip()
   {
       Scene scence = SceneManager.GetActiveScene();
       SceneManager.LoadScene("Level 1");


   }

   // Update is called once per frame
  

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

   public void QuitMainMenu()
   {
       SceneManager.LoadScene("Main Menu");
   }

   public void RestartGameButton()
   {
       //Scene scence = SceneManager.GetActiveScene();
       SceneManager.LoadScene("Info");

   }

   public void Settings()
   {
       SceneManager.LoadScene("Settings");
   }

}
