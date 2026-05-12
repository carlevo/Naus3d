using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChanger : MonoBehaviour
{
    public float delay =0f;
    public string nameScene;
public void SwappScene()
    {
        SceneLoader sc = GameObject.Find("Canvas").GetComponent<SceneLoader>();
        sc.LoadScene(nameScene,delay);
    }
}
