using UnityEngine;
using System.Collections;
using TMPro;

public class CarController2 : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAngle;
    [SerializeField] private int speedint;


    [SerializeField] private WheelCollider _frontLeft;
    [SerializeField] private WheelCollider _frontRight;
    [SerializeField] private WheelCollider _rearLeft;
    [SerializeField] private WheelCollider _rearRight;

    [SerializeField] private Transform _frontRightWheel;
    [SerializeField] private Transform _frontLeftWheel;
    [SerializeField] private Transform _rearRightWheel;
    [SerializeField] private Transform _rearLeftWheel;

    [SerializeField] private TextMeshProUGUI _speedText;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
        StartCoroutine(SpeedUpdate());
    }

    private void Update()
    {
        float distance = Vector3.Distance(lastPosition, transform.position);
        float speed = distance / Time.deltaTime;
        lastPosition = transform.position;
        speedint = Mathf.RoundToInt(speed);
        

        Vector3 FRposition;
        Quaternion FRrotation;
        _frontRight.GetWorldPose(out FRposition, out FRrotation);
        _frontRightWheel.position = FRposition;
        _frontRightWheel.rotation = FRrotation;

        Vector3 FLposition;
        Quaternion FLrotation;
        _frontLeft.GetWorldPose(out FLposition, out FLrotation);
        _frontLeftWheel.position = FLposition;
        _frontLeftWheel.rotation = FLrotation;

        Vector3 RRposition;
        Quaternion RRrotation;
        _rearLeft.GetWorldPose(out RRposition, out RRrotation);
        _rearRightWheel.position = RRposition;
        _rearRightWheel.rotation = RRrotation;

        Vector3 RLposition;
        Quaternion FRLrotation;
        _rearRight.GetWorldPose(out RLposition, out FRLrotation);
        _rearLeftWheel.position = RLposition;
        _rearLeftWheel.rotation = FRLrotation;

        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(transform.position.x, 4, transform.position.z);
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        }
    }

    private void FixedUpdate()
    {
        _rearLeft.motorTorque = Input.GetAxis("Vertical") * _speed;
        _rearRight.motorTorque = Input.GetAxis("Vertical") * _speed;

        _frontLeft.steerAngle = Input.GetAxis("Horizontal") * _maxAngle;
        _frontRight.steerAngle = Input.GetAxis("Horizontal") * _maxAngle;
    }

    private IEnumerator SpeedUpdate()
    {
        while(true)
        {
           _speedText.text = speedint.ToString() + "КМ/Ч";
        yield return new WaitForSeconds(0.3f); 
        }
        
    }
}
