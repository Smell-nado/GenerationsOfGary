using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LimbView : TapSteveElement {

    public Transform uiElement; 
    public Text limbOrbAmount;

    //public RawImage limbOrgImage;

    //I could find the Text and RawImage in using get component or something like that.
    void Start()
    {
        if (uiElement != null) 
        {
            limbOrbAmount = uiElement.GetComponentInChildren<Text>();
            app.controller.limbController.UpdateLimbOrbAmount(transform.name, this);//This should probably be initialized in the main controller
        }
        else 
        {
            Debug.LogWarning("You forgot to attach the UI elements to the LimbView script");
        }

        // string uiName = "" + transform.name + "ui";
        // limbOrbAmount = Find(uiName).GetComponentInChildren<Text>();
    }

    //This function should probably be in the controller
    // public void UpdateAmount(string limbName)
    // {
    //     if (uiElement != null)
    //     {
    //         limbOrbAmount.text = app.model.limbModels[limbName].orbLimbAmount.ToString();

    //         if (app.model.limbModels[limbName].orbLimbAmount > 0)
    //         {
    //             uiElement.gameObject.SetActive(true);
    //         }
    //         else {
    //             uiElement.gameObject.SetActive(false);
    //         }
    //     }
    //     else 
    //     {
    //         Debug.LogWarning("You forgot to attach the UI elements to thhe LimbView script");
    //     }
    //}

    public void TapSteve(string limbName) 
    {
        TapSteveNotifications.TapLimb(limbName, this, this.gameObject);
    }

    public void EndProgress(string limbName)
    {
        TapSteveNotifications.EndProgress(limbName, this, this.gameObject);
    }
}
