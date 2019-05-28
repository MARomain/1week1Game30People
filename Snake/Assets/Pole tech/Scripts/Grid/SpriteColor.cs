using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteColor
{
    public Sprite sprite;
    public Color col;
}

[System.Serializable]
public class Configuration
{
    public SpriteColor spriteAndColorToApply;
    public enum Conditions { Up, Down, Left, Right}
    public Conditions[] conditions;
}
