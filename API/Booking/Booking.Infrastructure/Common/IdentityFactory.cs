using Booking.Application.Common.Interfaces;
using Booking.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.Common
{
    public class IdentityFactory : IIdentityFactory
    {
        private readonly IServiceProvider _provider;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<User> _signInManager;

        public IdentityFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public UserManager<User> UserManager => _userManager ??= 
            _provider.GetRequiredService<UserManager<User>>();

        public RoleManager<IdentityRole> RoleManager => _roleManager ??= 
            _provider.GetRequiredService<RoleManager<IdentityRole>>();

        public SignInManager<User> SignInManager => _signInManager ??=
            _provider.GetRequiredService<SignInManager<User>>();
    }
}
