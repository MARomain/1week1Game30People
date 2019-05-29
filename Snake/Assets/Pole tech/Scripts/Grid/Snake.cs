using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    [Space(10)]
    [Header("Scripts & Components : ")]
    [Space(10)]

    Case startCase; //Remplie par le SnakeConfiguration
    Joystick joystick;

    [Space(10)]
    [Header("Snake Settings : ")]
    [Space(10)]
    
    public int id, startSize = 0;
    public float moveSpeed = .5f;
    float timer;

    bool isInvincible = false, isDashing = false, isBeyongCamera = false, aimant = false;

    [Space(10)]
    

    public List<Case> body;
    public List<Direction.Condition> bodyDirections;

    




    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void SetupSnake()
    {
        for (int i = 0; i < startSize; i++)
        {
            AjouterNouvelleCaseAuCorps(bodyDirections[bodyDirections.Count - 1]); //On ajoute une nouvelle case après la dernière case avec la même orientation que cette dernière
        }
    }





    #region Mouvement


    // Update is called once per frame
    void Update()
    {
        if (!ScoreManager.instance.partieGagnée)
        {

            if (timer < moveSpeed)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;

                GoToNextCase(body[0], GetDirectionFromInput());
            }
        }
    }






    private Direction.Condition GetDirectionFromInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal" + id);
        float vertical = Input.GetAxisRaw("Vertical" + id);

        float inputToUse = 0f;
        bool useHorizontal;

        if(Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            inputToUse = horizontal;
            useHorizontal = true;
        }
        else
        {
            inputToUse = vertical;
            useHorizontal = false;
        }
        
        switch (Sign(inputToUse))
        {
            case -1:
                return (useHorizontal) ? Direction.Condition.Left : Direction.Condition.Down;
            case 1:
                return (useHorizontal) ? Direction.Condition.Right : Direction.Condition.Up;
            default:
                return bodyDirections[0];
        }
    }

    float Sign(float n)
    {
        return n < 0f ? -1f : (n > 0f ? 1f : 0f);
    }




    private void GoToNextCase(Case head, Direction.Condition directionDuMouvement)
    {
        if((GetNextCase(head.pos, directionDuMouvement).caseType == Case.CaseType.Obstacle && !isInvincible) ||
            GetNextCase(head.pos, directionDuMouvement).caseType == Case.CaseType.LimiteTerrain ||
            (GetNextCase(head.pos, directionDuMouvement).caseType == Case.CaseType.Snake && !isInvincible) || 
            (GetNextCase(head.pos, directionDuMouvement).caseType == Case.CaseType.SnakeHead && !isInvincible))
        {
            ScoreManager.instance.KillPlayer();
        }
        else if(GetNextCase(head.pos, directionDuMouvement).caseType == Case.CaseType.Gélule)
        {
            ScoreManager.instance.AddPoint(id);
            AvancerUneCase(directionDuMouvement);
            AjouterNouvelleCaseAuCorps(bodyDirections[bodyDirections.Count - 1]);
            
        }
        else
        {
            AvancerUneCase(directionDuMouvement);
        }
    }

    private void AvancerUneCase(Direction.Condition directionDuMouvement)
    {
        Case dernièreCase = body[body.Count-1];
        Case nouvelleCase = GetNextCase(body[0].pos, directionDuMouvement);

        Case casePrécédente = body[0];
        Direction.Condition directionPrécédente = bodyDirections[0];


        body[0] = nouvelleCase;
        body[0].caseType = Case.CaseType.SnakeHead;
        body[0].ChangerCaseConfiguration();
        bodyDirections[0] = directionDuMouvement;

        for (int i = 1; i < body.Count; i++)
        {
            body[i] = casePrécédente;
            body[i].caseType = Case.CaseType.Snake;
            body[i].ChangerCaseConfiguration();
            bodyDirections[i] = directionPrécédente;

            casePrécédente = body[i];
            directionPrécédente = bodyDirections[i];
        }

        dernièreCase.caseType = Case.CaseType.TerrainNavigable;
        dernièreCase.ChangerCaseConfiguration();
    }




    private Case GetNextCase(Vector2 pos, Direction.Condition newCaseDirection)
    {
        Vector2 nextPos = pos;
        Case nextCase = null;

        switch (newCaseDirection)
        {
            case Direction.Condition.Up:
                nextPos += Vector2.up;
                break;

            case Direction.Condition.Down:
                nextPos += Vector2.down;
                break;

            case Direction.Condition.Left:
                nextPos += Vector2.left;
                break;

            case Direction.Condition.Right:
                nextPos += Vector2.right;
                break;

        }

        nextCase = Physics2D.OverlapPoint(nextPos).GetComponent<Case>();

        return nextCase;
    }


    #endregion





    #region Ajouter une nouvelle case au corps

    private void AjouterNouvelleCaseAuCorps(Direction.Condition newCaseDirection)
    {
        body.Add(GetNewCase(body[body.Count-1].pos, newCaseDirection));

        body[body.Count - 1].caseType = Case.CaseType.Snake;
        body[body.Count - 1].ChangerCaseConfiguration();

        bodyDirections.Add(newCaseDirection);
    }

    private Case GetNewCase(Vector2 pos, Direction.Condition newCaseDirection)
    {
        Vector2 nextPos = pos;
        Case nextCase = null;

        switch (newCaseDirection)
        {
            case Direction.Condition.Up:
                nextPos += Vector2.down;
                break;

            case Direction.Condition.Down:
                nextPos += Vector2.up;
                break;

            case Direction.Condition.Left:
                nextPos += Vector2.right;
                break;

            case Direction.Condition.Right:
                nextPos += Vector2.left;
                break;

        }

        nextCase = Physics2D.OverlapPoint(nextPos).GetComponent<Case>();

        return nextCase;
    }


    #endregion
}
