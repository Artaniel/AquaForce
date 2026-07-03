using UnityEngine;
using System.Collections.Generic;

public class AbilityFactory : MonoBehaviour
{
    private Game _game;

    public List<Ability> abilities;
    public FreezeAbility freezeAbility;
    public waterBoostAbility waterBoostAbility;

    public bool isBoostedMassGain = false;

    public void Init(Game game) {
        _game = game; 
        abilities = new List<Ability>();    
        abilities.Add(freezeAbility);
        abilities.Add(waterBoostAbility);
        freezeAbility.Init(_game);
        waterBoostAbility.Init(_game);
    }

    public void ManualFixedUpdate() {
        foreach (Ability ability in abilities) {
            ability.ManualFixedUpdate();
        }
    }

    public void TryUseFreeze() {
        freezeAbility.Activate();
    }
    
    public void TryUseWaterBoost() {
        waterBoostAbility.Activate();
    }
}

