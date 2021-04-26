using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheie : MonoBehaviour
{
    public GameObject Semn;
    public GameObject Gratii;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(Semn);
            Destroy(Gratii);
            Destroy(this.gameObject);

        }
    }
}
