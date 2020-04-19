using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private static TextWriter instance;
    private List<TextWriterSingle> textWriterSinlgeList;

    private void Awake()
    {
        instance = this;
    textWriterSinlgeList = new List<TextWriterSingle>();
    
    }
    
    public static void AddWriter_Static(Text uiText, string textToWrite, float timePerCharacter)
    {
    
        instance.AddWriter(uiText,textToWrite,timePerCharacter);
    
    }

    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter)
    {
        textWriterSinlgeList.Add(new TextWriterSingle(uiText, textToWrite, timePerCharacter));
        
    }

    private void Update()
    {
        for (int i = 0; i < textWriterSinlgeList.Count; i++)
        {
           bool destroyInstance = textWriterSinlgeList[i].Update();

           if (destroyInstance)
           {

               textWriterSinlgeList.RemoveAt(i);
               i--;
              
           }

          
        }

           
    }
   
        
    public class TextWriterSingle {


        private Text uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;

        public TextWriterSingle(Text uiText, string textToWrite, float timePerCharacter)
        {

            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            characterIndex = 0;
        
        }
        public bool Update()
        {

                timer -= Time.deltaTime;
                while (timer <= 0f)
                {

                    timer += timePerCharacter;
                    characterIndex++;
                    uiText.text = textToWrite.Substring(0, characterIndex);

                    if (characterIndex >= textToWrite.Length)
                    {
                        return true;

                    }
                }
                return false;
        }
    
    
    
    
    }

}
