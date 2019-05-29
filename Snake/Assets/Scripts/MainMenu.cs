using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject firstSelectedObject;
    public EventSystem eventSystem;

    public GameObject pressStartBtn;
    public GameObject panel1Player;
    public GameObject panel2Players;

    public float timerCredit = 30f;


    void Start()
    {
        //audioSource.PlayOneShot(music, 1f);


        pressStartBtn.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            PressStart();
        }

        if (Input.GetButtonDown("Credits"))
        {
            SceneManager.LoadScene("Credits");
        }

        //Comme dans les jeux de naguère, les crédits apparaissent si on ne fait rien sur l'écran titre
        timerCredit -= Time.deltaTime;

        if (timerCredit <= 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }

    public void PressStart()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        pressStartBtn.SetActive(false);
        Select1Player();
    }

    public void Select1Player()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        SceneManager.LoadScene("Select1Player");
    }

    public void Select2Players()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        SceneManager.LoadScene("Select2Players");
    }

    public void Credits()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        SceneManager.LoadScene("Credits");
    }
}
