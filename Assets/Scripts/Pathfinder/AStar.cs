using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class AStar
{
    // Start is called before the first frame update

    Grid grid;

    public List<Node> MostRecentPath = new List<Node>();

    //float[] debugCoordinates = new float[2];

    public AStar(Grid _grid)
    {
        this.grid = _grid;
    }

    public Node GetNode(float x, float y) {
        return this.grid.GetNode(x, y);
    }

    public List<Node> FindPath(Node startNode, Node targetNode) {
        startNode.gCost = 0;
        startNode.hCost = 0;
        targetNode.parent = null;

        Linked opened = new Linked();
        List<Node> closed = new List<Node>();

        opened.Add(startNode);

        while (opened.length > 0) {
            Node ptr = opened.Push();
            closed.Add(ptr);

            if (ptr == targetNode) {
                return this.TracePath(startNode, targetNode);
            }
            /*if (ptr.x == debugCoordinates[0] && ptr.y == debugCoordinates[1]) {

            }*/
            foreach (Node neighbour in ptr.Directions) {
                CheckNeighour(neighbour, ptr, targetNode, opened, closed);
            }
        }
        return new List<Node>();
    }
    void CheckNeighour(Node neighbour, Node current, Node target, Linked opened, List<Node> closed) {
        if (neighbour == null) return;
        if (!neighbour.walkable || closed.Contains(neighbour)) return;

        float movementCost = current.gCost + current.GetDistance(neighbour);
        bool neighbourInOpened = opened.Contains(neighbour);
        /*if (neighbour.x == debugCoordinates[0] && neighbour.y == debugCoordinates[1]) {

        }*/
        if (movementCost < neighbour.gCost || !neighbourInOpened) {
            neighbour.gCost = movementCost;
            neighbour.hCost = neighbour.GetDistance(target);
            neighbour.parent = current;


            if (!neighbourInOpened) opened.Add(neighbour);
            else opened.Update(neighbour);

        }
    }

    List<Node> TracePath(Node start, Node target) {
        if (target.parent == null) return null;

        List<Node> path = new List<Node>();
        for (Node ptr = target; ptr != start; ptr = ptr.parent) {
            path.Add(ptr);
        }
        path.Reverse();

        if (this.grid.debug) MostRecentPath = path;
        return path;
    }
}
