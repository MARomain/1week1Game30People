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


    void Start()
    {
        //audioSource.PlayOneShot(music, 1f);

        if (EventSystem.currentSelectedGameObject == null)
        {
            EventSystem.SetSelectedGameObject(FirstSelectedObject);
        }
    }

    public void PlayGame()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        SceneManager.LoadScene("Scene_Vincent"); //***** A changer *****//
    }

    public void QuitGame()
    {
        //audioSource.PlayOneShot(soundSelection, 1f);
        Application.Quit();
    }
}
