using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script se encarga de generar enemigos normales de forma periódica.
// Se debe asignar a un GameObject vacío en la escena.
public class GeneradorEnemics : MonoBehaviour
{
    // Prefab del enemigo normal que se instanciará en cada generación.
    // Se asigna desde el Inspector de Unity.
    public GameObject _NauEnemicPrefab;

    // Start se llama una vez al inicio de la escena.
    void Start()
    {
        IniciGeneraEnemics();
    }

    // Update se llama una vez por frame. No se usa aquí.
    void Update()
    {
        
    }

    // Inicia la generación periódica de enemigos normales.
    // El primer enemigo aparece a los 2 segundos y luego uno cada 1 segundo.
    public void IniciGeneraEnemics()
    {
        // Param1: Nombre del método a llamar.
        // Param2: Segundos hasta la primera llamada.
        // Param3: Segundos entre repeticiones.
        InvokeRepeating("CreaEnemic", 2f, 1f);
    }

    // Detiene la generación de enemigos. Se llama cuando acaba la partida.
    public void AturaGenerarEnemics()
    {
        CancelInvoke("CreaEnemic");
    }

    // Instancia un enemigo normal en una posición horizontal aleatoria
    // en el borde superior de la pantalla.
    private void CreaEnemic()
    {
        GameObject nauEnemic = Instantiate(_NauEnemicPrefab);

        // Obtenemos los límites de la pantalla en coordenadas del mundo.
        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        // Posición X aleatoria entre el margen izquierdo y derecho de la pantalla.
        float posicioHoritzontalComponentX = Random.Range(minPantalla.x, maxPantalla.x);

        // Colocamos el enemigo en la parte superior de la pantalla.
        nauEnemic.transform.position = new Vector2(posicioHoritzontalComponentX, maxPantalla.y);
    }
}
