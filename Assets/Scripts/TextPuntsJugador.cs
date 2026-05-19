using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPuntsJugador : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _puntsJugadorText;
    private int _puntsJugadorInt;

    // Start is called before the first frame update
    void Start()
    {
        _puntsJugadorText = GetComponent<TMPro.TextMeshProUGUI>();
        _puntsJugadorInt = 0;

        if (_puntsJugadorText != null)
        {
            _puntsJugadorText.text = "Puntos: 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPuntsJugador(int nousPunts)
    {
        if (_puntsJugadorText == null)
        {
            _puntsJugadorText = GetComponent<TMPro.TextMeshProUGUI>();
            if (_puntsJugadorText == null) return;
        }

        _puntsJugadorInt += nousPunts;
        _puntsJugadorText.text = "Puntos: " + _puntsJugadorInt;
        ValorsGlobals.puntsAconseguits = _puntsJugadorText.text;
        ValorsGlobals.puntsTotals = _puntsJugadorInt;
    }

    public int getPuntsJugador()
    {
        return _puntsJugadorInt;
    }

    public void InicialitzarPunts()
    {
        if (_puntsJugadorText == null)
        {
            _puntsJugadorText = GetComponent<TMPro.TextMeshProUGUI>();
            if (_puntsJugadorText == null) return;
        }

        _puntsJugadorInt = 0;
        _puntsJugadorText.text = "Puntos: 0";
    }
}
