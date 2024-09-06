using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCutter : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask chainLayerMask;

    private bool isCutting = false;
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            isCutting = true;
        }

        if(Input.GetMouseButtonUp(0)) {
            isCutting = false;
        }

        if(!isCutting){
            CutChain();
        }
    }

    void CutChain() {
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, chainLayerMask)) {
            GameObject chainPart = hit.collider.gameObject;
            Destroy(chainPart.GetComponent<HingeJoint>());

            Destroy(chainPart);
        }
    }
}
