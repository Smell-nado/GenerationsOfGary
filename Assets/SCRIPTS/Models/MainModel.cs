// BounceModel.cs
using System.Collections.Generic;

// Contains all data related to the app.
public class MainModel : TapSteveElement
{

	//All the Data for the game
    public PlayerModel playerModel = new PlayerModel();

    //ALL LIMBS//////////////////////////////////////////////////////////////////////////////////////////
    //Baby Limbs
    public LimbModel babyLimbModel = new LimbModel(0);
    
    //Child Limbs
    public LimbModel childHeadModel = new LimbModel(3);
    public LimbModel childBodyModel = new LimbModel(2);
    public LimbModel childLimbsModel = new LimbModel(1);

    //Adult Limbs
    public LimbModel adultHeadModel = new LimbModel(3);
    public LimbModel adultBodyModel = new LimbModel(2);
    public LimbModel adultRightArmModel = new LimbModel(1);
    public LimbModel adultLeftArmModel = new LimbModel(1);
    public LimbModel adultRightLegModel = new LimbModel(1);
    public LimbModel adultLeftLegModel = new LimbModel(1);

    //Easy Access to models
    public Dictionary<string, LimbModel> limbModels = new Dictionary<string, LimbModel>();
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    void Awake()
    {
        //Baby
        limbModels.Add("babysteve", babyLimbModel);
        //Child
        limbModels.Add("childhead", childHeadModel);
        limbModels.Add("childbody", childBodyModel);
        limbModels.Add("childlimbs", childLimbsModel);
        //Adult
        limbModels.Add("adulthead", adultHeadModel);
        limbModels.Add("adultbody", adultBodyModel);
        limbModels.Add("adultrightarm", adultRightArmModel);
        limbModels.Add("adultleftarm", adultLeftArmModel);
        limbModels.Add("adultrightleg", adultRightLegModel);
        limbModels.Add("adultleftleg", adultLeftLegModel);
    }
}

public class LimbModel
{
    public bool isProgressing;

    //Attribute types
    public enum LimbType {
        all,
        strength,
        heart,
        intellect
    }
    public LimbType limbType;

    public int limbLevel;

    public int XPReward;
    public float increaseSpeed;//This will be how much it scales per frame
    public float speedBoostFactor;
    public float speedBoostTime;

    public float attributeValue;

    public LimbModel(int type)
    {
        limbLevel = 1;
        XPReward = 1;
        increaseSpeed = 0.005f;
        speedBoostFactor = 5f;
        speedBoostTime = 0.1f;
        attributeValue = 0;

        switch (type)
        {
            case 0 :
            limbType = LimbType.all;
            break;
            case 1 :
            limbType = LimbType.strength;
            break;
            case 2 :
            limbType = LimbType.heart;
            break;
            case 3 :
            limbType = LimbType.intellect;
            break;
        }
    }
}

public class PlayerModel
{
    public int playerLevel = 0;
    public int mainXP = 0;
    public bool rightHanded = false;

    public enum PlayerState {
        Baby,
        Child,
        Adult
    }
    public PlayerState playerState;

    public PlayerModel()
    {

    }
}