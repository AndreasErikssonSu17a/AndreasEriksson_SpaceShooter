using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float speed;

	// Use this for initialization
	void Start()
	{

	}

	void FixedUpdate()
	{
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
}
