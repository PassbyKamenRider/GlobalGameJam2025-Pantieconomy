using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private InputAction pressed, axis;
    [SerializeField] private float rotationSpeed = 1;

    private Transform cam;
    private Vector2 rotation;
    private bool rotationAllowed;

    private void Awake() {
        cam = Camera.main.transform;
        pressed.Enable();
        axis.Enable();
        pressed.performed += _ => { StartCoroutine(Rotate()); };
        pressed.canceled += _ => { rotationAllowed = false; };
        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
    }

    private IEnumerator Rotate()
    {
        rotationAllowed = true;
        while(rotationAllowed)
        {
            rotation *= rotationSpeed;
            transform.Rotate(Vector3.up, rotation.x, Space.World);
            transform.Rotate(-cam.right, rotation.y, Space.World);
            yield return null;
        }
    }
}
