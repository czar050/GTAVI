using UnityEngine;

public class SitinCar : MonoBehaviour
{
    [SerializeField] private GameObject _cameraPlayer;
    [SerializeField] private GameObject _cameraCar;
    [SerializeField] CarController carController;
    [SerializeField] private GameObject _player;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = _player.GetComponent<MeshRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(other.gameObject.CompareTag("Player"))
            {
                _cameraPlayer.SetActive(false);
                _cameraCar.SetActive(true);
                carController.enabled = true;
                meshRenderer.enabled = false;
            }
        }
    }
}
