
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFacilityMaini.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IFacilityMaini.EntityModels.CommonEntity;
using static IFacilityMaini.EntityModels.MainiAPIEntity;

namespace IFacilityMaini.Controllers
{
    [ApiController]
    public class MainiAPIController : ControllerBase
    {
        #region Intialazation
        /// <summary>
        /// IMainiAPI interface
        /// </summary>
        private readonly IMainiAPI mainiAPI;

        /// <summary>
        /// Maini API Controller constructor
        /// </summary>
        /// <param name="_mainiAPI"></param>
        public MainiAPIController(IMainiAPI _mainiAPI)
        {
            mainiAPI = _mainiAPI;
        }
        #endregion

        #region Business Logic

        /// <summary>
        /// Push Alarm Data
        /// </summary>
        /// <param name="pushAlarmData">push Alarm Datas</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushAlarmData")]
        public async Task<IActionResult> PushAlarmData(PushAlarmCustomEntity pushAlarmData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushAlarmData(pushAlarmData);
            return Ok(response);
        }

        /// <summary>
        /// Push Machine Mode
        /// </summary>
        /// <param name="pushMachineModeData">push Machine Mode Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushMachineMode")]
        public async Task<IActionResult> PushMachineMode(PushMachineModeCustomEntity pushMachineModeData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushMachineMode(pushMachineModeData);
            return Ok(response);
        }

        /// <summary>
        /// Push Parameters
        /// </summary>
        /// <param name="pushParametersData">push Parameters Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushParameters")]
        public async Task<IActionResult> PushParameters(PushParametersCustomEntity pushParametersData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushParameters(pushParametersData);
            return Ok(response);
        }

        /// <summary>
        /// push Axis Position Data
        /// </summary>
        /// <param name="pushAxisPositionData">push Axis Position Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushAxisPosition")]
        public async Task<IActionResult> PushAxisPosition(PushAxisPositionCustomEntity pushAxisPositionData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushAxisPosition(pushAxisPositionData);
            return Ok(response);
        }

        /// <summary>
        /// Push Axis Details
        /// </summary>
        /// <param name="pushAxisDetailsData">push Axis Details Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushAxisDetails")]
        public async Task<IActionResult> PushAxisDetails(PushAxisDetailsCustomEntity pushAxisDetailsData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushAxisDetails(pushAxisDetailsData);
            return Ok(response);
        }

        /// <summary>
        /// Push Program Execution Data
        /// </summary>
        /// <param name="pushProgramExecutionData">push Program Execution Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushProgramExecutionData")]
        public async Task<IActionResult> PushProgramExecutionData(PushProgramExecutionDataCustomEntity pushProgramExecutionData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushProgramExecutionData(pushProgramExecutionData);
            return Ok(response);
        }

        /// <summary>
        /// Push Parameter Sensor Data
        /// </summary>
        /// <param name="pushParameterSensorData">push Parameter Sensor Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushParameterSensorData")]
        public async Task<IActionResult> PushParameterSensorData(PushParameterSensorDataCustomEntity pushParameterSensorData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushParameterSensorData(pushParameterSensorData);
            //CommonResponse response = new CommonResponse();
            return Ok(response);
        }

        /// <summary>
        /// Push Parameter Tool Data
        /// </summary>
        /// <param name="pushParameterToolData">push Parameter Tool Data</param>
        /// <returns>API success/failure status and message</returns>
        [HttpPost]
        [Route("MainiAPI/PushParameterToolData")]
        public async Task<IActionResult> PushParameterToolData(PushParameterToolDataCustomEntity pushParameterToolData)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.PushParameterToolData(pushParameterToolData);
            return Ok(response);
        }

        /// <summary>
        /// Add Machine Config
        /// </summary>
        /// <param name="machineConfigPost"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("MainiAPI/AddMachineConfig")]
        public async Task<IActionResult> AddMachineConfig(MachineConfigPost machineConfigPost)
        {
            //calling MainiAPI DAL - business layer
            CommonResponseWithId response = mainiAPI.AddMachineConfig(machineConfigPost);
            return Ok(response);
        }

        /// <summary>
        /// Update Machine Config
        /// </summary>
        /// <param name="machineConfigPut"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("MainiAPI/UpdateMachineConfig")]
        public async Task<IActionResult> UpdateMachineConfig(MachineConfigPut machineConfigPut)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.UpdateMachineConfig(machineConfigPut);
            return Ok(response);
        }

        #endregion

        #region Anjali API's

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            CommonResponse response = mainiAPI.Login(userName, password);
            return Ok(response);
        }

        /// <summary>
        /// Get Plants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/GetPlants")]
        public async Task<IActionResult> GetPlants()
        {
            CommonResponse response = mainiAPI.GetPlants();
            return Ok(response);
        }

        /// <summary>
        /// Get Child Part Number
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("Login/GetChildPartNumber")]
        //public async Task<IActionResult> GetChildPartNumber(int partId)
        //{
        //    CommonResponse response = mainiAPI.GetChildPartNumber(partId);
        //    return Ok(response); 
        //}

        /// <summary>
        /// Get Fg Part Number
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/GetFgPartNumber")]
        public async Task<IActionResult> GetFgPartNumber(int plantId)
        {
            CommonResponse response = mainiAPI.GetFgPartNumber(plantId);
            return Ok(response);
        }

        /// <summary>
        /// GetChildPartNumber
        /// </summary>
        /// <param name="fgPartId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/GetChildPartNumber")]
        public async Task<IActionResult> GetChildPartNumber(int fgPartId)
        {
            CommonResponse response = mainiAPI.GetChildPartNumber(fgPartId);
            return Ok(response);
        }

        /// <summary>
        /// Get Routing No
        /// </summary>
        /// <param name="fgPartId"></param>
        /// <param name="childFgPartId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/GetRoutingNo")]
        public async Task<IActionResult> GetRoutingNo(int fgPartId, int childFgPartId)
        {
            CommonResponse response = mainiAPI.GetRoutingNo(fgPartId, childFgPartId);
            return Ok(response);
        }

        /// <summary>
        /// GetDirEntry
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login/GetDirEntry")]
        public async Task<IActionResult> GetDirEntry(DirInfo data)
        {
            //calling MainiAPI DAL - business layer
            CommonResponse response = mainiAPI.GetDirEntry(data);
            return Ok(response);
        }

        /// <summary>
        /// GetCells
        /// </summary>
        /// <param name="plantId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/GetCells")]
        public async Task<IActionResult> GetCells(int plantId)
        {
            CommonResponse response = mainiAPI.GetCells(plantId);
            return Ok(response);
        }

        /// <summary>
        /// cellFinalId
        /// </summary>
        /// <param name="cellFinalId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/cellFinalId")]
        public async Task<IActionResult> GetSubCells(int cellFinalId)
        {
            CommonResponse response = mainiAPI.GetSubCells(cellFinalId);
            return Ok(response);
        }

        /// <summary>
        /// GetMachines
        /// </summary>
        /// <param name="subCellFinalId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login/GetMachines")]
        public async Task<IActionResult> GetMachines(int subCellFinalId)
        {
            CommonResponse response = mainiAPI.GetMachines(subCellFinalId);
            return Ok(response);
        }

        #endregion
    }
}




