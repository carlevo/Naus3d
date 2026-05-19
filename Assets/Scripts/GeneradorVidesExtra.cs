using UnityEngine;

public class GeneradorVidesExtra : MonoBehaviour
{
    public GameObject _VidaExtraPrefab; // ← Arrastra el prefab del corazón aquí

    void Start()
    {
        InvokeRepeating("CreaVidaExtra", 3f, 3f);
    }

    private void CreaVidaExtra()
    {
        if (_VidaExtraPrefab == null)
        {
            Debug.LogError("Falta el prefab de VidaExtra en el generador");
            return;
        }

        // Obtener los límites de la pantalla
        Camera cam = Camera.main;
        float profunditat = Mathf.Abs(cam.transform.position.z);
        
        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, profunditat));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, profunditat));
        
        // Posición aleatoria en X, arriba de la pantalla
        float x = Random.Range(min.x, max.x);
        Vector3 pos = new Vector3(x, max.y + 5f, 0);  // Generamos arriba del todo

        Instantiate(_VidaExtraPrefab, pos, Quaternion.identity);
        Debug.Log("Corazón generado en posición: " + pos);
    }
}