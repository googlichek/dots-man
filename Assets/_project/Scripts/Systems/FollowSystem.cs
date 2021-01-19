using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.Scripts
{
    public class FollowSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var deltaTime = Time.DeltaTime;

            Entities
                .WithAll<Translation, Rotation>()
                .ForEach((Entity entity, in FollowComponent follow) =>
                {
                    if (HasComponent<Translation>(follow.Target) && HasComponent<Rotation>(follow.Target))
                    {
                        var currentPosition = GetComponent<Translation>(entity).Value;
                        var currentRotation = GetComponent<Rotation>(entity).Value;

                        var targetPosition = GetComponent<Translation>(follow.Target).Value;
                        var targetRotation = GetComponent<Rotation>(follow.Target).Value;

                        targetPosition += math.mul(targetRotation, targetPosition) * -follow.Distance;
                        targetPosition += follow.Offset;

                        targetPosition.x = follow.ShouldFreezeX ? currentPosition.x : targetPosition.x;
                        targetPosition.y = follow.ShouldFreezeY ? currentPosition.y : targetPosition.y;
                        targetPosition.z = follow.ShouldFreezeZ ? currentPosition.z : targetPosition.z;
                        targetRotation = follow.ShouldFreezeRotation ? currentRotation : targetRotation;

                        targetPosition = math.lerp(currentPosition, targetPosition, deltaTime * follow.MoveSpeed);
                        targetRotation = math.lerp(currentRotation.value, targetRotation.value, deltaTime * follow.MoveRotation);

                        SetComponent(entity, new Translation {Value = targetPosition});
                        SetComponent(entity, new Rotation {Value = targetRotation});
                    }
                })
                .WithStructuralChanges()
                .Run();
        }
    }
}
