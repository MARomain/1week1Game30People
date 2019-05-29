using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [Space(10)]
    [Header("Scripts & Components : ")]
    [Space(10)]

    Case startCase; //Remplie par le SnakeConfiguration


    [Space(10)]
    [Header("Snake Settings : ")]
    [Space(10)]
    
    public int id, startSize;
    public List<Case> body;
    public List<Direction> bodyDirections;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
