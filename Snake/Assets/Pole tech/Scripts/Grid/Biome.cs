using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [Space(10)]
    [Header("Scripts & Components : ")]
    [Space(10)]
    
    public SpriteColor[] biomeSpriteAndColors;   //Le changement de sprite et de couleur pour chaque biome
    public Case[] biomeCases;   //Les cases qui seront comprises dans ce biome

    private void OnValidate()
    {
        for (int i = 0; i < biomeCases.Length; i++)
        {
            biomeCases[i].spriteAndColors = biomeSpriteAndColors;
            biomeCases[i].ChangerCaseConfiguration();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
