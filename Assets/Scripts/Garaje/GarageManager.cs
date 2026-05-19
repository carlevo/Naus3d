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
        ShowPreview(prefab, previewPosition, previewRotation, previewScale);
    }

    public void ShowPreview(GameObject prefab, Vector3 position, Vector3 rotation, Vector3 scale)
    {
        if (currentPreview != null)
            Destroy(currentPreview);

        currentPreview = Instantiate(prefab, previewRoot);
        currentPreview.transform.localPosition = position;
        currentPreview.transform.localEulerAngles = rotation;
        currentPreview.transform.localScale = scale;
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
