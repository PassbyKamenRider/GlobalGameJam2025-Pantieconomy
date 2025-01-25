using UnityEngine;

public class ModelDisplay : MonoBehaviour
{
    [SerializeField] Transform model;
    public void RotateModel(float val)
    {
        model.transform.Rotate(0, val, 0);
    }
}
