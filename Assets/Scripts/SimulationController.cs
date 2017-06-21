using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationController : MonoBehaviour {

	// Simulation parameters
	public float[] masses = new float[3];
	public Color[] colors = new Color[3];
	public GameObject[] centers = new GameObject[3];
	public float angle = 0f;
	public float charge = 0.01f;
	public Vector3 initialPosition = new Vector3(-1, 0, 0);
	public Vector3 initialVelocity = new Vector3(0f, 1f, 0f);

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
				Fire();
				autoFireCountdown = autoFireDelay;
			}
		}

		// Move Centers
		for (int i = 0; i < masses.Length; i++)
		{
			Vector3 velocity = Quaternion.Euler(0f, 0f, angle) * initialVelocity;

			float frequency = charge * Field.induction / masses[i];
			float fi = Mathf.Atan(velocity.x / velocity.y);

			centers[i].transform.position = new Vector3(
				initialPosition.x + (velocity.magnitude / frequency) * Mathf.Cos(fi),
				-(initialPosition.y + (velocity.magnitude / frequency) * Mathf.Sin(fi)),
				-1
			);

			centers[i].GetComponent<SpriteRenderer>().color = colors[i];
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

			Time.timeScale = UserInterfaceController.instance.timeScale;
		}
	}

	public void Fire()
	{
		GameObject particleInstance = GameObject.Instantiate(particle, initialPosition, Quaternion.identity) as GameObject;
		Particle particleController = particleInstance.GetComponent<Particle>();

		int index = Random.Range(0, masses.Length);

		Vector3 velocity = Quaternion.Euler(0f, 0f, angle) * initialVelocity;

		particleController.Setup(velocity, charge, masses[index], initialPosition);
		particleInstance.GetComponent<SpriteRenderer>().color = colors[index];
		particleInstance.GetComponent<TrailRenderer>().material.SetColor("_Color", colors[index]);
	}
}
