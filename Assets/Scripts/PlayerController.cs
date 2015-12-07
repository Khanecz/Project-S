using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	

	public float speed = 6.5f;


	void Update () 
	{
		Movement();
	}



	void Movement () 

	{
		if(Input.GetKey (KeyCode.D))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		if(Input.GetKey (KeyCode.A))
		{
			transform.Translate(-Vector2.left * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}

	}
	
}
