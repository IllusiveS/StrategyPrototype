public interface ICombat
{
	ICombat getInstance();

	void setUp(UCombat unity, IArmy atk, IArmy def);

	IArmy CalculateWinner();
	void BeginCombat(IArmy atk, IArmy def);
	void EndCombat();
}
