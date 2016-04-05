using UnityEngine;
using System.Collections;


public class LimbController : TapSteveElement {

    void OnEnable()
    {
        TapSteveNotifications.onTapLimb += TapLimbHandler;
        TapSteveNotifications.onEndProgress += EndProgressHandler;
    }

    void OnDisable ()
    {
        TapSteveNotifications.onTapLimb -= TapLimbHandler;
        TapSteveNotifications.onEndProgress -= EndProgressHandler;
    }

	// Handles the events
    public void TapLimbHandler(string p_event_path,Object p_target,params object[] p_data)
    {
        //WE have limbName, connected limbView, and the gameObjectt
        if (!app.model.limbModels[p_event_path].isProgressing)
        {
            app.model.limbModels[p_event_path].isProgressing = true;
            app.punchcomponent.PunchObject(p_data[0] as GameObject);
            app.progressbarcomponent.StartBar(p_data[0] as GameObject);

            //Move limb orb value to total value
            app.model.playerModel.orbAmount += app.model.limbModels[p_event_path].orbLimbAmount;
            app.model.limbModels[p_event_path].orbLimbAmount = 0;

            //update
            app.controller.playerController.UpdatePlayerOrbs();
            LimbView limbScript = p_target as LimbView;
            UpdateLimbOrbAmount(p_event_path, limbScript);
        }
        else 
        {
            //Tell the game object to speed up  
            app.punchcomponent.ShakeObject(p_data[0] as GameObject);
            app.progressbarcomponent.SpeedUpBar(p_data[0] as GameObject);
        }
    }

    public void EndProgressHandler (string p_event_path,Object p_target,params object[] p_data)
    {
        //set it to false
        app.model.limbModels[p_event_path].isProgressing = false;

        //Increase limb orb amount
        app.model.limbModels[p_event_path].orbLimbAmount += app.model.limbModels[p_event_path].orbReward;

        //Update limb orb view
        LimbView limbScript = p_target as LimbView;
        UpdateLimbOrbAmount(p_event_path, limbScript);
    }

    //Moving this from LimbView
    public void UpdateLimbOrbAmount(string limbName, LimbView limbScript)
    {
        if (limbScript.uiElement != null)
        {
            limbScript.limbOrbAmount.text = app.model.limbModels[limbName].orbLimbAmount.ToString();

            if (app.model.limbModels[limbName].orbLimbAmount > 0)
            {
                limbScript.uiElement.gameObject.SetActive(true);
            }
            else {
                limbScript.uiElement.gameObject.SetActive(false);
            }
        }
        else 
        {
            Debug.LogWarning("You forgot to attach the UI elements to thhe LimbView script");
        }

    }
}
