namespace ApprovalTests.Persistence
{
	public interface ILoader<T>
	{
		T Load();
	}
}