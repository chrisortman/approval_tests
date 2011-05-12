namespace SimpleLogger
{
	public interface ILoader<T>
	{
		T Load();
	}
}