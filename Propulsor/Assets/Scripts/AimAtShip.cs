using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtShip : MonoBehaviour {

    [SerializeField]
    GameObject Source;

    [SerializeField]
    GameObject Destination;

    Vector2 source;
    Vector2 dest;
    Rigidbody2D body;
    /*
    int arraySoruce = new int[2];
    int arrayDestination = new int[2];*/

    void Start()
    {
        body = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        /*arraySource[0] = arraySoruce.GetAxis ("Horizontal");
        arraySoruce[1] = arraySoruce.GetAxis ("Vertical");

        arrayDestination[0] = Destination.GetAxis ("Horizontal");
        arrayDestination[1] = Destination.GetAxis ("Vertical");*/


        source.x = Input.GetAxis ("Horizontal");
        source.y = Input.GetAxis ("Vertical");

        dest.x = Destination.GetComponent.GetAxis ("Horizontal");
        dest.y = Destination.Input.GetAxis ("Vertical");



        Quaternion rotation = Quaternion.LookRotation ((dest - source).normalized);

    }
}



