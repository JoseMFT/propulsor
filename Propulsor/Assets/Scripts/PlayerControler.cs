using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControler: MonoBehaviour {

    //float thrust = 3f;
    float combustible = 100f;
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]
    GameObject prefabParticles;
    [SerializeField]
    float initialImpulse = 15f;
    float impulse;
    [SerializeField]
    TextMeshProUGUI FuelLeft;
    [SerializeField]
    TextMeshProUGUI MoreFuel;
    [SerializeField]
    GameObject Fuel;

    void Start () {
        body = GetComponent<Rigidbody2D> ();
    }



    void Update () {
        combustible = combustible - Time.deltaTime * 0.5f;
        if (combustible > 100f) {
            FuelLeft.text = "Overfuel";
            impulse = initialImpulse * 2f;
        }
        if (combustible <= 100f) {
            FuelLeft.text = combustible.ToString ("00.0") + "%";
            impulse = initialImpulse;

            direction.x = Input.GetAxis ("Horizontal") * Time.deltaTime * impulse;
            direction.y = Input.GetAxis ("Vertical") * Time.deltaTime * impulse;


        }
    }

    private void OnTriggerEnter2D (Collider2D choque) {
        if (choque.tag == "Fuel") {
            combustible = combustible + 15f;
            Debug.Log ("+15 Fuel");
        }

        Instantiate (prefabParticles, choque.transform.position, choque.transform.rotation);
        Destroy (choque.gameObject, 1);
    }

    private void FixedUpdate () {

        body.AddForce (direction, ForceMode2D.Impulse);
    }
}
