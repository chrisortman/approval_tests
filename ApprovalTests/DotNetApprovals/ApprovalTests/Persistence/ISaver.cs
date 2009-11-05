namespace ApprovalTests.Persistence
{
	public interface ISaver<T>
	{
		T Save(T t);
	}
}
