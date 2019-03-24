using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    // Use this for initialization

    public float speed;
    public float direction;
    public float adjustSpeed;
    public Transform rightLimit;
    public Transform leftLimit;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
            direction = -1;
        }
        else
        {
            direction = 0;
        }


        if(transform.position.x >= rightLimit.position.x)
        {
            transform.position = new Vector3(rightLimit.position.x, transform.position.y, transform.position.z);
          
        }
        else if(transform.position.x <= leftLimit.position.x)
        {
            transform.position = new Vector3(leftLimit.position.x, transform.position.y, transform.position.z);
        }
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.rigidbody.velocity = new Vector2(collision.rigidbody.velocity.x + (direction * adjustSpeed), collision.rigidbody.velocity.y);
        Debug.Log(collision.rigidbody.velocity);
    }
}
