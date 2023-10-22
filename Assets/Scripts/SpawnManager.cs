using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool isGameActive = true;
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private float _spawnRate = 5.0f;
    private float _xSpawnRange = 8.5f;
    private float _ySpawn = 8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            Instantiate(_enemyprefab, new Vector3(Random.Range(-_xSpawnRange, _xSpawnRange), _ySpawn, 0), Quaternion.identity);
        }
    }
}
