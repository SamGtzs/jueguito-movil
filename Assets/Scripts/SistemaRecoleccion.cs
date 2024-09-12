using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SistemaRecoleccion : MonoBehaviour
{
    private int HighScore;

    public int cantidadGemas;

    public TextMeshProUGUI numero;

    public TextMeshProUGUI GemasFinales;

    private void Start()
    {
        ResetGemas();
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
    }


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
        if(cantidadGemas > HighScore)
        {
         HighScore=cantidadGemas;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();

            if(HighScore != null)
            {
                GemasFinales.text = HighScore.ToString();
            }
        }

    }

    private void ResetGemas()
    {
        HighScore = 0;
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
}
