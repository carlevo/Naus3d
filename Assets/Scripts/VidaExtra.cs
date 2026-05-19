using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    public float velocidadCaida = 0.5f;
    public Vector3 escala = new Vector3(0.5f, 0.5f, 0.5f);

    private Camera _cam;
    private float _margeInferior;

    private void Start()
    {
        transform.localScale = escala;

        _cam = Camera.main;

        // Forzamos render por delante para evitar que quede oculto por sprites/fondos.
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.sortingOrder = 20;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        Collider col = GetComponent<Collider>();
        _margeInferior = col != null ? col.bounds.extents.y : 0.2f;
    }

    private void Update()
    {
        // Movimiento hacia abajo
        transform.position += Vector3.down * velocidadCaida * Time.deltaTime;

        if (_cam == null)
        {
            _cam = Camera.main;
            if (_cam == null) return;
        }

        // Obtener la profundidad correcta para calcular los límites
        float profunditat = Mathf.Abs(transform.position.z - _cam.transform.position.z);
        if (profunditat < 0.01f) profunditat = _cam.nearClipPlane + 0.01f;
        Vector3 minPantalla = _cam.ViewportToWorldPoint(new Vector3(0, 0, profunditat));
        
        // Destruir solo si sale por abajo de la pantalla
        if (transform.position.y < minPantalla.y - _margeInferior)
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