using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparitieSemn : MonoBehaviour
{
    public GameObject Semn;
    public Collider2D col;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            Semn.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Semn.SetActive(false);
        }
    }

}
