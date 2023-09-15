using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHelper : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_Text bestScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (DataPersistence.Instance.bestScore > 0)
        {
            bestScoreText.text = "Best Score : " + DataPersistence.Instance.bestPlayerName + " : " + DataPersistence.Instance.bestScore;
            inputName.text = DataPersistence.Instance.playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        //Debug.Log(inputName.text);
        DataPersistence.Instance.playerName = inputName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
