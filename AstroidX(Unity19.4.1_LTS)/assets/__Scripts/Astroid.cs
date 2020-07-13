using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rigid;
    public GameObject particalEffect;
    public GameObject playerDeathParticalEffect;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other);
            if (gameObject.tag == "AstroidA")
            {
                Vector3 destroyAstroidPos = gameObject.transform.position;
                Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                AstroidGenerator.AG.CreatingAstroidAfterDestroyingAstroidA(destroyAstroidPos);
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 500;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);

            }
            else if(gameObject.tag == "AstroidB")
            {
                Vector3 destroyAstroidPos = gameObject.transform.position;
                Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                AstroidGenerator.AG.CreatingAstroidAfterDestroingAstroidB(destroyAstroidPos);
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 300;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);
            }
            else if(gameObject.tag == "AstroidC")
            {
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 100;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);
                Instantiate(particalEffect, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }else if(other.tag == "Player")
        {
            Instantiate(playerDeathParticalEffect, other.gameObject.transform.position, other.gameObject.transform.rotation);
            other.gameObject.SetActive(false);
            CanvasScript.CS.restartPanel.SetActive(true);
        }
    }

}
