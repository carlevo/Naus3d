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
        Vector3 posicio = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject projectil = Instantiate(_ProjectilPrefab, posicio, Quaternion.identity);

        // Si el prefab no tiene script de movimiento, se añade en runtime para evitar balas estáticas.
        if (projectil.GetComponent<ProjectilJugador>() == null)
        {
            projectil.AddComponent<ProjectilJugador>();
        }
    }
}