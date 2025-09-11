using Microsoft.AspNetCore.Identity;

namespace Travellin.Infrastructure.Data.Seeds
{
    static class IdentityUserRoleSeed
    {
        public static List<IdentityUserRole<string>> Data => new()
            {
                // Admin mapping
                new IdentityUserRole<string>
                {
                    UserId = "2dacdb51-fee9-4479-904c-cafe7dca22a6", // admin
                    RoleId = "d35a86a5-72b3-4e7e-bb7f-5ef782b36f7c"  // Admin role ID
                },

                // Host mapping
                new IdentityUserRole<string>
                {
                    UserId = "3dacdb51-fee9-4479-904c-cafe7dca22a7", // host
                    RoleId = "59ebef1f-d79b-4db0-9c5a-304836f14ff1"  // Host role ID
                },

                // Customer mappings - only the six specified IDs
                new IdentityUserRole<string>
                {
                    UserId = "4dacdb51-fee9-4479-904c-cafe7dca22a8",
                    RoleId = "9c75a5df-20a4-4ff1-85a5-bb52f9cf223f" // Customer role ID
                },
                new IdentityUserRole<string>
                {
                    UserId = "user-2222-3333-4444-5555bbbb",
                    RoleId = "9c75a5df-20a4-4ff1-85a5-bb52f9cf223f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user-3333-4444-5555-6666cccc",
                    RoleId = "9c75a5df-20a4-4ff1-85a5-bb52f9cf223f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user-4444-5555-6666-7777dddd",
                    RoleId = "9c75a5df-20a4-4ff1-85a5-bb52f9cf223f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user-5555-6666-7777-8888eeee",
                    RoleId = "9c75a5df-20a4-4ff1-85a5-bb52f9cf223f"
                },
                new IdentityUserRole<string>
                {
                    UserId = "user-7777-8888-9999-0000ffff",
                    RoleId = "9c75a5df-20a4-4ff1-85a5-bb52f9cf223f"
                }
            };
    }
}
