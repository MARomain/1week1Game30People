using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreTextJ1;
    public Text scoreTextJ2;

    private int scoreJ1;
    private int scoreJ2;

    public int valueToWin;

    public GameObject pannelButtonP1;
    public GameObject pannelButtonP2;


    public GameObject pannelResult1Player;
    public GameObject pannelResult2Players;
    public Text textUISolo;
    public Text textUIP1;
    public Text textUIP2;

    public Text timerUI1Player;
    public Text timerUI2Players;

    public float timer = 10;

    public GameObject pannelTransition;
    public float transitionTime = 1f;

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
       // pannelResult.SetActive(false);

    }

    void Start()
    {

        //Si deux joueurs
        pannelButtonP2.SetActive(true);

    }

    void Update()
    {
        if (pannelResult1Player.activeSelf)
        {
            timer -= Time.deltaTime;
            timerUI1Player.text = "RETURN TO MENU IN " + timer.ToString("F0") + "...";
        }

        if (pannelResult2Players.activeSelf)
        {
            timer -= Time.deltaTime;
            timerUI2Players.text = "RETURN TO MENU IN " + timer.ToString("F0") + "...";
        }


        if (timer <= 0)
        {
            pannelTransition.SetActive(true);
            Invoke("ChangeScene", transitionTime);
        }
    }

    public void KillPlayer()
    {

            pannelResult1Player.SetActive(true);
            textUISolo.text = "GAME OVER";
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
        //Solo
        if (scoreJ1 >= valueToWin)
        {
            pannelResult1Player.SetActive(true);
            textUISolo.text = "YOU WIN !";
        }


        //Multi
        if (scoreJ1 >= valueToWin)
        {
            pannelResult2Players.SetActive(true);
            textUIP1.text = "PLAYER 1 WINS !";
            textUIP2.text = "PLAYER 1 LOSES...";

        }

        if (scoreJ2 >= valueToWin)
        {
            pannelResult2Players.SetActive(true);
            textUIP2.text = "PLAYER 2 WINS !";
            textUIP1.text = "PLAYER 1 LOSES !";

        }
    }

    void ChangeScene()
    {

        SceneManager.LoadScene("MainMenu");
    }

}
