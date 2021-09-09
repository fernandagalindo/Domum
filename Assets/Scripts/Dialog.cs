using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text textDisplay;        //texto sendo exibido
    public string[] sentences;      //conjunto de textos a serem exibidos
    private int index;              //índice das sentenças
    public float typingSpeed;
    public GameObject continueButton;
  
    public GameObject nextSceneButton;
    


    public AudioClip fxButton;
    public AudioClip fxWrite;
   

    //sentences = [sentence(1), sentence(2), sentence(3), ..., sentence(n)];
    //index = 1, 2, 3, ..., n;
    //sentence(1) = "Exemplo de sentença!";

    void Start()
    {
        StartCoroutine(Type());
        nextSceneButton.SetActive(false);
    }


    void Update()
    {
        if (textDisplay.text == sentences[index] && index < sentences.Length)
        {
            continueButton.SetActive(true);
           

        }

    }

    /// <summary>
    /// Corrotina para exibir um caracter por vez.
    /// </summary>
    IEnumerator Type() {

        foreach (char letter in sentences[index].ToCharArray())
        {
           

            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

        
    }

    /// <summary>
    /// Vai para a próxima sentença.
    /// </summary>
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
           
        }
        else{
            //textDisplay.text = "";
            continueButton.SetActive(false);
            nextSceneButton.SetActive(true);
        }
    }
}
     
    

