using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float Speed;
    public int HP;
	
	void Update ()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Laser")
        {
            HP -= 1;
            
            if(HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
