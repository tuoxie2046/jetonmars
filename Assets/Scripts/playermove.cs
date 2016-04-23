using UnityEngine;
using CnControls;
using System.Collections;

// This is merely an example, it's for an example purpose only
// Your game WILL require a custom controller scripts, there's just no generic character control systems, 
// they at least depend on the animations

[RequireComponent(typeof(CharacterController))]
public class playermove : MonoBehaviour
{
    public float MovementSpeed = 10f;

    private Transform _mainCameraTransform;
    private Transform _transform;
    private CharacterController _characterController;
	private Vector3 firstPos = new Vector3(0f, 0f, 0f);
	private Vector3 firstRo = new Vector3 (10f, 0f, 0f);
	private Vector3 thirdPos = new Vector3(0f, 1.5f, -13f);
	private Vector3 thirdRo = new Vector3(30f, 0f, 0f);
	private int changePer = 0;

    private void OnEnable()
    {
		_mainCameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
		if (Input.GetKeyDown("k")) {
			GameObject gameobject = GameObject.FindWithTag ("MainCamera");
			if (changePer == 0) {
				//Vector3 newPos = new Vector3(gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y+1.5f, gameObject.GetComponent<Transform> ().position.z-13f);
				//gameObject.GetComponent<Transform> ().position = newPos;
				//Quaternion newRo = Quaternion.Euler(gameObject.GetComponent<Transform> ().rotation.x-10, 0, 0);
				//gameObject.GetComponent<Transform> ().localRotation = newRo;
				gameobject = GameObject.Find("firstcamera");
				changePer = 1;
			} else {
				//Vector3 newPos = new Vector3(gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y-1.5f, gameObject.GetComponent<Transform> ().position.z+13f);
				//gameObject.GetComponent<Transform> ().position = newPos;
				//Quaternion newRo = Quaternion.Euler(gameObject.GetComponent<Transform> ().rotation.x+10, 0, 0);
				//gameObject.GetComponent<Transform> ().localRotation = newRo;
				gameobject = GameObject.Find("thirdcamera");
				changePer = 0;
			}

		}
		//Debug.Log (_mainCameraTransform.position.x + ", " + _mainCameraTransform.position.y);
        // Just use CnInputManager. instead of Input. and you're good to go
        var inputVector = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
        Vector3 movementVector = Vector3.zero;

        // If we have some input
        if (inputVector.sqrMagnitude > 0.001f)
        {
            movementVector = _mainCameraTransform.TransformDirection(inputVector);
            movementVector.y = 0f;
            movementVector.Normalize();
            _transform.forward = movementVector;
        }

		//Debug.Log (movementVector.x + ", " + movementVector.y);
        //movementVector += Physics.gravity;
        _characterController.Move(movementVector * Time.deltaTime* 200);
    }
}
