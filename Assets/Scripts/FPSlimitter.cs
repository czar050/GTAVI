using UnityEngine;

public class FPSlimitter : MonoBehaviour
{
    [SerializeField] private int _FPSLimit;

    private void Start()
    {
        Application.targetFrameRate = _FPSLimit;
    }
}
