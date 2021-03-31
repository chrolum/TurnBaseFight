using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class MainLoop
	{
		static void Main(string[] args)
		{
			Game newGame = new Game();
			while (true)
			{
				if (newGame.isWin())
				{
					Console.Clear();
					Console.WriteLine("You beat down all monister! Win!");
					break;
				}

				if (newGame.isFailed())
				{
					Console.Clear();
					Console.WriteLine("Oops, all heros has been sleep here forever");
					break;
				}


				Console.Clear();
				int r_idx = 0;
				foreach (var h in newGame.characterList)
				{
					if (!h.isDead && h.isMoniter)
					{
						Console.SetCursorPosition(40, r_idx++);
						h.ShowStatus();
					}
				}
				Console.SetCursorPosition(0, 0);
				foreach (var h in newGame.characterList)
				{
					if (!h.isDead && !h.isMoniter)
						h.ShowStatus();
				}

				CharacterBase curr_character = newGame.turnQueue.Dequeue();
				if (curr_character.isDead)
				{
					continue;
				}
				Console.WriteLine("Now is {0} ", curr_character.name);

				// AI
				if (curr_character.isAuto)
				{
					AI.AutoAction(curr_character, newGame);
				}
				else
				{
					//selec action
					RESELECT:
					Console.WriteLine("Select yout action: 0: Attack, 1: skill");
					ActionType actionType = (ActionType)Utills.GetUserIntInput();


					switch (actionType)
					{
						case ActionType.Attack:
							curr_character.Attack(newGame.SelectTarget());
							break;
						case ActionType.Skill:
							SkillType t = newGame.SelectSkillType(curr_character);
							SkillStatus status = curr_character.UseSkill(t, curr_character, newGame.SelectTarget(t));
							if (status != SkillStatus.ActionSuccess)
							{
								Utills.PrintSkillUseFailNotification(status);
								goto RESELECT;
							}
							break;
					}
				}

				// death check
				foreach (var h in newGame.characterList)
				{
					if (h.HP <= 0 && !h.isDead)
					{
						Console.WriteLine("{0}'s Hp is {1}, lower than 0! Has Dead!", h.name, h.HP);
						h.isDead = true;
					}
				}
				newGame.turnQueue.Enqueue(curr_character);
				Console.WriteLine("Press any key for next turn");
				Console.ReadKey();

			}
		}
	}
}
