using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GirlLogic : MonoBehaviour {

	public Transform sightStart, sightEnd;

	public bool spotted = false;
	public bool facingLeft = true;


	public GameObject pheart;

	void Start()
	{
		InvokeRepeating("Patrol", 0f, Random.Range(2,6));
	}
	
	void Update () 
	{
		Raycasting ();
		Behaviours ();
	}

	void Raycasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.red);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours()
	{
		if(spotted ==true)
		{
			pheart.SetActive(true);
		}
		else
		{
			pheart.SetActive(false);
		}





	}
	void Patrol ()
	{
		facingLeft = !facingLeft;
		if(facingLeft==true)
		{
			transform.eulerAngles = new Vector2(0,0);
		}
		else
		{
			transform.eulerAngles = new Vector2(0,180);
		}
	}


		
		
	}
