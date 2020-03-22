﻿using System.Collections.Generic;
using UnityEngine;

namespace Die4Games.ModularScript.Elements
{
    [CreateAssetMenu]
    public class AttackElement : ScriptableObject
    {
        [Tooltip("The elements that are defeated by this element.")]
        public List<AttackElement> DefeatedElements = new List<AttackElement>();
    }
}