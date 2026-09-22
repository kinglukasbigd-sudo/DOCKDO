public class JavaStub
{
	public static readonly JavaStub Instance = new JavaStub();
	public void Call(string method, params object[] args) { }
	public T Call<T>(string method, params object[] args) { return default(T); }
}
