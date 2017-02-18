using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MocapController : MonoBehaviour {

	public OVRCameraRig camera; //Drag camera rig object on to the script in the editor.

	void Awake()
	{
		camera.UpdatedAnchors += UpdateAnchors;
	}

	void UpdatedAnchors(OVRCameraRig rigToUpdate)
	{
		Transform headTransform = GetHeadTransform(); //Write yourself
		Transform lHandTransform = GetLHandTransform(); //Write yourself
		Transform rHandTransform = GetRHandTransform(); //Write yourself

		rigToUpdate.trackerAnchor = headTransform;
		rigToUpdate.leftHandAnchor= lHandTransform;
		rigToUpdate.rightHandAnchor= rHandTransform;
	}
}
