using System.Linq;
using SportsPro.DataLayer.SeedData;

namespace SportsPro.Models
{
    public class Check
    {
        public static string EmailExists(Repository<Customer> data, string email)
        {
            string msg = "";

            if (!string.IsNullOrEmpty(email))
            {
                var customer = data.Get(new QueryOptions<Customer>
                {
                    Where = c => c.Email.ToLower() == email.ToLower()
                });
                if (customer != null)
                {
                    msg = "Email address already in use";
                }
            }

            return msg;
        }
    }
}
