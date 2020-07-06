using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    static private CanvasScript _CS;
    static public CanvasScript CS
    {
        get
        {
            return _CS;
        }
        private set
        {
            if (_CS != null)
            {
                Debug.LogWarning("Second attempt to set CanvasScript singleton _CS.");
            }
            _CS = value;
        }
    }
    // Start is called before the first frame update
    public Text scoreShownInGame;
    public GameObject restartPanel;
    public GameObject congratulationPanel;
    void Start()
    {
        CS = this;
        restartPanel.SetActive(false);
        congratulationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int number)
    {
        scoreShownInGame.text = number.ToString();
        if (number == 2100)
            congratulationPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
