using System.Collections.Generic;

namespace ObseverProject
{
    /// <summary>
    /// Class to portray a customer in this system
    /// </summary>
    public class Customer : IObserver<Product>
    {
        /// <summary>
        /// Customer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// List of product categories that we want to monitor for changes
        /// </summary>
        public List<Category> FavouriteCategories { get; set; }

        /// <summary>
        /// Our own implementation of the Update method
        /// </summary>
        /// <param name="observable">Passing in the product to capture the state of the product</param>
        public void Update(Product observable)
        {
            //Check if the product is in our category range
            if (FavouriteCategories.Contains(observable.Category))
            {
                //Send email to notify of change
                EmailHelper.SendEmail("example smtp", "example address from", "example address to", "example subject", "example body", new Credentials() { Username = "user", Password = "password" });
            }
        }
    }
}
