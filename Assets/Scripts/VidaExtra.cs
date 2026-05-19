using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    public float velocidadCaida = 3f;
    public Vector3 escala = new Vector3(0.5f, 0.5f, 1f);

    private void Start()
    {
        transform.localScale = escala;
        Debug.Log("Corazón iniciado en posición: " + transform.position);
    }

    private void Update()
    {
        // Movimiento hacia abajo
        transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);
        Debug.Log("Moviendo corazón. Nueva Y: " + transform.position.y);

        Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NauJugador"))
        {
            NauJugador jugador = other.GetComponent<NauJugador>();
            if (jugador != null) jugador.AfegirVida(1);
            Destroy(gameObject);
        }
    }
}