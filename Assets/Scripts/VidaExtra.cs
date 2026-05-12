using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    [SerializeField] private float _vel = 3f;
    [SerializeField] private int _videsQueDona = 1;

    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos = novaPos + Vector2.down * _vel * Time.deltaTime;
        transform.position = novaPos;

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "NauJugador")
        {
            NauJugador nauJugador = objecteTocat.GetComponent<NauJugador>();
            if (nauJugador != null)
            {
                nauJugador.AfegirVida(_videsQueDona);
            }

            Destroy(gameObject);
        }
    }
}
