using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            PlayerPrefs.SetString("Scena", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("YouDied");
        }
    }
}
