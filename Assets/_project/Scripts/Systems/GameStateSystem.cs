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
            GameManager.Instance.UpdatePelletCount(pelletQuery.CalculateEntityCount());

            if (pelletQuery.CalculateEntityCount() <= 0)
                GameManager.Instance.Win();

            var playerQuery = GetEntityQuery(ComponentType.ReadOnly<PlayerComponent>());
            if (playerQuery.CalculateEntityCount() <= 0)
                GameManager.Instance.Lose();
        }
    }
}
