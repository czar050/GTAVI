using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private Terrain _terrain;
    [SerializeField] private int _numberOfTree;
    [SerializeField] private Transform TreeParent;

    private void Start()
    {
        for (int i = 0; i < _numberOfTree; i++)
        {
            float randomX = Random.Range(-500,500);
            float randomZ = Random.Range(-500,500);
            float randomY = _terrain.SampleHeight(new Vector3(randomX, 0, randomZ));
            float treeHeight = _treePrefab.GetComponent<Renderer>().bounds.size.y;
            Vector3 treePosition = new Vector3(randomX, randomY -(treeHeight/12.0f),randomZ);
            Instantiate(_treePrefab, treePosition, Quaternion.Euler(0, Random.Range(0,360),0), TreeParent);
        }
    }
}
