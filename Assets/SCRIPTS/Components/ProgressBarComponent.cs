using UnityEngine;
using System.Collections;

public class ProgressBarComponent : TapSteveElement {

    float scaleZStart;
    float scaleZEnd = 0.0001f;
    float scaleZ;

    bool boosted = false;

    Transform bar;

    public void StartBar(GameObject limb)
    {
        bar = limb.GetComponentInChildren<ProgressBarView>().transform;
        bar.GetComponentInChildren<Renderer>().enabled = true;

        scaleZStart = bar.localScale.z;
        scaleZ = scaleZStart;

        StartCoroutine(BarProgress(limb));
    }

    IEnumerator BarProgress (GameObject limb)
    {
        scaleZ -= app.model.limbModels[limb.name].increaseSpeed/scaleZStart;//This makes sure it goes up to 1.
        bar.localScale = new Vector3(bar.localScale.x, bar.localScale.y, scaleZ);

        yield return new WaitForFixedUpdate();

        if(scaleZ < scaleZEnd)
        {
            EndBar(limb);
        }
        else 
        {
            StartCoroutine(BarProgress(limb));
        }
    }

    public void SpeedUpBar(GameObject limb)
    {
        if (!boosted)
        {
            boosted = true;
            StartCoroutine(BarSpeedBoost(app.model.limbModels[limb.name].speedBoostFactor, app.model.limbModels[limb.name].speedBoostTime, limb));
        }        
    }

    IEnumerator BarSpeedBoost (float booster, float boostTime, GameObject limb)
    {
        app.model.limbModels[limb.name].increaseSpeed *= booster;
        yield return new WaitForSeconds(boostTime);
        app.model.limbModels[limb.name].increaseSpeed /= booster;
        boosted = false;
    }

    void EndBar(GameObject limb)
    {
        StopCoroutine(BarProgress(limb));
        bar.GetComponentInChildren<Renderer>().enabled  = false;
        scaleZ = scaleZStart;
        bar.localScale = new Vector3(bar.localScale.x, bar.localScale.y, scaleZ);

        //FIre the end progress methog in the connected limb view
        limb.GetComponentInChildren<LimbView>().EndProgress(limb.name);
    }
	
}
