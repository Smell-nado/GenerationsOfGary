using UnityEngine;
using System.Collections;

public class PunchComponent : MonoBehaviour {

float punchAmount = 0.2f;
float punchTime = 0.6f;

float rotateAmount = 15f;
float rotateTime = 0.5f;

	public void PunchObject(GameObject ob)
    {
        LeanTween.scale(ob, Vector3.one * punchAmount, punchTime).setEase(LeanTweenType.punch);
    }

    public void ShakeObject(GameObject ob)
    {
        LeanTween.rotateAround(ob, Vector3.forward, rotateAmount, rotateTime).setEase(LeanTweenType.punch);
    }
}
