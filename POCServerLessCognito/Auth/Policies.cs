using Microsoft.AspNetCore.Authorization;

namespace POCServerLessCognito.Auth
{
    public static class Policies
    {
        public const string MakePayments = "MakePayments";
        public const string ViewPayments = "ViewPayments";
        //public const string CanAddDrinks = "CanAddDrinks";

        public static void Configure(AuthorizationOptions options)
        {
            // Code based policy: Calculations over Claims information
            options.AddPolicy(MakePayments, builder =>
            {
                builder.AddRequirements(new CognitoGroupAuthorizationRequirement(MakePayments));
            });

            options.AddPolicy(ViewPayments, policyBuilder =>
            {
                policyBuilder.AddRequirements(new CognitoGroupAuthorizationRequirement(ViewPayments));
            });

            // Policy with simple rules. Based in User claims information
            //options.AddPolicy(CanAddDrinks, policyBuilder =>
            //{
            //    policyBuilder.RequireRole("Admin", "Vendor");
            //});
        }
    }
}
