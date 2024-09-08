using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SistemaRecoleccion : MonoBehaviour
{
    public int cantidadGemas;

    public TextMeshProUGUI numero;

    private void Update()
    {
        numero.text = cantidadGemas.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            cantidadGemas ++;
        }
    }
}
