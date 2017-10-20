using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
  
    [SerializeField] private List<MonoBehaviour> objects = new List<MonoBehaviour>();

    public T registerObject<T>(T newObj) where T: MonoBehaviour {
        T g = Instantiate(newObj);
        objects.Add(g);
        g.gameObject.SetActive(false);
        return g;
    }

    public T registerObject<T>(GameObject newObj) where T : MonoBehaviour {
        GameObject g = Instantiate(newObj);
        T gComponent = g.GetComponent<T>();
        objects.Add(g.GetComponent<T>());
        g.SetActive(false);
        return gComponent;
    }

    public void activateObject(MonoBehaviour referenceObject){
        if (objects.Contains(referenceObject)){
            referenceObject.gameObject.SetActive(true);
        }
    }

    public void activateObject(MonoBehaviour referenceObject, Vector3 position, Quaternion rotation){
        if (objects.Contains(referenceObject))
        {
            referenceObject.gameObject.SetActive(true);
            referenceObject.transform.position = position;
            referenceObject.transform.rotation = rotation;
        }
    }

    public void deactivateObject(MonoBehaviour referenceObject){
        if (objects.Contains(referenceObject)){
            referenceObject.gameObject.SetActive(false);
        }
    }
}
