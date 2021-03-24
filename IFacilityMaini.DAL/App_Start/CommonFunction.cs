﻿using IFacilityMaini.DBModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using static IFacilityMaini.EntityModels.CommonEntity;
using System.Threading.Tasks;
using MailTracker = IFacilityMaini.EntityModels.CommonEntity.MailTracker;
using System.Net;
using IFacilityMaini.DAL.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using System.Globalization;

namespace IFacilityMaini.DAL.App_Start
{
    public class CommonFunction
    {
        public readonly IHostingEnvironment _hostingEnvironment;
        unitworksccsContext db = new unitworksccsContext();
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CommonFunction));

        /// <summary>
        /// Mail Sender 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int SendEmail(MailSender data, long mailTrackerId, string url)
        {
            try
            {
                //    //internally calling from database about from mail details
                //    var emailDetails = db.EmailMaster.Where(m => m.IsDeleted == false).OrderByDescending(m => m.EmailId).FirstOrDefault();
                //    SmtpClient smtp = new SmtpClient(emailDetails.Host);//smtp object creation for mail sending
                //    smtp.EnableSsl = Convert.ToBoolean(emailDetails.Ssl);
                //    smtp.UseDefaultCredentials = false;
                //    smtp.Port = (int)emailDetails.Port;
                //    string senderId = emailDetails.EmailId;
                //    string password = emailDetails.Password;
                //    smtp.Credentials = new System.Net.NetworkCredential(senderId, password);

                //    MailMessage mail = new MailMessage();
                //    mail.From = new MailAddress(senderId);
                //    //To Add To-Mail ID's
                //    //foreach (var eachmail in data.Torecipents)
                //    //{
                //    //    mail.To.Add(new MailAddress(eachmail.to));
                //    //}
                //    //foreach (var eachmail in data.CCrecipents)
                //    //{
                //    //    mail.CC.Add(new MailAddress(eachmail.cc));
                //    //}
                //    //foreach (var eachmail in data.Bccrecipents)
                //    //{
                //    //    mail.To.Add(new MailAddress(eachmail.bcc));
                //    //}


                //    mail.To.Add("suhas.cm@srkssolutions.com");

                //    mail.Subject = data.subject;
                //    mail.Body = data.emailContent;
                //    mail.IsBodyHtml = true;
                //    smtp.Send(mail);
            }
            catch (Exception e)
            {
                log.Error(e); if (e.InnerException != null) { log.Error(e.InnerException.ToString()); }
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Add Mail Tracker
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public long MailTracker(MailSender data, long userId)
        {
            long mailTrackerId = 0;
            try
            {
                MailTracker mail = new MailTracker();
                //var emailDetails = (from em in db.EmailMaster
                //                    join m in db.ModuleWiseEmailMaster on em.EmailMasterId equals m.EmailId
                //                    where m.IsDeleted == false && em.IsDeleted == false && m.ModuleWiseEmailMasterId == data.moduleWiseEmailMasterId
                //                    select em).FirstOrDefault();
                //List<string> toList = new List<string>();
                //foreach (var item in data.toRecipents)
                //{
                //    toList.Add(item.to);
                //}

                //if (emailDetails != null)
                //{
                //    #region mail Tracker intial assigment

                //    mail.to = string.Join(",", toList);
                //    mail.isExpiryExists = data.isExpiryExists;
                //    mail.emailContent = data.emailContent;
                //    mail.from = emailDetails.EmailId;
                //    var moduleWiseEmailMaster = db.ModuleWiseEmailMaster.Where(m => m.ModuleWiseEmailMasterId == data.moduleWiseEmailMasterId).FirstOrDefault();
                //    int? moduleId = Convert.ToInt32(moduleWiseEmailMaster.ModuleId);
                //    int? hours = moduleWiseEmailMaster.MailExpiryHours;
                //    mail.expiryHours = Convert.ToInt32(hours);
                //    mail.moduleId = Convert.ToInt32(moduleId);
                //    #endregion
                //}

                //#region add mail details to tracker
                //DBModels.MailTracker mailTracker = new DBModels.MailTracker();
                //mailTracker.MailModuleId = mail.moduleId;
                //mailTracker.MailSentByEmailId = mail.from;
                //mailTracker.MailSentToEmailId = mail.to;
                //mailTracker.MailDescription = mail.emailContent;
                //mailTracker.MailSentTime = DateTime.Now;
                //mailTracker.IsExpiryExists = mail.isExpiryExists;
                //if (mailTracker.IsExpiryExists == true)
                //{
                //    int hour = mail.expiryHours;
                //    DateTime expiryDate = DateTime.Now.AddHours(hour);
                //    mailTracker.ExpiryTime = expiryDate;
                //}
                //mailTracker.CreatedOn = DateTime.Now;
                //mailTracker.CreatedBy = null;
                //mailTracker.IsActive = true;
                //mailTracker.IsDeleted = false;
                //mailTracker.UserId = userId;
                //db.MailTracker.Add(mailTracker);
                //db.SaveChanges();
                //mailTrackerId = mailTracker.MailTrakerId;

            }
            catch (Exception ex)
            {

            }
            return mailTrackerId;
        }

        /// <summary>
        /// Skip Values
        /// </summary>
        /// <param name="skipCount"></param>
        /// <returns></returns>
        public SkipDetailsFunction SkipFunctionPagination(int skipCount, string url)
        {
            unitworksccsContext db = new unitworksccsContext();
            SkipDetailsFunction returnValue = new SkipDetailsFunction();
            try
            {
                // dynamic c = db.MasterValue.Where(mv => mv.MasterValueName == "pagination").FirstOrDefault().MasterValueInt;
                int skipValueLocal = 0;
                if (skipCount == 1)
                {
                    skipValueLocal = 0;
                }
                else
                {
                    skipValueLocal = (skipCount - 1) * 10;
                }
                returnValue.skipValue = skipValueLocal;
                returnValue.takeValue = 10;
            }
            catch (Exception e)
            {
                log.Error(e); if (e.InnerException != null) { log.Error(e.InnerException.ToString()); }
            }

            return returnValue;
        }

        /// <summary>
        /// Unique code genrator according to type of code
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string UniqueCodeGenerator(string type)
        {
            string code = "";
            Random random = new Random();
            switch (type)
            {
                case "company":
                    code = "SRKS_CMPNY_" + random.Next(0, 9999999).ToString();
                    break;
                case "vendor":
                    code = "SRKS_VEND_" + random.Next(0, 9999999).ToString();
                    break;
                case "employee":
                    code = "SRKS_EMP_" + random.Next(0, 9999999).ToString();
                    break;
                case "lead":
                    code = "SRKS_LEAD_" + random.Next(0, 9999999).ToString();
                    break;
                default: break;
            }
            return code;
        }

        /// <summary>
        /// Ordinal Number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string OrdinalNumber(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }

        /// <summary>
        /// Get Plant Id By Plant Code
        /// </summary>
        /// <param name="plantCode"></param>
        /// <returns></returns>
        public int GetPlantIdByPlantCode(string plantCode)
        {
            int plantId = 0;
            try
            {
                var data = db.UnitworkccsTblplant.Where(m => m.IsDeleted == 0 && m.PlantCode == plantCode).FirstOrDefault();
                if (data != null)
                {
                    plantId = data.PlantId;
                }
            }
            catch (Exception e)
            {
                log.Error(e); if (e.InnerException != null) { log.Error(e.InnerException.ToString()); }
            }
            return plantId;
        }

        /// <summary>
        /// Get Part Id By Material Code
        /// </summary>
        /// <param name="materialCode"></param>
        /// <returns></returns>
        public int GetPartIdByMaterialCode(string materialCode)
        {
            int partId = 0;
            try
            {
                var data = db.UnitworkccsTblparts.Where(m => m.IsDeleted == 0 && m.PartNo == materialCode).FirstOrDefault();
                if (data != null)
                {
                    partId = data.PartId;
                }
            }
            catch (Exception e)
            {
                log.Error(e); if (e.InnerException != null) { log.Error(e.InnerException.ToString()); }
            }
            return partId;
        }

        /// <summary>
        /// Get Current Shift
        /// </summary>
        /// <returns></returns>
        public string GetCurrentShift()
        {
            string shift = "";



            #region Get Shift
            DateTime Time = DateTime.Now;
            TimeSpan Tm = new TimeSpan(Time.Hour, Time.Minute, Time.Second);

            CommonFunction cf = new CommonFunction();
            string correctedDate = GetCorrectedDate();
            List<ShiftList> UnitworkccsTblshiftMstr = cf.ShiftList(correctedDate);

            var shiftDetaild = UnitworkccsTblshiftMstr.Where(m => m.shiftStartDateTime <= Time && m.shiftEndDateTime >= Time).FirstOrDefault();
            var shiftDetails = db.UnitworkccsTblshiftMstr.Where(m => m.ShiftId == shiftDetaild.shfitId).FirstOrDefault();

            if (shiftDetails != null)
            {
                shift = shiftDetails.ShiftName;
            }

            #endregion
            return shift;
        }

        /// <summary>
        /// Get Current Shift Id
        /// </summary>
        /// <param name="shiftName"></param>
        /// <returns></returns>
        public int GetCurrentShiftId(string shiftName)
        {
            int shiftId = 0;



            #region Get Shift Id

            var shiftDetaild = db.UnitworkccsTblshiftMstr.Where(m => m.ShiftName == shiftName).FirstOrDefault();

            if (shiftDetaild != null)
            {
                shiftId = shiftDetaild.ShiftId;
            }

            #endregion
            return shiftId;
        }

        /// <summary>
        /// GetCurrentDate
        /// </summary>
        /// <returns></returns>
        public string GetCorrectedDate()
        {
            #region Get Corrected Date
            string correctedDate = null;
            var StartTime = db.UnitworkccsTbldaytiming.Where(m => m.IsDeleted == 0).FirstOrDefault();
            TimeSpan End = StartTime.EndTime;
            TimeSpan EndTimeSpan = new TimeSpan(0, 0, 0);
            TimeSpan TimeSpanNow = DateTime.Now.TimeOfDay;
            if (TimeSpanNow >= EndTimeSpan && TimeSpanNow <= End)
            {
                correctedDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            else
            {
                correctedDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            #endregion
            return correctedDate;
        }

        /// <summary>
        /// GetCurrentShift
        /// </summary>
        /// <param name="correctedDate"></param>
        /// <returns></returns>
        public List<ShiftList> ShiftList(string correctedDate)
        {
            List<ShiftList> shiftLists = new List<ShiftList>();
            try
            {
                var shiftDetails = db.UnitworkccsTblshiftMstr.ToList();
                int i = 1;
                foreach (var item in shiftDetails)
                {
                    ShiftList shiftList = new ShiftList();
                    shiftList.shfitId = item.ShiftId;
                    shiftList.shiftName = item.ShiftName;

                    switch (i)
                    {
                        case 1:
                            string datee = DateTime.Now.Date.ToShortDateString();
                            string date1 = correctedDate + " " + item.StartTime;
                            string dateee = Convert.ToDateTime(correctedDate).ToShortDateString();
                            string date2 = dateee + " " + item.EndTime;
                            shiftList.shiftStartDateTime = Convert.ToDateTime(date1);
                            shiftList.shiftEndDateTime = Convert.ToDateTime(date2);
                            break;
                        case 2:
                            string datee1 = DateTime.Now.Date.ToShortDateString();
                            string date11 = correctedDate + " " + item.StartTime;
                            string dateee1 = Convert.ToDateTime(correctedDate).ToShortDateString();
                            string date21 = dateee1 + " " + item.EndTime;
                            shiftList.shiftStartDateTime = Convert.ToDateTime(date11);
                            shiftList.shiftEndDateTime = Convert.ToDateTime(date21);
                            break;
                        case 3:
                            string datee2 = DateTime.Now.Date.ToShortDateString();
                            string date12 = correctedDate + " " + item.StartTime;
                            string dateee2 = Convert.ToDateTime(correctedDate).Date.AddDays(1).ToShortDateString();
                            string date22 = dateee2 + " " + item.EndTime;
                            shiftList.shiftStartDateTime = Convert.ToDateTime(date12);
                            shiftList.shiftEndDateTime = Convert.ToDateTime(date22);
                            break;
                        default: break;
                    }

                    shiftLists.Add(shiftList);
                    i++;
                }
            }
            catch (Exception ex)
            {
            }

            return shiftLists;
        }

        /// <summary>
        /// Mode Name
        /// </summary>
        /// <param name="modeId"></param>
        /// <returns></returns>
        public Mode ModeName(int modeId)
        {
            Mode mode = new Mode();
            string modeName = "";
            string modeColor = "";
            try
            {
                switch (modeId)
                {
                    case 0:
                        modeColor = "YELLOW";
                        modeName = "IDLE";
                        break;
                    case 1:
                        modeColor = "GREEN";
                        modeName = "PROD";
                        break;
                    case 4:
                        modeColor = "BLUE";
                        modeName = "POWEROFF";
                        break;
                    case 2:
                        modeColor = "RED";
                        modeName = "BREAKDOWN";
                        break;
                    case 3:
                        modeColor = "RED";
                        modeName = "RESERVED";
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            { }

            mode.modeColor = modeColor;
            mode.modeName = modeName;
            return mode;
        }

        /// <summary>
        /// Log File
        /// </summary>
        /// <param name="Msg"></param>
        public void LogFile(string Msg)
        {
            string path1 = AppDomain.CurrentDomain.BaseDirectory;
            string appPath = @"G:\Temp\ModeResponse.txt";
            using (StreamWriter writer = new StreamWriter(appPath, true)) //true => Append Text
            {
                writer.WriteLine(System.DateTime.Now + ":  " + Msg);
            }
        }

        /// <summary>
        /// Get Week Number
        /// </summary>
        /// <returns></returns>
        public int GetWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        /// <summary>
        /// Get Mode Quarter
        /// </summary>
        /// <returns></returns>
        public int GetModeQuarter()
        {
            int monthNumber = 0, monthQuarter = 0;
            try
            {
                monthNumber = DateTime.Now.Month;
                if (monthNumber > 0 && monthNumber <= 4)
                {
                    monthQuarter = 1;
                }
                else if (monthNumber > 4 && monthNumber <= 8)
                {
                    monthQuarter = 2;
                }
                else if (monthNumber > 8 && monthNumber <= 12)
                {
                    monthQuarter = 3;
                }
            }
            catch (Exception ex)
            {

            }

            return monthQuarter;
        }

        /// <summary>
        /// Machine Id By Machine Name
        /// </summary>
        /// <param name="machineName"></param>
        /// <returns></returns>
        public int MachineIdByMachineName(string machineName)
        {
            int machineId = 0;
            try
            {
                var macDetails = db.UnitworkccsTblmachinedetails.Where(m => m.MachineName == machineName.Trim()).FirstOrDefault();
                if (macDetails != null)
                {
                    machineId = macDetails.MachineId;
                }
            }
            catch (Exception ex)
            {

            }

            return machineId;

        }

        /// <summary>
        /// Convert Milli seconds To Minutes
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public double ConvertMillisecondsToMinutes(double milliseconds)
        {
            try
            {
                return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Min To Integer
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int MinToInteger(string item)
        {
            int retItem = 0;
            try
            {
                string[] arry = item.Split(':');
                int min = Convert.ToInt32(arry[0]);
                int milliSec = Convert.ToInt32(arry[1]);

                milliSec = Convert.ToInt32(ConvertMillisecondsToMinutes(milliSec));

                retItem = min + milliSec;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return retItem;

        }

        ///// <summary>
        ///// SMS Send Common Function
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public CommonResponse SMSSend(SMSNotificationCustom data, long userId, AppSettings appSettings)
        //{
        //    CommonResponse response = new CommonResponse();
        //    //SMSRetriveDetails();
        //    try
        //    {
        //        StreamReader readStream;

        //        // to mobileNumber
        //        string mobileNumber = "&mobileNumber=" + data.mobileNumber;

        //        // message 
        //        string message = "&message=" + data.message;

        //        // sid
        //        string sid = "&sid=SMSCntry";

        //        // mtype message type
        //        string mtype = "&mtype=N";

        //        // delivery report
        //        string DR = "&DR=Y";

        //        string smsNotification = appSettings.SMSNotification;

        //        string finalURL = smsNotification + mobileNumber + message + sid + mtype + DR;

        //        HttpWebRequest objRequest1 = (HttpWebRequest)WebRequest.Create(finalURL);
        //        objRequest1.ContentType = "application /x-www-form-urlencoded";
        //        objRequest1.ContentType = @"application/text; charset=utf-8";
        //        objRequest1.Method = "GET";


        //        HttpWebResponse httpResponse = (HttpWebResponse)objRequest1.GetResponse();

        //        using (Stream stream = httpResponse.GetResponseStream())
        //        {
        //            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        //            String responseString = reader.ReadToEnd();
        //            response.response = responseString;
        //            response.isStatus = true;
        //            #region save api shoot id to db w.r.t to phone number 


        //            string[] smsResponse = responseString.Split(':');
        //            SmsTracker item = new SmsTracker();

        //            item.SmsResponse = smsResponse[1];
        //            item.SmsSentByUserId = userId;
        //            item.SmsSentTo = 0;
        //            item.SmsSentToPhoneNumber = data.mobileNumber;
        //            item.SmsMessage = data.message;
        //            item.IsDelivered = false;
        //            item.SmsSentDate = DateTime.Now;
        //            item.IsDeleted = false;
        //            item.IsActive = true;
        //            item.CreatedOn = DateTime.Now;
        //            item.CreatedBy = userId;
        //            db.SmsTracker.Add(item);
        //            db.SaveChanges();

        //            #endregion
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.isStatus = false;
        //    }
        //    return response;
        //}

    }
}