using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    [Space(10)]
    [Header("Scripts & Components : ")]
    [Space(10)]

    Transform t;
    SpriteRenderer sr;

    [Space(10)]
    [Header("Case Settings : ")]
    [Space(10)]

    [HideInInspector] public Vector2 pos;
    [HideInInspector] public enum CaseType { Rien, Obstacle, TerrainNavigable, Gélule, Snake, SnakeHead };
    public CaseType caseType;

    public SpriteColor[] spriteAndColors;

    private void OnValidate()
    {
        ChangerCaseConfiguration();
    }


    public void ChangerCaseConfiguration()
    {
        if (!sr)
        {
            sr = GetComponent<SpriteRenderer>();
        }

        switch (caseType)
        {
            case CaseType.Rien:
                sr.sprite = spriteAndColors[0].sprite;
                sr.color = new Color(0f, 0f, 0f, 0f);
                break;

            case CaseType.Obstacle:
                sr.sprite = spriteAndColors[0].sprite;
                sr.color = spriteAndColors[0].col;
                break;

            case CaseType.TerrainNavigable:
                sr.sprite = spriteAndColors[1].sprite;
                sr.color = spriteAndColors[1].col;
                break;

            case CaseType.Gélule:
                sr.sprite = spriteAndColors[2].sprite;
                sr.color = spriteAndColors[2].col;
                break;

            case CaseType.Snake:

                SpriteColor sc = SnakeManager.instance.GetSnakeConfiguration(this);

                sr.sprite = sc.sprite;
                sr.color = sc.col;
                break;

            case CaseType.SnakeHead:

                SpriteColor scHead = SnakeManager.instance.GetSnakeConfiguration(this);

                sr.sprite = scHead.sprite;
                sr.color = scHead.col;
                break;


            default:
                Debug.Log($"La fonction {caseType} n'a pas encore été implémentée");
                break;
        }
    }


    
}
