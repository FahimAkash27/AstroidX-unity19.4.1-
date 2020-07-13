using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject levelPanel;
    public Text levelNo, astroidAndChildrenNo;
    public static int levelNumber;

    public GameObject fullScreenButton, normalButton;

    public GameObject player, background, astroidGenerator;

    static private LevelManager _L;
    static public LevelManager L
    {
        get
        {
            return _L;
        }
        private set
        {
            if (_L != null)
            {
                Debug.LogWarning("Second attempt to set LevelManager singleton _L.");
            }
            _L = value;
        }
    }

    private void Awake()
    {
        L = this;
    }
    void Start()
    {
        levelNumber = 1;
        SetLevelNo(levelNumber);

        levelPanel.SetActive(true);

        player.SetActive(false);
        background.SetActive(false);
        astroidGenerator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelNo(int n)
    {
        levelPanel.SetActive(true);
        if(n < 2)
        {
            fullScreenButton.SetActive(true);
            normalButton.SetActive(false);
        }
        else
        {
            fullScreenButton.SetActive(false);
            normalButton.SetActive(true);
        }
        levelNo.text = "Level " + n.ToString();
        int astroidNo = n + 2;
        int childrenNo = (n * 6) + 2;
        astroidAndChildrenNo.text = "Astroid : " + astroidNo.ToString() + "                    Children : " + childrenNo.ToString();
    }

    public void SetActiveEveryThing()
    {
        player.SetActive(true);
        PlayerShip.S.PlayerStartEffect();
        background.SetActive(true);

        astroidGenerator.SetActive(true);
        AstroidGenerator.numberOfAstroid = 2 + LevelManager.levelNumber;
        AstroidGenerator.AG.CreatingAstroid(AstroidGenerator.numberOfAstroid);
        AstroidGenerator.AG.score = 0;

        CanvasScript.CS.SetScore(0);
        
        levelPanel.SetActive(false);
    }
}
