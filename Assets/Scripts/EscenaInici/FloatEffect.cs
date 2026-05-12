using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    [Header("Float Settings")]
    public float amplitude = 0.15f;   // cuánto sube/baja
    public float frequency = 1.2f;    // qué tan rápido oscila

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;  // guarda posición original
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = _startPosition + new Vector3(0f, offsetY, 0f);
    }
}