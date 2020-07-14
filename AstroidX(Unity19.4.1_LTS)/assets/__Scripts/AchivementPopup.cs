using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementPopup : MonoBehaviour
{
    public Vector3 startPosition, offscreenPosition;
    public float moveSpeed = 80f;
    public float movePauseTime = 2f;

    public Text title, description;

    public bool bIsAlreadyPopping = false;
    public List<StringTuple> achievementList = new List<StringTuple>();

    public static AchivementPopup Ap;

    private void Awake()
    {
        Ap = this;
    }
    void Start()
    {
        startPosition = transform.position;
        offscreenPosition = startPosition;
        offscreenPosition.y += 200;
        transform.position = offscreenPosition;
    }

    public void PopUp(StringTuple st)
    {
        PopUp(st.title, st.description);
    }

    public void PopUp(string achivementTitle,string achivementDescription)
    {
        if (!bIsAlreadyPopping)
        {
            bIsAlreadyPopping = true;
            title.text = achivementTitle;
            description.text = achivementDescription;
            StartCoroutine(MoveToPosition());
        }
        else
        {
            StringTuple st = new StringTuple(achivementTitle, achivementDescription);
            achievementList.Add(st);
            StartCoroutine(WaitYourTurn());
        }

    }

    IEnumerator WaitYourTurn()
    {
        while (bIsAlreadyPopping)
        {
            yield return new WaitForSeconds(0.5f);
        }
        if (achievementList.Count > 0)
        {
            StringTuple st = achievementList[0];
            achievementList.RemoveAt(0);

            PopUp(st);
        }
    }

    public IEnumerator MoveToPosition()
    {
        float step = (moveSpeed / (offscreenPosition - startPosition).magnitude * Time.fixedDeltaTime);
        float t = 0;
        float u;
        while (t <= 1.0f)
        {
            t += step;
            u = 1 - (1 - t) * (1 - t); // This does some fancy easing on the Lerp
            transform.position = Vector3.LerpUnclamped(offscreenPosition, startPosition, u);
            yield return new WaitForFixedUpdate();
        }
        transform.position = startPosition;

        yield return new WaitForSeconds(movePauseTime);

        t = 0;
        while (t <= 1.0f)
        {
            t += step;
            u = t * t; // This does some fancy easing on the Lerp
            transform.position = Vector3.Lerp(startPosition, offscreenPosition, u);
            yield return new WaitForFixedUpdate();
        }
        transform.position = offscreenPosition;
        bIsAlreadyPopping = false;
    }

    [System.Serializable]
    public struct StringTuple
    {
        public string title, description;

        public StringTuple(string t, string d)
        {
            title = t;
            description = d;
        }
    }
}
