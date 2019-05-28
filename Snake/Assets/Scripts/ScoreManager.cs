using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextJ1;
    public Text scoreTextJ2;

    private int scoreJ1;
    private int scoreJ2;

    public int valueToWin;

    public GameObject pannelWin;
    public Text victoryText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreTextJ1.text = ("ScoreJ1 " + scoreJ1);
        scoreTextJ2.text = ("ScoreJ2 " + scoreJ2);

        if (Input.GetButtonDown("Fire1"))
        {
            CollectBonusJ1();
            WinGame();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            CollectBonusJ2();
            WinGame();
        }
    }

    public void KillPlayer()
    {
        
    }

    public void CollectBonusJ1()
    {
        Debug.Log("Score added");
        scoreJ1++;
    }

    public void CollectBonusJ2()
    {
        Debug.Log("Score added");
        scoreJ2++;
    }

    public void WinGame()
    {
        if (scoreJ1 >= valueToWin)
        {
            pannelWin.SetActive(true);
            victoryText.text = "Le joueur 1 a gagné la partie !"; 
        }

        if (scoreJ2 >= valueToWin)
        {
            pannelWin.SetActive(true);
            victoryText.text = "Le joueur 2 a gagné la partie !";
        }
    }

}
