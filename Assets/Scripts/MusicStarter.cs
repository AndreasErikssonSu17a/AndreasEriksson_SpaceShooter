using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
	//Hittade inget bra script att ha detta i så det fick bli här.
	void Start()
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<MenuMusicLoop>().PlayMusic();
	}
}
