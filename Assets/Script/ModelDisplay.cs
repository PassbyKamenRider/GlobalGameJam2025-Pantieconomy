using UnityEngine;

public class ModelDisplay : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float floatSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Transform model;
    private Vector3 originPosition;

    private void Start()
    {
        originPosition = model.transform.position;
    }

    private void Update()
    {
        RotateModel(rotateSpeed * Time.deltaTime);
        MoveModel();
    }
    public void RotateModel(float val)
    {
        model.transform.Rotate(0, val, 0);
    }

    public void MoveModel()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * amplitude;
        model.transform.position = new Vector3(originPosition.x, originPosition.y + yOffset, originPosition.z);
    }
}
