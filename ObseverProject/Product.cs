using System.Collections.Generic;
using System.Linq;

namespace ObseverProject
{
    /// <summary>
    /// Class to portray the product to be observed
    /// </summary>
    public class Product : IObservable<Customer>
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category of the product
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product discount which is to be observed as a property
        /// </summary>
        private decimal discount;
        public decimal Discount
        {
            get { return discount; }
            set
            {
                //Notifying about the discount becoming bigger than it was
                if (value > discount)
                {
                    Notify();
                }
                discount = value;
            }
        }

        //Clients acting as observers that need to be notified
        private readonly List<Customer> observers = new List<Customer>();

        /// <summary>
        /// Method for adding new observers to our observable 
        /// </summary>
        /// <param name="newObservers">List of new observers to be added</param>
        public void Subscribe(params Customer[] newObservers)
        {
            observers.AddRange(newObservers);
        }

        /// <summary>
        /// Method for unsubscribing (removing) existing subscribed observers
        /// </summary>
        /// <param name="existingObservers">List of existing observers to be removed</param>
        public void Unsubscribe(params Customer[] existingObservers)
        {
            observers.RemoveAll(existingObservers.Contains);
        }

        /// <summary>
        /// Method for notifying the observers about the discount change
        /// </summary>
        public void Notify()
        {
            observers.ForEach(observer => observer.Update(this));
        }

    }
}
