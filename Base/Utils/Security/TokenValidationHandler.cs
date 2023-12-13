using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BufaloCargo.Utils.Security
{
    public class TokenValidationHandler
    {
        private readonly IConfiguration _configuration;

        public TokenValidationHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ClaimsPrincipal getprincipal(string token)
        {
            Models.Response rp = new Models.Response();
            HttpResponseMessage st = new HttpResponseMessage();
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            SecurityToken securityToken;
            try
            {
                //token = Decrypt(token);
                var secretKey = _configuration["JWT_SECRET_KEY"];
                var audienceToken = _configuration["JWT_AUDIENCE_TOKEN"];
                var issuerToken = _configuration["JWT_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));


                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                return tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            }
            catch (SecurityTokenValidationException ex)
            {
                return null;
            }
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

        public string GenerateToken(string login, string userid, List<string> roles, Guid? entidad_id)
        {
            // appsetting for Token JWT
            var secretKey = _configuration["JWT_SECRET_KEY"];
            var audienceToken = _configuration["JWT_AUDIENCE_TOKEN"];
            var issuerToken = _configuration["JWT_ISSUER_TOKEN"];
            var expireTime = _configuration["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.NameIdentifier, userid),
                new Claim(ClaimTypes.PrimaryGroupSid, entidad_id.ToString())
            });

            //recorremos la lista de roles que se envian, y se agrega un rol por cada uno
            if (roles != null)
            {
                foreach (var r in roles)
                {
                    Claim cc = new Claim(ClaimTypes.Role, r);
                    claimsIdentity.AddClaim(cc);
                }
            }

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            return jwtTokenString;
            //return Encrypt(jwtTokenString);
        }
        public static DateTime ConvertTimespan(uint timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp);
        }
        internal class TokenValidateHandler : DelegatingHandler
        {
            private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
            {
                token = null;
                IEnumerable<string> authzHeaders;
                if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
                {
                    return false;
                }
                var bearerToken = authzHeaders.ElementAt(0);
                //con esta linea se desencripta si es que colocamos el token encriptado con el MD
                //token = Decrypt(bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken);
                token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;

                return true;
            }

            //protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            //{
            //    Models.Response rp = new Models.Response();                

            //    string token;
            //    HttpResponseMessage st = new HttpResponseMessage();

            //    // determine whether a jwt exists or not
            //    if (!TryRetrieveToken(request, out token))
            //    {
            //        //Task<HttpResponseMessage> x = base.SendAsync(request, cancellationToken);
            //        return base.SendAsync(request, cancellationToken);
            //    }

            //    try
            //    {
            //        var secretKey = _configuration["JWT_SECRET_KEY"];
            //        var audienceToken = _configuration["JWT_AUDIENCE_TOKEN"];
            //        var issuerToken = _configuration["JWT_ISSUER_TOKEN"];
            //        var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            //        IdentityModelEventSource.ShowPII = true;

            //        SecurityToken securityToken;
            //        var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            //        TokenValidationParameters validationParameters = new TokenValidationParameters()
            //        {
            //            ValidAudience = audienceToken,
            //            ValidIssuer = issuerToken,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            LifetimeValidator = this.LifetimeValidator,
            //            IssuerSigningKey = securityKey
            //        };

            //        // Extract and assign Current Principal and user
            //        Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            //        HttpContext.Current.User = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

            //        return base.SendAsync(request, cancellationToken);
            //    }
            //    catch (SecurityTokenValidationException ex)
            //    {
            //        if (ex.ToString().Contains("Lifetime validation failed"))
            //        {
            //            LoginModel lm = new LoginModel();
            //            lm.token = token;
            //            aSecurity sg = new aSecurity();
            //            ClaimsPrincipal cp = getprincipalnotime(token);
            //            Guid usuario = Guid.Parse(cp.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault());
            //            sg.TimeLogOff(usuario);

            //            st.StatusCode = HttpStatusCode.Redirect;
            //            st.Headers.Add("Message", "Session Vencida");
            //            //autil.MensajeRetorno(ref rp, 1, string.Empty, null, HttpStatusCode.Redirect);
            //        }
            //        else
            //        {
            //            st.StatusCode = HttpStatusCode.Unauthorized;
            //            st.Headers.Add("Message", "Session no autorizada");
            //            //autil.MensajeRetorno(ref rp, 1, string.Empty, null, HttpStatusCode.Unauthorized);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        st.StatusCode = HttpStatusCode.InternalServerError;
            //        st.Headers.Add("Message", "Error General");
            //        //autil.MensajeRetorno(ref rp, 4, string.Empty, null, HttpStatusCode.InternalServerError);
            //    }

            //    return Task<HttpResponseMessage>.Factory.StartNew(() => st);
            //}

            public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
            {
                if (expires != null)
                {
                    if (DateTime.UtcNow < expires) return true;
                }
                return false;
            }

            //private ClaimsPrincipal getprincipalnotime(string token)
            //{
            //    var secretKey = _configuration["JWT_SECRET_KEY"];
            //    var audienceToken = _configuration["JWT_AUDIENCE_TOKEN"];
            //    var issuerToken = _configuration["JWT_ISSUER_TOKEN"];
            //    var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

            //    SecurityToken securityToken;
            //    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            //    TokenValidationParameters validationParameters = new TokenValidationParameters()
            //    {
            //        ValidAudience = audienceToken,
            //        ValidIssuer = issuerToken,
            //        ValidateLifetime = false,
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = securityKey
            //    };
            //    return tokenHandler.ValidateToken(token, validationParameters, out securityToken);

            //}
        }
    }
}
