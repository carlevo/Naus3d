using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnemicEspecial : MonoBehaviour
{
    private float _vel = 5f;
    private Vector3 _direccio = Vector3.down;

    void Update()
    {
        Vector3 novaPos = transform.position;
        novaPos += _direccio * _vel * Time.deltaTime;
        transform.position = novaPos;

        float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, profunditatCamera));
        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider objecteTocat)
    {
        if (objecteTocat.CompareTag("NauJugador"))
        {
            Destroy(gameObject);
        }
    }
}
