using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : BasicEnemy
{
	void Start()
	{
		ChangeShip();	//Eftersom jag har Start med så byts den ut i arv.

		//Ändrar nedanstående variabler.
		speed = 2;
		hp = 3;
		damage = 2;
		score = 20;

		rbody2d = GetComponent<Rigidbody2D>();
	}
}
