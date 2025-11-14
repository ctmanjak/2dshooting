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

        private void OnDestroy()
        {
            Save();
        }

        private void Save()
        {
            UserData saveData = new UserData(
                ScoreManager.Instance.HighScore,
                ScoreManager.Instance.Score,
                Player.GetHealth(),
                UpgradeManager.Instance.UpgradeLevel
            );
            PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(saveData));
        }

        private void Load()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return;
            
            UserData userData = JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(SaveKey));

            if (userData == null) return;
            
            ScoreManager.Instance.Load(userData);
            Player.Load(userData);
            UpgradeManager.Instance.Load(userData);
        }
    }
}
