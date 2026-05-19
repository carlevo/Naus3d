using UnityEngine;

public class GeneradorVidesExtra : MonoBehaviour
{
    public GameObject _VidaExtraPrefab; // ← Arrastra el prefab del corazón aquí
    [SerializeField] private float _intervalSpawn = 3f;
    [SerializeField] private float _margeLateral = 0.6f;
    [SerializeField] private float _offsetSpawnSuperior = 1f;

    void Start()
    {
        InvokeRepeating("CreaVidaExtra", _intervalSpawn, _intervalSpawn);
    }

    private void CreaVidaExtra()
    {
        if (_VidaExtraPrefab == null)
        {
            Debug.LogError("Falta el prefab de VidaExtra en el generador");
            return;
        }

        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogWarning("No hi ha Main Camera per generar cors.");
            return;
        }

        float zSpawn = 0f;
        GameObject jugador = GameObject.FindWithTag("NauJugador");
        if (jugador != null) zSpawn = jugador.transform.position.z;

        // Límites de pantalla a la profundidad real donde aparecerá el corazón.
        float profunditat = Mathf.Abs(zSpawn - cam.transform.position.z);
        if (profunditat < 0.01f) profunditat = cam.nearClipPlane + 0.01f;

        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, profunditat));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, profunditat));

        float minX = min.x + _margeLateral;
        float maxX = max.x - _margeLateral;
        if (minX > maxX)
        {
            minX = min.x;
            maxX = max.x;
        }

        // Posición aleatoria en X, justo por encima del borde superior.
        float x = Random.Range(minX, maxX);
        Vector3 pos = new Vector3(x, max.y + _offsetSpawnSuperior, zSpawn);

        Instantiate(_VidaExtraPrefab, pos, Quaternion.identity);
    }
}