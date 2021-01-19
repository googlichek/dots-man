using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Game.Scripts
{
    [DisallowMultipleComponent]
    public class OnKillAuthoringComponent : MonoBehaviour, IConvertGameObjectToEntity, IDeclareReferencedPrefabs
    {
        public string SFXName;
        public GameObject SpawnPrefab;
        public int PointValue;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new OnKillComponent
            {
                SFXName = new Unity.Collections.FixedString64(SFXName),
                SpawnPrefab = conversionSystem.GetPrimaryEntity(SpawnPrefab)
            });
        }

        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(SpawnPrefab);
        }
    }
}
