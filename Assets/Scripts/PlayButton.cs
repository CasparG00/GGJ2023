using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 1;

    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        LoadLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) | Input.GetKeyDown(KeyCode.Return))
        {
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(sceneIndex);
    }
}
