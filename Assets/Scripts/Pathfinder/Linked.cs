using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkedNode<T> {

    public LinkedNode<T> next;
    public LinkedNode<T> prev;

    public T value;
    public LinkedNode(T value) {
        this.value = value;
    }

    public void AddAfter(LinkedNode<T> node) {
        //node.next = null;
        //node.prev = null;
        LinkedNode<T> old = this.next;
        this.next = node;
        node.prev = this;
        if (old != null) {
            old.prev = node;
        } node.next = old;
    }
    public void AddBefore(LinkedNode<T> node) {
        //node.next = null;
        //node.prev = null;
        LinkedNode<T> old = this.prev;
        this.prev = node;
        node.next = this;
        if (old != null) {
            old.next = node;
        } node.prev = old;
    }
    public void Remove() {
        LinkedNode<T> prev = this.prev;
        LinkedNode<T> next = this.next;

        if (prev != null) this.prev.next = next;
        if (next != null) this.next.prev = prev;

    }
}

public class Linked
{
    LinkedNode<Node> first = null;
    public int length = 0;

    public void Add(Node newValue) {
        LinkedNode<Node> newNode = new LinkedNode<Node> (newValue);

        if (this.first == null) this.first = newNode;
        else {
            LinkedNode<Node> ptr = this.first;
            while (ptr.next != null) {
                if (newNode.value.fCost < ptr.value.fCost || (
                    newNode.value.fCost == ptr.value.fCost && newNode.value.hCost < ptr.value.hCost)) {
                    ptr.AddBefore(newNode);
                    break;
                }ptr = ptr.next;
            }
            if (ptr.next == null) {
                if (newNode.value.fCost < ptr.value.fCost || (newNode.value.fCost == ptr.value.fCost && newNode.value.hCost < ptr.value.hCost) )
                    ptr.AddBefore(newNode);
                else ptr.AddAfter(newNode);
            }
        }
        this.length++;
        if (this.first.prev != null) {
            this.first = this.first.prev;
            if (this.first.prev != null) {

            }
        }
    }

    public void Update(Node CheckNode) {
        LinkedNode<Node> ptr = this.first;
        while (ptr != null) {
            if (ptr.value == CheckNode) {
                Update(ptr);
                break;
            }ptr = ptr.next;
        }
    }

    public void Update(LinkedNode<Node> CheckNode) {
        LinkedNode<Node> ptr = CheckNode.next;
        CheckNode.Remove();
        if (CheckNode == this.first) {
            this.first = CheckNode.next;
        }
        CheckNode.next = null;
        CheckNode.prev = null;
        //length--;
        while (ptr != null) {
            if (CheckNode.value.fCost > ptr.value.fCost || (
                    CheckNode.value.fCost == ptr.value.fCost && CheckNode.value.hCost > ptr.value.hCost)) {
                ptr.AddAfter(CheckNode);
                break;
            }
            ptr = ptr.prev;
        }
        if(ptr == null) {
            CheckNode.AddAfter(this.first);
            this.first = CheckNode;
        }
        if (this.first.prev != null) {
            this.first = this.first.prev; 
            if (this.first.prev != null) {

            }
        }
    }

    public Node Push() {
        LinkedNode<Node> temp = this.first;
        this.first.Remove();
        this.first = temp.next;
        length--;
        return temp.value;
    }

    public bool Contains(Node value) {
        for (LinkedNode<Node> ptr = this.first; ptr != null; ptr = ptr.next) {
            if (ptr.value == value) {
                return true;
            }
        } 
        return false;
    }
}
