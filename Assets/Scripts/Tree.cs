using UnityEngine;

public class Tree : MonoBehaviour
{
    private bool _hasRigidbody;
    private CarController2 _carController;

    private void Start()
    {
        _carController = GameObject.Find("Car").GetComponent<CarController2>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            if(gameObject.GetComponent<Rigidbody>() == null)
            {
                Rigidbody rb = gameObject.AddComponent<Rigidbody>();
                _hasRigidbody = true;
            }
        }
    }
}
