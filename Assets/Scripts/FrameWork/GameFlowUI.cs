using UnityEngine;
using UnityEngine.UI;

public class GameFlowUI : MonoBehaviour
{
    [SerializeField] Text GameOverText;
    [SerializeField] Text WinnerText;
    [SerializeField] ReturnScript returnScript; // Reference ke ReturnScript

    void Start()
    {
        GameOverText?.gameObject.SetActive(false);
        WinnerText?.gameObject.SetActive(false);

        // Cari ReturnScript jika tidak di-assign di inspector
        if (returnScript == null)
        {
            returnScript = FindObjectOfType<ReturnScript>();
        }

        GameServices.GetGameState().OnGameOver += ShowGameResults;
    }

    void ShowGameResults(ETeam winner)
    {
        GameOverText?.gameObject.SetActive(true);
        WinnerText?.gameObject.SetActive(true);

        if (WinnerText)
        {
            WinnerText.color = GameServices.GetTeamColor(winner);
            WinnerText.text = "Winner is " + winner.ToString() + " team";
        }

        // Tampilkan return button ketika game selesai
        if (returnScript != null)
        {
            returnScript.ShowReturnButton();
        }
        else
        {
            Debug.LogWarning("ReturnScript tidak ditemukan!");
        }
    }
}