using System;
using System.Collections.Generic;
using System.Text;

namespace TurnBasedFight
{
	class Goblin : CharacterBase
	{
		public Goblin(string _name = "Goblin", int _HP = 100, int _DEF = 10, int _MP = 30, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = _name;
			onwSkill[SkillType.EnumBaseSkill] = GlobalSkillPool.RegisterSkill(SkillType.EnumBaseSkill);
			isAuto = true;
			isMoniter = true;
		}
	}
	class GoblinKing : CharacterBase
	{
		public GoblinKing(string _name = "Goblin King", int _HP = 300, int _DEF = 10, int _MP = 300, int _ATK = 10, int _DEX = 10)
			: base(_HP, _DEF, _MP, _ATK, _DEX)
		{
			name = _name;
			onwSkill[SkillType.EnumBaseSkill] = GlobalSkillPool.RegisterSkill(SkillType.EnumBaseSkill);
			onwSkill[SkillType.EnumArcaneMissile] = GlobalSkillPool.RegisterSkill(SkillType.EnumArcaneMissile);
			onwSkill[SkillType.EnumNormalHealth] = GlobalSkillPool.RegisterSkill(SkillType.EnumNormalHealth);
			onwSkill[SkillType.EnumCriticalHit] = GlobalSkillPool.RegisterSkill(SkillType.EnumCriticalHit);
			isAuto = true;
			isMoniter = true;
		}
	}
}
