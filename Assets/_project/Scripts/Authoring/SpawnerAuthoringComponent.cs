using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Game.Scripts
{
    public class SpawnerAuthoringComponent : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public GameObject SpawnObject;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager
                .AddComponentData(
                    entity,
                    new SpawnerComponent
                    {
                        SpawnPrefab = conversionSystem.GetPrimaryEntity(SpawnObject)
                    });
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(SpawnObject);
        }
    }
}
