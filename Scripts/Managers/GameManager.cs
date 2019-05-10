using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public GameObject enemySpawner;
    public GameObject inGameUI;
    
    void Start()
    {
       GameObject playerObj = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
       inGameUI.SetActive(true);
       enemySpawner.SetActive(true);
       enemySpawner.GetComponent<EnemySpawner>().target = playerObj;
    }  
}