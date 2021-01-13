using Unity.Entities;
using Unity.Transforms;

namespace Game.Scripts
{
    public class SpawnerSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .ForEach((ref SpawnerComponent spawner, in Translation translation, in Rotation rotation) =>
                {
                    if (!EntityManager.Exists(spawner.SpawnObject))
                    {
                        spawner.SpawnObject = EntityManager.Instantiate(spawner.SpawnPrefab);

                        EntityManager.SetComponentData(spawner.SpawnObject, translation);
                        EntityManager.SetComponentData(spawner.SpawnObject, rotation);
                    }
                })
                .WithStructuralChanges()
                .Run();
        }
    }
}
