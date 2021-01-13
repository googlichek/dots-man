using Unity.Entities;
using UnityEngine;

namespace Game.Scripts
{
    [AlwaysUpdateSystem]
    public class GameStateSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var pelletQuery = GetEntityQuery(ComponentType.ReadOnly<PelletComponent>());

            Debug.Log(pelletQuery.CalculateEntityCount());
        }
    }
}
