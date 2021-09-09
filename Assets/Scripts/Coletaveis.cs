using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coletaveis : MonoBehaviour
{
    public Text MyScoreText;
    private int ScoreNum;




    void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = "Sabedoria: " + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
     if(Coin.tag == "ColetBom")
        {
            ScoreNum += 10;
            Destroy(Coin.gameObject);
            MyScoreText.text = "Sabedoria: " + ScoreNum;
        }

     if(Coin.tag == "ColetRuim")
        {
            ScoreNum -= 5;
            Destroy(Coin.gameObject);
            MyScoreText.text = "Sabedoria: " + ScoreNum;
        }
    }
}

