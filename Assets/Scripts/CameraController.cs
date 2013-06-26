using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject target;

    public float cameraDistance = 10;
    private float scrollSpeed = 5f;
    private float cameraDistanceMax = 40;
    private float cameraDistanceMin = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cameraDistance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);

        camera.transform.position = new Vector3(transform.position.x, cameraDistance, transform.position.z);
	}
}
