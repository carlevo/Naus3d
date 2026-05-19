using UnityEngine;
using UnityEngine.UI;

public class ShipButtonUI : MonoBehaviour
{
    [Header("Datos de esta nave")]
    public GameObject shipPrefab;
    public Sprite shipSprite;
    public string shipName = "Nave";

    [Header("Override de preview (deja en cero para usar los valores del GarageManager)")]
    public bool useCustomPreviewTransform = false;
    public Vector3 previewPosition = Vector3.zero;
    public Vector3 previewRotation = new Vector3(0, 180, 0);
    public Vector3 previewScale = Vector3.one;

    [Header("Referencias")]
    public ShipSelectionSO selectionData;
    public GarageManager garageManager;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        Image img = GetComponent<Image>();
        if (img != null && shipSprite != null)
            img.sprite = shipSprite;

        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        selectionData.selectedShipPrefab = shipPrefab;
        selectionData.selectedShipSprite = shipSprite;
        selectionData.selectedShipName = shipName;

        if (useCustomPreviewTransform)
            garageManager.ShowPreview(shipPrefab, previewPosition, previewRotation, previewScale);
        else
            garageManager.ShowPreview(shipPrefab);
    }
}
