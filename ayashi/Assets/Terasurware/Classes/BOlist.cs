using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BOlist : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public string english;
		public string japanese;
		public string headcount;
		public string time;
		public string difficulty;
		public string lucky;
		public string communication;
		public string card;
		public string forBeginner;
	}
}

