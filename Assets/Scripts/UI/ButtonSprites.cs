using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSprites : CharacterSelect	//Är väldigt likt CS fast är till knappar istället för sprites.
{
	public Button button;

	//Byter knapparna till den färg spelaren valt till skeppet.
	protected override void Start()
	{
		button.GetComponent<Image>().sprite = spaceships[arrayPos];
	}
}
