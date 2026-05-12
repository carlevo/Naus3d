using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    private int _vides;
    private bool _estaMort;
    private int _totalVidesRecollides;

    [SerializeField] private int _videsInicials = 3;

    public GameObject _ExplosioPrefab;



    // Start is called before the first frame update
    void Start()
    {
        _vel = 8f;
        _vides = _videsInicials;
        _estaMort = false;
        _totalVidesRecollides = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioInputX = Input.GetAxisRaw("Horizontal");
        float direccioInputY = Input.GetAxisRaw("Vertical");
        //Debug.Log(direccioInputX + " - " + direccioInputY);

        Vector2 direccioIndicada = new Vector2(direccioInputX, direccioInputY).normalized;
        //Debug.Log(direccioIndicada + " magnitud=" + direccioIndicada.magnitude);

        MoureNau(direccioIndicada);

    }

    void MoureNau(Vector2 direccioIndicada)
    {
        // Anem a moure la nau:
        // 1) Agafem la posici� actual (x, y) de la nau:
        //      transform.position ens retorna la posici� actual de la nau.
        Vector2 posNau = transform.position;

        // 2) Trobem la nova posici� de la nau:
        posNau = posNau + direccioIndicada * _vel * Time.deltaTime;
        //Debug.Log("Time.deltaTime=" + Time.deltaTime);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        maxPantalla.x = maxPantalla.x - 0.6f;
        minPantalla.x = minPantalla.x + 0.6f;
        maxPantalla.y = maxPantalla.y - 0.8f;
        minPantalla.y = minPantalla.y + 0.8f;

        posNau.x = Mathf.Clamp(posNau.x, minPantalla.x, maxPantalla.x);
        posNau.y = Mathf.Clamp(posNau.y, minPantalla.y, maxPantalla.y);

        // 3) Assignem la nova posici� (movem l'objecte):
        transform.position = posNau;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Enemic" || objecteTocat.tag == "ProjectilEnemic")
        {
            RebreImpacte();
        }
    }

    private void RebreImpacte()
    {
        if (_estaMort)
        {
            return;
        }

        _vides--;

        if (_ExplosioPrefab != null)
        {
            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;
        }

        if (_vides > 0)
        {
            return;
        }

        _estaMort = true;

        // Gesti� de vides jugador i canvi d'escena.

        // No cal destruir la nau del jugador si es canvia l'escena.
        //Destroy(gameObject);

        TextPuntsJugador textPunts = GetComponent<TextPuntsJugador>();
        if (textPunts != null)
        {
            ValorsGlobals.puntsTotals = textPunts.getPuntsJugador();
        }
        ValorsGlobals.totalVidesRecollides = _totalVidesRecollides;

        SceneManager.LoadScene("EscenaResultats");
    }

    public int getVidesJugador()
    {
        return _vides;
    }

    public void AfegirVida(int videsAfegides)
    {
        if (_estaMort)
        {
            return;
        }

        _vides += videsAfegides;
        _totalVidesRecollides += videsAfegides;
    }
}
