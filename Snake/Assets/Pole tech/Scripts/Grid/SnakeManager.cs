using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{


    public Snake snakeJ1, snakeJ2;
    public Configuration[] configurationsJ1, configurationsJ2;



    public static SnakeManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;

        snakeJ1 = GameObject.Find("Snake J1").GetComponent<Snake>();
        snakeJ2 = GameObject.Find("Snake J2").GetComponent<Snake>();
    }


    private void Start()
    {
        
    }



    public SpriteColor GetSnakeConfiguration(Case @case)
    {
        bool caseHasBeenFound = false;
        bool conditionsHaveBeenMet = false;
        Snake joueur = null;
        Configuration configDeLaCase = null;

        while (!caseHasBeenFound)
        {
            for (int i = 0; i < snakeJ1.body.Count; i++)
            {
                if (snakeJ1.body.Contains(@case))
                {
                    caseHasBeenFound = true;
                    configDeLaCase = snakeJ1.bodyConfigurations[i];
                    joueur = snakeJ1;
                    break;
                }

                if (snakeJ2.body.Contains(@case))
                {
                    caseHasBeenFound = true;
                    configDeLaCase = snakeJ2.bodyConfigurations[i];
                    joueur = snakeJ2;
                    break;
                }
            }
        }

        if (caseHasBeenFound)
        {
            Configuration[] configTuUse = (joueur.id == snakeJ1.id) ? configurationsJ1 : configurationsJ2;

            while (!conditionsHaveBeenMet)
            {
                for (int i = 0; i < configTuUse.Length; i++)
                {
                    if (configDeLaCase.conditions == configTuUse[i].conditions)
                    {
                        conditionsHaveBeenMet = true;
                        return configTuUse[i].spriteAndColorToApply;
                    }


                }
            }
        }

        Debug.LogError("Erreur : La configuration n'a pas été trouvée.");
        return null;


    }
}
