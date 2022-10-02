using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    [SerializeField]
    GameObject Origin;
    
    [SerializeField]
    GameObject Destination;

    Vector2 source;
    Vector2 dest;
    Vector2 up;
    Rigidbody2D body;

    Vector2 firstPosition;
    Vector2 lastPosition;
    /*
    void Start() {

        Vector2 source = Origin.GetComponent<Transform> ().transform.position;
        body = GetComponent<Rigidbody2D> ();
        transform.Translate (source + up);
    }
    */

    void Update() { 
        Vector2 source = Origin.GetComponent<Transform> ().transform.position;
        Vector2 dest = Destination.GetComponent<Transform> ().transform.position;

        //firstPosition = dest - source;
        Quaternion rotation = Quaternion.LookRotation ((dest - source).normalized);
        /*lastPosition = dest - source;

        if (firstPosition != lastPosition) {
            transform.Translate (source + up);
        }
        */

    }
}



