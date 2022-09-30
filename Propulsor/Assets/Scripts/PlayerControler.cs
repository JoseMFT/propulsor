using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler: MonoBehaviour {
    float thrust = 3f;
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]
    float Impulse = 5f;
    void Start () {
        body = GetComponent<Rigidbody2D> ();
    }

    void Update () {

        direction.x = Input.GetAxis ("Horizontal") * Time.deltaTime * Impulse;
        direction.y = Input.GetAxis ("Vertical") * Time.deltaTime * Impulse;
    }

    private void FixedUpdate () {

        body.AddForce (direction, ForceMode2D.Impulse);
    }

}
