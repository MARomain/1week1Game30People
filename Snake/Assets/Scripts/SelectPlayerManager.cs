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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerUI.text = timer.ToString("F0");

        if (timer <= 0)
        {
            SceneManager.LoadScene("Scene_Vincent"); // A CHANGER !!
        }

        if (Input.GetButtonDown("Fire1") && sceneIndex != 2)
        {
            AnotherPlayerJoined();
        }
    }

    public void AnotherPlayerJoined()
    {
        SceneManager.LoadScene("Select2Players");
    }
}
