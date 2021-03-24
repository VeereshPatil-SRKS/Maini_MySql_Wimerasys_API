using System;
using System.Collections.Generic;
using System.Text;

namespace IFacilityMaini.EntityModels
{
    public class MainiAPIEntity
    {
        /// <summary>
        /// Push Alarm Custom Entity
        /// </summary>
        public class PushAlarmCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public List<AlarmData> alarmData { get; set; }
        }

        /// <summary>
        /// Alarm Data
        /// </summary>
        public class AlarmData
        {
            public string alarmMessage { get; set; }
            public int alarmNumber { get; set; }
            public int axisNumber { get; set; }
            public int absolutePosition { get; set; }
        }

        /// <summary>
        /// Push Machine Mode Custom Entity
        /// </summary>
        public class PushMachineModeCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public int machineMode { get; set; }
        }

        /// <summary>
        /// Push Parameters Custom Entity
        /// </summary>
        public class PushParametersCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public string powerOnTime { get; set; }
            public string operatingTime { get; set; }
            public string cuttingTime   { get; set; }
            public int partsCount { get; set; }
            public int partsTotal { get; set; }
        }

        /// <summary>
        /// Push Axis Position Custom Entity
        /// </summary>
        public class PushAxisPositionCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public List<AxisCustomEntity> axisPosition { get; set; }
        }

        /// <summary>
        /// Axis Position Custom Entity
        /// </summary>
        public class AxisPositionCustomEntity
        {
            public AxisCustomEntity axis { get; set; }
        }

        /// <summary>
        /// Axis Custom Entity
        /// </summary>
        public class AxisCustomEntity
        {
            public string axisName { get; set; }
            public string absolutePositionValue { get; set; }
            public string relativePositionValue { get; set; }
            public string machinePositionValue { get; set; }
            public string distanceToGoValue { get; set; }
        }

        /// <summary>
        /// Push Axis Details Custom Entity
        /// </summary>
        public class PushAxisDetailsCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public double feedOveridePercentage { get; set; }
            public double feedRate { get; set; }
            public double spindleLoad { get; set; }
            public double spindleSpeed { get; set; }
        }

        /// <summary>
        /// Push Program Execution Data Custom Entity
        /// </summary>
        public class PushProgramExecutionDataCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public string programName { get; set; }
            public bool isProgramStart { get; set; }
            public DateTime programStartOrEndDateTime { get; set; }
        }

        /// <summary>
        /// Push Parameter Sensor Data Custom Entity
        /// </summary>
        public class PushParameterSensorDataCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public double[] current { get; set; }
            public double[] pressure { get; set; }
            public double[] temperature { get; set; }
            public double[] level { get; set; }
        }

        public class PushParameterSensorDataCustomEntityList
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public List<CurrentCustomEntity> current { get; set; }
            public List<PressureCustomEntity> pressure { get; set; }
            public List<TemperatureCustomEntity> temperature { get; set; }
            public List<LevelCustomEntity> level { get; set; }
        }

        /// <summary>
        /// Current Custom Entity
        /// </summary>
        public class CurrentCustomEntity
        {
            public string currentValueName { get; set; }
            public double currentValue { get; set; }
        }

        /// <summary>
        /// Pressure Custom Entity
        /// </summary>
        public class PressureCustomEntity
        {
            public string pressureValueName { get; set; }
            public double pressureValue { get; set; }
        }

        /// <summary>
        /// Temperature Custom Entity
        /// </summary>
        public class TemperatureCustomEntity
        {
            public string temperatureValueName { get; set; }
            public double temperatureValue { get; set; }
        }

        /// <summary>
        /// Level Custom Entity
        /// </summary>
        public class LevelCustomEntity
        {
            public string levelValueName { get; set; }
            public double levelValue { get; set; }
        }

        /// <summary>
        /// Push Parameter Tool Data Custom Entity
        /// </summary>
        public class PushParameterToolDataCustomEntity
        {
            public string machineName { get; set; }
            public DateTime timeStamp { get; set; }
            public DateTime machineTimeStamp { get; set; }
            public List<ToolCustomEntity> tool { get; set; }
   
        }

        /// <summary>
        /// Tool Custom Entity
        /// </summary>
        public class ToolCustomEntity
        {
            public string toolGroupName { get; set; }
            public List<ToolGroupCustomEntity> toolGroup { get; set; }

        }

        /// <summary>
        /// Tool Group Custom Entity
        /// </summary>
        public class ToolGroupCustomEntity
        {
            public string toolNumber { get; set; }
            public int capacity { get; set; }
            public int partsProduced { get; set; }
        }

        /// <summary>
        /// Machine Config Post
        /// </summary>
        public class MachineConfigPost
        {
            public string machineName { get; set; }
            public int transmissionFrequency { get; set; }
            public string loggerType { get; set; }
            public string machineIp { get; set; }
            public int machinePort { get; set; }
            public int numOfAxis { get; set; }
            public int toolGroupNum { get; set; }
            public int numberOfCurrent { get; set; }
            public int numberOfTemperature { get; set; }
            public int numberOfPresure { get; set; }
            public int numberOfLevel { get; set; }
        }

        /// <summary>
        /// Machine Config Put
        /// </summary>
        public class MachineConfigPut
        {
            public int machineIdPK { get; set; }
            public string machineName { get; set; }
            public int transmissionFrequency { get; set; }
            public string loggerType { get; set; }
            public string machineIp { get; set; }
            public int machinePort { get; set; }
            public int numOfAxis { get; set; }
            public int toolGroupNum { get; set; }
            public int numberOfCurrent { get; set; }
            public int numberOfTemperature { get; set; }
            public int numberOfPresure { get; set; }
            public int numberOfLevel { get; set; }
        }

        /// <summary>
        /// DirInfo
        /// </summary>
        public class DirInfo
        {
            public int plantId { get; set; }
            public int cellId { get; set; }
            public int subCellId { get; set; }
            public int machineId { get; set; }
        }

        /// <summary>
        /// RejectionReworkDet
        /// </summary>
        public class RejectionReworkDet
        {
            public int plantId { get; set; }
            public string plantName { get; set; }
            public int cellId { get; set; }
            public string cellName { get; set; }
            public int subCellId { get; set; }
            public string subCellName { get; set; }
            public int machineId { get; set; }
            public string machineName { get; set; }
            public int? partId { get; set; }
            public string partNo { get; set; }
            public string partDesc { get; set; }
            public string workOrderNo { get; set; }
            public int? operatorId { get; set; }
            public string operatorName { get; set; }
            public string employeeNo { get; set; }
            public string partQrCode { get; set; }
            public string date { get; set; }
            public string shift { get; set; }
            public int? quantity { get; set; }
            public int? defectCodeId { get; set; }
            public string defectCode { get; set; }
            public string defectCodeDesc { get; set; }
            public string isRejectionOrRework { get; set; }
        }
    }
}
