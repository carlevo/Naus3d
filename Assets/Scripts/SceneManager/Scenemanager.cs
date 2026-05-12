using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public float currentTimeLeft;
    public GameObject shipObject;
    public float shipLaunchSpeed = 3f;

    private bool isCountingDown;
    private string pendingScene;

    void Awake()
    {
        currentTimeLeft = 0f;
        isCountingDown = false;
    }

    void Update()
    {
        if (!isCountingDown) return;

        currentTimeLeft -= Time.deltaTime;

        if (shipObject != null)
            shipObject.transform.Translate(Vector3.up * shipLaunchSpeed * Time.deltaTime, Space.World);

        if (currentTimeLeft <= 0f)
        {
            isCountingDown = false;
            SceneManager.LoadScene(pendingScene);
        }
    }

    //Este parametro hace que la escena siempre se escriba en cada boton en el onclick
    public void LoadScene(String SceneName, float delay)
    {
        pendingScene = SceneName;
        currentTimeLeft = delay;
        isCountingDown = true;

        if (shipObject != null)
        {
            FloatEffect fe = shipObject.GetComponent<FloatEffect>();
            if (fe != null) fe.enabled = false;
        }
    }
}
