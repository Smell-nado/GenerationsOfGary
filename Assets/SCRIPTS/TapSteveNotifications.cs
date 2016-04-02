using UnityEngine;
using System.Collections;

// This class will give static access to the events strings.
 class TapSteveNotifications 
{
    //Delegates and Events
    public delegate void TapLimbHandler (string p_event_path,Object p_target,params object[] p_data);
    public static event TapLimbHandler onTapLimb;

    public delegate void EndProgressHandler (string p_event_path,Object p_target,params object[] p_data);
    public static event EndProgressHandler onEndProgress;


    //Activation Methods
    public static void TapLimb (string limbName, Object limbScript, params object[] pData)
    {
        if (!Object.ReferenceEquals(null, onTapLimb)) 
        {
            //Debug.Log("Tap Limb EVENT: Limb-" + limbName + ", Limbscript-" + limbScript + ", Object-" + pData);
            onTapLimb(limbName, limbScript, pData);
        }
    }

    public static void EndProgress (string limbName, Object limbScript, params object[] pData)
    {
        if (!Object.ReferenceEquals(null, onEndProgress))
        {
            //Debug.Log("End Progress EVENT: Limb-" + limbName + ", Limbscript-" + limbScript + ", Object-" + pData);
            onEndProgress(limbName, limbScript, pData);
        }
    }

}
