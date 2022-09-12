using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Ticketano.DAL.Models;
using Ticketano.Domain.Models;
using Ticketano.Domain.Models.Settings;

namespace Ticketano.BLL.Services;

public class AccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AccountService(UserManager<User> userManager,
        SignInManager<User> signInManager,
        JwtSettings jwtSettings
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings;
    }
    
    public async Task<TokenModel> SignIn(SignInModel user)
    {
        var ret = new TokenModel();
        var result = await this._signInManager.PasswordSignInAsync(user.Email.Trim(), user.Password, false, false);

        if (result.Succeeded)
        {
            var userDb = await this._userManager.FindByEmailAsync(user.Email.Trim());
            if (userDb.IsActive == null || userDb.IsActive.Value)
            {
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _jwtSettings.ValidIssuer,
                    audience: _jwtSettings.ValidAudience,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.IssuerSigningKey)), SecurityAlgorithms.HmacSha256),
                    claims: new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sid, userDb.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    },
                    expires: DateTime.UtcNow.AddMinutes(300)
                );

                ret.Jwt = new JwtSecurityTokenHandler().WriteToken(token);
                ret.Successed = true;
                ret.User = new UserModel()
                {
                    Id = userDb.Id,
                    Email = userDb.Email,
                    FirstName = userDb.FirstName,
                    LastName = userDb.LastName
                };
            }
        }
        return ret;
    }
    
    
    public async Task SignUp(SignUpModel account)
    {
        var user = new User()
        {
            Email = account.Email,
            UserName = account.Email,
            IsActive = true,
            FirstName = account.FirstName,
            LastName = account.LastName,
            LastActiveAt = DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, account.Password);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join(";", result.Errors));
        }
    }
}