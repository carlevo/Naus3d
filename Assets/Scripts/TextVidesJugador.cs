using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextVidesJugador : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _videsJugadorText;
    private NauJugador _nauJugador;

    void Start()
    {
        _videsJugadorText = GetComponent<TMPro.TextMeshProUGUI>();
        ActualitzarReferenciaJugador();
        ActualitzarText();
    }

    void Update()
    {
        if (_nauJugador == null)
        {
            ActualitzarReferenciaJugador();
        }

        ActualitzarText();
    }

    private void ActualitzarReferenciaJugador()
    {
        GameObject nauJugadorObj = GameObject.FindWithTag("NauJugador");
        if (nauJugadorObj != null)
        {
            _nauJugador = nauJugadorObj.GetComponent<NauJugador>();
        }
    }

    private void ActualitzarText()
    {
        if (_videsJugadorText == null)
        {
            return;
        }

        if (_nauJugador != null)
        {
            _videsJugadorText.text = "Vides: " + _nauJugador.getVidesJugador();
        }
        else
        {
            _videsJugadorText.text = "Vides: 0";
        }
    }
}
