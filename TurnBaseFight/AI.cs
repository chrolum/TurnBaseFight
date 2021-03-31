using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	static class AI
	{
		static Random r = new Random();
		static public int AutoAction(CharacterBase org, Game currGame)
		{
			if (!org.isAuto)
				return -1;

			ActionType at = (ActionType)r.Next(0, (int)ActionType.ActionEnd);

			// get random target
			CharacterBase rand_target = currGame.heros[r.Next(0, currGame.heros.Length)];
			CharacterBase[] rand_target_list = new CharacterBase[1];
			rand_target_list[0] = rand_target;

			//get random skill
			switch (at)
			{
				case ActionType.Attack:
					org.Attack(rand_target_list);
					break;
				case ActionType.Skill:
					var keyList = new List<SkillType>(org.onwSkill.Keys);
					org.UseSkill(keyList[r.Next(keyList.Count)], org, rand_target_list);
					break;
				default:
					org.UseSkill(SkillType.EnumBaseSkill, org, rand_target_list);
					break;
			}

			return 0;
		}
	}
}
