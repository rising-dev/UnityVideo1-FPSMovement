using UnityEngine;

public class CameraController : MonoBehaviour
{

	public float sensitivity = 100f;

	Transform playerBody;

	float mouseX = 0f;
	float mouseY = 0f;
	float cameraXRotation = 0f;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		playerBody = transform.parent;
	}

	void Update()
    {
		mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; 
		mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

		cameraXRotation -= mouseY;
		cameraXRotation = Mathf.Clamp(cameraXRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(cameraXRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up, mouseX);
    }
}
