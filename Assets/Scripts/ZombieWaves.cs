using System.Collections.Generic;
using UnityEngine;

public class ZombieWaves : MonoBehaviour
{
    [SerializeField] private Zombie _prefab = null;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private int _zombiesToSpawn = 3;

    private float _currentTime = 0f;

    private Queue<float> _timeToSpawnZombies;

    private void Awake()
    {
        List<float> times = new();
        for (int i = 0; i < _zombiesToSpawn; i++)
        {
            times.Add(Random.Range(0f, _duration));
        }

        times.Sort();
        _timeToSpawnZombies = new(times);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_timeToSpawnZombies.Count == 0)
            return;

        if (_timeToSpawnZombies.Peek() < _currentTime)
        {
            SpawnZombie();
            _timeToSpawnZombies.Dequeue();
        }
    }

    private void SpawnZombie()
    {
        Instantiate(_prefab, Utils.GetRandomZombiePosition(), Quaternion.identity);
    }
}
