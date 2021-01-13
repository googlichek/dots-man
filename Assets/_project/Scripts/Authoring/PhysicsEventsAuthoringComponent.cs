using Unity.Entities;
using UnityEngine;

namespace Game.Scripts
{
    public class PhysicsEventsAuthoringComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddBuffer<CollisionBuffer>(entity);
            dstManager.AddBuffer<TriggerBuffer>(entity);
        }
    }
}
