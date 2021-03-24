using IFacilityMaini.DAL.App_Start;
using IFacilityMaini.DAL.Helpers;
using IFacilityMaini.DAL.Resource;
using IFacilityMaini.DBModels;
using IFacilityMaini.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IFacilityMaini.EntityModels.CommonEntity;
using static IFacilityMaini.EntityModels.MainiAPIEntity;


namespace IFacilityMaini.DAL
{
    public class MainiAPIDAL : IMainiAPI
    {
        #region Intialazation
        /// <summary>
        /// DB connection through entity
        /// </summary>
        unitworksccsContext db = new unitworksccsContext();

        /// <summary>
        /// App Settings intialization
        /// </summary>
        private readonly AppSettings appSettings;

        /// <summary>
        /// log4net intialization
        /// </summary>
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainiAPIDAL));

        /// <summary>
        /// MainiAPIDAL constructor
        /// </summary>
        /// <param name="_db"></param>
        /// <param name="_appSettings"></param>
        public MainiAPIDAL(unitworksccsContext _db, IOptions<AppSettings> _appSettings)
        {
            db = _db;
            appSettings = _appSettings.Value;
        }
        #endregion
        #region API

        /// <summary>
        /// Push Alarm Data
        /// </summary>
        /// <param name="pushAlarmData">push Alarm Datas</param>
        /// <returns>API success/failure status and message</returns>
        //public CommonResponse PushAlarmData(PushAlarmCustomEntity pushAlarmData)
        //{
        //    CommonResponse obj = new CommonResponse();
        //    try
        //    {

        //        UnitworkccsAlarmHistoryMaster tblPriorityAlarmsObj = new UnitworkccsAlarmHistoryMaster();
        //        CommonFunction commonFunction = new CommonFunction();
        //        string shift = commonFunction.GetCurrentShift();
        //        string correctedDate = commonFunction.GetCorrectedDate();

        //        DateTime alaramDate = DateTime.Now;
        //        try
        //        {
        //            alaramDate = Convert.ToDateTime(pushAlarmData.timeStamp);
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        tblPriorityAlarmsObj.AlarmDate = alaramDate;
        //        tblPriorityAlarmsObj.AlarmTime = alaramDate.TimeOfDay;
        //        tblPriorityAlarmsObj.AlarmDateTime = alaramDate;
        //        tblPriorityAlarmsObj.InsertedOn = DateTime.Now;
        //        int machineId = commonFunction.MachineIdByMachineName(pushAlarmData.machineName);
        //        tblPriorityAlarmsObj.MachineId = machineId;
        //        tblPriorityAlarmsObj.Shift = shift;
        //        tblPriorityAlarmsObj.CorrectedDate = Convert.ToDateTime(correctedDate);

        //        foreach (var pushAlarmDatas in pushAlarmData.alarmData)
        //        {
        //            tblPriorityAlarmsObj.AlarmMessage = pushAlarmDatas.alarmMessage;
        //            tblPriorityAlarmsObj.Status = pushAlarmDatas.alarmMessage;
        //            tblPriorityAlarmsObj.AxisNo = pushAlarmDatas.axisNumber.ToString();
        //            tblPriorityAlarmsObj.AxisNum = pushAlarmDatas.axisNumber.ToString();
        //            tblPriorityAlarmsObj.AbsPos = pushAlarmDatas.absolutePosition.ToString();
        //            tblPriorityAlarmsObj.AlarmNo = pushAlarmDatas.alarmNumber.ToString();
        //            db.UnitworkccsAlarmHistoryMaster.Add(tblPriorityAlarmsObj);
        //            db.SaveChanges();
        //        }
        //        obj.response = ResourceResponse.PushAlarmDataInsert;
        //        obj.isStatus = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
        //        obj.response = ResourceResponse.ExceptionMessage;
        //        obj.isStatus = false;
        //    }
        //    return obj;
        //}

        public CommonResponse PushAlarmData(PushAlarmCustomEntity pushAlarmData)
        {
            CommonResponse obj = new CommonResponse();
            try
            {


                foreach (var pushAlarmDatas in pushAlarmData.alarmData)
                {


                    UnitworkccsAlarmHistoryMaster tblPriorityAlarmsObj = new UnitworkccsAlarmHistoryMaster();
                    CommonFunction commonFunction = new CommonFunction();
                    string shift = commonFunction.GetCurrentShift();
                    string correctedDate = commonFunction.GetCorrectedDate();

                    DateTime alaramDate = DateTime.Now;
                    try
                    {
                        alaramDate = Convert.ToDateTime(pushAlarmData.timeStamp);
                    }
                    catch (Exception ex)
                    {

                    }
                    tblPriorityAlarmsObj.AlarmDate = alaramDate;
                    tblPriorityAlarmsObj.AlarmTime = alaramDate.TimeOfDay;
                    tblPriorityAlarmsObj.AlarmDateTime = alaramDate;
                    tblPriorityAlarmsObj.InsertedOn = DateTime.Now;
                    int machineId = commonFunction.MachineIdByMachineName(pushAlarmData.machineName);
                    tblPriorityAlarmsObj.MachineId = machineId;
                    tblPriorityAlarmsObj.Shift = shift;
                    tblPriorityAlarmsObj.CorrectedDate = Convert.ToDateTime(correctedDate);


                    tblPriorityAlarmsObj.AlarmMessage = pushAlarmDatas.alarmMessage;
                    tblPriorityAlarmsObj.Status = pushAlarmDatas.alarmMessage;
                    tblPriorityAlarmsObj.AxisNo = pushAlarmDatas.axisNumber.ToString();
                    tblPriorityAlarmsObj.AxisNum = pushAlarmDatas.axisNumber.ToString();
                    tblPriorityAlarmsObj.AbsPos = pushAlarmDatas.absolutePosition.ToString();
                    tblPriorityAlarmsObj.AlarmNo = pushAlarmDatas.alarmNumber.ToString();
                    db.UnitworkccsAlarmHistoryMaster.Add(tblPriorityAlarmsObj);
                    db.SaveChanges();
                }
                obj.response = ResourceResponse.PushAlarmDataInsert;
                obj.isStatus = true;

            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }




        /// <summary>
        /// Push Machine Mode
        /// </summary>
        /// <param name="pushMachineModeData">push Machine Mode Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushMachineMode(PushMachineModeCustomEntity pushMachineModeData)
        {
            CommonResponse obj = new CommonResponse();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(pushMachineModeData);

            try
            {
                Mode mode = new Mode();
                CommonFunction commonFunction = new CommonFunction();
                //commonFunction.LogFile(json.ToString());
                string shift = commonFunction.GetCurrentShift();
                mode = commonFunction.ModeName(pushMachineModeData.machineMode);
                string correctedDate = commonFunction.GetCorrectedDate();
                int machineId = commonFunction.MachineIdByMachineName(pushMachineModeData.machineName);
                DateTime startTime = DateTime.Now;
                try
                {
                    startTime = Convert.ToDateTime(pushMachineModeData.timeStamp);
                }
                catch (Exception ex)
                {

                }

                #region Update in live mode table

                InsertingDataIntoModeTable(mode.modeName, machineId, mode.modeColor, correctedDate, shift);

                #endregion

                obj.response = ResourceResponse.PushMachineModeInsert;
                obj.isStatus = true;
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Inserting Data Into Mode Table
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="machineId"></param>
        /// <param name="color"></param>
        /// <param name="CorrectedDate"></param>
        /// <param name="Shift"></param>
        /// <returns></returns>
        public bool InsertingDataIntoModeTable(string mode, int machineId, string color, string CorrectedDate, string Shift)
        {
            bool tic = true;
            //Based on the machineid and correctedDate select the last(Latest) mode in mode table 
            // see if new mode is equal to last(latest) mode , if not insert.

            //Take last mode from today insert it now. or latest of modes from latest of previous days . Only if current mode is different from new mode.

            #region cheking the day for completion

            List<UnitworkccsTbllivemode> lastMode = new List<UnitworkccsTbllivemode>();
            UnitworkccsTbllivemode lastmodesinglerow = new UnitworkccsTbllivemode();


            lastMode = db.UnitworkccsTbllivemode.Where(m => m.MachineId == machineId && m.IsCompleted == 0).OrderByDescending(m => m.StartTime).ToList();


            if (lastMode != null && lastMode.Count == 1)
            {
                lastmodesinglerow = lastMode.OrderByDescending(m => m.ModeId).FirstOrDefault();

                if (lastmodesinglerow.MacMode != mode)
                {
                    try
                    {
                        //update endtime for last mode 
                        DateTime dt = DateTime.Now;
                        int lastmodeID = lastmodesinglerow.ModeId;
                        //get colorcode
                        if (lastmodeID != 0)
                        {
                            UnitworkccsTbllivemode tmprevious = new UnitworkccsTbllivemode();
                            DateTime CompletedModeET = DateTime.Now;

                            // getting the last completed endtime validete with the present start time
                            CompletedModeET = Convert.ToDateTime(db.UnitworkccsTbllivemode.Where(m => m.IsDeleted == 0 && m.IsCompleted == 1 && m.MachineId == machineId).OrderByDescending(m => m.ModeId).Select(m => m.EndTime).FirstOrDefault());
                            tmprevious = db.UnitworkccsTbllivemode.Find(lastmodeID);

                            DateTime PresentModeST = Convert.ToDateTime(tmprevious.StartTime);

                            if (PresentModeST == CompletedModeET)
                            {
                                string previousmode = tmprevious.MacMode;
                                if (mode != previousmode)
                                {
                                    UpdateModeRow(dt, lastmodeID, machineId, color, CorrectedDate);
                                    AddModeRow(CorrectedDate, dt, color, machineId, mode, Shift);
                                }
                            }
                            else
                            {
                                string previousmode = tmprevious.MacMode;
                                if (mode != previousmode)
                                {
                                    UpdateModeRow(dt, lastmodeID, machineId, color, CorrectedDate);
                                    AddModeRow(CorrectedDate, dt, color, machineId, mode, Shift);
                                }
                            }

                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            else if (lastMode.Count > 1)
            {
                //string getmodequery2 = "SELECT ModeId,StartTime,MacMode From [unitworksccs].[unitworkccs].[UnitworkccsTbllivemode] WHERE IsCompleted = 0 and MachineId = " + machineId + " and CorrectedDate<='" + CorrectedDate + "' order by ModeId";
                string getmodequery2 = "SELECT ModeId,StartTime,MacMode From unitworksccs.`unitworkccs.Tbllivemode` WHERE IsCompleted = 0 and MachineId = " + machineId + " and CorrectedDate<='" + CorrectedDate + "' order by ModeId";


                DataTable dtModeMultiple = new DataTable();

                using (ConnectionString mc = new ConnectionString())
                {
                    mc.Open(appSettings.ConnectionString);
                    SqlDataAdapter daMode1 = new SqlDataAdapter(getmodequery2, appSettings.ConnectionString.ToString());
                    daMode1.Fill(dtModeMultiple);
                    mc.Close(appSettings.ConnectionString);
                }
                using (ConnectionString mc = new ConnectionString())
                {
                    mc.Open(appSettings.ConnectionString);
                    for (int i = 0; i < (dtModeMultiple.Rows.Count - 1); i++)
                    {
                        string mode1 = dtModeMultiple.Rows[i][2].ToString();
                        string mode2 = dtModeMultiple.Rows[i + 1][2].ToString();
                        if (mode1 == mode2)
                        {
                            DataTable dtModeMultiple2 = new DataTable();

                            // SqlDataAdapter cmdpoweroff = new SqlDataAdapter("DELETE FROM [unitworksccs].[unitworkccs].[UnitworkccsTbllivemode] where ModeId = " + Convert.ToInt32(dtModeMultiple.Rows[i][0]), appSettings.ConnectionString.ToString());

                            SqlDataAdapter cmdpoweroff = new SqlDataAdapter("DELETE FROM unitworksccs.`unitworkccs.Tbllivemode` where ModeId = " + Convert.ToInt32(dtModeMultiple.Rows[i][0]), appSettings.ConnectionString.ToString());


                            cmdpoweroff.Fill(dtModeMultiple2);

                        }
                    }
                    mc.Close(appSettings.ConnectionString);
                }
            }
            else
            {
                DateTime dt = DateTime.Now;
                AddModeRow(CorrectedDate, dt, color, machineId, mode, Shift);
            }
            #endregion

            return tic;
        }

        /// <summary>
        /// Add Mode Row
        /// </summary>
        /// <param name="CorrectedDate"></param>
        /// <param name="dt"></param>
        /// <param name="color"></param>
        /// <param name="machineId"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int AddModeRow(string CorrectedDate, DateTime dt, string color, int machineId, string mode, string shift)
        {
            int Ret = 1;
            CommonFunction commonFunction = new CommonFunction();
            int shiftId = commonFunction.GetCurrentShiftId(shift);

            try
            {
                UnitworkccsTbllivemode tm = new UnitworkccsTbllivemode();
                tm.CorrectedDate = Convert.ToDateTime(CorrectedDate);
                tm.InsertedBy = 1;
                tm.InsertedOn = dt;
                tm.StartTime = dt;
                tm.ColorCode = color;
                tm.IsDeleted = 0;
                tm.IsCompleted = 0;
                tm.MachineId = machineId;
                tm.MacMode = mode;
                tm.ModeType = mode;
                tm.ModeTypeEnd = 0;
                tm.StartIdle = 0;
                tm.IsInserted = 0;
                tm.IsShiftEnd = shiftId;
                tm.Shift = shift;
                db.UnitworkccsTbllivemode.Add(tm);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

            return Ret;
        }

        /// <summary>
        /// Update Mode Row
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="lastmachineid"></param>
        /// <param name="machineId"></param>
        /// <param name="PresentColor"></param>
        /// <param name="correctedDate"></param>
        /// <returns></returns>
        public int UpdateModeRow(DateTime dt, int lastmachineid, int machineId, string PresentColor, string correctedDate)
        {
            int Ret = 1;

            try
            {
                UnitworkccsTbllivemode tmprevious = db.UnitworkccsTbllivemode.Where(m => m.ModeId == lastmachineid).FirstOrDefault();
                DateTime ModeStartTime = Convert.ToDateTime(tmprevious.StartTime);
                tmprevious.EndTime = dt;
                tmprevious.IsCompleted = 1;
                var duationinsec = dt.Subtract(Convert.ToDateTime(tmprevious.StartTime)).TotalSeconds;
                tmprevious.DurationInSec = Convert.ToInt32(duationinsec);
                tmprevious.ModeTypeEnd = 1;
                tmprevious.ModifiedOn = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

            return Ret;
        }

        /// <summary>
        /// Push Parameters
        /// </summary>
        /// <param name="pushParametersData">push Parameters Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushParameters(PushParametersCustomEntity pushParametersData)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                string shift = commonFunction.GetCurrentShift();
                int machineId = commonFunction.MachineIdByMachineName(pushParametersData.machineName);
                DateTime insertedTime = DateTime.Now;

                try
                {
                    insertedTime = Convert.ToDateTime(pushParametersData.timeStamp);
                    //insertedTime = insertedTime.AddHours(5).AddMinutes(30);
                }
                catch (Exception ex)
                {

                }

                UnitworkccsParametersMaster UnitworkccsParametersMaster = new UnitworkccsParametersMaster();
                int opTm = commonFunction.MinToInteger(pushParametersData.operatingTime);
                int poTm = commonFunction.MinToInteger(pushParametersData.powerOnTime);

                UnitworkccsParametersMaster.OperatingTime = opTm.ToString();
                UnitworkccsParametersMaster.PowerOnTime = poTm.ToString();
                UnitworkccsParametersMaster.PartsCount = pushParametersData.partsCount;
                UnitworkccsParametersMaster.InsertedOn = insertedTime;
                UnitworkccsParametersMaster.MachineId = machineId;
                UnitworkccsParametersMaster.Shift = commonFunction.GetCurrentShiftId(shift);
                string corrDate = commonFunction.GetCorrectedDate();
                UnitworkccsParametersMaster.CorrectedDate = Convert.ToDateTime(corrDate);
                UnitworkccsParametersMaster.PartsTotal = pushParametersData.partsTotal;
                UnitworkccsParametersMaster.CuttingTime = pushParametersData.cuttingTime;
                db.UnitworkccsParametersMaster.Add(UnitworkccsParametersMaster);
                db.SaveChanges();

                obj.response = ResourceResponse.PushParametersInsert;
                obj.isStatus = true;
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// push Axis Position Data
        /// </summary>
        /// <param name="pushAxisPositionData">push Axis Position Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushAxisPosition(PushAxisPositionCustomEntity pushAxisDatas)
        {
            CommonResponse obj = new CommonResponse();
            // var json = Newtonsoft.Json.JsonConvert.SerializeObject(pushAxisDatas);
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                //  commonFunction.LogFile(json.ToString());
                string shift = commonFunction.GetCurrentShift();
                int machineId = commonFunction.MachineIdByMachineName(pushAxisDatas.machineName);
                foreach (var pushAxisData in pushAxisDatas.axisPosition)
                {
                    UnitworkccsTblAxisdetails1 UnitworkccsTblAxisdetails1 = new UnitworkccsTblAxisdetails1();
                    UnitworkccsTblAxisdetails1.MachineId = machineId;
                    UnitworkccsTblAxisdetails1.Axis = pushAxisData.axisName;
                    UnitworkccsTblAxisdetails1.AbsPos = Convert.ToDecimal(pushAxisData.absolutePositionValue);
                    UnitworkccsTblAxisdetails1.RelPos = Convert.ToDecimal(pushAxisData.relativePositionValue);
                    UnitworkccsTblAxisdetails1.MacPos = Convert.ToDecimal(pushAxisData.machinePositionValue);
                    UnitworkccsTblAxisdetails1.DistPos = Convert.ToDecimal(pushAxisData.distanceToGoValue);
                    UnitworkccsTblAxisdetails1.StartTime = Convert.ToDateTime(pushAxisDatas.timeStamp);
                    UnitworkccsTblAxisdetails1.IsDeleted = 0;
                    UnitworkccsTblAxisdetails1.InsertedOn = DateTime.Now;
                    db.UnitworkccsTblAxisdetails1.Add(UnitworkccsTblAxisdetails1);
                    db.SaveChanges();
                }

                obj.response = ResourceResponse.PushAxisPositionInsert;
                obj.isStatus = true;

            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Push Axis Details
        /// </summary>
        /// <param name="pushAxisDetailsData">push Axis Details Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushAxisDetails(PushAxisDetailsCustomEntity pushAxisData)
        {
            CommonResponse obj = new CommonResponse();
            // var json = Newtonsoft.Json.JsonConvert.SerializeObject(pushAxisData);
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                //commonFunction.LogFile(json.ToString());
                string shift = commonFunction.GetCurrentShift();
                int machineId = commonFunction.MachineIdByMachineName(pushAxisData.machineName);

                UnitworkccsTblAxisdetails2 UnitworkccsTblAxisdetails2 = new UnitworkccsTblAxisdetails2();
                UnitworkccsTblAxisdetails2.MachineId = machineId;
                UnitworkccsTblAxisdetails2.StartTime = Convert.ToDateTime(pushAxisData.timeStamp);
                UnitworkccsTblAxisdetails2.FeedRate = Convert.ToDecimal(pushAxisData.feedRate);
                UnitworkccsTblAxisdetails2.SpindleLoad = Convert.ToDecimal(pushAxisData.spindleLoad);
                UnitworkccsTblAxisdetails2.SpindleSpeed = Convert.ToDecimal(pushAxisData.spindleSpeed);
                UnitworkccsTblAxisdetails2.FeedRatePercentage = Convert.ToDecimal(pushAxisData.feedOveridePercentage);
                UnitworkccsTblAxisdetails2.IsDeleted = 0;
                UnitworkccsTblAxisdetails2.InsertedOn = DateTime.Now;
                db.UnitworkccsTblAxisdetails2.Add(UnitworkccsTblAxisdetails2);
                db.SaveChanges();


                obj.response = ResourceResponse.PushAxisDetailsInsert;
                obj.isStatus = true;
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Push Program Execution Data
        /// </summary>
        /// <param name="pushProgramExecutionData">push Program Execution Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushProgramExecutionData(PushProgramExecutionDataCustomEntity pushProgramExecutionData)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                string shift = commonFunction.GetCurrentShift();
                int machineId = commonFunction.MachineIdByMachineName(pushProgramExecutionData.machineName);
                string correctedDate = commonFunction.GetCorrectedDate();
                if (pushProgramExecutionData.isProgramStart == true)
                {
                    UnitworkccsProgramExecutionMaster UnitworkccsProgramExecutionMaster = new UnitworkccsProgramExecutionMaster();
                    UnitworkccsProgramExecutionMaster.ProgramName = pushProgramExecutionData.programName;
                    UnitworkccsProgramExecutionMaster.CorrectedDate = Convert.ToDateTime(correctedDate);
                    UnitworkccsProgramExecutionMaster.MachineId = machineId;
                    UnitworkccsProgramExecutionMaster.ProgramExcutedDateTime = Convert.ToDateTime(pushProgramExecutionData.timeStamp);
                    UnitworkccsProgramExecutionMaster.ProgramStartDateTime = Convert.ToDateTime(pushProgramExecutionData.programStartOrEndDateTime);
                    UnitworkccsProgramExecutionMaster.IsDeleted = 0;
                    UnitworkccsProgramExecutionMaster.CreatedOn = DateTime.Now;
                    db.UnitworkccsProgramExecutionMaster.Add(UnitworkccsProgramExecutionMaster);
                    db.SaveChanges();
                    obj.response = ResourceResponse.PushProgramExecutionDataInsert;
                    obj.isStatus = true;
                }
                else
                {
                    DateTime correctedDateDF = Convert.ToDateTime(correctedDate);
                    var UnitworkccsProgramExecutionMaster = db.UnitworkccsProgramExecutionMaster.Where(m => m.MachineId == machineId && m.ProgramName == pushProgramExecutionData.programName && m.CorrectedDate == correctedDateDF).FirstOrDefault();
                    if (UnitworkccsProgramExecutionMaster != null)
                    {
                        UnitworkccsProgramExecutionMaster.ProgramEndDateTime = Convert.ToDateTime(pushProgramExecutionData.programStartOrEndDateTime);
                        UnitworkccsProgramExecutionMaster.ModifiedOn = DateTime.Now;
                        db.SaveChanges();
                        obj.response = ResourceResponse.PushProgramExecutionDataUpdate;
                        obj.isStatus = true;
                    }
                    else
                    {

                    }
                }



            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Push Parameter Sensor Data
        /// </summary>
        /// <param name="pushParameterSensorData">push Parameter Sensor Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushParameterSensorData(PushParameterSensorDataCustomEntity pushParameterSensorData)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                string shift = commonFunction.GetCurrentShift();
                int machineId = commonFunction.MachineIdByMachineName(pushParameterSensorData.machineName);
                string correctedDate = commonFunction.GetCorrectedDate();

                UnitworkccsParameterSendorData UnitworkccsParameterSendorData = new UnitworkccsParameterSendorData();
                UnitworkccsParameterSendorData.MachineId = machineId;
                UnitworkccsParameterSendorData.SensorDataCapturedTime = Convert.ToDateTime(pushParameterSensorData.timeStamp);
                UnitworkccsParameterSendorData.IsDeleted = 0;
                UnitworkccsParameterSendorData.CreatedOn = DateTime.Now;
                UnitworkccsParameterSendorData.CorrectedDate = Convert.ToDateTime(correctedDate);
                db.UnitworkccsParameterSendorData.Add(UnitworkccsParameterSendorData);
                db.SaveChanges();
                try
                {
                    foreach (var current in pushParameterSensorData.current)
                    {
                        UnitworkccsParameterSensorDataCurrent UnitworkccsParameterSensorDataCurrent = new UnitworkccsParameterSensorDataCurrent();
                        UnitworkccsParameterSensorDataCurrent.ParameterSensorDataId = UnitworkccsParameterSendorData.ParameterSensorDataId;
                        UnitworkccsParameterSensorDataCurrent.CurrentValue = Convert.ToDecimal(current);
                        db.UnitworkccsParameterSensorDataCurrent.Add(UnitworkccsParameterSensorDataCurrent);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                }
                try
                {
                    foreach (var pressure in pushParameterSensorData.pressure)
                    {
                        UnitworkccsParameterSensorDataPressure UnitworkccsParameterSensorDataPressure = new UnitworkccsParameterSensorDataPressure();
                        UnitworkccsParameterSensorDataPressure.ParameterSensorDataId = UnitworkccsParameterSendorData.ParameterSensorDataId;
                        UnitworkccsParameterSensorDataPressure.PressureValue = Convert.ToDecimal(pressure);
                        db.UnitworkccsParameterSensorDataPressure.Add(UnitworkccsParameterSensorDataPressure);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                }
                try
                {
                    foreach (var temperature in pushParameterSensorData.temperature)
                    {
                        UnitworkccsParameterSensorDataTemperature UnitworkccsParameterSensorDataTemperature = new UnitworkccsParameterSensorDataTemperature();
                        UnitworkccsParameterSensorDataTemperature.ParameterSensorDataId = UnitworkccsParameterSendorData.ParameterSensorDataId;
                        UnitworkccsParameterSensorDataTemperature.TemperatureValue = Convert.ToDecimal(temperature);
                        db.UnitworkccsParameterSensorDataTemperature.Add(UnitworkccsParameterSensorDataTemperature);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                }
                try
                {
                    foreach (var level in pushParameterSensorData.level)
                    {
                        UnitworkccsParameterSensorDataLevel UnitworkccsParameterSensorDataLevel = new UnitworkccsParameterSensorDataLevel();
                        UnitworkccsParameterSensorDataLevel.ParameterSensorDataId = UnitworkccsParameterSendorData.ParameterSensorDataId;
                        UnitworkccsParameterSensorDataLevel.LevelValue = Convert.ToDecimal(level);
                        db.UnitworkccsParameterSensorDataLevel.Add(UnitworkccsParameterSensorDataLevel);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                }


                obj.response = ResourceResponse.PushParameterSensorDataInsert;
                obj.isStatus = true;
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Push Parameter Tool Data
        /// </summary>
        /// <param name="pushParameterToolData">push Parameter Tool Data</param>
        /// <returns>API success/failure status and message</returns>
        public CommonResponse PushParameterToolData(PushParameterToolDataCustomEntity pushParameterToolData)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                string shift = commonFunction.GetCurrentShift();
                int machineId = commonFunction.MachineIdByMachineName(pushParameterToolData.machineName);
                string correctedDate = commonFunction.GetCorrectedDate();


                foreach (var tool in pushParameterToolData.tool)
                {

                    foreach (var toolGroup in tool.toolGroup)
                    {
                        UnitworkccsParameterToolData parameterToolData = new UnitworkccsParameterToolData();
                        parameterToolData.MachineId = machineId;
                        parameterToolData.CorrectedDate = Convert.ToDateTime(correctedDate);
                        parameterToolData.ToolGroupName = tool.toolGroupName;
                        parameterToolData.ParameterToolDataCapturedDate = Convert.ToDateTime(pushParameterToolData.timeStamp);
                        parameterToolData.ToolNumber = toolGroup.toolNumber;
                        parameterToolData.Capacity = toolGroup.capacity;
                        parameterToolData.Partsproduced = toolGroup.partsProduced;
                        db.UnitworkccsParameterToolData.Add(parameterToolData);
                        db.SaveChanges();
                    }
                }


                obj.response = ResourceResponse.PushParameterToolDataInsert;
                obj.isStatus = true;
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// AddMachineConfig
        /// </summary>
        /// <param name="machineConfigPost"></param>
        /// <returns></returns>
        public CommonResponseWithId AddMachineConfig(MachineConfigPost machineConfigPost)
        {
            CommonResponseWithId obj = new CommonResponseWithId();
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                string shift = commonFunction.GetCurrentShift();

                string correctedDate = commonFunction.GetCorrectedDate();
                var machineData = db.UnitworkccsTblmachinedetails.Where(m => m.IsDeleted == 0 && m.MachineName == machineConfigPost.machineName && m.Ipaddress == machineConfigPost.machineIp).FirstOrDefault();

                if (machineData == null)
                {
                    UnitworkccsTblmachinedetails machineDetailsWimerasys = new UnitworkccsTblmachinedetails();
                    machineDetailsWimerasys.MachineName = machineConfigPost.machineName;
                    machineDetailsWimerasys.TransmissionFrequency = machineConfigPost.transmissionFrequency;
                    machineDetailsWimerasys.LoggerType = machineConfigPost.loggerType;
                    machineDetailsWimerasys.Ipaddress = machineConfigPost.machineIp;
                    machineDetailsWimerasys.MachinePort = machineConfigPost.machinePort;
                    machineDetailsWimerasys.NumOfAxis = machineConfigPost.numOfAxis;
                    machineDetailsWimerasys.ToolGroupNum = machineConfigPost.toolGroupNum;
                    machineDetailsWimerasys.NumberOfCurrent = machineConfigPost.numberOfCurrent;
                    machineDetailsWimerasys.NumberOfTemperature = machineConfigPost.numberOfTemperature;
                    machineDetailsWimerasys.NumberOfPresure = machineConfigPost.numberOfPresure;
                    machineDetailsWimerasys.NumberOfLevel = machineConfigPost.numberOfLevel;
                    machineDetailsWimerasys.IsDeleted = 0;
                    machineDetailsWimerasys.InsertedOn = DateTime.Now.ToString();
                    machineDetailsWimerasys.CreatedOn = DateTime.Now;
                    machineDetailsWimerasys.IsWimerasys = 1;
                    db.UnitworkccsTblmachinedetails.Add(machineDetailsWimerasys);
                    db.SaveChanges();
                    obj.response = ResourceResponse.MachineConfigInsert;
                    obj.isStatus = true;
                    obj.machineIdPK = machineDetailsWimerasys.MachineId;
                }
                else
                {
                    obj.response = ResourceResponse.MachineConfigInsertFail;
                    obj.isStatus = false;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// AddMachineConfig
        /// </summary>
        /// <param name="machineConfigPost"></param>
        /// <returns></returns>
        public CommonResponse UpdateMachineConfig(MachineConfigPut machineConfigPost)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                CommonFunction commonFunction = new CommonFunction();
                string shift = commonFunction.GetCurrentShift();

                string correctedDate = commonFunction.GetCorrectedDate();
                var machineDetailsWimerasys = db.UnitworkccsTblmachinedetails.Where(m => m.MachineId == machineConfigPost.machineIdPK).FirstOrDefault();

                if (machineDetailsWimerasys != null)
                {
                    machineDetailsWimerasys.MachineName = machineConfigPost.machineName;
                    machineDetailsWimerasys.TransmissionFrequency = machineConfigPost.transmissionFrequency;
                    machineDetailsWimerasys.LoggerType = machineConfigPost.loggerType;
                    machineDetailsWimerasys.Ipaddress = machineConfigPost.machineIp;
                    machineDetailsWimerasys.MachinePort = machineConfigPost.machinePort;
                    machineDetailsWimerasys.NumOfAxis = machineConfigPost.numOfAxis;
                    machineDetailsWimerasys.ToolGroupNum = machineConfigPost.toolGroupNum;
                    machineDetailsWimerasys.NumberOfCurrent = machineConfigPost.numberOfCurrent;
                    machineDetailsWimerasys.NumberOfTemperature = machineConfigPost.numberOfTemperature;
                    machineDetailsWimerasys.NumberOfPresure = machineConfigPost.numberOfPresure;
                    machineDetailsWimerasys.NumberOfLevel = machineConfigPost.numberOfLevel;
                    machineDetailsWimerasys.IsDeleted = 0;
                    machineDetailsWimerasys.CreatedOn = DateTime.Now;
                    db.SaveChanges();
                    obj.response = ResourceResponse.MachineConfigUpdate;
                    obj.isStatus = true;
                }
                else
                {
                    obj.response = ResourceResponse.MachineConfigUpdateFailure;
                    obj.isStatus = true;
                }

            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }
        #endregion

        #region Anjali APIs

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public CommonResponse Login(string userName, string password)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTbloperatordetails
                             where wf.UserName == userName && wf.Password == password
                             select new
                             {
                                 operatorName = wf.OperatorName,
                                 operatorId = wf.OpId,
                                 roleId = wf.RoleId
                             }).FirstOrDefault();
                if (check != null)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "Not Authorized User";
                }

            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Plants
        /// </summary>
        /// <returns></returns>
        public CommonResponse GetPlants()
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblplant
                             where wf.IsDeleted == 0
                             select new
                             {
                                 plantId = wf.PlantId,
                                 plantName = wf.PlantName,
                                 plantDescription = wf.PlantDesc,
                                 plantCode = wf.PlantCode,
                             }).ToList();

                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Fg Part Number
        /// </summary>
        /// <returns></returns>
        public CommonResponse GetFgPartNumber(int plantId)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblfgandcellallocation
                             where wf.IsDeleted == 0 && wf.PlantId == plantId
                             select new
                             {
                                 plantId = wf.PlantId,
                                 fgPartNumber = db.UnitworkccsTblparts.Where(m => m.PartNo == wf.PartNo).Select(m => m.Fgcode).FirstOrDefault(),
                                 fgPartId = wf.FgAndCellAllocationId,
                                 plantCode = db.UnitworkccsTblplant.Where(m => m.PlantId == wf.PlantId).Select(m => m.PlantCode).FirstOrDefault()
                             }).ToList();

                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Child Part Number
        /// </summary>
        /// <param name="fgpartId"></param>
        /// <returns></returns>
        public CommonResponse GetChildPartNumber(int fgPartId)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblchildfgpartno
                             where wf.IsDeleted == 0 /*&& wf.FgPartId == fgPartId*/
                             select new
                             {
                                 // fgPartId = wf.FgPartId,
                                 childFgpartId = wf.ChildFgpartId,
                                 childFgPartNo = wf.ChildFgPartNo,
                                 childPartNoDesc = wf.ChildPartNoDesc,
                                 plantId = db.UnitworkccsTblplant.Where(m => m.PlantId == wf.PlantId).Select(m => m.PlantCode).FirstOrDefault()
                             }).ToList();

                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Routing No
        /// </summary>
        /// <param name="fgPartId"></param>
        /// <param name="childFgPartId"></param>
        /// <returns></returns>
        public CommonResponse GetRoutingNo(int fgPartId, int childFgPartId)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblroutingno
                             where wf.ChildFgPartId == childFgPartId && wf.FgPartId == fgPartId
                             select new
                             {
                                 routingNumber = wf.RoutingNo,
                                 routingId = wf.Id,
                                 plantId = wf.PlantId
                             }).ToList();
                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Dir Entry
        /// </summary>
        /// <returns></returns>
        public CommonResponse GetDirEntry(DirInfo data)
        {
            CommonResponse obj = new CommonResponse();
            CommonFunction commonFunction = new CommonFunction();
            string shift = commonFunction.GetCurrentShift();
            string correctedDate = commonFunction.GetCorrectedDate();
            List<RejectionReworkDet> RejectionReworkDetList = new List<RejectionReworkDet>();

            try
            {
                var rejection = db.UnitworkccsTblrejectiondetails.Where(m => m.MachineId == data.machineId && m.CorrectedDate == correctedDate && m.Shift == shift).ToList();

                foreach (var item in rejection)
                {
                    RejectionReworkDet rejectionReworkDet = new RejectionReworkDet();
                    rejectionReworkDet.plantId = data.plantId;
                    rejectionReworkDet.plantName = db.UnitworkccsTblplant.Where(m => m.PlantId == data.plantId).Select(m => m.PlantName).FirstOrDefault();
                    rejectionReworkDet.cellId = data.cellId;
                    rejectionReworkDet.cellName = db.UnitworkccsTblcellfinalmaster.Where(m => m.CellFinalId == data.cellId).Select(m => m.CellFinalName).FirstOrDefault();
                    rejectionReworkDet.subCellId = data.subCellId;
                    rejectionReworkDet.subCellName = db.UnitworkccsTblsubcellfinalmaster.Where(m => m.SubCellFinalId == data.subCellId).Select(m => m.SubCellFinalName).FirstOrDefault();
                    rejectionReworkDet.machineId = data.machineId;
                    rejectionReworkDet.machineName = db.UnitworkccsTblmachinedetails.Where(m => m.MachineId == data.machineId).Select(m => m.MachineName).FirstOrDefault();
                    rejectionReworkDet.partId = db.UnitworkccsTblfgpartnodet.Where(m => m.FgPartId == item.FgPartId).Select(m => m.PartId).FirstOrDefault();
                    rejectionReworkDet.partNo = db.UnitworkccsTblparts.Where(m => m.PartId == rejectionReworkDet.partId).Select(m => m.Fgcode).FirstOrDefault();
                    rejectionReworkDet.partDesc = db.UnitworkccsTblparts.Where(m => m.PartId == rejectionReworkDet.partId).Select(m => m.PartName).FirstOrDefault();
                    rejectionReworkDet.workOrderNo = db.UnitworkccsTblfgpartnodet.Where(m => m.FgPartId == item.FgPartId).Select(m => m.WorkOrderNo).FirstOrDefault();
                    rejectionReworkDet.operatorId = item.OperatorId;
                    rejectionReworkDet.operatorName = db.UnitworkccsTbloperatordetails.Where(m => m.OpId == item.OperatorId).Select(m => m.OperatorName).FirstOrDefault();
                    DateTime createdOn = Convert.ToDateTime(item.CreatedOn);
                    rejectionReworkDet.date = createdOn.ToString("yyyy-MM-dd HH:mm:ss");
                    rejectionReworkDet.shift = item.Shift;
                    rejectionReworkDet.quantity = item.DefectQty;
                    rejectionReworkDet.defectCodeId = item.DefectCodeId;
                    rejectionReworkDet.defectCode = db.UnitworkccsTbldefectcodemaster.Where(m => m.DefectCodeId == rejectionReworkDet.defectCodeId).Select(m => m.DefectCodeName).FirstOrDefault();
                    rejectionReworkDet.defectCodeDesc = db.UnitworkccsTbldefectcodemaster.Where(m => m.DefectCodeId == rejectionReworkDet.defectCodeId).Select(m => m.DefectCodeDesc).FirstOrDefault();
                    rejectionReworkDet.isRejectionOrRework = "Rejection";
                    RejectionReworkDetList.Add(rejectionReworkDet);
                }

                var rework = db.UnitworkccsTblreworkdetails.Where(m => m.MachineId == data.machineId && m.CorrectedDate == correctedDate && m.Shift == shift).ToList();

                foreach (var items in rework)
                {
                    RejectionReworkDet rejectionReworkDet1 = new RejectionReworkDet();
                    rejectionReworkDet1.plantId = data.plantId;
                    rejectionReworkDet1.plantName = db.UnitworkccsTblplant.Where(m => m.PlantId == data.plantId).Select(m => m.PlantName).FirstOrDefault();
                    rejectionReworkDet1.cellId = data.cellId;
                    rejectionReworkDet1.cellName = db.UnitworkccsTblcellfinalmaster.Where(m => m.CellFinalId == data.cellId).Select(m => m.CellFinalName).FirstOrDefault();
                    rejectionReworkDet1.subCellId = data.subCellId;
                    rejectionReworkDet1.subCellName = db.UnitworkccsTblsubcellfinalmaster.Where(m => m.SubCellFinalId == data.subCellId).Select(m => m.SubCellFinalName).FirstOrDefault();
                    rejectionReworkDet1.machineId = data.machineId;
                    rejectionReworkDet1.machineName = db.UnitworkccsTblmachinedetails.Where(m => m.MachineId == data.machineId).Select(m => m.MachineName).FirstOrDefault();
                    rejectionReworkDet1.partId = db.UnitworkccsTblfgpartnodet.Where(m => m.FgPartId == items.FgPartId).Select(m => m.PartId).FirstOrDefault();
                    rejectionReworkDet1.partNo = db.UnitworkccsTblparts.Where(m => m.PartId == rejectionReworkDet1.partId).Select(m => m.Fgcode).FirstOrDefault();
                    rejectionReworkDet1.partDesc = db.UnitworkccsTblparts.Where(m => m.PartId == rejectionReworkDet1.partId).Select(m => m.PartName).FirstOrDefault();
                    rejectionReworkDet1.workOrderNo = db.UnitworkccsTblfgpartnodet.Where(m => m.FgPartId == items.FgPartId).Select(m => m.WorkOrderNo).FirstOrDefault();
                    rejectionReworkDet1.operatorId = items.OperatorId;
                    rejectionReworkDet1.operatorName = db.UnitworkccsTbloperatordetails.Where(m => m.OpId == items.OperatorId).Select(m => m.OperatorName).FirstOrDefault();
                    DateTime createdOn = Convert.ToDateTime(items.CreatedOn);
                    rejectionReworkDet1.date = createdOn.ToString("yyyy-MM-dd HH:mm:ss");
                    rejectionReworkDet1.shift = items.Shift;
                    rejectionReworkDet1.quantity = items.DefectQty;
                    rejectionReworkDet1.defectCodeId = items.DefectCodeId;
                    rejectionReworkDet1.defectCode = db.UnitworkccsTbldefectcodemaster.Where(m => m.DefectCodeId == rejectionReworkDet1.defectCodeId).Select(m => m.DefectCodeName).FirstOrDefault();
                    rejectionReworkDet1.defectCodeDesc = db.UnitworkccsTbldefectcodemaster.Where(m => m.DefectCodeId == rejectionReworkDet1.defectCodeId).Select(m => m.DefectCodeDesc).FirstOrDefault();
                    rejectionReworkDet1.isRejectionOrRework = "Rework";
                    RejectionReworkDetList.Add(rejectionReworkDet1);
                }
                obj.isStatus = true;
                obj.response = RejectionReworkDetList;
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Cells
        /// </summary>
        /// <param name="plantId"></param>
        /// <returns></returns>
        public CommonResponse GetCells(int plantId)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblcellfinalmaster
                             where wf.IsDeleted == 0 && wf.PlantId == plantId
                             select new
                             {
                                 cellFinalId = wf.CellFinalId,
                                 cellFinalName = wf.CellFinalName,
                                 cellFinalDesc = wf.CellFinalDesc
                             }).ToList();

                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Cells
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public CommonResponse GetSubCells(int cellFinalId)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblsubcellfinalmaster
                             where wf.IsDeleted == 0 && wf.CellFinalId == cellFinalId
                             select new
                             {
                                 subCellFinalId = wf.SubCellFinalId,
                                 subCellFinalName = wf.SubCellFinalName,
                                 subCellFinalDesc = wf.SubCellFinalDesc
                             }).ToList();

                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }

        /// <summary>
        /// Get Machines
        /// </summary>
        /// <param name="subCellFinalId"></param>
        /// <returns></returns>
        public CommonResponse GetMachines(int subCellFinalId)
        {
            CommonResponse obj = new CommonResponse();
            try
            {
                var check = (from wf in db.UnitworkccsTblmachinedetails
                             where wf.IsDeleted == 0 && wf.CellId == subCellFinalId
                             select new
                             {
                                 machineId = wf.MachineId,
                                 machineName = wf.MachineName,
                                 machineDisplayName = wf.MachineDisplayName,
                                 machineDescription = wf.MachineDescription
                             }).ToList();

                if (check.Count > 0)
                {
                    obj.isStatus = true;
                    obj.response = check;
                }
                else
                {
                    obj.isStatus = false;
                    obj.response = "No Items Found";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
                obj.response = ResourceResponse.ExceptionMessage;
                obj.isStatus = false;
            }
            return obj;
        }
        #endregion
    }
}




















////git (M S sql connection old code)
///
//using IFacilityMaini.DAL.App_Start;
//using IFacilityMaini.DAL.Helpers;
//using IFacilityMaini.DAL.Resource;
//using IFacilityMaini.DBModels;
//using IFacilityMaini.Interface;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static IFacilityMaini.EntityModels.CommonEntity;
//using static IFacilityMaini.EntityModels.MainiAPIEntity;


//namespace IFacilityMaini.DAL
//{
//    public class MainiAPIDAL : IMainiAPI
//    {
//        #region Intialazation
//        /// <summary>
//        /// DB connection through entity
//        /// </summary>
//        unitworksccsContext db = new unitworksccsContext();

//        /// <summary>
//        /// App Settings intialization
//        /// </summary>
//        private readonly AppSettings appSettings;

//        /// <summary>
//        /// log4net intialization
//        /// </summary>
//        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MainiAPIDAL));

//        /// <summary>
//        /// MainiAPIDAL constructor
//        /// </summary>
//        /// <param name="_db"></param>
//        /// <param name="_appSettings"></param>
//        public MainiAPIDAL(unitworksccsContext _db, IOptions<AppSettings> _appSettings)
//        {
//            db = _db;
//            appSettings = _appSettings.Value;
//        }
//        #endregion
//        #region API

//        /// <summary>
//        /// Push Alarm Data
//        /// </summary>
//        /// <param name="pushAlarmData">push Alarm Datas</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushAlarmData(PushAlarmCustomEntity pushAlarmData)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {

//                AlarmHistoryMaster tblPriorityAlarmsObj = new AlarmHistoryMaster();
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();
//                string correctedDate = commonFunction.GetCorrectedDate();

//                DateTime alaramDate = DateTime.Now;
//                try
//                {
//                    alaramDate = Convert.ToDateTime(pushAlarmData.timeStamp);
//                }
//                catch (Exception ex)
//                {

//                }
//                tblPriorityAlarmsObj.AlarmDate = alaramDate;
//                tblPriorityAlarmsObj.AlarmTime = alaramDate.TimeOfDay;
//                tblPriorityAlarmsObj.AlarmDateTime = alaramDate;
//                tblPriorityAlarmsObj.InsertedOn = DateTime.Now;
//                int machineId = commonFunction.MachineIdByMachineName(pushAlarmData.machineName);
//                tblPriorityAlarmsObj.MachineId = machineId;
//                tblPriorityAlarmsObj.Shift = shift;
//                tblPriorityAlarmsObj.CorrectedDate = Convert.ToDateTime(correctedDate);

//                foreach (var pushAlarmDatas in pushAlarmData.alarmData)
//                {
//                    tblPriorityAlarmsObj.AlarmMessage = pushAlarmDatas.alarmMessage;
//                    tblPriorityAlarmsObj.Status = pushAlarmDatas.alarmMessage;
//                    tblPriorityAlarmsObj.AxisNo = pushAlarmDatas.axisNumber.ToString();
//                    tblPriorityAlarmsObj.AxisNum = pushAlarmDatas.axisNumber.ToString();
//                    tblPriorityAlarmsObj.AbsPos = pushAlarmDatas.absolutePosition.ToString();
//                    tblPriorityAlarmsObj.AlarmNo = pushAlarmDatas.alarmNumber.ToString();
//                    db.AlarmHistoryMaster.Add(tblPriorityAlarmsObj);
//                    db.SaveChanges();
//                }
//                obj.response = ResourceResponse.PushAlarmDataInsert;
//                obj.isStatus = true;

//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Push Machine Mode
//        /// </summary>
//        /// <param name="pushMachineModeData">push Machine Mode Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushMachineMode(PushMachineModeCustomEntity pushMachineModeData)
//        {
//            CommonResponse obj = new CommonResponse();
//            var json = Newtonsoft.Json.JsonConvert.SerializeObject(pushMachineModeData);

//            try
//            {
//                Mode mode = new Mode();
//                CommonFunction commonFunction = new CommonFunction();
//                //commonFunction.LogFile(json.ToString());
//                string shift = commonFunction.GetCurrentShift();
//                mode = commonFunction.ModeName(pushMachineModeData.machineMode);
//                string correctedDate = commonFunction.GetCorrectedDate();
//                int machineId = commonFunction.MachineIdByMachineName(pushMachineModeData.machineName);
//                DateTime startTime = DateTime.Now;
//                try
//                {
//                    startTime = Convert.ToDateTime(pushMachineModeData.timeStamp);
//                }
//                catch (Exception ex)
//                {

//                }

//                #region Update in live mode table

//                InsertingDataIntoModeTable(mode.modeName, machineId, mode.modeColor, correctedDate, shift);

//                #endregion

//                obj.response = ResourceResponse.PushMachineModeInsert;
//                obj.isStatus = true;
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Inserting Data Into Mode Table
//        /// </summary>
//        /// <param name="mode"></param>
//        /// <param name="machineId"></param>
//        /// <param name="color"></param>
//        /// <param name="CorrectedDate"></param>
//        /// <param name="Shift"></param>
//        /// <returns></returns>
//        public bool InsertingDataIntoModeTable(string mode, int machineId, string color, string CorrectedDate, string Shift)
//        {
//            bool tic = true;
//            //Based on the machineid and correctedDate select the last(Latest) mode in mode table 
//            // see if new mode is equal to last(latest) mode , if not insert.

//            //Take last mode from today insert it now. or latest of modes from latest of previous days . Only if current mode is different from new mode.

//            #region cheking the day for completion

//            List<Tbllivemode> lastMode = new List<Tbllivemode>();
//            Tbllivemode lastmodesinglerow = new Tbllivemode();


//            lastMode = db.Tbllivemode.Where(m => m.MachineId == machineId && m.IsCompleted == 0).OrderByDescending(m => m.StartTime).ToList();


//            if (lastMode != null && lastMode.Count == 1)
//            {
//                lastmodesinglerow = lastMode.OrderByDescending(m => m.ModeId).FirstOrDefault();

//                if (lastmodesinglerow.MacMode != mode)
//                {
//                    try
//                    {
//                        //update endtime for last mode 
//                        DateTime dt = DateTime.Now;
//                        int lastmodeID = lastmodesinglerow.ModeId;
//                        //get colorcode
//                        if (lastmodeID != 0)
//                        {
//                            Tbllivemode tmprevious = new Tbllivemode();
//                            DateTime CompletedModeET = DateTime.Now;

//                            // getting the last completed endtime validete with the present start time
//                            CompletedModeET = Convert.ToDateTime(db.Tbllivemode.Where(m => m.IsDeleted == 0 && m.IsCompleted == 1 && m.MachineId == machineId).OrderByDescending(m => m.ModeId).Select(m => m.EndTime).FirstOrDefault());
//                            tmprevious = db.Tbllivemode.Find(lastmodeID);

//                            DateTime PresentModeST = Convert.ToDateTime(tmprevious.StartTime);

//                            if (PresentModeST == CompletedModeET)
//                            {
//                                string previousmode = tmprevious.MacMode;
//                                if (mode != previousmode)
//                                {
//                                    UpdateModeRow(dt, lastmodeID, machineId, color, CorrectedDate);
//                                    AddModeRow(CorrectedDate, dt, color, machineId, mode, Shift);
//                                }
//                            }
//                            else
//                            {
//                                string previousmode = tmprevious.MacMode;
//                                if (mode != previousmode)
//                                {
//                                    UpdateModeRow(dt, lastmodeID, machineId, color, CorrectedDate);
//                                    AddModeRow(CorrectedDate, dt, color, machineId, mode, Shift);
//                                }
//                            }

//                        }
//                    }
//                    catch (Exception e)
//                    {

//                    }
//                }
//            }
//            else if (lastMode.Count > 1)
//            {
//                string getmodequery2 = "SELECT ModeId,StartTime,MacMode From [unitworksccs].[unitworkccs].[tbllivemode] WHERE IsCompleted = 0 and MachineId = " + machineId + " and CorrectedDate<='" + CorrectedDate + "' order by ModeId";
//                DataTable dtModeMultiple = new DataTable();

//                using (ConnectionString mc = new ConnectionString())
//                {
//                    mc.Open(appSettings.ConnectionString);
//                    SqlDataAdapter daMode1 = new SqlDataAdapter(getmodequery2, appSettings.ConnectionString.ToString());
//                    daMode1.Fill(dtModeMultiple);
//                    mc.Close(appSettings.ConnectionString);
//                }
//                using (ConnectionString mc = new ConnectionString())
//                {
//                    mc.Open(appSettings.ConnectionString);
//                    for (int i = 0; i < (dtModeMultiple.Rows.Count - 1); i++)
//                    {
//                        string mode1 = dtModeMultiple.Rows[i][2].ToString();
//                        string mode2 = dtModeMultiple.Rows[i + 1][2].ToString();
//                        if (mode1 == mode2)
//                        {
//                            DataTable dtModeMultiple2 = new DataTable();

//                            SqlDataAdapter cmdpoweroff = new SqlDataAdapter("DELETE FROM [unitworksccs].[unitworkccs].[tbllivemode] where ModeId = " + Convert.ToInt32(dtModeMultiple.Rows[i][0]), appSettings.ConnectionString.ToString());
//                            cmdpoweroff.Fill(dtModeMultiple2);

//                        }
//                    }
//                    mc.Close(appSettings.ConnectionString);
//                }
//            }
//            else
//            {
//                DateTime dt = DateTime.Now;
//                AddModeRow(CorrectedDate, dt, color, machineId, mode, Shift);
//            }
//            #endregion

//            return tic;
//        }

//        /// <summary>
//        /// Add Mode Row
//        /// </summary>
//        /// <param name="CorrectedDate"></param>
//        /// <param name="dt"></param>
//        /// <param name="color"></param>
//        /// <param name="machineId"></param>
//        /// <param name="mode"></param>
//        /// <returns></returns>
//        public int AddModeRow(string CorrectedDate, DateTime dt, string color, int machineId, string mode, string shift)
//        {
//            int Ret = 1;
//            CommonFunction commonFunction = new CommonFunction();
//            int shiftId = commonFunction.GetCurrentShiftId(shift);

//            try
//            {
//                Tbllivemode tm = new Tbllivemode();
//                tm.CorrectedDate = Convert.ToDateTime(CorrectedDate);
//                tm.InsertedBy = 1;
//                tm.InsertedOn = dt;
//                tm.StartTime = dt;
//                tm.ColorCode = color;
//                tm.IsDeleted = 0;
//                tm.IsCompleted = 0;
//                tm.MachineId = machineId;
//                tm.MacMode = mode;
//                tm.ModeType = mode;
//                tm.ModeTypeEnd = 0;
//                tm.StartIdle = 0;
//                tm.IsInserted = 0;
//                tm.IsShiftEnd = shiftId;
//                tm.Shift = shift;
//                db.Tbllivemode.Add(tm);
//                db.SaveChanges();
//            }
//            catch (Exception e)
//            {

//            }

//            return Ret;
//        }

//        /// <summary>
//        /// Update Mode Row
//        /// </summary>
//        /// <param name="dt"></param>
//        /// <param name="lastmachineid"></param>
//        /// <param name="machineId"></param>
//        /// <param name="PresentColor"></param>
//        /// <param name="correctedDate"></param>
//        /// <returns></returns>
//        public int UpdateModeRow(DateTime dt, int lastmachineid, int machineId, string PresentColor, string correctedDate)
//        {
//            int Ret = 1;

//            try
//            {
//                Tbllivemode tmprevious = db.Tbllivemode.Where(m => m.ModeId == lastmachineid).FirstOrDefault();
//                DateTime ModeStartTime = Convert.ToDateTime(tmprevious.StartTime);
//                tmprevious.EndTime = dt;
//                tmprevious.IsCompleted = 1;
//                var duationinsec = dt.Subtract(Convert.ToDateTime(tmprevious.StartTime)).TotalSeconds;
//                tmprevious.DurationInSec = Convert.ToInt32(duationinsec);
//                tmprevious.ModeTypeEnd = 1;
//                tmprevious.ModifiedOn = DateTime.Now;
//                db.SaveChanges();
//            }
//            catch (Exception e)
//            {

//            }

//            return Ret;
//        }

//        /// <summary>
//        /// Push Parameters
//        /// </summary>
//        /// <param name="pushParametersData">push Parameters Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushParameters(PushParametersCustomEntity pushParametersData)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();
//                int machineId = commonFunction.MachineIdByMachineName(pushParametersData.machineName);
//                DateTime insertedTime = DateTime.Now;

//                try
//                {
//                    insertedTime = Convert.ToDateTime(pushParametersData.timeStamp);
//                    //insertedTime = insertedTime.AddHours(5).AddMinutes(30);
//                }
//                catch (Exception ex)
//                {

//                }

//                ParametersMaster parametersMaster = new ParametersMaster();
//                int opTm = commonFunction.MinToInteger(pushParametersData.operatingTime);
//                int poTm = commonFunction.MinToInteger(pushParametersData.powerOnTime);

//                parametersMaster.OperatingTime = opTm.ToString();
//                parametersMaster.PowerOnTime = poTm.ToString();
//                parametersMaster.PartsCount = pushParametersData.partsCount;
//                parametersMaster.InsertedOn = insertedTime;
//                parametersMaster.MachineId = machineId;
//                parametersMaster.Shift = commonFunction.GetCurrentShiftId(shift);
//                string corrDate = commonFunction.GetCorrectedDate();
//                parametersMaster.CorrectedDate = Convert.ToDateTime(corrDate);
//                parametersMaster.PartsTotal = pushParametersData.partsTotal;
//                parametersMaster.CuttingTime = pushParametersData.cuttingTime;
//                db.ParametersMaster.Add(parametersMaster);
//                db.SaveChanges();

//                obj.response = ResourceResponse.PushParametersInsert;
//                obj.isStatus = true;
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// push Axis Position Data
//        /// </summary>
//        /// <param name="pushAxisPositionData">push Axis Position Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushAxisPosition(PushAxisPositionCustomEntity pushAxisDatas)
//        {
//            CommonResponse obj = new CommonResponse();
//            // var json = Newtonsoft.Json.JsonConvert.SerializeObject(pushAxisDatas);
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                //  commonFunction.LogFile(json.ToString());
//                string shift = commonFunction.GetCurrentShift();
//                int machineId = commonFunction.MachineIdByMachineName(pushAxisDatas.machineName);
//                foreach (var pushAxisData in pushAxisDatas.axisPosition)
//                {
//                    TblAxisdetails1 tblAxisdetails1 = new TblAxisdetails1();
//                    tblAxisdetails1.MachineId = machineId;
//                    tblAxisdetails1.Axis = pushAxisData.axisName;
//                    tblAxisdetails1.AbsPos = Convert.ToDecimal(pushAxisData.absolutePositionValue);
//                    tblAxisdetails1.RelPos = Convert.ToDecimal(pushAxisData.relativePositionValue);
//                    tblAxisdetails1.MacPos = Convert.ToDecimal(pushAxisData.machinePositionValue);
//                    tblAxisdetails1.DistPos = Convert.ToDecimal(pushAxisData.distanceToGoValue);
//                    tblAxisdetails1.StartTime = Convert.ToDateTime(pushAxisDatas.timeStamp);
//                    tblAxisdetails1.IsDeleted = 0;
//                    tblAxisdetails1.InsertedOn = DateTime.Now;
//                    db.TblAxisdetails1.Add(tblAxisdetails1);
//                    db.SaveChanges();
//                }

//                obj.response = ResourceResponse.PushAxisPositionInsert;
//                obj.isStatus = true;

//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Push Axis Details
//        /// </summary>
//        /// <param name="pushAxisDetailsData">push Axis Details Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushAxisDetails(PushAxisDetailsCustomEntity pushAxisData)
//        {
//            CommonResponse obj = new CommonResponse();
//            // var json = Newtonsoft.Json.JsonConvert.SerializeObject(pushAxisData);
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                //commonFunction.LogFile(json.ToString());
//                string shift = commonFunction.GetCurrentShift();
//                int machineId = commonFunction.MachineIdByMachineName(pushAxisData.machineName);

//                TblAxisdetails2 tblAxisdetails2 = new TblAxisdetails2();
//                tblAxisdetails2.MachineId = machineId;
//                tblAxisdetails2.StartTime = Convert.ToDateTime(pushAxisData.timeStamp);
//                tblAxisdetails2.FeedRate = Convert.ToDecimal(pushAxisData.feedRate);
//                tblAxisdetails2.SpindleLoad = Convert.ToDecimal(pushAxisData.spindleLoad);
//                tblAxisdetails2.SpindleSpeed = Convert.ToDecimal(pushAxisData.spindleSpeed);
//                tblAxisdetails2.FeedRatePercentage = Convert.ToDecimal(pushAxisData.feedOveridePercentage);
//                tblAxisdetails2.IsDeleted = 0;
//                tblAxisdetails2.InsertedOn = DateTime.Now;
//                db.TblAxisdetails2.Add(tblAxisdetails2);
//                db.SaveChanges();


//                obj.response = ResourceResponse.PushAxisDetailsInsert;
//                obj.isStatus = true;
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Push Program Execution Data
//        /// </summary>
//        /// <param name="pushProgramExecutionData">push Program Execution Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushProgramExecutionData(PushProgramExecutionDataCustomEntity pushProgramExecutionData)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();
//                int machineId = commonFunction.MachineIdByMachineName(pushProgramExecutionData.machineName);
//                string correctedDate = commonFunction.GetCorrectedDate();
//                if (pushProgramExecutionData.isProgramStart == true)
//                {
//                    ProgramExecutionMaster programExecutionMaster = new ProgramExecutionMaster();
//                    programExecutionMaster.ProgramName = pushProgramExecutionData.programName;
//                    programExecutionMaster.CorrectedDate = Convert.ToDateTime(correctedDate);
//                    programExecutionMaster.MachineId = machineId;
//                    programExecutionMaster.ProgramExcutedDateTime = Convert.ToDateTime(pushProgramExecutionData.timeStamp);
//                    programExecutionMaster.ProgramStartDateTime = Convert.ToDateTime(pushProgramExecutionData.programStartOrEndDateTime);
//                    programExecutionMaster.IsDeleted = false;
//                    programExecutionMaster.CreatedOn = DateTime.Now;
//                    db.ProgramExecutionMaster.Add(programExecutionMaster);
//                    db.SaveChanges();
//                    obj.response = ResourceResponse.PushProgramExecutionDataInsert;
//                    obj.isStatus = true;
//                }
//                else
//                {
//                    DateTime correctedDateDF = Convert.ToDateTime(correctedDate);
//                    var programExecutionMaster = db.ProgramExecutionMaster.Where(m => m.MachineId == machineId && m.ProgramName == pushProgramExecutionData.programName && m.CorrectedDate == correctedDateDF).FirstOrDefault();
//                    if (programExecutionMaster != null)
//                    {
//                        programExecutionMaster.ProgramEndDateTime = Convert.ToDateTime(pushProgramExecutionData.programStartOrEndDateTime);
//                        programExecutionMaster.ModifiedOn = DateTime.Now;
//                        db.SaveChanges();
//                        obj.response = ResourceResponse.PushProgramExecutionDataUpdate;
//                        obj.isStatus = true;
//                    }
//                    else
//                    {

//                    }
//                }



//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Push Parameter Sensor Data
//        /// </summary>
//        /// <param name="pushParameterSensorData">push Parameter Sensor Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushParameterSensorData(PushParameterSensorDataCustomEntity pushParameterSensorData)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();
//                int machineId = commonFunction.MachineIdByMachineName(pushParameterSensorData.machineName);
//                string correctedDate = commonFunction.GetCorrectedDate();

//                ParameterSendorData parameterSendorData = new ParameterSendorData();
//                parameterSendorData.MachineId = machineId;
//                parameterSendorData.SensorDataCapturedTime = Convert.ToDateTime(pushParameterSensorData.timeStamp);
//                parameterSendorData.IsDeleted = false;
//                parameterSendorData.CreatedOn = DateTime.Now;
//                parameterSendorData.CorrectedDate = Convert.ToDateTime(correctedDate);
//                db.ParameterSendorData.Add(parameterSendorData);
//                db.SaveChanges();
//                try
//                {
//                    foreach (var current in pushParameterSensorData.current)
//                    {
//                        ParameterSensorDataCurrent parameterSensorDataCurrent = new ParameterSensorDataCurrent();
//                        parameterSensorDataCurrent.ParameterSensorDataId = parameterSendorData.ParameterSensorDataId;
//                        parameterSensorDataCurrent.CurrentValue = Convert.ToDecimal(current);
//                        db.ParameterSensorDataCurrent.Add(parameterSensorDataCurrent);
//                        db.SaveChanges();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                }
//                try
//                {
//                    foreach (var pressure in pushParameterSensorData.pressure)
//                    {
//                        ParameterSensorDataPressure parameterSensorDataPressure = new ParameterSensorDataPressure();
//                        parameterSensorDataPressure.ParameterSensorDataId = parameterSendorData.ParameterSensorDataId;
//                        parameterSensorDataPressure.PressureValue = Convert.ToDecimal(pressure);
//                        db.ParameterSensorDataPressure.Add(parameterSensorDataPressure);
//                        db.SaveChanges();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                }
//                try
//                {
//                    foreach (var temperature in pushParameterSensorData.temperature)
//                    {
//                        ParameterSensorDataTemperature parameterSensorDataTemperature = new ParameterSensorDataTemperature();
//                        parameterSensorDataTemperature.ParameterSensorDataId = parameterSendorData.ParameterSensorDataId;
//                        parameterSensorDataTemperature.TemperatureValue = Convert.ToDecimal(temperature);
//                        db.ParameterSensorDataTemperature.Add(parameterSensorDataTemperature);
//                        db.SaveChanges();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                }
//                try
//                {
//                    foreach (var level in pushParameterSensorData.level)
//                    {
//                        ParameterSensorDataLevel parameterSensorDataLevel = new ParameterSensorDataLevel();
//                        parameterSensorDataLevel.ParameterSensorDataId = parameterSendorData.ParameterSensorDataId;
//                        parameterSensorDataLevel.LevelValue = Convert.ToDecimal(level);
//                        db.ParameterSensorDataLevel.Add(parameterSensorDataLevel);
//                        db.SaveChanges();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                }


//                obj.response = ResourceResponse.PushParameterSensorDataInsert;
//                obj.isStatus = true;
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Push Parameter Tool Data
//        /// </summary>
//        /// <param name="pushParameterToolData">push Parameter Tool Data</param>
//        /// <returns>API success/failure status and message</returns>
//        public CommonResponse PushParameterToolData(PushParameterToolDataCustomEntity pushParameterToolData)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();
//                int machineId = commonFunction.MachineIdByMachineName(pushParameterToolData.machineName);
//                string correctedDate = commonFunction.GetCorrectedDate();


//                foreach (var tool in pushParameterToolData.tool)
//                {

//                    foreach (var toolGroup in tool.toolGroup)
//                    {
//                        ParameterToolData parameterToolData = new ParameterToolData();
//                        parameterToolData.MachineId = machineId;
//                        parameterToolData.CorrectedDate = Convert.ToDateTime(correctedDate);
//                        parameterToolData.ToolGroupName = tool.toolGroupName;
//                        parameterToolData.ParameterToolDataCapturedDate = Convert.ToDateTime(pushParameterToolData.timeStamp);
//                        parameterToolData.ToolNumber = toolGroup.toolNumber;
//                        parameterToolData.Capacity = toolGroup.capacity;
//                        parameterToolData.Partsproduced = toolGroup.partsProduced;
//                        db.ParameterToolData.Add(parameterToolData);
//                        db.SaveChanges();
//                    }
//                }


//                obj.response = ResourceResponse.PushParameterToolDataInsert;
//                obj.isStatus = true;
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// AddMachineConfig
//        /// </summary>
//        /// <param name="machineConfigPost"></param>
//        /// <returns></returns>
//        public CommonResponseWithId AddMachineConfig(MachineConfigPost machineConfigPost)
//        {
//            CommonResponseWithId obj = new CommonResponseWithId();
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();

//                string correctedDate = commonFunction.GetCorrectedDate();
//                var machineData = db.Tblmachinedetails.Where(m => m.IsDeleted == 0 && m.MachineName == machineConfigPost.machineName && m.Ipaddress == machineConfigPost.machineIp).FirstOrDefault();

//                if (machineData == null)
//                {
//                    Tblmachinedetails machineDetailsWimerasys = new Tblmachinedetails();
//                    machineDetailsWimerasys.MachineName = machineConfigPost.machineName;
//                    machineDetailsWimerasys.TransmissionFrequency = machineConfigPost.transmissionFrequency;
//                    machineDetailsWimerasys.LoggerType = machineConfigPost.loggerType;
//                    machineDetailsWimerasys.Ipaddress = machineConfigPost.machineIp;
//                    machineDetailsWimerasys.MachinePort = machineConfigPost.machinePort;
//                    machineDetailsWimerasys.NumOfAxis = machineConfigPost.numOfAxis;
//                    machineDetailsWimerasys.ToolGroupNum = machineConfigPost.toolGroupNum;
//                    machineDetailsWimerasys.NumberOfCurrent = machineConfigPost.numberOfCurrent;
//                    machineDetailsWimerasys.NumberOfTemperature = machineConfigPost.numberOfTemperature;
//                    machineDetailsWimerasys.NumberOfPresure = machineConfigPost.numberOfPresure;
//                    machineDetailsWimerasys.NumberOfLevel = machineConfigPost.numberOfLevel;
//                    machineDetailsWimerasys.IsDeleted = 0;
//                    machineDetailsWimerasys.InsertedOn = DateTime.Now.ToString();
//                    machineDetailsWimerasys.CreatedOn = DateTime.Now;
//                    machineDetailsWimerasys.IsWimerasys = true;
//                    db.Tblmachinedetails.Add(machineDetailsWimerasys);
//                    db.SaveChanges();
//                    obj.response = ResourceResponse.MachineConfigInsert;
//                    obj.isStatus = true;
//                    obj.machineIdPK = machineDetailsWimerasys.MachineId;
//                }
//                else
//                {
//                    obj.response = ResourceResponse.MachineConfigInsertFail;
//                    obj.isStatus = false;
//                }

//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// AddMachineConfig
//        /// </summary>
//        /// <param name="machineConfigPost"></param>
//        /// <returns></returns>
//        public CommonResponse UpdateMachineConfig(MachineConfigPut machineConfigPost)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                CommonFunction commonFunction = new CommonFunction();
//                string shift = commonFunction.GetCurrentShift();

//                string correctedDate = commonFunction.GetCorrectedDate();
//                var machineDetailsWimerasys = db.Tblmachinedetails.Where(m => m.MachineId == machineConfigPost.machineIdPK).FirstOrDefault();

//                if (machineDetailsWimerasys != null)
//                {
//                    machineDetailsWimerasys.MachineName = machineConfigPost.machineName;
//                    machineDetailsWimerasys.TransmissionFrequency = machineConfigPost.transmissionFrequency;
//                    machineDetailsWimerasys.LoggerType = machineConfigPost.loggerType;
//                    machineDetailsWimerasys.Ipaddress = machineConfigPost.machineIp;
//                    machineDetailsWimerasys.MachinePort = machineConfigPost.machinePort;
//                    machineDetailsWimerasys.NumOfAxis = machineConfigPost.numOfAxis;
//                    machineDetailsWimerasys.ToolGroupNum = machineConfigPost.toolGroupNum;
//                    machineDetailsWimerasys.NumberOfCurrent = machineConfigPost.numberOfCurrent;
//                    machineDetailsWimerasys.NumberOfTemperature = machineConfigPost.numberOfTemperature;
//                    machineDetailsWimerasys.NumberOfPresure = machineConfigPost.numberOfPresure;
//                    machineDetailsWimerasys.NumberOfLevel = machineConfigPost.numberOfLevel;
//                    machineDetailsWimerasys.IsDeleted = 0;
//                    machineDetailsWimerasys.CreatedOn = DateTime.Now;
//                    db.SaveChanges();
//                    obj.response = ResourceResponse.MachineConfigUpdate;
//                    obj.isStatus = true;
//                }
//                else
//                {
//                    obj.response = ResourceResponse.MachineConfigUpdateFailure;
//                    obj.isStatus = true;
//                }

//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }
//        #endregion

//        #region Anjali APIs

//        /// <summary>
//        /// Login
//        /// </summary>
//        /// <param name="userName"></param>
//        /// <param name="password"></param>
//        /// <returns></returns>
//        public CommonResponse Login(string userName, string password)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.TblOperatorDetails
//                             where wf.UserName == userName && wf.Password == password
//                             select new
//                             {
//                                 operatorName = wf.OperatorName,
//                                 operatorId = wf.OpId,
//                                 roleId = wf.RoleId
//                             }).FirstOrDefault();
//                if (check != null)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "Not Authorized User";
//                }

//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Plants
//        /// </summary>
//        /// <returns></returns>
//        public CommonResponse GetPlants()
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.Tblplant
//                             where wf.IsDeleted == 0
//                             select new
//                             {
//                                 plantId = wf.PlantId,
//                                 plantName = wf.PlantName,
//                                 plantDescription = wf.PlantDesc,
//                                 plantCode = wf.PlantCode,
//                             }).ToList();

//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Fg Part Number
//        /// </summary>
//        /// <returns></returns>
//        public CommonResponse GetFgPartNumber(int plantId)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.TblFgAndCellAllocation
//                             where wf.IsDeleted == 0 && wf.PlantId == plantId
//                             select new
//                             {
//                                 plantId = wf.PlantId,
//                                 fgPartNumber = db.Tblparts.Where(m => m.PartId == wf.PartId).Select(m => m.Fgcode).FirstOrDefault(),
//                                 fgPartId = wf.FgAndCellAllocationId,
//                                 plantCode = db.Tblplant.Where(m => m.PlantId == wf.PlantId).Select(m => m.PlantCode).FirstOrDefault()
//                             }).ToList();

//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Child Part Number
//        /// </summary>
//        /// <param name="fgpartId"></param>
//        /// <returns></returns>
//        public CommonResponse GetChildPartNumber(int fgPartId)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.TblChildFgPartNo
//                             where wf.IsDeleted == 0 && wf.FgPartId == fgPartId
//                             select new
//                             {
//                                 fgPartId = wf.FgPartId,
//                                 childFgpartId = wf.ChildFgpartId,
//                                 childFgPartNo = wf.ChildFgPartNo,
//                                 childPartNoDesc = wf.ChildPartNoDesc,
//                                 plantId = db.Tblplant.Where(m => m.PlantId == wf.PlantId).Select(m => m.PlantCode).FirstOrDefault()
//                             }).ToList();

//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Routing No
//        /// </summary>
//        /// <param name="fgPartId"></param>
//        /// <param name="childFgPartId"></param>
//        /// <returns></returns>
//        public CommonResponse GetRoutingNo(int fgPartId, int childFgPartId)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.TblRoutingNo
//                             where wf.ChildFgPartId == childFgPartId && wf.FgPartId == fgPartId
//                             select new
//                             {
//                                 routingNumber = wf.RoutingNo,
//                                 routingId = wf.Id,
//                                 plantId = wf.PlantId
//                             }).ToList();
//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Dir Entry
//        /// </summary>
//        /// <returns></returns>
//        public CommonResponse GetDirEntry(DirInfo data)
//        {
//            CommonResponse obj = new CommonResponse();
//            CommonFunction commonFunction = new CommonFunction();
//            string shift = commonFunction.GetCurrentShift();
//            string correctedDate = commonFunction.GetCorrectedDate();
//            List<RejectionReworkDet> RejectionReworkDetList = new List<RejectionReworkDet>();

//            try
//            {
//                var rejection = db.TblRejectionDetails.Where(m => m.MachineId == data.machineId && m.CorrectedDate == correctedDate && m.Shift == shift).ToList();

//                foreach (var item in rejection)
//                {
//                    RejectionReworkDet rejectionReworkDet = new RejectionReworkDet();
//                    rejectionReworkDet.plantId = data.plantId;
//                    rejectionReworkDet.plantName = db.Tblplant.Where(m => m.PlantId == data.plantId).Select(m => m.PlantName).FirstOrDefault();
//                    rejectionReworkDet.cellId = data.cellId;
//                    rejectionReworkDet.cellName = db.TblCellFinalMaster.Where(m => m.CellFinalId == data.cellId).Select(m => m.CellFinalName).FirstOrDefault();
//                    rejectionReworkDet.subCellId = data.subCellId;
//                    rejectionReworkDet.subCellName = db.TblSubCellFinalMaster.Where(m => m.SubCellFinalId == data.subCellId).Select(m => m.SubCellFinalName).FirstOrDefault();
//                    rejectionReworkDet.machineId = data.machineId;
//                    rejectionReworkDet.machineName = db.Tblmachinedetails.Where(m => m.MachineId == data.machineId).Select(m => m.MachineName).FirstOrDefault();
//                    rejectionReworkDet.partId = db.TblFgPartNoDet.Where(m => m.FgPartId == item.FgPartId).Select(m => m.PartId).FirstOrDefault();
//                    rejectionReworkDet.partNo = db.Tblparts.Where(m => m.PartId == rejectionReworkDet.partId).Select(m => m.Fgcode).FirstOrDefault();
//                    rejectionReworkDet.partDesc = db.Tblparts.Where(m => m.PartId == rejectionReworkDet.partId).Select(m => m.PartName).FirstOrDefault();
//                    rejectionReworkDet.workOrderNo = db.TblFgPartNoDet.Where(m => m.FgPartId == item.FgPartId).Select(m => m.WorkOrderNo).FirstOrDefault();
//                    rejectionReworkDet.operatorId = item.OperatorId;
//                    rejectionReworkDet.operatorName = db.TblOperatorDetails.Where(m => m.OpId == item.OperatorId).Select(m => m.OperatorName).FirstOrDefault();
//                    DateTime createdOn = Convert.ToDateTime(item.CreatedOn);
//                    rejectionReworkDet.date = createdOn.ToString("yyyy-MM-dd HH:mm:ss");
//                    rejectionReworkDet.shift = item.Shift;
//                    rejectionReworkDet.quantity = item.DefectQty;
//                    rejectionReworkDet.defectCodeId = item.DefectCodeId;
//                    rejectionReworkDet.defectCode = db.TblDefectCodeMaster.Where(m => m.DefectCodeId == rejectionReworkDet.defectCodeId).Select(m => m.DefectCodeName).FirstOrDefault();
//                    rejectionReworkDet.defectCodeDesc = db.TblDefectCodeMaster.Where(m => m.DefectCodeId == rejectionReworkDet.defectCodeId).Select(m => m.DefectCodeDesc).FirstOrDefault();
//                    rejectionReworkDet.isRejectionOrRework = "Rejection";
//                    RejectionReworkDetList.Add(rejectionReworkDet);
//                }

//                var rework = db.TblReworkDetails.Where(m => m.MachineId == data.machineId && m.CorrectedDate == correctedDate && m.Shift == shift).ToList();

//                foreach (var items in rework)
//                {
//                    RejectionReworkDet rejectionReworkDet1 = new RejectionReworkDet();
//                    rejectionReworkDet1.plantId = data.plantId;
//                    rejectionReworkDet1.plantName = db.Tblplant.Where(m => m.PlantId == data.plantId).Select(m => m.PlantName).FirstOrDefault();
//                    rejectionReworkDet1.cellId = data.cellId;
//                    rejectionReworkDet1.cellName = db.TblCellFinalMaster.Where(m => m.CellFinalId == data.cellId).Select(m => m.CellFinalName).FirstOrDefault();
//                    rejectionReworkDet1.subCellId = data.subCellId;
//                    rejectionReworkDet1.subCellName = db.TblSubCellFinalMaster.Where(m => m.SubCellFinalId == data.subCellId).Select(m => m.SubCellFinalName).FirstOrDefault();
//                    rejectionReworkDet1.machineId = data.machineId;
//                    rejectionReworkDet1.machineName = db.Tblmachinedetails.Where(m => m.MachineId == data.machineId).Select(m => m.MachineName).FirstOrDefault();
//                    rejectionReworkDet1.partId = db.TblFgPartNoDet.Where(m => m.FgPartId == items.FgPartId).Select(m => m.PartId).FirstOrDefault();
//                    rejectionReworkDet1.partNo = db.Tblparts.Where(m => m.PartId == rejectionReworkDet1.partId).Select(m => m.Fgcode).FirstOrDefault();
//                    rejectionReworkDet1.partDesc = db.Tblparts.Where(m => m.PartId == rejectionReworkDet1.partId).Select(m => m.PartName).FirstOrDefault();
//                    rejectionReworkDet1.workOrderNo = db.TblFgPartNoDet.Where(m => m.FgPartId == items.FgPartId).Select(m => m.WorkOrderNo).FirstOrDefault();
//                    rejectionReworkDet1.operatorId = items.OperatorId;
//                    rejectionReworkDet1.operatorName = db.TblOperatorDetails.Where(m => m.OpId == items.OperatorId).Select(m => m.OperatorName).FirstOrDefault();
//                    DateTime createdOn = Convert.ToDateTime(items.CreatedOn);
//                    rejectionReworkDet1.date = createdOn.ToString("yyyy-MM-dd HH:mm:ss");
//                    rejectionReworkDet1.shift = items.Shift;
//                    rejectionReworkDet1.quantity = items.DefectQty;
//                    rejectionReworkDet1.defectCodeId = items.DefectCodeId;
//                    rejectionReworkDet1.defectCode = db.TblDefectCodeMaster.Where(m => m.DefectCodeId == rejectionReworkDet1.defectCodeId).Select(m => m.DefectCodeName).FirstOrDefault();
//                    rejectionReworkDet1.defectCodeDesc = db.TblDefectCodeMaster.Where(m => m.DefectCodeId == rejectionReworkDet1.defectCodeId).Select(m => m.DefectCodeDesc).FirstOrDefault();
//                    rejectionReworkDet1.isRejectionOrRework = "Rework";
//                    RejectionReworkDetList.Add(rejectionReworkDet1);
//                }
//                obj.isStatus = true;
//                obj.response = RejectionReworkDetList;
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Cells
//        /// </summary>
//        /// <param name="plantId"></param>
//        /// <returns></returns>
//        public CommonResponse GetCells(int plantId)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.TblCellFinalMaster
//                             where wf.IsDeleted == 0 && wf.PlantId == plantId
//                             select new
//                             {
//                                 cellFinalId = wf.CellFinalId,
//                                 cellFinalName = wf.CellFinalName,
//                                 cellFinalDesc = wf.CellFinalDesc
//                             }).ToList();

//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Cells
//        /// </summary>
//        /// <param name="shopId"></param>
//        /// <returns></returns>
//        public CommonResponse GetSubCells(int cellFinalId)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.TblSubCellFinalMaster
//                             where wf.IsDeleted == 0 && wf.CellFinalId == cellFinalId
//                             select new
//                             {
//                                 subCellFinalId = wf.SubCellFinalId,
//                                 subCellFinalName = wf.SubCellFinalName,
//                                 subCellFinalDesc = wf.SubCellFinalDesc
//                             }).ToList();

//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }

//        /// <summary>
//        /// Get Machines
//        /// </summary>
//        /// <param name="subCellFinalId"></param>
//        /// <returns></returns>
//        public CommonResponse GetMachines(int subCellFinalId)
//        {
//            CommonResponse obj = new CommonResponse();
//            try
//            {
//                var check = (from wf in db.Tblmachinedetails
//                             where wf.IsDeleted == 0 && wf.CellId == subCellFinalId
//                             select new
//                             {
//                                 machineId = wf.MachineId,
//                                 machineName = wf.MachineName,
//                                 machineDisplayName = wf.MachineDisplayName,
//                                 machineDescription = wf.MachineDescription
//                             }).ToList();

//                if (check.Count > 0)
//                {
//                    obj.isStatus = true;
//                    obj.response = check;
//                }
//                else
//                {
//                    obj.isStatus = false;
//                    obj.response = "No Items Found";
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(ex); if (ex.InnerException != null) { log.Error(ex.InnerException.ToString()); }
//                obj.response = ResourceResponse.ExceptionMessage;
//                obj.isStatus = false;
//            }
//            return obj;
//        }
//        #endregion
//    }
//}