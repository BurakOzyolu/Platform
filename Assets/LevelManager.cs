using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpanPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerSpawner();
    }
    void PlayerSpawner()
    {
        Instantiate(playerPrefab, playerSpanPosition.position,Quaternion.identity);
    }
    public void ReSpawnPlayer()
    {
        Instantiate(playerPrefab, playerSpanPosition.position, Quaternion.identity);
    }
}
