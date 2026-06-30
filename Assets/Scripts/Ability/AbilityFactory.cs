using UnityEngine;
using System.Collections.Generic;

public class AbilityFactory : MonoBehaviour
{
    private Game _game;

    public List<Ability> abilities;

    public void Init(Game game) {
        _game = game; 
        abilities = new List<Ability>();
    }

    public void ResetAllAbilities() {
        foreach (Ability ability in abilities) {
            ability.Reset();
        }
    }

    public void ManualFixedUpdate() {
        foreach (Ability ability in abilities) {
            ability.ManualFixedUpdate();
        }
    }
}

