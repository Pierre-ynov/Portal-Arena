using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPiece 
{
    public int id { get; set; }
    public string name { get; set; } 
    public Bar health { get; set; }
    public Bar armor { get; set; }

    //public Slot<Attack> attack { get; set; }



}
