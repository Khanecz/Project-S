using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	

	public float speed = 6.5f;
	public bool interact = false;
	public bool grounded = false;
	public Transform lineStart, lineEnd, groundedEnd;
	public float jumpheight = 400f;


	RaycastHit2D whatIHit;



	void Update () 
	{
		Movement();
		Raycasting ();
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
		if(Input.GetKeyDown (KeyCode.Space) && grounded == true)
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpheight);
		}


	}

	void Raycasting ()
	{


		Debug.DrawLine (lineStart.position, lineEnd.position, Color.red);
		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.blue);

		grounded = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 <<LayerMask.NameToLayer ("Ground") );

		if (Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Guard") ))
		{
			whatIHit = Physics2D.Linecast(lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Guard"));
			interact = true;
		}
		else
		{
			interact = false;
		}

		if (Input.GetKey (KeyCode.E) && interact == true)
		{
			Destroy (whatIHit.collider.gameObject);
		}
	}
	
}
