using System;
using System.Collections.Generic;
using System.Text;
using static IFacilityMaini.EntityModels.CommonEntity;
using static IFacilityMaini.EntityModels.MainiAPIEntity;

namespace IFacilityMaini.Interface
{
    public interface IMainiAPI
    {
        CommonResponse PushAlarmData(PushAlarmCustomEntity pushAlarmData);
        CommonResponse PushMachineMode(PushMachineModeCustomEntity pushMachineModeData);
        CommonResponse PushParameters(PushParametersCustomEntity pushParametersData);
        CommonResponse PushAxisPosition(PushAxisPositionCustomEntity pushAxisData);
        CommonResponse PushAxisDetails(PushAxisDetailsCustomEntity pushAxisData);
        CommonResponse PushProgramExecutionData(PushProgramExecutionDataCustomEntity pushProgramExecutionData);
        CommonResponse PushParameterSensorData(PushParameterSensorDataCustomEntity pushParameterSensorData);
        CommonResponse PushParameterToolData(PushParameterToolDataCustomEntity pushParameterToolData);
        CommonResponseWithId AddMachineConfig(MachineConfigPost pushParameterToolData);
        CommonResponse UpdateMachineConfig(MachineConfigPut pushParameterToolData);
        CommonResponse Login(string userName, string password);
        CommonResponse GetPlants();
        CommonResponse GetFgPartNumber(int plantId);
        CommonResponse GetChildPartNumber(int fgPartId);
        CommonResponse GetRoutingNo(int fgPartId, int childFgPartId);
        CommonResponse GetDirEntry(DirInfo data);
        CommonResponse GetCells(int plantId);
        CommonResponse GetSubCells(int cellFinalId);
        CommonResponse GetMachines(int subCellFinalId);
    }
}
