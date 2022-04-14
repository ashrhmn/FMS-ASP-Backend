using JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using Newtonsoft.Json;

namespace Web_API.Auth
{
    public class JwtManage
    {
        private const string Secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public static string EncodeToken(AuthPayload payload)
        {
            JWT.Algorithms.IJwtAlgorithm algorithm = new JWT.Algorithms.HMACSHA256Algorithm();
            JWT.IJsonSerializer serializer = new JWT.Serializers.JsonNetSerializer();
            JWT.IBase64UrlEncoder urlEncoder = new JWT.JwtBase64UrlEncoder();
            JWT.IJwtEncoder encoder = new JWT.JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, Secret);
            return token;
        }

        public static string DecodeToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JWT.Serializers.JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                JWT.Algorithms.IJwtAlgorithm algorithm = new JWT.Algorithms.HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var json = decoder.Decode(token, Secret, verify: true);
                return json;
            }
            catch (JWT.Exceptions.TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                return null;
            }
            catch (JWT.Exceptions.SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                return null;
            }
            catch (Exception error)
            {
                Console.WriteLine("JWT Decode error : " + error.ToString());
                return null;
            }
        }
        public AuthPayload LoggedInUser(HttpCookieCollection cookies)
        {
            HttpCookie cookie = cookies["session"];
            if (cookie == null) return null;
            var token = cookie["token"];
            var decodedObject = DecodeToken(token);
            if (decodedObject == null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                cookies.Add(cookie);
                return null;
            }
            var result = JsonConvert.DeserializeObject<AuthPayload>(decodedObject);
            return result;
        }

        public static AuthPayload LoggedInUser(string token)
        {
            var decodedObject = DecodeToken(token);
            if (decodedObject == null) return null;
            var result = JsonConvert.DeserializeObject<AuthPayload>(decodedObject);
            return result;
        }

        public static AuthPayload LoggedInUser(HttpActionContext httpActionContext)
        {
            var token = httpActionContext.Request.Headers.Authorization;
            if (token == null) return null;
            return LoggedInUser(token.ToString());
        }

        public static void AuthorizeUser(HttpActionContext actionContext, string role)
        {
            var user = JwtManage.LoggedInUser(actionContext);
            if (user == null)
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Token");
                return;
            }

            if (user.Role == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Role is null");
                return;
            }
            if (user.Role.ToLower().Equals(role) || role.Equals("*")) return;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
        }
        public static void AuthorizeUser(HttpActionContext actionContext, List<string> roles)
        {
            var user = JwtManage.LoggedInUser(actionContext);
            if (user == null)
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Token");
                return;
            }
            if (roles.Contains(user.Role.ToLower()) || roles.Contains("*")) return;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
        }
    }
}