using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	void update()
	{
		transform.position = new Vector3(player.position.x + 7, 5, -20);
	}


}
