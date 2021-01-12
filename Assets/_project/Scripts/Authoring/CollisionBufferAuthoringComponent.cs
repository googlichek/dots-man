using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.Scripts
{
    [DisallowMultipleComponent]
    public class CollisionBufferAuthoringComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddBuffer<CollisionBuffer>(entity);
        }
    }
}
