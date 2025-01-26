using UnityEngine;

public class CarController : MonoBehaviour
{
    public Wheel[] _wheels;
    public int _motorTorque;
    private float _verticalInput;
    private float _horizontalInput;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        foreach (Wheel wheel in _wheels)
        {
            wheel.WheelCollider.motorTorque = _motorTorque * _verticalInput;
            wheel.UpdateMeshPosition();
        }
        Steering();
    }

    private void Steering()
    {
        float steerAngle = _horizontalInput * 25;
        foreach (Wheel wheel in _wheels)
        {
            if(wheel.isForward)
            {
                wheel.WheelCollider.steerAngle = steerAngle;
            }
        }
    }
}


[System.Serializable]
public struct Wheel
{
    public Transform WheelMesh;
    public WheelCollider WheelCollider;
    public bool isForward;

    public void UpdateMeshPosition()
    {
        Vector3 position;
        Quaternion rotation;

        WheelCollider.GetWorldPose(out position, out rotation);

        WheelMesh.position = position;
        WheelMesh.rotation = rotation;
    }
}