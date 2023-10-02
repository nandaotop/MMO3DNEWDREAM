using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "ScriptableObject/Skills")]
public class Skill : ScriptableObject
{
    public AnimName animName = AnimName.atk; 
}

public enum AnimName
{
    atk
}