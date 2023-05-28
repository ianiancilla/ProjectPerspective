using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level", fileName = "Level")]
public class LevelSO : ScriptableObject
{
    [SerializeField] Perspective startingPerspective;
    [SerializeField] Vector3 playerStartDirection;
    [SerializeField] Vector3Int goalPosition;


    public Perspective StartingPerspective() => startingPerspective;
    public Vector3 PlayerStartDirection() => playerStartDirection;

    public Vector3 GoalPosition() => goalPosition;
}
