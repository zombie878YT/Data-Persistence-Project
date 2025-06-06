using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public InputField Name;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = PersistentData.Instance.playerHighScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

        PersistentData.Instance.Save();
    }

    public void NameEntered()
    {
        PersistentData.Instance.playerName = Name.text;
    }
}
