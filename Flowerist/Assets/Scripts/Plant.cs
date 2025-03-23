using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant :ICloneable
{
    public PlantData plantData;
    public PlantStates currentState; 

    public virtual void Initialize(PlantData data){
        currentState = PlantStates.Seed; 
        plantData=data;
    }

    public void AdvanceState()
    {
        if (currentState == PlantStates.Seed) currentState = PlantStates.Sprout;
        else if (currentState == PlantStates.Sprout) currentState = PlantStates.Flower;
    }
    public virtual object Clone()=>this.MemberwiseClone();
    
}
public class Seed : Plant {
    public override void Initialize(PlantData data) => base.Initialize(data);
}

public class Sprout : Plant {
    public override void Initialize(PlantData data) => base.Initialize(data);
}

public class Flower : Plant {
    public override void Initialize(PlantData data) => base.Initialize(data);
}