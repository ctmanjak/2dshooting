using _02Scripts.Player;
using _02Scripts.Score;
using _02Scripts.UI;
using UnityEngine;

namespace _02Scripts.Save
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }
        private const string SaveKey = "SaveData";

        public PlayerEntity Player;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            UserData userData = new UserData();
            ScoreManager.Instance.Save(userData);
            Player.Save(userData);
            UpgradeManager.Instance.Save(userData);
            
            PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(userData));
        }

        private void Load()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return;
            
            UserData userData = JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(SaveKey));

            if (userData == null) return;
            
            ScoreManager.Instance.Load(userData.Score, userData.HighScore);
            Player.Load(userData.Health);
            UpgradeManager.Instance.Load(userData.UpgradeLevel);
        }
    }
}
