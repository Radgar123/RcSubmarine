using System.Collections.Generic;
using UnityEngine;

namespace ManagersAndControllers.SaveManager
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private SaveData _saveData;

        #region Save

        public void SaveData()
        {
            AddUser();
            string playerData = JsonUtility.ToJson(_saveData);
            string filePath = Application.persistentDataPath + "/submarineRcHighScores.json";
            Debug.Log(filePath);
            System.IO.File.WriteAllText(filePath,playerData);
        }

        private void AddUser()
        {
            SaveDataObject _saveDataObject = new SaveDataObject();
            _saveDataObject.name = GameManager.instance.playerName;
            _saveDataObject.time = GameManager.instance.playerTime;
            
            _saveData._saveDataObjects.Add(_saveDataObject);
        }

        #endregion

        #region Load
        
        public void LoadData()
        {
            string filePath = Application.persistentDataPath + "/submarineRcHighScores.json";
            string playerData = System.IO.File.ReadAllText(filePath);

            _saveData = JsonUtility.FromJson<SaveData>(playerData);
        }
        
        #endregion
        
    }

    [System.Serializable]
    public class SaveData
    {
        public List<SaveDataObject> _saveDataObjects;
    }
}