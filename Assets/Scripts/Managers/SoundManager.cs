using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public bool mute;

    Toggle toggle;

    void Awake()
    {

        if (toggle == null)
        { 
        
          toggle = FindObjectOfType<Toggle>();
        
        }
    
    }

    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ToogleMusic(bool value)
    {

        mute = value;

        if (mute)
        {

            toggle.isOn = true;
            AudioListener.volume = 0;
        }

        else
        {

            toggle.isOn = false;
            AudioListener.volume = 1;
        
        }
    
    }
    
    
}
