using UnityEngine;
using System.Collections.Generic;

public class FinalScreenUI : MonoBehaviour
{    
    private Game _game;
    private UI _ui;

    public List<LevelButtonUI> levelButtons;

    public void Init(Game game, UI ui) {
        _game = game;
        _ui = ui;
        
        for (int i = 0; i < levelButtons.Count; i++) {
            levelButtons[i].Init(_game, this, i);
        }
    }

    public void Open() {
        gameObject.SetActive(true);
    }
}
