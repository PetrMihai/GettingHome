using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheieFalsa : MonoBehaviour
{

    public GameObject CheiaNuEBuna;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CheiaNuEBuna.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CheiaNuEBuna.SetActive(false);
        }
    }
}
