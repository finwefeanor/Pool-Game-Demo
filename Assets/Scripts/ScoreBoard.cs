using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    public Text countText;
    public Text winText;
    private int count;
    int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        //scoreText.text = score.ToString();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    public void SetCountText() 
    {

        countText.text = "Count: " + count.ToString();
        count = count + 1;
        if (count >= 6)
        {
            winText.text = "You Reached 5 points! To Finish the game shoot both balls from corners to the void";
        }
    }

    public void ScoreHit(int scoreIncrease) 
    { 
        score = score + scoreIncrease;
        scoreText.text = score.ToString();
    }
}
