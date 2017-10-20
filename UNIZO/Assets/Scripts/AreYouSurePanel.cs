using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AreYouSurePanel : MonoBehaviour {

    //public static AreYouSurePanel singleton;
    protected RectTransform rect;

    [SerializeField]
    protected int Index;

    [SerializeField]
    protected Vector3 IncrementFactor;

    [SerializeField]
    protected float desiredSize;


    protected virtual void Awake ()
    {
        //singleton = this;
        rect = GetComponent<RectTransform>();
        //Index = 0;
	}

    public void SetIndex(int i)
    {
        Index = i;
    }

    protected void Update ()
    {
        if (Index == 0 && rect.localScale.x > 0)
        {
            rect.localScale = rect.localScale - IncrementFactor * Time.deltaTime;

        }
        else if (Index == 1 && rect.localScale.x < desiredSize)
        {
            rect.localScale = rect.localScale + IncrementFactor * Time.deltaTime;
        }
           
    }

    public virtual void No()
    {
        Debug.Log("No");
        Index = 0;
    }

    public virtual void Yes(string name)
    {
        if (name == "Quit")
            Application.Quit();
        else
            Application.LoadLevel(name);
    }

    public virtual void Trigger()
    {
        Index = 1;
    }
}
