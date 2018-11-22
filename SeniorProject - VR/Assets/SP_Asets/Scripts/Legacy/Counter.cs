using System;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Counter
	{
		float start;
		int length;
		bool completed;
		public Counter(int milli)
		{
			length = milli;
		}
		public void startTime(){
			start = Time.time*1000;
		}
		public bool ready(){
			if ((start + length) < (Time.time * 1000)) {
				return true;
			} else {
				return false;
			}
		}
	}
}

