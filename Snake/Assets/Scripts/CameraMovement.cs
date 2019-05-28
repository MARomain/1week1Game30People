using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target; //Position de la cible

    public float cameraSpeed = 25f;

    public float timerNextMoveIni; //Le temps qu'il faut à la caméra avant le prochain déplacement
    private float timerNextMove;

    public float timerMinValue = 10f; //Temps minimum avant que la caméra se déplace
    public float timerMaxValue = 30f; //Temps maximum avant que la caméra se déplace

    private bool needATarget = false;

    public GameObject[] wayPoint;
    public int index;
    public int lastPointReached;

    public GameObject test;




    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.FindGameObjectsWithTag("Waypoint");
        timerNextMoveIni = Random.Range(timerMinValue, timerMaxValue); //Pour équilibrage GD
        timerNextMove = timerNextMoveIni;
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
        index = Random.Range(0, wayPoint.Length);
        if (index != lastPointReached)
        {
            lastPointReached = index;
            target = wayPoint[index].transform;
            Debug.Log("Next point is " + target.name);
            needATarget = true;
        }
        else
        {
            GetNextWaypoint();
        }

    }

    public void GoToNextPoint()
    {
        Debug.Log("Going to " + target.name);
        Vector3 dir = Vector3.Slerp(test.transform.position, target.position - test.transform.position, 5); 
        test.transform.Translate(dir.normalized * cameraSpeed * Time.deltaTime, Space.World); 

        if (Vector3.Distance(test.transform.position, target.position) <= 0.4f) //Valeur moyenne car déplacements imprécis.
        {
            timerNextMove = timerNextMoveIni;
            needATarget = false;
            Debug.Log("Point Reached !");
        }
    }


}
