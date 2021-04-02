using System;
using System.Collections;
using System.Collections.Generic;

namespace TurnBasedFight
{
	class Stage
	{
		// character slot
		public List<CharacterBase> enemy;
		public List<CharacterBase> ourTeam;


		//stat cnt
		Stage(int ourTeamSize = 3, int enemyTeamSize = 1)
		{
			enemy = new List<CharacterBase>(enemyTeamSize);
			ourTeam = new List<CharacterBase>(ourTeamSize);

			InitalStage();
		}

		private void InitalStage()
		{
			//TODO: tmp add enemy and hero
			ourTeam.Add(GlobalHerosPool.GetHerosByIdx(0));
			ourTeam.Add(GlobalHerosPool.GetHerosByIdx(1));
			ourTeam.Add(GlobalHerosPool.GetHerosByIdx(2));

			//enemy.Add()
		}
	}
}
