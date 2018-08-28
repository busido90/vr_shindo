using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderController : MonoBehaviour
{

    public bool isCutFromOutside { get; private set; }

    private void Start() {
        isCutFromOutside = true;
    }

    private void OnTriggerEnter(Collider other) {
        isCutFromOutside = false;
    }

    private void OnTriggerExit(Collider other) {
        isCutFromOutside = true;
    }
}
