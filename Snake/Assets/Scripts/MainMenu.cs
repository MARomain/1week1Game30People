using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public AudioClip soundSelection;
    public AudioClip music;
    private AudioSource audioSource;
    public GameObject FirstSelectedObject;
    public EventSystem EventSystem;

    public GameObject pressStartBtn;
    public GameObject playerButtons;



    void Start()
    {
        //audioSource.PlayOneShot(music, 1f);

        if (EventSystem.currentSelectedGameObject == null)
        {
            EventSystem.SetSelectedGameObject(FirstSelectedObject);
        }

        pressStartBtn.SetActive(true);
        playerButtons.SetActive(false);
    }

    public void PressStart()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        pressStartBtn.SetActive(false);
        playerButtons.SetActive(true);
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
