using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughToggle : MonoBehaviour
{
    OVRPassthroughLayer passthroughLayer;
    public float passthroughTransitionSpeed = 5;
    bool transitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        passthroughLayer = GameObject.Find("[BuildingBlock] Passthrough").GetComponent<OVRPassthroughLayer>();
    }

    public void TransitionToPassthrough()
    {
        StartCoroutine(PassthroughGradient(true));
    }

    public void TransitionFromPassthrough()
    {
        StartCoroutine(PassthroughGradient(false));
    }

    IEnumerator PassthroughGradient(bool thumbsUp)
    {
        //Makes sure you can't transition if there is already a transition going on
        if (!transitioning)
        {
            transitioning = true;

            //If you have your thumbs up and passthrough is DISABLED (0 is off, 1 is on)
            if (thumbsUp && passthroughLayer.textureOpacity == 0)
            {
                //Enables passthrough gradually
                Debug.Log("Enabling Passthrough");

                //Scales the opacity transition with framerate using Time.deltaTime
                while (passthroughLayer.textureOpacity < 1)
                {
                    passthroughLayer.textureOpacity += passthroughTransitionSpeed * Time.deltaTime;
                    yield return null;  //Unity will crash if this isn't here
                }
            }
            else if (!thumbsUp && passthroughLayer.textureOpacity == 1)
            {
                //Disables passthrough gradually
                Debug.Log("Disabling Passthrough");
                while (passthroughLayer.textureOpacity > 0)
                {
                    passthroughLayer.textureOpacity -= passthroughTransitionSpeed * Time.deltaTime;
                    yield return null;
                }
            }

            //Sets transitioning to false so we can go back to passthrough or vice-versa
            transitioning = false;
        }
        yield return null;
    }

}
