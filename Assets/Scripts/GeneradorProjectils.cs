using UnityEngine;

public class GeneradorProjectils : MonoBehaviour
{
    public GameObject _ProjectilPrefab;

    void Update()
    {
        // Dispara con la tecla ESPACIO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneraProjectil();
        }
    }

    private void GeneraProjectil()
    {
        if (_ProjectilPrefab == null) return;

        // Instancia el proyectil en la posición actual del generador (que debe estar en la nave)
        Vector3 posicio = new Vector3(transform.position.x, transform.position.y, 0f);
        Instantiate(_ProjectilPrefab, posicio, Quaternion.identity);
    }
}