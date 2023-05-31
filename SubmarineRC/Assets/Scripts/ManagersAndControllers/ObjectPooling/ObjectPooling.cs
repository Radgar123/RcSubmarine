using System;
using System.Collections.Generic;
using UnityEngine;
using Universal;

namespace ManagersAndControllers.ObjectPooling
{
    public class ObjectPooling : Singleton<ObjectPooling>
    {
        [SerializeField] private List<ObjectToPool> _objectToPools;
        [SerializeField] private List<TwoDimensionalList<GameObject>> _twoDimensionalList;

        private void Awake()
        {
            //CreateObjectPools();
        }

        #region CreatePool

        private void CreateObjectPools()
        {
            _twoDimensionalList = new List<TwoDimensionalList<GameObject>>(_objectToPools.Count);

            foreach (var obj in _objectToPools)
            {
                for (int i = 0; i < obj.amount; i++)
                {
                    GameObject temp = Instantiate(obj.objectToPool);
                    
                }
            }

            for (int i = 0; i < _objectToPools.Count; i++)
            {
                for (int j = 0; i < _objectToPools[i].amount; j++)
                {
                    GameObject temp = Instantiate(_objectToPools[i].objectToPool);
                    temp.SetActive(false);
                    _twoDimensionalList[i].listOfElements.Add(temp);
                }
            }
        }

        #endregion
        
    }
}