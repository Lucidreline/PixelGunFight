using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void SwitchScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void SetNormalTimescale()
    {
        Time.timeScale = 1f;
    }
}
