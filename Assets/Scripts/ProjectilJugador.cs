using UnityEngine;

public class ProjectilJugador : MonoBehaviour
{
    float _vel = 10f;
    void Update()
    {
        transform.Translate(Vector3.up * _vel * Time.deltaTime);
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        if (transform.position.y > max.y) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemic")) Destroy(gameObject);
    }
}