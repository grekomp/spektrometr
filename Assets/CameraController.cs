using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Camera cam;
	public float minSize = 1f;
	public float movementSpeed = 1f;
	public float zoomSpeed = 1f;

	Vector3 mouseDragStart;
	Vector3 dragStartPosition;

	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void Update()
	{
		// Zooming
		float scroll = Input.GetAxis("Mouse ScrollWheel");

		if (scroll != 0)
		{
			Debug.Log(scroll);
			cam.orthographicSize -= zoomSpeed * scroll * Time.deltaTime;
		}

		// Moving
		if (Input.GetMouseButtonDown(1))
		{
			mouseDragStart = Input.mousePosition;
			dragStartPosition = transform.position;
		}
		else
		{
			if (Input.GetMouseButton(1))
			{
				Debug.Log("Moving");

				Vector3 move = cam.ScreenToViewportPoint(Input.mousePosition - mouseDragStart);
				move = new Vector3(move.x * movementSpeed, move.y * movementSpeed, 0);

				transform.position = dragStartPosition - move;
			}
		}
	}
}
