using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    [SerializeField] float _vel = 3f;
    [SerializeField] int _videsQueDona = 1;
    void Update()
    {
        transform.Translate(Vector3.down * _vel * Time.deltaTime);
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        if (transform.position.y < min.y) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NauJugador"))
        {
            other.GetComponent<NauJugador>().AfegirVida(_videsQueDona);
            Destroy(gameObject);
        }
    }
}