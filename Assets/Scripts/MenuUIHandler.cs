using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    
    public InputField userNameText;
    public Text highScoreText;

    public void NewNameEntered(string name)
    {
        DataManager.Instance.userName = name;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        userNameText.placeholder.gameObject.GetComponent<Text>().text = DataManager.Instance.savedUserName;
        highScoreText.text = $"Highscore: {DataManager.Instance.savedUserName}: {DataManager.Instance.savedHighScore}";
    }
        
    public void StartNew()
    {
        NewNameEntered(userNameText.text);
        SceneManager.LoadScene(1);
    }
   

    public void Exit()
    {
        DataManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
