using UnityEngine;
public class LookCheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _checkpoint;
    private void Update()
    {
        Vector3 direction = _checkpoint.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}