namespace Kenku.Extensions
{
    public static class WithExtension
    {
        public static T? With<T>(this T? instance, Action<T> action)
        {
            if (instance != null)
            {
                action
                    ?.Invoke(instance);
            }
            return instance;
        }
    }
}