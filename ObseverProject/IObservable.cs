namespace ObseverProject
{
    /// <summary>
    /// Interface for the object to be observed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObservable<T>
    {
        /// <summary>
        /// Method for Subscribing to the observer
        /// </summary>
        /// <param name="observer">Passing in the observer</param>
        void Subscribe(params T[] newObservers);
        /// <summary>
        /// Method for Unsubscribing from the observer
        /// </summary>
        /// <param name="observer">Pass in the observer</param>
        void Unsubscribe(params T[] existingObservers);
        /// <summary>
        /// Method for notifying the observer about action taking place
        /// </summary>
        void Notify();
    }
}
