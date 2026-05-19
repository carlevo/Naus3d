using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauEnemic : MonoBehaviour
{
    float _vel = 3f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 novaPos = transform.position;

        Vector3 direccio = Vector3.down;

        novaPos = novaPos + direccio * _vel * Time.deltaTime;

        transform.position = novaPos;

        float profunditatCamera = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 minPantalla = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, profunditatCamera));
        if (transform.position.y < minPantalla.y)
        {
            //Debug.Log("Ha sortit fora.");
            // GameObject �s l'objecte actual que t� aquest script (com si fos un "this").
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider objecteTocat)
    {
        bool impacteProjectilJugador =
            objecteTocat.GetComponent<ProjectilJugador>() != null ||
            objecteTocat.GetComponentInParent<ProjectilJugador>() != null;

        if (impacteProjectilJugador || objecteTocat.CompareTag("NauJugador"))
        {

            int puntsEnemic = 200;
            GameObject.Find("TextPunts").GetComponent<TextPuntsJugador>().setPuntsJugador(puntsEnemic);

            Destroy(gameObject);
        }
    }
}
