using UnityEngine;
using TMPro;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance = 2;
    [SerializeField] private float _limitX;
    [SerializeField] private float _limitY;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _score;


    private void Update()
    {
        float carDistance = Vector3.Distance(transform.position, _target.position);
        if(carDistance <= _distance)
        {
            _score++;
            _scoreText.text = _score.ToString();
            transform.position = new Vector3(Random.Range(0,_limitX),8,Random.Range(0,_limitY));
        }
    }
}
