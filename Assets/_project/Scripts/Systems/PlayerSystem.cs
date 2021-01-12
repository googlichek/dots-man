using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts
{
    public class PlayerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            Entities
                .WithAll<PlayerComponent>()
                .ForEach((ref MovableComponent movable) => { movable.Direction = new float3(x, 0, z); })
                .Schedule();
        }
    }
}
