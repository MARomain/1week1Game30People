using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 25f;

    public float timerNextMoveIni; //Le temps qu'il faut à la caméra avant le prochain déplacement
    private float timerNextMove;

    public float timerMinValue = 10f; //Temps minimum avant que la caméra se déplace
    public float timerMaxValue = 30f; //Temps maximum avant que la caméra se déplace

    private bool needATarget = false;

    public Transform[] wayPoints;
    public Transform currentWayPoint;
    public Transform verylastpoint;


    public int index;
    public int lastPointReached;
    

    public GameObject test;



    void Start()
    {
        int random = Random.Range(0, 9);
        currentWayPoint = wayPoints[random];
        timerNextMoveIni = Random.Range(timerMinValue, timerMaxValue); //Pour équilibrage GD
        timerNextMove = timerNextMoveIni;
        transform.position = currentWayPoint.transform.position;

        GetNextWaypoint();
    }




    // Update is called once per frame
    void Update()
    {
        if (timerNextMove > 0)
        {
            timerNextMove -= Time.deltaTime;
        }

        if (timerNextMove <= 0 && needATarget == false)
        {
            GetNextWaypoint();
        }

        if (needATarget == true)
        {
            GoToNextPoint();
        }

    }

    public void GetNextWaypoint()
    {
        index = Random.Range(0, currentWayPoint.GetComponent<Waypoint>().waypointsVoisins.Length);
 
        Debug.Log(index);
        if (currentWayPoint != currentWayPoint.GetComponent<Waypoint>().waypointsVoisins[index]  && currentWayPoint.GetComponent<Waypoint>().waypointsVoisins[index] != verylastpoint)
        {
            verylastpoint = currentWayPoint;
            //currentWayPoint = currentWayPoint.waypointsVoisins[index];
            currentWayPoint = currentWayPoint.GetComponent<Waypoint>().waypointsVoisins[index];
            needATarget = true;
        }
        else
        {
            GetNextWaypoint();
        }

    }

    public void GoToNextPoint()
    {
        Vector2 dir = Vector2.Lerp(transform.position, currentWayPoint.transform.position - transform.position, 5); 
        transform.Translate(dir.normalized * cameraSpeed * Time.deltaTime, Space.World); 

        if (Vector2.Distance(transform.position, currentWayPoint.transform.position) <= 0.05f) //Valeur moyenne car déplacements imprécis.
        {
            timerNextMove = timerNextMoveIni;
            needATarget = false;
        }
    }


}
