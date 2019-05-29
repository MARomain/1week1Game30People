using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    [Space(10)]
    [Header("Scripts & Components : ")]
    [Space(10)]

    Transform t;
    Animator a;

    [Space(10)]
    [Header("Case Settings : ")]
    [Space(10)]

    [HideInInspector] public Vector2 pos;
    [HideInInspector] public enum CaseType { Rien, Obstacle, TerrainNavigable, Gélule, Snake, SnakeHead };
    public CaseType caseType;

    public AnimName caseAnim;

    //private void OnValidate()
    //{
    //    if (!GetComponent<Animator>())
    //    {
    //        gameObject.AddComponent<Animator>();
    //    }

    //    ChangerCaseConfiguration();
    //}


    public void ChangerCaseConfiguration()
    {

        if (!a)
        {
            a = GetComponent<Animator>();
        }

        switch (caseType)
        {
            case CaseType.Rien:
                caseAnim = Grid.instance.animationToPlay[0];
                break;

            case CaseType.Obstacle:
                caseAnim = Grid.instance.animationToPlay[1];
                break;

            case CaseType.TerrainNavigable:
                caseAnim = Grid.instance.animationToPlay[0];
                break;

            case CaseType.Gélule:
                caseAnim = Grid.instance.animationToPlay[2];

                break;

            case CaseType.Snake:
                caseAnim = SnakeManager.instance.GetSnakeConfiguration(this);
                break;

            case CaseType.SnakeHead:
                caseAnim = SnakeManager.instance.GetSnakeConfiguration(this);
                break;


            default:
                Debug.Log($"La fonction {caseType} n'a pas encore été implémentée");
                break;
        }

        if(!a)
        a.Play(caseAnim.animName);

    }



}
