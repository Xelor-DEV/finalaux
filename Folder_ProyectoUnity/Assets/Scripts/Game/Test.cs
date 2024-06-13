using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private BinaryTree<char> tree = new BinaryTree<char>();
    private void Start()
    {

        tree.InsertNewNode('A');
        tree.InsertNewNode('B','A');
        tree.InsertNewNode('C', 'A');
        tree.InsertNewNode('D', 'B');
        tree.InsertNewNode('E', 'B');
        tree.InsertNewNode('F', 'C');
        tree.InsertNewNode('G', 'C');
        tree.InsertNewNode('H', 'E');
        tree.InsertNewNode('I', 'E');
        tree.InDepthSearch();
    }
}
