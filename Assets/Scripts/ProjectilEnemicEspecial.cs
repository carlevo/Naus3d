using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnemicEspecial : MonoBehaviour
{
    private float _vel = 5f;
    private Vector2 _direccio = new Vector2(0f, -1f);

    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos += _direccio * _vel * Time.deltaTime;
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
            Destroy(gameObject);
        }
    }
}
