using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://qiita.com/toRisouP/items/3619ad3d2b7d785968f1
namespace ScrollUI {
    public class Node : MonoBehaviour {
        public int NodeNumber => this.transform.GetSiblingIndex();
    }
}