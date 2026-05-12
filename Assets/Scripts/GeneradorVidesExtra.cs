using UnityEngine;

public class GeneradorVidesExtra : MonoBehaviour
{
    public GameObject _VidaExtraPrefab;

    void Start()
    {
        // Genera una vida extra cada 3 segundos, empezando a los 3 segundos.
        InvokeRepeating("CreaVidaExtra", 3f, 3f);
    }

    // Opcional: método público para detener la generación (por si el jugador muere)
    public void AturaGenerarVidesExtra()
    {
        CancelInvoke("CreaVidaExtra");
    }

    private void CreaVidaExtra()
    {
        if (_VidaExtraPrefab == null) return;

        // Obtener límites de la pantalla en coordenadas del mundo (3D, con Z = 0)
        Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
        Vector3 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

        // Posición X aleatoria entre los bordes izquierdo y derecho
        float posicioX = Random.Range(minPantalla.x, maxPantalla.x);
        Vector3 posicio = new Vector3(posicioX, maxPantalla.y, 0f);

        // Instanciar la vida extra en la parte superior
        Instantiate(_VidaExtraPrefab, posicio, Quaternion.identity);
    }
}