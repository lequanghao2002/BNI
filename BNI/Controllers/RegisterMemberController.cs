using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using Newtonsoft.Json;
using BNI.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BNI.Controllers
{
    public class RegisterMemberController : Controller
    {
        BNIContext _context = new BNIContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form1(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return Json("Không tìm thấy token");
            }
            var user = DecodeToken(token);
            if (user == null)
            {
                return Json("Mã hóa token không thành công");
            }
            var userData = CheckUserData(user.Email);
            if (userData == null)
            {
                return  RedirectToAction("UserAlready", "RegisterMember");
            }
            var memberdata = CheckMember(userData.ID);  
            if (memberdata != null)
            {
                return RedirectToAction("MemberAlready", "RegisterMember");
            }
            ViewBag.Userid = userData.ID;
            ViewBag.Email = userData.Email;
            return RedirectToAction("Form", "RegisterMember", new { id = userData.ID,email = userData.Email});
        }
        public IActionResult UserAlready()
        {
            return View();
        }
        public IActionResult MemberAlready()
        {
            return View();
        }
        public IActionResult RegiterSucces()
        {
            return View();
        }
        public IActionResult Form(int id, string Email)
        {
            ViewBag.Email = Email;
            ViewBag.Userid = id;
            return View();
        }
        public class ValidationResult
        {
            public List<string> Errors { get; set; }
            public Member Member { get; set; }
        }
        [HttpPost]
       

        public IActionResult Create(MemberDTO member)
        {
            if (ModelState.IsValid)
            {
                var newMember = new Member
                {
                    Logo = member.Logo,
                    Avatar = member.Avatar,
                    LinkWeb = member.LinkWeb,
                    QrCode = member.QrCode,
                    Facebook = member.Facebook,
                    Youtube = member.Youtube,
                    Zalo = member.Zalo,
                    Description = member.Description,
                    Pronoun = member.Pronoun,
                    Fullname = member.Fullname,
                    Company = member.Company,
                    PaymentCompany = member.PaymentCompany,
                    PaymentName = member.PaymentName,
                    Introducer = member.Introducer,
                    TaxNumber = member.TaxNumber,
                    TaxAddress = member.TaxAddress,
                    BillingAddress = member.BillingAddress,
                    BillingCompany = member.BillingCompany,
                    BillingEmail = member.BillingEmail,
                    Invoicecommitment = member.Invoicecommitment,
                    Sex = member.Sex,
                    Language = member.Language,
                    PhoneNumber = member.PhoneNumber,
                    Email = member.Email,
                    Address1 = member.Address1,
                    Address2 = member.Address2,
                    City = member.City,
                    Provice = member.Provice,
                    Country = member.Country,
                    PostalCode = member.PostalCode,
                    UserId = member.UserId,
                    BusinessSector = member.BusinessSector,
                    Referrer1 = member.Referrer1,
                    Referrer2 = member.Referrer2,
                    Commitmentinformation = member.Commitmentinformation,
                    DurationOfParticipation = member.DurationOfParticipation,
                    AlternateMeetingPerson = member.AlternateMeetingPerson,
                    CoC = member.CoC,
                    Timeintheindustry = member.Timeintheindustry,
                    Timeofcompanyestablishment = member.Timeofcompanyestablishment,
                    FieldOfRegistration = member.FieldOfRegistration,
                    Meetingcommitment = member.Meetingcommitment,
                    Contribute = member.Contribute,
                    Guestreferrals = member.Guestreferrals,
                    ParticipationHistory = member.ParticipationHistory,
                    Nameofparticipation = member.Nameofparticipation,
                    Commercialorganizations = member.Commercialorganizations,
                    ViolationOfTheLaw = member.ViolationOfTheLaw,
                    RegulatoryCompliance = member.RegulatoryCompliance,
                    Profession_ID = member.Profession_ID

                };
                _context.Members.Add(newMember);
                _context.SaveChanges();
                return RedirectToAction("RegisterSucces", "RegisterMember");// Chuyển hướng sau khi tạo thành viên thành công
            }

            //Get the list of errors in the ModelState
            var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

            var validationResult = new ValidationResult
            {
                Errors = errors.ToList(),
            };

            return Json(validationResult); // Trả về cả danh sách lỗi và đối tượng Member
        }
       



        [HttpPost]
        public async Task<IActionResult> Register(string emailAddress, string captcha, string agreeCheckbox)
        {
            string htmlbody = @"<table bgcolor=""#F2F2F2"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""table-layout:fixed"" width=""100%"">
	<tbody>
		<tr>
			<td>
			<table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""590"">
				<tbody>
					<tr>
						<td>
						<table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#000000;text-align:center"" width=""100%"">
							<tbody>
								<tr>
									<td height=""0"" valign=""bottom""><img alt=""curved top shadow"" border=""0"" height=""18"" src=""https://ci3.googleusercontent.com/meips/ADKq_NaQzTMQ4Qb_rXH5mjDZ_Q5bhqXE_vYvHKxuV2BD1OsaBM_cB6kzmXVnRck42Gikia8v8YC5vlcxStgidHgR5_D-qx3cJbGcrClkMTruFcs=s0-d-e1-ft#http://na-ab24.marketo.com/rs/bni/images/curv-top-sdw.png"" style=""display:block"" title=""curved top shadow"" width=""589"" class=""CToWUd"" data-bit=""iit""></td>
								</tr>
							</tbody>
						</table>
						

						<table bgcolor=""#C8102E"" border=""0"" cellpadding=""1"" cellspacing=""0"" style=""background-color:#c8102e;border-bottom:0px solid #63666a"" width=""100%"">
							<tbody>
								<tr>
									<td style=""font-size:1px;border-collapse:collapse;margin:0;padding:0"" width=""40"">&nbsp;</td>
									<td height=""0"">
									<div id=""m_-3305786114787980295headerBP"">
									<p>&nbsp;</p>

									<p><img height=""93"" src=""https://ci3.googleusercontent.com/meips/ADKq_Na0iBJfpvGrB2Sk34vmHnNCL9Mpe0tdAplrOTy23eWhSHzFiXMCn4HMwZjfkLOMwd03GdDqagZmm8_dvTvI_2XeG-bqaxEwbzU8o4eyszS4Da6Eqb77Frfg8CjSqSu4CzjKqA=s0-d-e1-ft#https://www2.bni.com/rs/166-SUM-744/images/BNIconnect_logo_final_white-01.png"" style=""display:block;margin-left:auto;margin-right:auto"" width=""475"" class=""CToWUd"" data-bit=""iit""></p>

									<p>&nbsp;</p>
									</div>
									</td>
									<td style=""font-size:1px;border-collapse:collapse;margin:0;padding:0"" width=""40"">&nbsp;</td>
								</tr>
							</tbody>
						</table>
						

						<table bgcolor=""#FFFFFF"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#ffffff;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#5e5d5d"" width=""100%"">
							<tbody>
								<tr>
									<td colspan=""3"" height=""25"" style=""font-size:1px;border-collapse:collapse;margin:0;padding:0"">&nbsp;</td>
								</tr>
								<tr>
									<td style=""font-size:1px"" width=""40"">&nbsp;</td>
									<td style=""font-family:Arial,Helvetica,sans-serif;font-size:14px;color:#5e5d5d;line-height:20px"" valign=""top"">
									<div id=""m_-3305786114787980295content"">
									<table bgcolor=""#FFFFFF"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""407"" style=""font-style:normal;font-variant-ligatures:normal;font-variant-caps:normal;font-weight:400;letter-spacing:normal;text-align:start;text-indent:0px;text-transform:none;white-space:normal;word-spacing:0px;text-decoration-style:initial;text-decoration-color:initial;background-color:#ffffff;font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#5e5d5d"">
										<tbody>
											<tr>
												<td style=""font-family:Arial,Helvetica,sans-serif;font-size:14px;color:#5e5d5d;line-height:20px"" valign=""top"">
												<p>Cảm ơn bạn đã quan tâm về BNI. Vui lòng thực hiện một vài thao tác nhỏ để bắt đầu hành trình xây dựng mạng lưới mối quan hệ và phát triển kinh doanh.</p>
												<a href=""https://www.bniconnectglobal.com/web/open/tokenator?concept=CONNECT&amp;token="" width=""157"" class=""CToWUd"" data-bit=""iit""></a>

												<p><br>
												Nếu gặp trục trặc khi đăng ký, xin liên hệ với đội ngũ hỗ trợ tại&nbsp;<a href=""https://bniconnect.zendesk.com/hc/en-us/requests/new"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://bniconnect.zendesk.com/hc/en-us/requests/new&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw18I7CFljYo6sQvv0Oisd4P""><strong>ĐÂY</strong></a>! Hoặc sao chép và dán&nbsp;<a href=""https://localhost:7289/RegisterMember/Form1?token={TOKEN_PLACEHOLDER}"" target=""_blank"" data-saferedirecturl=""https://localhost:7289/RegisterMember/Form1?token={TOKEN_PLACEHOLDER}"";source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw2L8QM-McOdapIcSwtAqPqj""><strong>LIÊN KẾT NÀY</strong></a>&nbsp;vào trình duyệt web. Liên kết sẽ hết hạn trong vòng 6 ngày.</p>


                                                < p>Sau khi đăng ký thành công, hãy truy cập trực tiếp vào<span>&nbsp;</span><strong><a href=""http://www.bniconnect.com/"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://www.bniconnect.com/&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw0qOknQJ7PJzN-i0HAGIhHE"">www.bniconnect.com</a></strong></p>

												<p>&nbsp;</p>

												<p>Trân trọng,</p>

												<p>BNI Connect</p>
												</td>
											</tr>
										</tbody>
									</table>
									</div>  
									</td>
									<td style=""font-size:1px;border-collapse:collapse;margin:0;padding:0"" width=""40"">&nbsp;</td>
								</tr>
								<tr>
									<td colspan=""3"" height=""60"" style=""font-size:1px;border-collapse:collapse;margin:0;padding:0"">&nbsp;</td>
								</tr>
							</tbody>
						</table>
						

						<table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#000000;text-align:center"" width=""100%"">
							<tbody>
								<tr>
									<td height=""40"" valign=""top""><img alt=""curved bottom shadow"" border=""0"" height=""34"" src=""https://ci3.googleusercontent.com/meips/ADKq_Na7w3XRmDkTQlDLw13ZJ6oKDz87Hv9dhHunvG3_fCJacdND38EX2Qm2B-aV5jUdzO6c2zlpTeikI_IqeDXf4HkoQRtZcyNwiNW_os2JLpHD44o=s0-d-e1-ft#http://na-ab24.marketo.com/rs/bni/images/curv-bottom-sdw.png"" style=""display:block"" title=""curved bottom shadow"" width=""589"" class=""CToWUd"" data-bit=""iit""></td>
								</tr>
								<tr>
									<td style=""color:#5e5d5d"">
									<div id=""m_-3305786114787980295footerBP"">
									<div align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""background:rgba(200,201,199,0.30);width:100%;border-collapse:collapse;margin:0 auto"" width=""100%"">&nbsp;</div>

									<div align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""background:rgba(200,201,199,0.30);width:100%;border-collapse:collapse;margin:0 auto"" width=""100%"">&nbsp; &nbsp; &nbsp; &nbsp;</div>

									<div align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""background:rgba(200,201,199,0.30);width:100%;border-collapse:collapse;margin:0 auto"" width=""100%"">&nbsp;</div>

									<div align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""background:rgba(200,201,199,0.30);width:100%;border-collapse:collapse;margin:0 auto"" width=""100%"">&nbsp; &nbsp; &nbsp; &nbsp; <a href=""https://www.facebook.com/bnivietnam/"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://www.facebook.com/bnivietnam/&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw03CcmiYZayqAbovyp7oswk""><img alt=""SocialIcons_darkgrey-02.png"" height=""50"" src=""https://ci3.googleusercontent.com/meips/ADKq_NaujvNHvICmpnENPPB6zWf5AZvuPM6JseYpM45NB88W-sRHdEEuuV15QLcqw0AD7IO5HobTF2MZb4u9nCXg9xvaAZCGTedGQvHd8ahRivDzRvgjj_KL6JYu7jhh=s0-d-e1-ft#https://www2.bni.com/rs/166-SUM-744/images/SocialIcons_darkgrey-02.png"" width=""51"" class=""CToWUd"" data-bit=""iit""></a>&nbsp;&nbsp; <a href=""https://www.linkedin.com/company/bni"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://www.linkedin.com/company/bni&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw3Trx0KxR4Oh5oQwAkmtkzY""><img alt=""SocialIcons_darkgrey-01.png"" height=""50"" src=""https://ci3.googleusercontent.com/meips/ADKq_Na1CZpJpbnmOcoKmIzMcJfKUuTB4aBwc5Ti0YJr0btcJX9_rXRkE8DoMns8hDSRQL_OGBKTXg7kSKghvJXE9FleBK5-w3CUPqVm8232O8hJjbizoqZhBolCNO0r=s0-d-e1-ft#https://www2.bni.com/rs/166-SUM-744/images/SocialIcons_darkgrey-01.png"" width=""50"" class=""CToWUd"" data-bit=""iit""></a>&nbsp;&nbsp; <a href=""https://twitter.com/bni_official_pg"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://twitter.com/bni_official_pg&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw3iF4dtsRaXhx9r2jEfTnJR""><img alt=""SocialIcons_darkgrey-03.png"" height=""50"" src=""https://ci3.googleusercontent.com/meips/ADKq_NbOvDNDvSAWcJ9k7u8OMhEC_sySBnOdKjv2Ae7iSeSxSB8NLL4mAFf2XLF_Qs0bVF4gUDqdJhVvyqXEcDnCGQaeJXaedyAdsgk8gMr9e7sP2mQS6MOa42nEkn-N=s0-d-e1-ft#https://www2.bni.com/rs/166-SUM-744/images/SocialIcons_darkgrey-03.png"" width=""51"" class=""CToWUd"" data-bit=""iit""></a>&nbsp;&nbsp;&nbsp; <a href=""https://www.youtube.com/user/BNIVN"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=https://www.youtube.com/user/BNIVN&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw3A754KBFsO9UPdeFottBDD""><img alt=""SocialIcons_darkgrey-04.png"" height=""50"" src=""https://ci3.googleusercontent.com/meips/ADKq_NaRsfSoP4wehm9EhLBy0rTioH4DZXdW0guMNHd8xtDFEq805-ePQFIP4_oLUpIQgpxeQHjpnucr2OEXuld1utXUcL4k3qUJJSHTXu-RIAFV70sIz5StbyLALx3K=s0-d-e1-ft#https://www2.bni.com/rs/166-SUM-744/images/SocialIcons_darkgrey-04.png"" width=""51"" class=""CToWUd"" data-bit=""iit""></a>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;

									<p><span style=""font-weight:bold;font-size:12px;font-family:helvetica,arial,sans-serif;color:#5e5d5d"">Charlotte - Castlebar - Paris - Stadskanaal - Mumbai -<br>
									Mysore - Bangalore - Colombo - Singapore - Guangzhou</span></p>

									<p><span style=""color:#5e5d5d;font-family:helvetica,arial,sans-serif""><span style=""font-style:normal;font-variant-ligatures:normal;font-variant-caps:normal;font-weight:400;letter-spacing:normal;text-align:left;text-indent:0px;text-transform:none;white-space:normal;word-spacing:0px;float:none;display:inline!important"">© 2020&nbsp; BNI Global, LLC&nbsp;&nbsp;</span><a href=""http://bnitos.com/privacy.html"" style=""box-sizing:border-box;color:#5e5d5d;text-decoration:none;font-size:12px"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://bnitos.com/privacy.html&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw0jGId9QFVGdwzdT9cpB8ce"">Privacy Policy</a>&nbsp;&nbsp;<a href=""http://bnitos.com"" style=""box-sizing:border-box;color:#5e5d5d;text-decoration:none;font-size:12px"" target=""_blank"" data-saferedirecturl=""https://www.google.com/url?q=http://bnitos.com&amp;source=gmail&amp;ust=1713345356148000&amp;usg=AOvVaw0fRrevwu_tfuYlPgmOfwHD"">Terms of Use</a></span></p>

									<p>&nbsp;</p>

									<p>&nbsp;</p>
									</div>
									</div>
									</td>
								</tr>
								<tr>
									<td height=""30"" style=""font-size:1px;border-collapse:collapse;margin:0;padding:0"">&nbsp;</td>
								</tr>
							</tbody>
						</table>
						</td>
					</tr>
				</tbody>
			</table>
			</td>
		</tr>
	</tbody>
</table>";
            try
            {
                var user = new User
                {
                    Email = emailAddress
                };
                DateTime expirationTime = DateTime.Now.AddDays(6); 
                string tokenWithExpiration = GenerateTokenWithExpiration(user, expirationTime);
                var modifiedHtmlBody = htmlbody.Replace("{TOKEN_PLACEHOLDER}", tokenWithExpiration);
                var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("phu3365@gmail.com", "ykcy orhq ndwv gabw"),
                    EnableSsl = true
                };
                await smtpClient.SendMailAsync(
                    new MailMessage("Sys Admin <bni.notifications@bniconnectglobal.com>", emailAddress, "ĐĂNG KÝ TÀI KHOẢN BNI CONNECT", modifiedHtmlBody)
                    {
                        IsBodyHtml = true
                    });
                ViewBag.SuccessDisplay = "display: block;";
                ViewBag.ErrorDisplay = "display: none;";
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.SuccessDisplay = "display: none;";
                ViewBag.ErrorDisplay = "display: block;";
                ViewBag.ErrorMessage = "Có lỗi xảy ra trong quá trình gửi email. Vui lòng thử lại sau.";
                return View("Index");
            }

        }
        private User DecodeToken(string token)
        {
            var tokenParts = token.Split('-');
            if (tokenParts.Length < 2)
            {
                return null;
            }
            var userDataBytes = Convert.FromBase64String(tokenParts[1]); // Lấy phần Base64
            var userDataJson = Encoding.UTF8.GetString(userDataBytes);
            var user = JsonConvert.DeserializeObject<User>(userDataJson);

            return user;
        }

        private string GenerateToken(User user)
        {
            var userDataBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));
            var userDataBase64 = Convert.ToBase64String(userDataBytes);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var token = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray());
            var tokenWithData = $"{token}-{userDataBase64}";
            return tokenWithData;
        }
        private string GenerateTokenWithExpiration(User user, DateTime expirationTime)
        {
            string basicToken = GenerateToken(user);
            long expirationTimestamp = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds();
            string tokenWithExpiration = $"{basicToken}-{expirationTimestamp}";
            return tokenWithExpiration;
        }

        private User CheckUserData(string email)
        {
            using (var context = new BNIContext())
            {
                var userData = context.Users.FirstOrDefault(u => u.Email == email);
                return userData;
            }
        }
        private Member CheckMember(int UserID)
        {
            using (var context = new BNIContext())
            {
                var member = context.Members.FirstOrDefault(u => u.UserId == UserID);
                return member;
            }
        }
    }
}
