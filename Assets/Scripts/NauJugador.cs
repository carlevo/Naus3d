using UnityEngine;
using UnityEngine.SceneManagement;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    private int _vides;
    private bool _estaMort;
    private int _totalVidesRecollides;

    [SerializeField] private int _videsInicials = 3;

    public GameObject _ExplosioPrefab;  // L'explosió també ha de ser 3D

    void Start()
    {
        _vel = 8f;
        _vides = _videsInicials;
        _estaMort = false;
        _totalVidesRecollides = 0;
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        Vector3 direccio = new Vector3(hor, ver, 0).normalized;
        MoureNau(direccio);
    }

    void MoureNau(Vector3 direccio)
    {
        Vector3 pos = transform.position;
        pos += direccio * _vel * Time.deltaTime;

        // Límits de pantalla en coordenades del món (càmera en perspectiva)
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        pos.x = Mathf.Clamp(pos.x, min.x + 0.6f, max.x - 0.6f);
        pos.y = Mathf.Clamp(pos.y, min.y + 0.6f, max.y - 0.6f);
        // Z es manté constant (per exemple, 0)
        pos.z = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemic") || other.CompareTag("ProjectilEnemic"))
        {
            RebreImpacte();
        }
    }

    private void RebreImpacte()
    {
        if (_estaMort) return;
        _vides--;

        if (_ExplosioPrefab != null)
        {
            Instantiate(_ExplosioPrefab, transform.position, Quaternion.identity);
        }

        if (_vides > 0) return;

        _estaMort = true;
        // Guardar punts i vides recollides
        TextPuntsJugador textPunts = GetComponent<TextPuntsJugador>();
        if (textPunts != null) ValorsGlobals.puntsTotals = textPunts.getPuntsJugador();
        ValorsGlobals.totalVidesRecollides = _totalVidesRecollides;
        SceneManager.LoadScene("EscenaResultats");
    }

    public int getVidesJugador() => _vides;
    public void AfegirVida(int q) { if (!_estaMort) { _vides += q; _totalVidesRecollides += q; } }
}