using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    [SerializeField] private Button returnButton;
    [SerializeField] private string menuSceneName = "menu"; // Ganti dengan nama scene menu Anda

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Jika button tidak di-assign di inspector, cari secara otomatis
        if (returnButton == null)
        {
            GameObject gameFlowCanvas = GameObject.Find("GameFlowCanvas");
            if (gameFlowCanvas != null)
            {
                Transform returnButtonTransform = gameFlowCanvas.transform.Find("ReturnButton");
                if (returnButtonTransform != null)
                {
                    returnButton = returnButtonTransform.GetComponent<Button>();
                }
            }
        }

        // Sembunyikan button di awal game
        if (returnButton != null)
        {
            returnButton.gameObject.SetActive(false); // Sembunyikan button
            returnButton.onClick.AddListener(ReturnToMenu);
        }
        else
        {
            Debug.LogError("ReturnButton tidak ditemukan di GameFlowCanvas!");
        }
    }

    // Method untuk menampilkan button ketika game selesai
    public void ShowReturnButton()
    {
        if (returnButton != null)
        {
            returnButton.gameObject.SetActive(true); // Tampilkan button
        }
    }

    // Method untuk menyembunyikan button (jika diperlukan)
    public void HideReturnButton()
    {
        if (returnButton != null)
        {
            returnButton.gameObject.SetActive(false); // Sembunyikan button
        }
    }

    // INI METHOD ReturnToMenu() YANG SUDAH ADA DI SCRIPT ANDA
    private void ReturnToMenu()
    {
        // Load scene menu
        SceneManager.LoadScene(menuSceneName);
    }

    void Update()
    {

    }

    private void OnDestroy()
    {
        // Unsubscribe dari event untuk mencegah memory leak
        if (returnButton != null)
        {
            returnButton.onClick.RemoveListener(ReturnToMenu);
        }
    }
}