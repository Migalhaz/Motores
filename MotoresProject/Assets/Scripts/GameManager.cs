using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    PlayerManager m_playerManager;
    [SerializeField] Transform m_spawnPoint;
    [SerializeField] List<EnemiesSpawn> m_enemiesSpawns;
    List<GameObject> m_currentEnemies;

    private void Start()
    {
        m_currentEnemies = new();
        m_playerManager = PlayerManager.Instance;
        SetupScene();
    }

    public void SetupScene()
    {
        m_playerManager.SetActive(true);
        m_playerManager.gameObject.transform.position = m_spawnPoint.position;
        m_currentEnemies.ForEach(x => Destroy(x));
        m_currentEnemies.Clear();
        m_playerManager.Setup();
        foreach (var enemies in m_enemiesSpawns)
        {
            foreach (var spawn in enemies.m_SpawnPositions)
            {
                m_currentEnemies.Add(Instantiate(enemies.m_EnemyPrefab, spawn, Quaternion.identity));
            }
        }
    }

    public void SetCheckpoint(Transform newSpawnpoint)
    {
        m_spawnPoint = newSpawnpoint;
    }
}

[System.Serializable]
public class EnemiesSpawn
{
    [SerializeField] GameObject m_enemyPrefab;
    [SerializeField] List<Vector3> m_spawnPositions;

    public GameObject m_EnemyPrefab => m_enemyPrefab;
    public List<Vector3> m_SpawnPositions => m_spawnPositions;
}