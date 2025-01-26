using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _carCamera;
    [SerializeField] private CarController2 _carController;
    [SerializeField] private GameObject _exit;
    private bool _inCar;
    private bool _pressF;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !_inCar)
        {
            float distance = Vector3.Distance(_player.transform.position, _exit.transform.position);
            if(distance <= 1.0f)
            {
                _inCar = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.F) && _inCar)
        {
            _inCar = false;
        }


        if(_inCar)
        {
            _player.SetActive(false);
            _carCamera.SetActive (true);
            _carController.enabled = true;
            _pressF = true;
        }
        else
        {
            _player.SetActive(true);
            _carCamera.SetActive(false);
            _carController.enabled = false;
            if(_pressF)
            {
                _player.transform.position = _exit.transform.position;
                _pressF = false;
            }
        }
    }
}
