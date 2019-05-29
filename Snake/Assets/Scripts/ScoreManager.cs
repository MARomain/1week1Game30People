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
    public Text TextUI;

    public Text timerUI;
    public float timer = 10;


    public bool partieGagnée = false;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }
    
    public void KillPlayer()
    {
        
    }

    public void AddPoint(int id)
    {

        if (id == 1)
        {
            Debug.Log("Score 1 added");
            scoreJ1++;
        }
        else
        {
            Debug.Log("Score 2 added");
            scoreJ2++;
        }

        scoreTextJ1.text = ("ScoreJ1 " + scoreJ1 + " / " + valueToWin);
        scoreTextJ2.text = ("ScoreJ2 " + scoreJ2 + " / " + valueToWin);

        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (scoreJ1 >= valueToWin)
        {
            pannelWin.SetActive(true);
            TextUI.text = "Le joueur 1 a gagné la partie !"; 
        }

        if (scoreJ2 >= valueToWin)
        {
            pannelWin.SetActive(true);
            TextUI.text = "Le joueur 2 a gagné la partie !";
        }
    }

}
