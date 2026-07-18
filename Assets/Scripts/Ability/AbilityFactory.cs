using UnityEngine;
using System.Collections.Generic;

public class AbilityFactory : MonoBehaviour
{
    private Game _game;

    public List<Ability> abilities;
    public FreezeAbility freezeAbility;
    public waterBoostAbility waterBoostAbility;

    public bool isBoostedMassGain = false;
    public Dictionary<Ability, int> inventory;

    public void Init(Game game) {
        _game = game; 
        abilities = new List<Ability>();    
        abilities.Add(freezeAbility);
        abilities.Add(waterBoostAbility);
        freezeAbility.Init(_game);
        waterBoostAbility.Init(_game);
        inventory = new Dictionary<Ability, int>();
        inventory.Add(freezeAbility, 2);
        inventory.Add(waterBoostAbility, 2);

        _game.ui.abilityUi.RefreshNumbers();
    }

    public void ManualFixedUpdate() {
        foreach (Ability ability in abilities) {
            ability.ManualFixedUpdate();
        }
    }

    public void TryUseFreeze() {
        if (inventory[freezeAbility] > 0){
            freezeAbility.Activate();
            inventory[freezeAbility]--;
            _game.ui.abilityUi.RefreshNumbers();
        }
    }
    
    public void TryUseWaterBoost() {
        if (inventory[waterBoostAbility] > 0){
            waterBoostAbility.Activate();
            inventory[waterBoostAbility]--;
            _game.ui.abilityUi.RefreshNumbers();
        }
    }

    public void Reset() {
        
    }
}

