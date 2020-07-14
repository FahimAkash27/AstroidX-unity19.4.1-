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
    public static int finalScore;

    public bool firstKill = false;
    public bool rookie = false;
    void Start()
    {
        finalScore = 2100;
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
        if(firstKill == false && number > 0)
        {
            AchivementManager.AM.FirstDustDone();
            firstKill = true;
        }
        if(number >= 5500 && rookie == false)
        {
            rookie = true;
            AchivementManager.AM.RookiePilot();
        }
        scoreShownInGame.text = number.ToString();
        if (number == ((LevelManager.levelNumber * 1500) + 600))
        {
            StartCoroutine(DoWait());
        }
            //congratulationPanel.SetActive(true);
            
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public IEnumerator DoWait()
    {
        yield return new WaitForSeconds(2);
        int levelno = LevelManager.levelNumber + 1;
        LevelManager.levelNumber = levelno;
        LevelManager.L.SetLevelNo(levelno);
        AstroidGenerator.AG.score = 0;
    }
}
