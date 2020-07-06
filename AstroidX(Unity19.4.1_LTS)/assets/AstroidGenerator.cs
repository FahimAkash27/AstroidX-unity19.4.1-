using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidGenerator : MonoBehaviour
{

    static private AstroidGenerator _AG;
    static public AstroidGenerator AG
    {
        get
        {
            return _AG;
        }
        private set
        {
            if (_AG != null)
            {
                Debug.LogWarning("Second attempt to set AstroidGenerator singleton _AG.");
            }
            _AG = value;
        }
    }


    int numberOfAstroid;
    // Start is called before the first frame update
    [Header("Set in Inspector")]
    public GameObject[]     astroidPrefebs;
    public int speedUpperLimit;
    public int speedLowerLimit;
    public int score;
    Rigidbody rigid;
    void Start()
    {
        AG = this;
        numberOfAstroid = 3;
        CreatingAstroid(3);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatingAstroid(int numberOfAstroid)
    {
        for(int i = 0; i<numberOfAstroid; i++)
        {
            int randomNumber = Random.Range(0, 3);
            GameObject astroid = Instantiate<GameObject>(astroidPrefebs[i]);
            Vector3 pos = new Vector3(Random.Range(-15f, 15f), Random.Range(-9f, 9f), 0f);
            astroid.transform.position = pos;

            rigid = astroid.GetComponent<Rigidbody>();
            Vector3 velocity = new Vector3(Random.Range(speedLowerLimit, speedUpperLimit), Random.Range(speedLowerLimit,
                speedUpperLimit),0f );
            rigid.AddForce(velocity);

        }
    }

    public void CreatingAstroidAfterDestroyingAstroidA(Vector3 pos)
    {
        int reverse = 1;
        for (int i = 0; i < 2; i++)
        {
            GameObject a = Instantiate<GameObject>(astroidPrefebs[1]);
            a.transform.position = pos + new Vector3(reverse, reverse, 0f);
            a.transform.rotation = Random.rotation;
            rigid = a.GetComponent<Rigidbody>();
            Vector3 velocity = new Vector3(Random.Range(225, 275)*reverse, Random.Range(250,
                300)*reverse, 0f);
            rigid.AddForce(velocity);
            reverse = -1;
        }
    }

    public void CreatingAstroidAfterDestroingAstroidB(Vector3 pos)
    {
        int reverse = 1;
        for (int i = 0; i < 2; i++)
        {
            GameObject a = Instantiate<GameObject>(astroidPrefebs[2]);
            a.transform.position = pos + new Vector3(reverse,reverse,0f);
            a.transform.rotation = Random.rotation;
            rigid = a.GetComponent<Rigidbody>();
            Vector3 velocity = new Vector3(Random.Range(250, 300)*reverse, Random.Range(300,
                350)*reverse, 0f);
            rigid.AddForce(velocity);
            reverse = -1;
        }
    }





}
