using UnityEngine;
using System.Collections;

public class LimbView : TapSteveElement {

    public void TapSteve(string limbName) 
    {
        TapSteveNotifications.TapLimb(limbName, this, this.gameObject);
    }

    public void EndProgress(string limbName)
    {
        TapSteveNotifications.EndProgress(limbName, this, this.gameObject);
    }
}
