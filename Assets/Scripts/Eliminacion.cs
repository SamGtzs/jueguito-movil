using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminacion : MonoBehaviour
{
    public GameObject gameOverCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Spikes"))
        {
            Destroy(gameObject);
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
            
        }
        
    }
}
