using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed;

    public int hp = 5;
    
	void Update ()
	{
		float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(-moveY, 0, 0);

		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}
}
