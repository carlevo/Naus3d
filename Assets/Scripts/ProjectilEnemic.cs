using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnemic : MonoBehaviour
{
    private float _vel;
    private bool _continuaUltimaDireccio;
    private Vector3 _direccioJugador;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;
        _continuaUltimaDireccio = false;
        _direccioJugador = Vector3.down;
        Invoke("ContinuaUltimaDireccio", 1.5f);
        // Al cap de 1,5 segons, crida ContinuaUltimaDireccio.
        //  Aix� fa que _continuaUltimaDireccio es posi a true i
        //  el projectil deixi de seguir al jugador.
    }

    // Update is called once per frame
    void Update()
    {
        //MovimentVertical();
        if (GameObject.FindWithTag("NauJugador") != null)
        {
            if (!_continuaUltimaDireccio)
            {
                GameObject nauJugador = GameObject.FindWithTag("NauJugador");
                _direccioJugador = (nauJugador.transform.position - transform.position).normalized;
            }

            Vector3 novaPos = transform.position;
            novaPos = novaPos + _direccioJugador * _vel * Time.deltaTime;
            transform.position = novaPos;

            ComprovarDinsPantalla();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ComprovarDinsPantalla()
    {
        float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, profunditatCamera));
        Vector3 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, profunditatCamera));
        if ((transform.position.y < minPantalla.y) || (transform.position.x < minPantalla.x) ||
            (transform.position.y > maxPantalla.y) || (transform.position.x > maxPantalla.x))
        {
            Destroy(gameObject);
        }
    }

    private void ContinuaUltimaDireccio()
    {
        _continuaUltimaDireccio = true;
    }

    // Per si es volgu�s que el projectil nom�s vagi en vertical avall.
    private void MovimentVertical()
    {
        Vector3 novaPos = transform.position;

        novaPos = novaPos + Vector3.down * _vel * Time.deltaTime;

        transform.position = novaPos;
    }

    private void OnTriggerEnter(Collider objecteTocat)
    {
        if (objecteTocat.CompareTag("NauJugador"))
        {
            Destroy(gameObject);
        }
    }
}
