using UnityEngine;
using UnityEngine.SceneManagement;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    private int _vides;
    private bool _estaMort;
    private int _totalVidesRecollides;

    [SerializeField] private int _videsInicials = 3;

    

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
        //Debug.Log($"Input Horizontal: {hor}, Vertical: {ver}");
        Vector3 direccio = new Vector3(hor, ver, 0).normalized;
        MoureNau(direccio);
    }

    void MoureNau(Vector3 direccio)
    {
        Vector3 pos = transform.position;
        Debug.Log($"Input direccio: {direccio}");
        pos += direccio * _vel * Time.deltaTime;

        // Límits de pantalla en coordenades del món (càmera en perspectiva)
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
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