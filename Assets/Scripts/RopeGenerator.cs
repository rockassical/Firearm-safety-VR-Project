using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGenerator : MonoBehaviour
{
    public GameObject ropeSegmentPrefab; // Prefab of a rope segment with Rigidbody and  ConfigurableJoint
    public Transform startPoint; // Start anchor point
    public Transform endPoint; // End anchor point
    public int segmentCount = 10; // Number of segments
    public float segmentLength = 0.5f; // Length of each segment
    private void Start()
    {
        GenerateRope();
    }
    void GenerateRope()
    {
        Vector3 segmentPosition = startPoint.position;
        GameObject previousSegment = null;
        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = Instantiate(ropeSegmentPrefab, segmentPosition,
           Quaternion.identity);
            Rigidbody rb = segment.GetComponent<Rigidbody>();
            // Link each segment with a ConfigurableJoint
            if (previousSegment != null)
            {
                ConfigurableJoint joint = segment.AddComponent<ConfigurableJoint>();
                joint.connectedBody = previousSegment.GetComponent<Rigidbody>();
                joint.autoConfigureConnectedAnchor = false;
                joint.anchor = Vector3.zero;
                joint.connectedAnchor = new Vector3(0, -segmentLength, 0);
                // Adjust joint settings for flexibility
                joint.xMotion = ConfigurableJointMotion.Locked;
                joint.yMotion = ConfigurableJointMotion.Limited;
                joint.zMotion = ConfigurableJointMotion.Locked;
                joint.angularXMotion = ConfigurableJointMotion.Limited;
                joint.angularYMotion = ConfigurableJointMotion.Limited;
                joint.angularZMotion = ConfigurableJointMotion.Limited;

            }
            else
            {
                // Attach the first segment to the start point
                segment.transform.position = startPoint.position;
                segment.GetComponent<ConfigurableJoint>().connectedBody =
               startPoint.GetComponent<Rigidbody>();
            }
            // Update position for next segment
            segmentPosition -= transform.up * segmentLength;
            previousSegment = segment;
        }
        // Attach last segment to the end point
        previousSegment.GetComponent<ConfigurableJoint>().connectedBody =
       endPoint.GetComponent<Rigidbody>();
    }
}