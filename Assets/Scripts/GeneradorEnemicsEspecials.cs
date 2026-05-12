using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemicsEspecials : MonoBehaviour
{
    public GameObject _NauEnemicEspecialPrefab;

    // Start is called before the first frame update
    void Start()
    {
        IniciGeneraEnemicsEspecials();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciGeneraEnemicsEspecials()
    {
        InvokeRepeating("CreaEnemicEspecial", 7f, 5f);
    }

    private void CreaEnemicEspecial()
    {
        if (_NauEnemicEspecialPrefab == null) return;

        float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, profunditatCamera));
        Vector3 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, profunditatCamera));

        float posicioHoritzontalComponentX = Random.Range(minPantalla.x, maxPantalla.x);

        GameObject nauEnemicEspecial = Instantiate(_NauEnemicEspecialPrefab);
        nauEnemicEspecial.transform.position = new Vector3(posicioHoritzontalComponentX, maxPantalla.y, transform.position.z);
    }
}
