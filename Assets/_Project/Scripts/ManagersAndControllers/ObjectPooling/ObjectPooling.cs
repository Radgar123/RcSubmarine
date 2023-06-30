using System;
using System.Collections.Generic;
using AI;
using Radgar.Singleton;
using UnityEngine;
//using Universal;

namespace ManagersAndControllers.ObjectPooling
{
    public class ObjectPooling : Singleton<ObjectPooling>
    {
        [SerializeField] private List<ObjectToPool> _objectToPools;
        //[SerializeField] private List<TwoDimensionalList<GameObject>> _twoDimensionalList;
        [SerializeField] private List<GameObject> _objectsInPool;

        private void Awake()
        {
            CreateObjectPools();
        }

        #region CreatePool

        private void CreateObjectPools()
        {
            //_twoDimensionalList = new List<TwoDimensionalList<GameObject>>(_objectToPools.Count);

            foreach (var obj in _objectToPools)
            {
                for (int i = 0; i < obj.amount; i++)
                {
                    GameObject temp = Instantiate(obj.objectToPool);
                    temp.SetActive(false);
                    _objectsInPool.Add(temp);
                }
            }

            /*for (int i = 0; i < _objectToPools.Count; i++)
            {
                for (int j = 0; i < _objectToPools[i].amount; j++)
                {
                    GameObject temp = Instantiate(_objectToPools[i].objectToPool);
                    temp.SetActive(false);
                    _twoDimensionalList[i].listOfElements.Add(temp);
                }
            }*/
        }

        #endregion

        #region GetObjectFromPool

        public GameObject GetPooledObject()
        {
            foreach (var pooledObject in _objectsInPool)
            {
                if (!pooledObject.activeInHierarchy)
                {
                    return pooledObject;
                }
            }
            
            return null;
        }

        #endregion

        #region Reset

        public void ResetPool()
        {
            foreach (var obj in _objectsInPool)
            {
                obj.gameObject.SetActive(false);
            }
            
            ResetPoolPos();
        }

        private void ResetPoolPos()
        {
            foreach (var obj in _objectsInPool)
            {
                obj.transform.position = new Vector3(0, 0, 0);
            }
        }

        #endregion
        
    }
}