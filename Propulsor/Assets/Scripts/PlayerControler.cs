using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControler: MonoBehaviour {

    //float thrust = 3f;
    float combustible = 100f;
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]
    GameObject prefabParticles;
    [SerializeField]
    float impulse = 15f;
    [SerializeField]
    TextMeshProUGUI FuelLeft;
    float sePuedeMover = 1f;
    [SerializeField]
    GameObject finalDePartida;

    void Start () {
        body = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        combustible = combustible - Time.deltaTime * 0.5f;
        if (combustible > 100f) {
            combustible = 100.0f;
        }
        if (combustible <= 100f) {
            FuelLeft.text = combustible.ToString ("00.0") + "%";
            direction.x = Input.GetAxis ("Horizontal") * Time.deltaTime * impulse * sePuedeMover;
            direction.y = Input.GetAxis ("Vertical") * Time.deltaTime * impulse * sePuedeMover;
        }
        if (combustible < 0f) {
            sePuedeMover = 0f;
            finalDePartida.SetActive (true);
        }
    }

    private void OnTriggerEnter2D (Collider2D choque) {
        if (choque.tag == "Fuel") {
            combustible = combustible + 15f;
            Debug.Log ("+15 Fuel");
            sePuedeMover = 1f;
        }

        Instantiate (prefabParticles, choque.transform.position, choque.transform.rotation);
        Destroy (choque.gameObject);
    }

    private void FixedUpdate () {
        body.AddForce (direction, ForceMode2D.Impulse);
    }

    public void ClickEnBoton () {
        Debug.Log ("Ha clicado");
        SceneManager.LoadScene (0);
    }
}
