using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadNextScene()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i+1);
    }
}
