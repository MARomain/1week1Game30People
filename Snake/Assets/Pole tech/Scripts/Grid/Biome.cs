using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biome : MonoBehaviour
{
    [Space(10)]
    [Header("Scripts & Components : ")]
    [Space(10)]
    
    public Case[] biomeCases;   //Les cases qui seront comprises dans ce biome
    public Case caseStartJ1, caseStartJ2; //Les cases de départ du joueur dans ce biome


    //private void OnValidate()
    //{
    //    for (int i = 0; i < biomeCases.Length; i++)
    //    {
    //        biomeCases[i].ChangerCaseConfiguration();
    //    }
    //}


    public void OnEnable()
    {
        for (int i = 0; i < biomeCases.Length; i++)
        {
            biomeCases[i].gameObject.SetActive(true);
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < biomeCases.Length; i++)
        {
            biomeCases[i].gameObject.SetActive(false);
        }
    }



    public void SpawnObjects()
    {
        bool caseVierge = false;
        Case caseChoisie = null;
        for (int i = 0; i < Grid.instance.nbObjetsRamassablesParBiome; i++)
        {

            while (!caseVierge)
            {
                caseChoisie = biomeCases[Random.Range(0, biomeCases.Length)];
                if(caseChoisie.caseType == Case.CaseType.TerrainNavigable)
                {
                    caseVierge = true;
                }

            }
            caseChoisie.caseType = Case.CaseType.Gélule;
            caseChoisie.ChangerCaseConfiguration();


        }
    }
}
