// using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos()
    {
        if (Camera.main != null) return Camera.main.WorldToScreenPoint(this.transform.position);

        return default;
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        if (Camera.main != null) this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - this.mousePosition);
    }
}
