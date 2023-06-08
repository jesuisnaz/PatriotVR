using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameController;

public interface IEventListener
{
    void Notify(GameState state);
}
