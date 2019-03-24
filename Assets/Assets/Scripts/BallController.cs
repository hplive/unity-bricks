using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float maxHorizontalSpeed;
    public float vertSpeed; //velocity start movement

    private Rigidbody2D theRB;

    public bool ballActive; //activa a bola. pricipalmente para o inicio do jogo
    public Transform startPoint;

    private GameManager theGM;

	void Start () {
        theRB = GetComponent<Rigidbody2D>();
        theGM = FindObjectOfType<GameManager>();
       
	}
	

	void Update () {

        if (!ballActive)
        {
            theRB.velocity = Vector2.zero;
            transform.position = startPoint.position;
        }
        else
        {

        }


		if(theRB.velocity.x > maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(maxHorizontalSpeed, theRB.velocity.y);
        }
        else if (theRB.velocity.x < -maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(-maxHorizontalSpeed, theRB.velocity.y);
        }

        Debug.Log("\nDEBUG ::" +theRB.velocity);
	}
    //executa quando o objecto deixa outro objecto
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag=="Brick")
            Destroy(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            ballActive = false;
            theGM.RespawnBall();
        }
    }
    public void ActivateBall()
    {
        ballActive = true;
        theRB.velocity = new Vector2(vertSpeed, vertSpeed);
    }
}
