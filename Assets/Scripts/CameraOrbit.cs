using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 5.0f;
    [SerializeField] private float xSpeed = 100.0f;
    [SerializeField] private float ySpeed = 100.0f;
    [SerializeField] private float yMinLimit = -20.0f;
    [SerializeField] private float yMaxLimit = 80.0f;
    [SerializeField] private float scrollSpeed = 2.0f;
    [SerializeField] private float x = 0.0f;
    [SerializeField] private float y = 0.0f;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void Update()
    {
        if(_target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y += Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

            _distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            _distance = Mathf.Clamp(_distance, 3.0f, 15.0f);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -_distance) + _target.position;
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
