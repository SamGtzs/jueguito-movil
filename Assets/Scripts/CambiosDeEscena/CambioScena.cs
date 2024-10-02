using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
}
