using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rigid;
    public GameObject particalEffect;
    public GameObject playerDeathParticalEffect;

     bool firstKill = false;

    static bool firstLuckyShot = false;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("LuckyShott"))
        {
            int n = 0;
            PlayerPrefs.SetInt("LuckyShott", n);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            ScreenWrapper_My screenWrapper_My = other.gameObject.GetComponent<ScreenWrapper_My>();
            int luckyShot = PlayerPrefs.GetInt("LuckyShott");


            if (gameObject.tag == "AstroidA")
            {
                Vector3 destroyAstroidPos = gameObject.transform.position;
                Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);
                
                AstroidGenerator.AG.CreatingAstroidAfterDestroyingAstroidA(destroyAstroidPos);
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 500;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);

                if(screenWrapper_My.screenWrappered == true && luckyShot == 0)
                {
                    AchivementManager.AM.LuckyShot();
                    int n = 1;
                    PlayerPrefs.SetInt("LuckyShott", n);
                }else if(screenWrapper_My.screenWrappered == true && luckyShot > 0)
                {
                    int n = PlayerPrefs.GetInt("LuckyShott");
                    n++;
                    PlayerPrefs.SetInt("LuckyShott", n);

                    if (n == 100)
                        AchivementManager.AM.EagleEye();

                }

                Destroy(gameObject);


            }
            else if(gameObject.tag == "AstroidB")
            {
                Vector3 destroyAstroidPos = gameObject.transform.position;
                Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);
                
                AstroidGenerator.AG.CreatingAstroidAfterDestroingAstroidB(destroyAstroidPos);
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 300;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);

                if (screenWrapper_My.screenWrappered == true && luckyShot == 0)
                {
                    AchivementManager.AM.LuckyShot();
                    int n = 1;
                    PlayerPrefs.SetInt("LuckyShott", n);
                }
                else if (screenWrapper_My.screenWrappered == true && luckyShot > 0)
                {
                    int n = PlayerPrefs.GetInt("LuckyShott");
                    n++;
                    PlayerPrefs.SetInt("LuckyShott", n);

                    if (n == 100)
                        AchivementManager.AM.EagleEye();
                }

                Destroy(gameObject);

            }
            else if(gameObject.tag == "AstroidC")
            {
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 100;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);
                Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);


                if (screenWrapper_My.screenWrappered == true && luckyShot == 0)
                {
                    AchivementManager.AM.LuckyShot();
                    int n = 1;
                    PlayerPrefs.SetInt("LuckyShott", n);
                }
                else if (screenWrapper_My.screenWrappered == true && luckyShot > 0)
                {
                    int n = PlayerPrefs.GetInt("LuckyShott");
                    n++;
                    PlayerPrefs.SetInt("LuckyShott", n);

                    if (n == 100)
                        AchivementManager.AM.EagleEye();
                }

                Destroy(gameObject);
                

            }
            Destroy(other.gameObject);
        }
        else if(other.tag == "Player")
        {
            Instantiate(playerDeathParticalEffect, other.gameObject.transform.position, other.gameObject.transform.rotation);
            int n = PlayerShip.S.fireShots;
            PlayerPrefs.SetInt("fireShots", n);
            other.gameObject.SetActive(false);
            CanvasScript.CS.restartPanel.SetActive(true);
        }
    }


}
