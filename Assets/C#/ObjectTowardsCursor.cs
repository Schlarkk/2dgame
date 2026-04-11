using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTowardsCursor : MonoBehaviour
{
void Update()
{
    // Get the position of the cursor in screen space
    Vector3 cursorScreenPosition = Input.mousePosition;

    // Set the z-coordinate to the object's z-coordinate
    cursorScreenPosition.z = transform.position.z - Camera.main.transform.position.z;

    // Convert the cursor position from screen space to world space
    Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorScreenPosition);

    // Calculate the vector from the object to the cursor
    Vector3 lookDirection = cursorWorldPosition - transform.position;

    // Calculate the angle between the positive Y-axis and the lookDirection
    float angle = Mathf.Atan2(lookDirection.x, lookDirection.y) * Mathf.Rad2Deg;

    // Set the object's rotation to face the cursor
    transform.rotation = Quaternion.Euler(0, 0, -angle);
}
}
