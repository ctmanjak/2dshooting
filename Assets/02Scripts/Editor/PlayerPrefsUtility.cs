using UnityEditor;
using UnityEngine;

namespace _02Scripts.Editor
{
    public static class PlayerPrefsUtility
    {
        [MenuItem("Tools/Clear PlayerPrefs %#r")]
        public static void ClearPlayerPrefs()
        {
            if (!EditorUtility.DisplayDialog("초기화 확인",
                    "정말 PlayerPrefs를 모두 삭제하시겠습니까?", "예", "아니오")) return;
            
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}