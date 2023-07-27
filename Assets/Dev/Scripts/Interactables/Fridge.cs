using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Interactables
{
    public class Fridge : MonoBehaviour, ICollectables
    {
        [SerializeField] private List<GameObject> stockPool;
        [SerializeField] private int poolSize;
        [SerializeField] private GameObject stockPrefab;

        private void Awake()
        {
            PoolInit();
        }

        private void PoolInit()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var obj = Instantiate(stockPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.SetActive(false);
                obj.name = $"stock {i}";
                stockPool.Add(obj);
            }
        }
        
        private GameObject GetAvailableBullet()
        {
            var firstInactiveObject = stockPool.FirstOrDefault(go => !go.activeSelf);
            return firstInactiveObject;
        }

        public void Execute()
        {
            var obj = GetAvailableBullet();
            
        }
    }
}
