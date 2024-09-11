using UnityEngine;

public class CanvasGanaste : MonoBehaviour
{
    public GameObject gameWinCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Final"))
        {
            Destroy(gameObject);
            gameWinCanvas.SetActive(true);
            Time.timeScale = 0;

        }

    }
}
