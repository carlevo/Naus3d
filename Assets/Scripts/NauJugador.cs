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
        pos += direccio * _vel * Time.deltaTime;

        Camera cam = Camera.main;
        if (cam != null)
        {
            float zJugador = transform.position.z;
            float profunditat = Mathf.Abs(zJugador - cam.transform.position.z);
            if (profunditat < 0.01f) profunditat = cam.nearClipPlane + 0.01f;

            // Con perspectiva, ViewportToWorldPoint necesita la profundidad respecto a la cámara.
            Vector3 min = cam.ViewportToWorldPoint(new Vector3(0f, 0f, profunditat));
            Vector3 max = cam.ViewportToWorldPoint(new Vector3(1f, 1f, profunditat));

            float margeX = 0f;
            float margeY = 0f;
            Collider col = GetComponent<Collider>();
            if (col != null)
            {
                margeX = col.bounds.extents.x;
                margeY = col.bounds.extents.y;
            }

            pos.x = Mathf.Clamp(pos.x, min.x + margeX, max.x - margeX);
            pos.y = Mathf.Clamp(pos.y, min.y + margeY, max.y - margeY);
        }

        // Manté la nau al mateix pla Z.
        pos.z = transform.position.z;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool esEnemic = other.CompareTag("Enemic");
        bool esProjectilEnemic =
            other.GetComponent<ProjectilEnemic>() != null ||
            other.GetComponent<ProjectilEnemicEspecial>() != null ||
            other.GetComponentInParent<ProjectilEnemic>() != null ||
            other.GetComponentInParent<ProjectilEnemicEspecial>() != null;

        if (esEnemic || esProjectilEnemic)
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