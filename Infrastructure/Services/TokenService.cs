using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.SearchParams;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        IGenericRepo<Member> _memberRepo;
        IGenericRepo<MessInfo> _messRepo;

        public TokenService(IConfiguration config,
            IGenericRepo<MessInfo> messRepo,
            IGenericRepo<Member> memberRepo)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
            _memberRepo = memberRepo;
            _messRepo = messRepo;
        }

        public async Task<string> CreateTokenAsync(AppUser user)
        {
            var messId = 0;
            var messRole = "";
            var messName = "";

            var isVerified = user.PhoneNumberConfirmed ? "verified" : "notverified";
            var memberSpec = new MemberSingleSpec(new MemberSearchParams
            {
                UserId = user.Id
            });
            var existingMember = await _memberRepo.GetEntityWithSpec(memberSpec);
            if (existingMember != null)
            {
                messId = existingMember.MessId;
                messRole = existingMember.MessRole;
                var messSpec = new MessSingleSpec(messId);
                var existingMess = await _messRepo.GetEntityWithSpec(messSpec);
                if (existingMess != null)
                {
                    messName = existingMess.MessName;
                }
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("MessId", messId.ToString()),
                new Claim("isMobileVerified", isVerified),
                new Claim("messRole", messRole),
                new Claim("messName", messName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Token:Issuer"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}