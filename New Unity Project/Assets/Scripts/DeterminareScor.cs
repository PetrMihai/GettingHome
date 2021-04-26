using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeterminareScor : MonoBehaviour
{
    public TextMeshProUGUI Scor;
    // Start is called before the first frame update
    void Start()
    {
        int x;
        x = PlayerPrefs.GetInt("Scor");
        Scor.text = x.ToString();

    }
}
