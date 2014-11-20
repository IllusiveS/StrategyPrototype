using System;
public class CombatStartPlayerGetter
{
	public static int getPlayer(sideEnum i)
	{
		if(i == sideEnum.Attacker)
		{
			return UCombat.getSingleton().Attackers.army.getPlayer();
		}

		return UCombat.getSingleton().Defenders.army.getPlayer();
	}
}

