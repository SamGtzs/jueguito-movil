using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anivel3 : MonoBehaviour
{
    public void jugar3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }
}
