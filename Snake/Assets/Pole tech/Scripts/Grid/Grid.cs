using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2Int gridSize;
    public AnimName[] animationToPlay;

    [Space(20)]

    public Case[] toutesLesCases;



    public static Grid instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }


    private void Start()
    {
        toutesLesCases = FindObjectsOfType<Case>();
    }

}
