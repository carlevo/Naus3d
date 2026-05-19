using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    public float velocidadCaida = 0.5f;  // Muy lento
    public Vector3 escala = new Vector3(0.5f, 0.5f, 0.5f);  // Tamaño visible

    private void Start()
    {
        transform.localScale = escala;
        Debug.Log("Corazón iniciado en posición: " + transform.position);
    }

    private void Update()
    {
        // Movimiento hacia abajo
        transform.Translate(Vector3.down * velocidadCaida * Time.deltaTime);

        // Obtener la profundidad correcta para calcular los límites
        Camera cam = Camera.main;
        float profunditat = Mathf.Abs(cam.transform.position.z);
        Vector3 minPantalla = cam.ViewportToWorldPoint(new Vector3(0, 0, profunditat));
        
        // Destruir solo si sale por abajo de la pantalla
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