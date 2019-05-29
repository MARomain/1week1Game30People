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




    void Start()
    {
        //audioSource.PlayOneShot(music, 1f);

        if (eventSystem.currentSelectedGameObject == null)
        {
            eventSystem.SetSelectedGameObject(firstSelectedObject);
        }

        pressStartBtn.SetActive(true);
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
