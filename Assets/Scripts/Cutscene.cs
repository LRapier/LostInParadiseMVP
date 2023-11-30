using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    void Start()
    {
        Invoke("NextScene", 10f);
    }


    void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
