using Unity.Entities;
using UnityEngine;

namespace Game.Scripts
{
    [DisallowMultipleComponent]
    public class CameraAuthoringComponent : MonoBehaviour, IConvertGameObjectToEntity
    {
        public AudioListener AudioListener;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new CameraComponent() {});
            conversionSystem.AddHybridComponent(AudioListener);
        }
    }
}
