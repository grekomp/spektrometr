using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    public static float induction = 1.0f;

	private void OnGUI()
	{
		induction = UserInterfaceController.instance.induction;
	}
}
