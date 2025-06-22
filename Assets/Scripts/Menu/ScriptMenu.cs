using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main"); // Pastikan nama scene-nya sama persis
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game..."); // Hanya muncul di Editor
        Application.Quit(); // Tidak bekerja di Editor, hanya saat game dibuild
    }
}