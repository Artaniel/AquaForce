using System.Collections.Generic;
using UnityEngine;

public class PropFactory : MonoBehaviour
{
    private Game _game;
    public List<Prop> props;    

    public void Init(Game game) {
        _game = game;
    }

    public void Register(Prop prop) {
        props.Add(prop);
        prop.Init(_game, this);
    }

    public void Destroy(Prop prop) {
        props.Remove(prop);
        Destroy(prop.gameObject);
    }
}
