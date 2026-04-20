using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 60f;
    public bool useLocalSpace = true;

    public bool canRotate = true;

    void Update()
    {
        if (!canRotate) return;

        if (useLocalSpace)
        {
            transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void SetDisEnable()
    {
        this.enabled = false;
        canRotate = false;
    }
}