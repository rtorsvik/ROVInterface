using System;
using System.Collections.Generic;

namespace Translator
{
	/*
	 * Class needs two functions and a name:
	 * 
	 * public static byte[] ConvertCommands(KeyValuePair<int, int>[]);	Converts a set of commands into the right format before sending
	 * public static Pair<int,int>[] ConvertData(byte[]);				Converts a set of recieved data to the right format before accepting them  
	 * public const string TRANSLATORNAME = "Your translator name";		Spesifies the name of the translator
     */

	/// <summary>
	/// Class functions as translator between this application and an external unit that doesnt use the same data format.
	/// </summary>
	public static class main
	{

		/// <summary>
		/// The name of this translator
		/// </summary>
		public const string TRANSLATORNAME = "Your translator name";



		/// <summary>
		/// Converts a set of commands into the right format before sending
		/// </summary>
		/// <param name="commands">Set of commands</param>
		/// <returns>byte array in the right format</returns>
		public static byte[] ConvertCommands(KeyValuePair<int, int>[] commands)
		{
			//TODO

			return null;
		}



		/// <summary>
		/// Converts a set of recieved data to the right format before accepting them  
		/// </summary>
		/// <param name="b">recieved data</param>
		/// <returns>KeyValuePair containing recieved data in the right format</returns>
		public static KeyValuePair<int, int>[] ConvertData(byte[] b)
		{
			//TODO

			return null;
		}

	}

}