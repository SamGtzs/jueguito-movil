using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioScena2 : MonoBehaviour
{

    public void menu(string escena)
    {

        SceneManager.LoadScene(escena);
    }
}
