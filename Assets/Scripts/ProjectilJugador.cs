using UnityEngine;

public class ProjectilJugador : MonoBehaviour
{
    float _vel = 10f;
    void Update()
    {
        transform.position += Vector3.up * _vel * Time.deltaTime;

        Camera cam = Camera.main;
        if (cam == null) return;

        float profunditat = Mathf.Abs(transform.position.z - cam.transform.position.z);
        if (profunditat < 0.01f) profunditat = cam.nearClipPlane + 0.01f;

        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1f, 1f, profunditat));
        float margeY = 0f;
        Collider col = GetComponent<Collider>();
        if (col != null) margeY = col.bounds.extents.y;

        if (transform.position.y > max.y + margeY) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si es un enemigo por tag o por componente
        bool esEnemic = other.CompareTag("Enemic") || 
                        other.GetComponent<NauEnemic>() != null || 
                        other.GetComponentInParent<NauEnemic>() != null;
        
        if (esEnemic)
        {
            // Destruir el enemigo si existe el componente
            NauEnemic enemic = other.GetComponent<NauEnemic>() ?? other.GetComponentInParent<NauEnemic>();
            if (enemic != null) Destroy(enemic.gameObject);
            
            // Destruir el proyectil
            Destroy(gameObject);
        }
    }
}