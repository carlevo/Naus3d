using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDataToGame : MonoBehaviour
{
    [Header("Campo para arrastrar los datos a la siguiente escena")]
    public ShipSelectionSO datosDeLaNave;

    public void datosAGameplay()
    {
        if (datosDeLaNave.selectedShipPrefab == null)
        {
            Debug.LogWarning("TakeDataToGame: No hay nave seleccionada.");
            return;
        }

        SceneManager.LoadScene("Pantalla juego");
    }
}
