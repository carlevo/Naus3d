using UnityEngine;

[CreateAssetMenu(fileName = "ShipSelection", menuName = "Game/Ship Selection")]
public class ShipSelectionSO : ScriptableObject
{
    [Header("Nave seleccionada en el Garage")]
    public GameObject selectedShipPrefab;
    public Sprite selectedShipSprite;
    public string selectedShipName;
}
