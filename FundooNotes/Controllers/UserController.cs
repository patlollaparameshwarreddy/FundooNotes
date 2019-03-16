namespace FundooNotes.Controllers
{
    using System;
    using System.Text;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using FundooNotes.model;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Caching.Distributed;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IDistributedCache _distributedCache;
        private readonly AppSetting _appSettings;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
            IEmailSender emailSender,IOptions<AppSetting> appSetting,IDistributedCache distributedCache)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _distributedCache = distributedCache;
            _appSettings = appSetting.Value;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = new ApplicationUser()
                {
                    UserName = model.emailId,
                    firstName = model.firstName,
                    lastName = model.lastName,
                    Email = model.emailId
                };

               var result = await _userManager.CreateAsync(user, model.password);
                
                return Ok(result);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
            {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                  {
                       new Claim("UserID",user.Id.ToString())
                  }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var cacheKey = "Token";
                    var token = _distributedCache.GetString(cacheKey);
                    if (!string.IsNullOrEmpty(token))
                    {
                        return Ok(new { token });
                    }
                    token = tokenHandler.WriteToken(securityToken);
                    _distributedCache.SetString(cacheKey, token);
                    return Ok(new { token });

                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _distributedCache.Remove("Token");
            return Ok();
        }

        [HttpPost]
        [Route("forgetpassword")]
        public async Task<bool> ForgetPassword(ForgetPasswordModel model)
        {
        
                var user = await _userManager.FindByEmailAsync(model.email);
                if (user == null)
                {
                    return false;
                }
                // MailMessage class is present is System.Net.Mail namespace
                MailMessage mailMessage = new MailMessage("patlollaparameshwarreddy7@gmail.com", model.email);
                Guid guid = Guid.NewGuid();
                // StringBuilder class is present in System.Text namespace
                StringBuilder sbEmailBody = new StringBuilder();
                sbEmailBody.Append("Dear " + ",<br/><br/>");
                sbEmailBody.Append("Please click on the following link to reset your password");
                sbEmailBody.Append("<br/>");
                sbEmailBody.Append("http://localhost:4200/resetpassword?uid=" + guid.ToString());
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("<b>BridgeIt</b>");

                mailMessage.IsBodyHtml = true;

                mailMessage.Body = sbEmailBody.ToString();
                mailMessage.Subject = "Reset Your Password";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "patlollaparameshwarreddy7@gmail.com",
                    Password = "pchintu0"
                };

                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            return true;

        }

    }

}