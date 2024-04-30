using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI result;

    public float score;

    void Start()
    {
        score = 0;
        result.gameObject.SetActive(false);
        scoreText.text = score.ToString() + "/ 10";
    }

    void Update()
    {

    }

    public void getPoint()
    {
        score++;
        if (score >= 10)
        {
            result.text = "Game Clear";
            result.gameObject.SetActive(true);
        }
        scoreText.text = score.ToString() + "/ 10";
    }
}
