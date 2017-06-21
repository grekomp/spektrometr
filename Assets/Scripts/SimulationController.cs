using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour {

	// Simulation parameters
	public float[] masses = new float[3];
	public Color[] colors = new Color[3];
	public float angle = 0f;
	public float charge = 0.01f;
	public Vector3 initialPosition = new Vector3(-1, 0, 0);
	public Vector3 initialVelocity = new Vector3(0, 1, 0);

	// Settings
	public bool autoFire = false;
	public float autoFireDelay = 0.2f;
	float autoFireCountdown = 0.0f;
	public GameObject particle;

	void Awake () {
		
	}
	
	void Update () {
		// If auto fire is enabled, countdown time
		if (autoFire)
		{
			autoFireCountdown -= Time.deltaTime;

			// Fire and reset timer
			if (autoFireCountdown <= 0)
			{
				Debug.Log("Autofire");

				Fire();
				autoFireCountdown = autoFireDelay;
			}
		}
	}

	void OnGUI()
	{
		if (UserInterfaceController.initialized)
		{
			// Updating options
			autoFire = UserInterfaceController.instance.autoFire;
			autoFireDelay = UserInterfaceController.instance.fireDelay;

			masses[0] = UserInterfaceController.instance.mass1;
			masses[1] = UserInterfaceController.instance.mass2;
			masses[2] = UserInterfaceController.instance.mass3;

			angle = UserInterfaceController.instance.angle;
		}
	}

	public void Fire()
	{
		GameObject particleInstance = GameObject.Instantiate(particle, initialPosition, Quaternion.identity) as GameObject;
		Particle particleController = particleInstance.GetComponent<Particle>();

		int index = Random.Range(0, masses.Length);

		Debug.Log(masses[index]);

		particleController.Setup(initialVelocity, charge, masses[index], initialPosition);
		particleInstance.GetComponent<SpriteRenderer>().color = colors[index];
		particleInstance.GetComponent<TrailRenderer>().material.SetColor("_Color", colors[index]);
	}
}
