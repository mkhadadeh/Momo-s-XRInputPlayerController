using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class XRLaserPointer : MonoBehaviour
{
    public bool renderLaser = true;
    public GameObject cursor;
    public float maxDistance = 1000;
    public LayerMask layerMask;

    RaycastHit hitInfo;
    RaycastHit previousHit;
    bool rayHitting;

    LineRenderer laserLine;
    Vector3[] laserPositions;

    [HideInInspector]
    public bool interactWithXRButtons;
    XRButton hoveredButton;

    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserPositions = new Vector3[2];
        hoveredButton = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot the ray out
        rayHitting = Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, maxDistance, layerMask);

        // If it hits
        if (rayHitting)
        {
            // Render cursor
            if (cursor != null)
            {
                cursor.SetActive(true);
                cursor.transform.position = hitInfo.point;
            }

            // Set laser endpoint
            laserPositions[1] = hitInfo.point;
        }
        else
        {
            // Disable cursor
            if(cursor != null)
            {
                cursor.SetActive(false);
            }

            // Set laser endpoint
            laserPositions[1] = transform.position + (transform.forward * maxDistance);

            // Remove references to anything that is currently being hovered on
            if (interactWithXRButtons)
            {
                if (hoveredButton != null)
                {
                    hoveredButton.ChangeState(XRButton.ButtonState.UP);
                    hoveredButton = null;
                }
            }
        }
        // Render laser
        laserPositions[0] = transform.position;
        laserLine.SetPositions(laserPositions);
        laserLine.enabled = renderLaser;

        // Interact with objects
        if (hitInfo.collider != null) {
            // Interact with XR buttons if allowed
            if (interactWithXRButtons)
            {
                XRButton currHitButton = hitInfo.collider.gameObject.GetComponent<XRButton>();
                if (hoveredButton == null && rayHitting && currHitButton != null)
                {
                    hoveredButton = currHitButton;
                    hoveredButton.ChangeState(XRButton.ButtonState.HOVERED);
                }
            }
        }

    }

    public void PressXRButton()
    {
        if(interactWithXRButtons && hoveredButton != null && hoveredButton.state != XRButton.ButtonState.DISABLED)
        {
            hoveredButton.ChangeState(XRButton.ButtonState.PRESSED);
        }
    }

    public void ReleaseXRButton()
    {
        if (interactWithXRButtons && hoveredButton != null && hoveredButton.state != XRButton.ButtonState.DISABLED)
        {
            hoveredButton.ChangeState(XRButton.ButtonState.HOVERED);
        }
    }

    public bool getRaycastHit(out RaycastHit hit)
    {
        // If the ray is currently hitting anything, output it at the reference and return true
        // Else output the last hit object and return false
        hit = hitInfo;
        return rayHitting;
    }
}
