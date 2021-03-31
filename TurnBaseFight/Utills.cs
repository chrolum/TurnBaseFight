using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class Utills
	{
		static public int GetUserIntInput()
		{
			int n;
			while (!Int32.TryParse(Console.ReadLine(), out n))
			{
				Console.WriteLine("Invail input");
			}
			return n;
		}


		static public void PrintSkillUseFailNotification(SkillStatus status)
		{
			switch (status)
			{
				case SkillStatus.NoEnoughHP:
					Console.WriteLine("No enough Hp to use this skill!");
					break;
				case SkillStatus.NoEnoughMP:
					Console.WriteLine("No enough Mp to use this skill!");
					break;
				case SkillStatus.NoEnoughUseTime:
					Console.WriteLine("No enough remain use time to use this skill!");
					break;
			}
		}
	}
}
