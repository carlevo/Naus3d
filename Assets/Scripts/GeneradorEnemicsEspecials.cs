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

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        float posicioHoritzontalComponentX = Random.Range(minPantalla.x, maxPantalla.x);

        GameObject nauEnemicEspecial = Instantiate(_NauEnemicEspecialPrefab);
        nauEnemicEspecial.transform.position = new Vector2(posicioHoritzontalComponentX, maxPantalla.y);
    }
}
