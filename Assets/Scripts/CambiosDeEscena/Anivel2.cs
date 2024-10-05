using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anivel2 : MonoBehaviour
{
    public void jugar2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }
}
