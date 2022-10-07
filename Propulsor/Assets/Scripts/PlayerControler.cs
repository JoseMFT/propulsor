using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControler: MonoBehaviour {

    //float thrust = 3f;
    float combustible = 100f;
    float sePuedeMover = 1f;
    float tiempoMensaje = 1f;
    bool Play = true;
    bool tocaGasolina = false;
    Rigidbody2D body;
    Vector2 direction;
    AudioSource Fuel;

    [SerializeField]
    float impulse = 15f;
    [SerializeField]
    GameObject prefabParticles;
    [SerializeField]
    TextMeshProUGUI FuelLeft;
    [SerializeField]
    GameObject MoreFuel;
    [SerializeField]
    GameObject LittleFuel;
    [SerializeField]
    GameObject finalDePartida;

    void Start () {
        body = GetComponent<Rigidbody2D> ();
        Fuel = GetComponent<AudioSource> ();
    }

    void Update () {
        if (tocaGasolina == true) {
            if (tiempoMensaje > 0f) {
                tiempoMensaje = tiempoMensaje - Time.deltaTime;
                Debug.Log (tiempoMensaje);
                if (tiempoMensaje < 0f) {
                    MoreFuel.SetActive (false);
                    tocaGasolina = false;
                }
            }
        }

        combustible = combustible - Time.deltaTime * 1.75f;
        if (combustible > 100f) {
            combustible = 100.0f;
        }
        if (combustible <= 100f) {
            FuelLeft.text = combustible.ToString ("00.0") + "%";
            direction.x = Input.GetAxis ("Horizontal") * Time.deltaTime * impulse * sePuedeMover;
            direction.y = Input.GetAxis ("Vertical") * Time.deltaTime * impulse * sePuedeMover * 0.7f;
        }
        if (combustible < 30f) {
            LittleFuel.SetActive (true);
        } else {
            LittleFuel.SetActive (false);
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
            Fuel.Play ();
            MoreFuel.SetActive (true);
            tocaGasolina = true;
            sePuedeMover = 1f;
            choque.GetComponent<AudioSource> ().Play ();
            Instantiate (prefabParticles, choque.transform.position, choque.transform.rotation);
            Destroy (choque.gameObject, 0.2f);
        }
    }

    private void FixedUpdate () {
        body.AddForce (direction, ForceMode2D.Impulse);
    }

    public void ClickEnBoton () {
        Debug.Log ("Ha clicado");
        SceneManager.LoadScene (0);
    }
}
