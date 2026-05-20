using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [Header("ScriptableObject (mismo asset)")]
    public ShipSelectionSO selectionData;

    [Header("Punto de spawn en la escena")]
    public Transform spawnPoint;


    private void Start()
    {
        SpawnSelectedShip();
    }

    private void SpawnSelectedShip()
    {
        if (selectionData.selectedShipPrefab == null)
        {
            Debug.LogError("ShipSpawner: No hay nave seleccionada en el ScriptableObject.");
            return;
        }

        Vector3 pos = spawnPoint != null ? spawnPoint.position : Vector3.zero;
        Quaternion rot = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

        GameObject ship = Instantiate(selectionData.selectedShipPrefab, pos, rot);
        ShipScaleConfig scaleConfig = ship.GetComponent<ShipScaleConfig>();
        if (scaleConfig != null)
            ship.transform.localScale = scaleConfig.scaleEnJuego;

        Debug.Log($"ShipSpawner: Nave '{selectionData.selectedShipName}' spawnada.");
    }
}
