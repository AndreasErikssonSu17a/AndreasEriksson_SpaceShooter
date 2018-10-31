using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
    
	void Update ()
	{
		float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(-moveY, 0, 0);
	}
}
