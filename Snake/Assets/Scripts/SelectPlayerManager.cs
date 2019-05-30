using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SelectPlayerManager : MonoBehaviour
{
    public Text timerUI;

    public float timer = 10;

    public int sceneIndex;

    public GameObject pannelTransition;
    public float transitionTime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        timerUI.text = timer.ToString("F0");

        if (timer <= 0)
        {
            pannelTransition.SetActive(true);
            Invoke("Scene_Vincent", transitionTime);
        }

        if (Input.GetButtonDown("Fire1") && sceneIndex != 2)
        {
            pannelTransition.SetActive(true);
            Invoke("AnotherPlayerJoined", transitionTime);
        }
    }

    public void AnotherPlayerJoined()
    {
        pannelTransition.SetActive(true);
        SceneManager.LoadScene("Select2Players");
    }
}
