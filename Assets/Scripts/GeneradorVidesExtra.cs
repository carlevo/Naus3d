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

        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        float x = Random.Range(min.x, max.x);
        Vector3 pos = new Vector3(x, max.y, 0);

        Instantiate(_VidaExtraPrefab, pos, Quaternion.identity);
        Debug.Log("Corazón generado en posición: " + pos);
    }
}