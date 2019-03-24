using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    private BallController theBall;
    public bool gameActive;
    public Text livesText;

    public GameObject gameOverScreen;
    public int lives;


    void Start()
    {
        theBall = FindObjectOfType<BallController>();

        livesText.text = "LIVES REMAINING: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            theBall.ActivateBall();
            gameActive = true;
        }
    }

    public void RespawnBall()
    {
        gameActive = false;
        lives -= 1;

        if (lives < 0)
        {
            theBall.gameObject.SetActive(false);
            gameOverScreen.gameObject.SetActive(true);
            livesText.text = "ALL LIVES LOST...";
        }
        else
        {
            livesText.text = "LIVES REMAINING: " + lives;
        }
    }
}
	