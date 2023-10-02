using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "ScriptableObject/Skills")]
public class Skill : ScriptableObject
{
    public AnimName animName = AnimName.atk;
    public Sprite sprite;
    public int cost = 2;
    public float countDown = 3;
    public float activationTime = 5;
    public float counter = 5;
}

public enum AnimName
{
    atk,
    BowShot
}