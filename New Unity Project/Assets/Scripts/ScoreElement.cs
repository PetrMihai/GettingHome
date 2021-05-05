using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text score1Text;
    public TMP_Text score2Text;
    public TMP_Text score3Text;
    public TMP_Text scorefText;

    public void NewScoreElement (string _username, int _score1, int _score2, int _score3, int _scoref)
    {
        usernameText.text = _username;
        score1Text.text = _score1.ToString();
        score2Text.text = _score2.ToString();
        score3Text.text = _score3.ToString();
        scorefText.text = _scoref.ToString();
    }

}
