using UnityEngine;
using System.Collections.Generic;

public class AbilityFactory : MonoBehaviour
{
    private Game _game;

    public List<Ability> abilities;
    public FreezeAbility freezeAbility;
    public FreezeAbility waterBoostAbility;

    public void Init(Game game) {
        _game = game; 
        abilities = new List<Ability>();    
        abilities.Add(freezeAbility);
        freezeAbility.Init(_game);
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
        if (waterBoostAbility.charges > 0) {
            waterBoostAbility.Activate();
        }
    }
}

