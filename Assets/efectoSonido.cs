using UnityEngine;

public class efectoSonido : MonoBehaviour
{

    public GameObject sonidoGema;
    

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            sonidoGema.SetActive(true);
        }
    }
}
