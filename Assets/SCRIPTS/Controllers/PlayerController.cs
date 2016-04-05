using UnityEngine;
using System.Collections;

public class PlayerController : TapSteveElement 
{
    public void UpdatePlayerOrbs()
    {   
        app.view.playerView.playerOrbAmount.text = app.model.playerModel.orbAmount.ToString();
    }
}
