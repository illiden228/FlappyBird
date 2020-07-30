using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_template);
        _elapsedTime = _secondsBetweenSpawn;
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if(_elapsedTime > _secondsBetweenSpawn)
        {
            if(TryGetObject(out GameObject column))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minPositionY, _maxPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                column.SetActive(true);
                column.transform.position = spawnPoint;

                DisableObjectAboardScreen();
            }
        }
    }
}
