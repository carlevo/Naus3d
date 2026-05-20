using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script del enemigo especial. Se mueve horizontalmente disparando proyectiles
// hasta llegar al borde de la pantalla, momento en que baja verticalmente y desaparece.
public class NauEnemicEspecial : MonoBehaviour
{
    // Velocidad de movimiento horizontal.
    float _velHoritzontal = 3f;
    // Velocidad de movimiento vertical (hacia abajo).
    float _velVertical = 3f;

    // Prefab del proyectil que dispara este enemigo.
    public GameObject _ProjectilEnemicEspecialPrefab;

    // Dirección horizontal: +1 si aparece en la mitad derecha, -1 si aparece en la izquierda.
    private float _direccioHoritzontal;
    // Indica si el enemigo todavía está en fase de movimiento horizontal.
    private bool _movimentHoritzontal = true;

    void Start()
    {
        // Determina la dirección horizontal según la mitad de pantalla donde aparece.
        // Si aparece a la derecha del centro, se mueve hacia la derecha (+1); si no, hacia la izquierda (-1).
        float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 centrePantalla = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, profunditatCamera));
        _direccioHoritzontal = transform.position.x >= centrePantalla.x ? 1f : -1f;

        // Empieza a disparar proyectiles cada 0,5 segundos (primera vez a los 0,5 s).
        InvokeRepeating("CreaProjectil", 0.5f, 0.5f);
    }

    void Update()
    {
        Vector3 novaPos = transform.position;

        if (_movimentHoritzontal)
        {
            // Fase horizontal: desplaza el enemigo en la dirección calculada en Start.
            novaPos.x += _direccioHoritzontal * _velHoritzontal * Time.deltaTime;
            transform.position = novaPos;

            // Comprueba si ha llegado al borde izquierdo o derecho de la pantalla.
            float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
            Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, profunditatCamera));
            Vector3 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, profunditatCamera));

            if (transform.position.x <= minPantalla.x || transform.position.x >= maxPantalla.x)
            {
                // Cambia a fase vertical y deja de disparar.
                _movimentHoritzontal = false;
                CancelInvoke("CreaProjectil");
            }
        }
        else
        {
            // Fase vertical: baja hacia el borde inferior de la pantalla.
            novaPos.y -= _velVertical * Time.deltaTime;
            transform.position = novaPos;

            // Si sale por debajo de la pantalla, se destruye.
            float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
            Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, profunditatCamera));
            if (transform.position.y < minPantalla.y)
            {
                Destroy(gameObject);
            }
        }
    }

    // Instancia un proyectil en la posición actual del enemigo.
    
    // Detecta colisión con un proyectil del jugador o con la nave del jugador.
    private void OnTriggerEnter(Collider objecteTocat)
    {
        bool impacteProjectilJugador =
            objecteTocat.GetComponent<ProjectilJugador>() != null ||
            objecteTocat.GetComponentInParent<ProjectilJugador>() != null;

        if (impacteProjectilJugador || objecteTocat.CompareTag("NauJugador"))
        {
            // Suma 500 puntos al marcador del jugador (más que el enemigo normal).
            int puntsEnemic = 500;
            TextPuntsJugador textPunts = FindObjectOfType<TextPuntsJugador>();
            if (textPunts != null)
            {
                textPunts.setPuntsJugador(puntsEnemic);
            }

            Destroy(gameObject);
        }
    }
}
