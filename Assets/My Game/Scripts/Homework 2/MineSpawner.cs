﻿using UnityEngine;


public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mine; 
    [SerializeField] private Transform _mineSpawnPlace;

    private void Update()
    {
        CreateMine();
    }

    private void CreateMine()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_mine, _mineSpawnPlace.position, _mineSpawnPlace.rotation);
        }
    }  
}
