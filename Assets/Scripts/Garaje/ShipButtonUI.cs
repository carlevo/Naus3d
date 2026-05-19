using UnityEngine;
using UnityEngine.UI;

public class ShipButtonUI : MonoBehaviour
{
    [Header("Datos de esta nave")]
    public GameObject shipPrefab;       // Prefab 3D desde 3DModels/Naves
    public Sprite shipSprite;           // Imagen del botón
    public string shipName = "Nave";

    [Header("Referencias")]
    public ShipSelectionSO selectionData;  // Arrastra el SO aquí
    public GarageManager garageManager;    // Arrastra el GarageManager aquí

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        // Poner la imagen al botón automáticamente
        Image img = GetComponent<Image>();
        if (img != null && shipSprite != null)
            img.sprite = shipSprite;

        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        // Guardar selección en el ScriptableObjects
        selectionData.selectedShipPrefab = shipPrefab;
        selectionData.selectedShipSprite = shipSprite;
        selectionData.selectedShipName = shipName;

        // Actualizar preview
        garageManager.ShowPreview(shipPrefab);
    }
}
