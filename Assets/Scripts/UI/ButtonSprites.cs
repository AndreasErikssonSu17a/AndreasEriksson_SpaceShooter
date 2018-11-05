using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSprites : CharacterSelect
{
	public Button button;

	void Start()
	{
		button.GetComponent<Image>().sprite = spaceships[arrayPos];
	}
}
