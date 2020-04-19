using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryText : MonoBehaviour
{
  
    private Text messageText;

  

    private void Awake()
    { 
    
    messageText = transform.Find("messageText").GetComponent<Text>();
   

    }

    private void Start()
    {
        //messageText.text = "You are a tank driver for a secret organization. Your mission is enter a terrorist building and destroy their all tanks. Be careful they have different types of tanks. You have these tanks' information under this text. Read carefully. We belive to you. Good luck soldier.   Commender  James";

                                                                                                                               
        TextWriter.AddWriter_Static(messageText, messageText.text,0.05f);
    }

    
    void Update()
    {
        

    }
}
