using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

    public const string branchName = "Branch";
    private bool linked;
    [SerializeField] private Node connectedParent, connectedChild;

    public void connect(){
        if (connectedChild){
            connectedParent.AddChild(connectedChild);
            connectedChild.setParent(connectedParent);
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.name.Contains("Node")){
            if (coll.transform.position.y > transform.position.y)
                connectedParent = coll.GetComponent<Node>();
            else
                connectedChild = coll.GetComponent<Node>();
        }
    }

    void Update(){
        if (!linked){
            connect();
            linked = true;
        }
    }
}
