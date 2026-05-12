using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PantallaResultats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntsText;
    [SerializeField] private TextMeshProUGUI videsRecollidesText;

    void Start()
    {
        // Mostrar puntos
        puntsText.text = "Punts: " + ValorsGlobals.puntsTotals.ToString();
        // Mostrar vidas recogidas
        videsRecollidesText.text = "Vides recollides: " + ValorsGlobals.totalVidesRecollides.ToString();
    }

    public void TornarInici()
    {
        // Reiniciar valores globales
        ValorsGlobals.puntsTotals = 0;
        ValorsGlobals.totalVidesRecollides = 0;
        ValorsGlobals.puntsAconseguits = "Punts: 0";

        // Cargar la escena de inicio (asegúrate del nombre exacto)
        UnityEngine.SceneManagement.SceneManager.LoadScene("EscenaInici");
    }
}