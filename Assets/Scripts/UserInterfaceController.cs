using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour {
	// Instance
	public static UserInterfaceController instance;
	public static bool initialized = false;

	// Mass
	InputField massInput1;
	InputField massInput2;
	InputField massInput3;
	public float mass1;
	public float mass2;
	public float mass3;

	// Angle
	Slider angleSlider;
	public float angle;

	// Fire Delay
	Slider fireDelaySlider;
	public float fireDelay;

	// Auto Fire
	Toggle autoFireToggle;
	public bool autoFire;

	// Time Scale
	Slider timeScaleSlider;
	public float timeScale;

	// Induction
	InputField inductionInput;
	public float induction;

	void Start () {
		// Setting instance for external access
		instance = this;
		initialized = true;

		// Setting up references to ui elements

		// Mass
		massInput1 = GameObject.Find("Mass 1").GetComponent<InputField>();
		massInput2 = GameObject.Find("Mass 2").GetComponent<InputField>();
		massInput3 = GameObject.Find("Mass 3").GetComponent<InputField>();

		// Angle
		angleSlider = GameObject.Find("Angle Slider").GetComponent<Slider>();

		// Fire Delay
		fireDelaySlider = GameObject.Find("Fire Delay Slider").GetComponent<Slider>();

		// Auto Fire
		autoFireToggle = GameObject.Find("Auto Fire Toggle").GetComponent<Toggle>();

		// Time Scale
		timeScaleSlider = GameObject.Find("Time Scale Slider").GetComponent<Slider>();

		// Induction
		inductionInput = GameObject.Find("Induction Input").GetComponent<InputField>();
	}
	
	void OnGUI() {
		// Update values based on user input

		// Mass
		mass1 = float.Parse(massInput1.text);
		mass2 = float.Parse(massInput2.text);
		mass3 = float.Parse(massInput3.text);

		// Angle
		angle = angleSlider.value;

		// Fire Delay
		fireDelay = fireDelaySlider.value;

		// Auto Fire
		autoFire = autoFireToggle.isOn;

		// Time Scale 
		timeScale = timeScaleSlider.value;

		// Induction
		induction = float.Parse(inductionInput.text);
	}
}
