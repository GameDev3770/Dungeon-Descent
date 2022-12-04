using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathFinderAPI : MonoBehaviour
{
    public bool debug;
    public bool gizmos;
    public bool handles;

    public Layer[] WalkableLayers = new Layer[0];
    public Layer[] UnWalkableLayers = new Layer[0];
    public float nodeScale = 1;

    // Start is called before the first frame update
    AStar aStar;
    Grid grid;

    void Start() {
        this.grid = new Grid(debug, gizmos, handles, WalkableLayers, UnWalkableLayers, nodeScale);
        this.grid.BuildGrid(gameObject);

        this.aStar = new AStar(this.grid);
    }

    public List<Node> GetPathing(GameObject StartObject, GameObject EndObject) {
        return this.GetPathing(GetNode(StartObject), GetNode(EndObject));
    }

    public List<Node> GetPathing(Node StartNode, Node EndNode) {
        return this.aStar.FindPath(StartNode, EndNode);
    }

    public Node GetNode(GameObject gameobject) {
        return this.grid.GetNode(gameobject.transform.position);
        //return this.grid.GetNode(gameobject.transform.position.x, gameobject.transform.position.z);
    }

    void OnDrawGizmos() {
        if (aStar != null) grid.OnDrawGizmos(aStar);
    }
}
