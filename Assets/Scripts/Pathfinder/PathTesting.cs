using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    List<Node> nodes;
    AStar Astar;
    void Start()
    {
        this.Astar = GameObject.Find("Map").GetComponent<AStar>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Node target = this.Astar.GetNode(this.target.transform.position.x, this.target.transform.position.z);
        Node player = this.Astar.GetNode(this.transform.position.x, this.transform.position.z);
        nodes = this.Astar.FindPath(player, target);
    }
    /*
    void OnDrawGizmos() {
        if (this.grid != null && this.grid.debug && nodes != null) {
            foreach(Node node in nodes) {
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(new Vector3(node.x, 0, node.y), new Vector3(this.grid.nodeScale, this.grid.nodeScale, this.grid.nodeScale) * 0.9f);
            }
        }
    }*/
}
