using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugGame : MonoBehaviour
{
    bool jPressed;
    void Update()
    {
        // J tuşuna basıldığında flag aktif olsun
        if (Input.GetKeyDown(KeyCode.J))
            jPressed = true;

        // Numara tuşuna basıldığında ve J aktifse sahne yükle
        if (jPressed)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SceneManager.LoadScene(2);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                SceneManager.LoadScene(3);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                SceneManager.LoadScene(4);

            if (Input.GetKeyDown(KeyCode.Alpha4))
                SceneManager.LoadScene(5);

            if (Input.GetKeyDown(KeyCode.Alpha5))
                SceneManager.LoadScene(6);

            if (Input.GetKeyDown(KeyCode.Alpha0))
                SceneManager.LoadScene(7);

            if (Input.GetKeyDown(KeyCode.Alpha9))
                SceneManager.LoadScene(1);

            // Numara tuşuna basıldıktan sonra J flag’i sıfırla
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.J))
                jPressed = false;
        }

    }
}
