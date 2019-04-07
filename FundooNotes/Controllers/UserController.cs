// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooNotes.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.IO;
    using System.Net.Mail;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooNotes.Model;
    using Microsoft.AspNetCore.Http;
    using System.Net.Http.Headers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// user controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user manager
        /// </summary>
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// The sign in manager
        /// </summary>
        private readonly SignInManager<ApplicationUser> signInManager;

        /// <summary>
        /// The email sender
        /// </summary>
        private readonly IEmailSender emailSender;

        /// <summary>
        /// The distributed cache
        /// </summary>
        private readonly IDistributedCache distributedCache;

        /// <summary>
        /// The application settings
        /// </summary>
        private readonly AppSetting appSettings;

        private IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="emailSender">The email sender.</param>
        /// <param name="appSetting">The application setting.</param>
        /// <param name="distributedCache">The distributed cache.</param>
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, IOptions<AppSetting> appSetting, IDistributedCache distributedCache, IHostingEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.distributedCache = distributedCache;
            this.appSettings = appSetting.Value;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns message</returns>
        /// <exception cref="Exception">system exception</exception>
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.BadRequest(this.ModelState);
                }

                var user = new ApplicationUser()
                {
                    UserName = model.emailId,
                    FirstName = model.firstName,
                    LastName = model.lastName,
                    Email = model.emailId
                };

               var result = await this.userManager.CreateAsync(user, model.password);
                
                return this.Ok(result);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns message</returns>
        /// <exception cref="Exception">system exception</exception>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
            {
            try
            {
                var user = await this.userManager.FindByEmailAsync(model.Email);
                if (user != null && await this.userManager.CheckPasswordAsync(user, model.Password))
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                  {
                       new Claim("UserID", user.Id.ToString())
                  }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var cacheKey = model.Email;
                    var token = this.distributedCache.GetString(cacheKey);
                    token = tokenHandler.WriteToken(securityToken);
                    this.distributedCache.SetString(cacheKey, token);
                    return this.Ok(new { token });
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }          
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>returns message</returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            this.distributedCache.Remove("Token");
            return this.Ok();
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>returns the token</returns>
        [HttpPost]
        [Route("forgetpassword")]
        public async Task<bool> ForgetPassword(ForgetPasswordModel model)
        {       
                var user = await this.userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return false;
                }
                //// MailMessage class is present is System.Net.Mail namespace
                MailMessage mailMessage = new MailMessage("patlollaparameshwarreddy7@gmail.com", model.Email);
                Guid guid = Guid.NewGuid();
                //// StringBuilder class is present in System.Text namespace
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

        [HttpPost]
        [Route("profile")]
        public ImageUploadResult Upload(IFormFile Files)
        {
            var stream = Files.OpenReadStream();
            var name = Files.FileName;
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("dekmrle72", "699555858957497", "LJIgvOlD9bDG5XvT9fLkIco_sZg");

            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult;
        }
    }
}
