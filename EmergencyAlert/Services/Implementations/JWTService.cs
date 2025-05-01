using EmergencyAlert.Core;
using EmergencyAlert.Models;
using EmergencyAlert.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmergencyAlert.Services.Implementations
{
    public class JWTService : IJWTService
    {
        public UserToken GetUserToken(User user)
        {
            //igive konpiguracia xd
            var jwtKey = "5d2ac3c352204e449d6a003e528ee3f4981d72151e3fc7ed4485e1297af56fd7063b5d0ef5bc61386948e97d1b4fec402a38fe04d1fa418e55930da1b72b33a44327464628834123ac0d069eec7acb130500d64538ca0a6a8d5ecafdfaa20d43bdf2c4c8be1a9e8195add8ecf2f8d43e153da285dd708f747e0e9314f6d6a450e44ec6940d1bdb78d0b32548a9b62f1badff07e1ec51552860d89689d0ee985e9a3cd4743aecb65982edf4b09e4410a9f0ed82badc57d2e05cba47cac2c2d4907bb7aa92ace7bf7718e549b658558fe643bc67b1c9975251120e56448268c95e1c241fee8d240295f116eeebb5fc9510b31ebb68177a50bd684dab6182b760d403b7f62e9099c3689223fa261bb9657f57ae79c2f5b23456b661fa97d8ddc465bd693fb024c9b27665b39b67d3f6270aaa2f63e0f986d2e1ef83a21d4a2d7be1846428e078d7fbc6ea87e42a8abe5f1651658e4cda667cc57a4bd7e64c92de9f1a40525c9438085bfa87bfd9fd9dfc1545e904d7fefbe083d736f3f9022816cf3465817883883375cd50e166e75a6bf286c230591b44bec82a8aba524301b699";
            var jwtIssuer = "chven";
            var jwtAuidience = "isini";
            var JwtDuration = 300; //wutebshia es dzma xd

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId , user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name , user.FirstName),
                new Claim(JwtRegisteredClaimNames.Name , user.LastName),
                new Claim(JwtRegisteredClaimNames.Email , user.Email),
                new Claim(ClaimTypes.Role , user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAuidience,
                expires: DateTime.Now.AddMinutes(JwtDuration),
                claims: Claims,
                signingCredentials: credentials

                );

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

        }
    }
}
