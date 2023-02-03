using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 0;
    private Text txtCom;

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey("Highscore"))
        {
            SCORE = PlayerPrefs.GetInt("Highscore");
        }

        PlayerPrefs.SetInt("Highscore", SCORE);


    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;

            PlayerPrefs.SetInt("Highscore", value);
            if(_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE)
            return;
        SCORE = scoreToTry;
    }

    [Tooltip("reset Highscore")]
    public bool resetHighscoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighscoreNow)
        {
            resetHighscoreNow = false;

            PlayerPrefs.SetInt("Highscore", 0);
            Debug.LogWarning("Highscore reset to 0");
        }
    }

}
