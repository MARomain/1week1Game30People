using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2Int gridSize;

    public Case[] toutesLesCases;

    private void Start()
    {
        toutesLesCases = FindObjectsOfType<Case>();
    }

}
