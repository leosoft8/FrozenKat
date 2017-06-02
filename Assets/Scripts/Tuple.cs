using UnityEngine;
using System;
using System.Collections;

public class Tuple : IComparable <Tuple>
{

	public int First { get; private set; }
	public string Second { get; private set; }

	public Tuple( int First , string Second ) {
		this.First = First;
		this.Second = Second;
	}

	public int CompareTo(Tuple other){

		if (this.First < other.First || this.First == other.First) {
			return 1;
		} 
		return -1;
	}

}