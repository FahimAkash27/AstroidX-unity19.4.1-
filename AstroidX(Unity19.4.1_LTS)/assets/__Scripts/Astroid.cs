using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rigid;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other);
            if (gameObject.tag == "AstroidA")
            {
                Vector3 destroyAstroidPos = gameObject.transform.position;
                Destroy(gameObject);
                AstroidGenerator.AG.CreatingAstroidAfterDestroyingAstroidA(destroyAstroidPos);
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 500;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);

            }
            else if(gameObject.tag == "AstroidB")
            {
                Vector3 destroyAstroidPos = gameObject.transform.position;
                Destroy(gameObject);
                AstroidGenerator.AG.CreatingAstroidAfterDestroingAstroidB(destroyAstroidPos);
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 300;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);
            }
            else if(gameObject.tag == "AstroidC")
            {
                AstroidGenerator.AG.score = AstroidGenerator.AG.score + 100;
                CanvasScript.CS.SetScore(AstroidGenerator.AG.score);
                Destroy(gameObject);
            }
        }else if(other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            CanvasScript.CS.restartPanel.SetActive(true);
        }
    }

}
