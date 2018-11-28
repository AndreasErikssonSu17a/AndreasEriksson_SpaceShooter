using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float speed;

	//Flyttar explosionen i samma riktning och hastighet som fienden den träffar.
	void FixedUpdate()
	{
		transform.Translate(-speed * Time.deltaTime, 0, 0);
	}
}
