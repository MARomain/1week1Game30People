﻿using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    // Use this for initialization
    void Awake()
    {
        if (instance == null) // càd s'il n'y a pas déjà d'AudioManager dans la scène
            instance = this; // donc on en obtient un
        else
        {
            Destroy(gameObject); //Pour éviter les doublons
        }

        //Pour que la musique ne se répète pas à chaque changement de scène : DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        //Pour jouer une musique constante à partir de ce script : Play("Nom de la musique"), à cette ligne même.
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Son :" + name + " pas trouvé !");
            return;
        }

        s.source.Play();
    }
}