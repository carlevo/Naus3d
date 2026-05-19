using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageManager : MonoBehaviour
{
    [Header("Zona de preview")]
    public Transform previewRoot;       // Transform vacío a la derecha donde aparece el prefab
    public Vector3 previewPosition = Vector3.zero;
    public Vector3 previewRotation = new Vector3(0, 180, 0);
    public Vector3 previewScale = Vector3.one;

    [Header("ScriptableObject")]
    public ShipSelectionSO selectionData;

    [Header("Nombre de la escena del juego")]
    public string gameSceneName = "GameScene";

    private GameObject currentPreview;

    private void Start()
    {
        // Si ya había una selección previa, mostrarla al volver al garage
        if (selectionData.selectedShipPrefab != null)
            ShowPreview(selectionData.selectedShipPrefab);
    }

    public void ShowPreview(GameObject prefab)
    {
        // Destruir preview anterior
        if (currentPreview != null)
            Destroy(currentPreview);

        // Instanciar el nuevo prefab en previewRoot
        currentPreview = Instantiate(prefab, previewRoot);
        currentPreview.transform.localPosition = previewPosition;
        currentPreview.transform.localEulerAngles = previewRotation;
        currentPreview.transform.localScale = previewScale;
    }

    // Llama este método desde el botón "Jugar"
    public void GoToGame()
    {
        if (selectionData.selectedShipPrefab == null)
        {
            Debug.LogWarning("GarageManager: No hay nave seleccionada.");
            return;
        }

        SceneManager.LoadScene(gameSceneName);
    }
}
