using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorVidesExtra : MonoBehaviour
{
    public GameObject _VidaExtraPrefab;

    public void Start()
    {
        
        InvokeRepeating("CreaVidaExtra", 3f, 3f);
    }

    public void AturaGenerarVidesExtra()
    {
        CancelInvoke("CreaVidaExtra");
    }

    private void CreaVidaExtra()
    {

        GameObject vidaExtra = Instantiate(_VidaExtraPrefab);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        float posicioX = Random.Range(minPantalla.x, maxPantalla.x);
        vidaExtra.transform.position = new Vector2(posicioX, maxPantalla.y);
    }
}
