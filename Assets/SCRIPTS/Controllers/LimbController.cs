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
    }
}
