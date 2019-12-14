using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Color_Calibration.CalibrationSDK
{
    public class i1dColorSDK
    {
        //[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        /// <summary>
        /// SDK return status
        /// 此枚举将由此SDK中的所有函数返回，以指示函数调用的返回状态。
        /// 
        /// </summary>
        public enum i1d3Status_t
        {
            i1d3Success = 0,        /**< Function Succeeded 		*/
            i1d3Err = -100, /**< Nonspecific error 			*/
            i1d3ErrInvalidDevicePtr = -101, /**< Device pointer is NULL		*/
            i1d3ErrNoDeviceFound = -102,    /**< No device found			*/

            // Errors passed through from calibrator class
            i1d3ErrFunctionNotAvailable = -504, /**< The requested Function is not supported by this device */
            i1d3ErrLockedCalibrator = -505, /**< The device is password-locked */
            i1d3ErrCalibratorAlreadyOpen = -508,    /**< The device is currently initialized */
            i1d3ErrCalibratorNotOpen = -509,    /**< No device is currently initialized */
            i1d3ErrTransactionError = -510, /**< The communications are out of sync  */
            i1d3ErrWrongDiffuserPosition = -512,    /**< The diffuser arm is in the wrong position for measurement */
            i1d3ErrIncorrectChecksum = -513,    /**< The calculated checksum is incorrect */
            i1d3ErrInvalidParameter = -517, /**< An invalid parameter was passed into the routine */
            i1d3ErrCalibratorError = -519,  /**< The device returned an error */
            i1d3ErrObsoleteFirmware = -520, /**< The firmware is obsolete */
            i1d3ErrCouldNotEnterBLMode = -521,   /**< Error entering bootloader mode */
            i1d3ErrUSBTimeout = -522,   /**< USB timed out waiting for response from device */
            i1d3ErrUSBCommError = -523, /**< USB communication error */
            i1d3ErrEEPROMWriteProtected = -524, /**< EEPROM-write protection error */

            // Errors passed through from matrix generator class
            i1d3ErrMGBadFile = -600,    /**< Couldn't open file */
            i1d3ErrMGTooFewColors = -601,   /**< Must have at least 3 colors in EDR file.*/
            i1d3ErrMGBadWavelengthIncrement = -602, /**< Currently we require 1nm wavelength increment*/
            i1d3ErrMGBadWavelengthEnd = -603,   /**< Currently we require up to at least 730nm.*/
            i1d3ErrMGBadWavelengthStart = -604, /**< Currently we require start at 380nm.*/
            i1d3ErrNoCMFFile = -605,    /**< Couldn't open CMF data file */
            i1d3ErrCMFFormatError = -606,   /**< Couldn't parse CMF data file */

            // Errors passed through from EDR Support class
            i1d3ErrEDRFileNotOpen = -700,   /**< Must open file before making other requests. */
            i1d3ErrEDRFileAlreadyOpen = -701,   /**< File already opened, close to open another file. */
            i1d3ErrEDRFileNotFound = -702,  /**< File not found. */
            i1d3ErrEDRSizeError = -703, /**< File too short. */
            i1d3ErrEDRHeaderError = -704,   /**< Header didn't have correct signature or file too short. */
            i1d3ErrEDRDataError = -705, /**< Data didn't load properly. */
            i1d3ErrEDRDataSignatureError = -706,    /**< Signature didn't match - corrupted file? */
            i1d3ErrEDRSpectralDataSignatureError = -707,    /**< Signature didn't match - corrupted file? */
            i1d3ErrEDRIndexTooHigh = -708,  /**< Requested more color data than available */
            i1d3ErrEDRNoYxyData = -709, /**< Can't request tri-stimulus */
            i1d3ErrEDRNoSpectralData = -710,    /**< Can't request spectral data in file without it. */
            i1d3ErrEDRNoWavelengthData = -711,  /**< No spectral data in file - in response to GetWavelengths */
            i1d3ErrEDRFixedWavelengths = -712,  /**< Evenly-spaced wavelengths */
            i1d3ErrEDRWavelengthTable = -713,   /**< Wavelengths are from table */
            i1d3ErrEDRParameterError = -714,    /**< Probably a null pointer to a call */

            // Errors returned from i1Display3 devices
            i1d3ErrHW_Locked = 16,      /**< i1Display3 is Locked */                            //0x10
            i1d3ErrHW_I2CLowClock = 80,     /**< EEPROM access error: clock is low */                //0x50
            i1d3ErrHW_NACKReceived = 81,        /**< EEPROM access error: NACK received */                //0x51
            i1d3ErrHW_EEAddressInvalid = 96,        /**< Invalid EEPROM address */                            //0x60
            i1d3ErrHW_InvalidCommand = 128, /**< Invalid command to i1Display3 */                    //0x80
            i1d3ErrHW_WrongDiffuserPosition = 129,  /**< Diffuser is in wrong positon for measurement */    //0x81

            // Errors returned from i1Display3 Rev. B devices / i1d3DC devices
            i1d3ErrHW_InvalidParameter = 130,    /**< Invalid parameter passed to device */              //0x82
            i1d3ErrHW_PeriodeTimeOut = 131,    /**< Period measurement timed out */                    //0x83
            i1d3ErrHW_InvalidMeasurement = 132,    /**< No valid measurement data for get Yxy function */  //0x84
            i1d3ErrHW_MatrixChecksum = 144,    /**< Matrix is missing or corrupt */                    //0x90
            i1d3ErrHW_MatrixAmbient = 145     /**< Ambient matrix is missing or corrupt */            //0x91

        }

        public enum i1d3MeasMode_t
        {
            i1d3MeasModeCRT = 0,                /**< CRT Measurement mode		*/
            i1d3MeasModeLCD = 1,                    /**< LCD Measurement mode		*/

            // Following modes not supported - maintained for X-Rite internal use only
            i1d3MeasModeLCDsim = 2,             /**< unsupported-for X-Rite internal use only*/
            i1d3MeasModeLCDseq = 3,             /**< unsupported-for X-Rite internal use only*/
            i1d3MeasModeCRTFixed = 4,           /**< unsupported-for X-Rite internal use only*/
            i1d3MeasModeCRTAutoDark = 5,        /**< unsupported-for X-Rite internal use only*/
            i1d3MeasModeLCDsimFixed = 6,        /**< unsupported-for X-Rite internal use only*/

            // New mode added 20Mar12 for plasmas and other pulsing displays
            i1d3MeasModeBurst = 7,
            // New measurement mode added 17Apr14 for i1Display3 devices with firmware v2.28 and later
            i1d3MeasModeAIO = 8
        }

        /// <summary>
        /// A structure to encapsulate a CIE Y,x,y data point
        /// 封装CIE Y，x，y数据点的结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct i1d3Yxy_t
        {
            double Y;       /**< Y luminance data in Cd/m2, or Lux */
            double x;       /**< x chrominance data */
            double y;       /**< y chrominance data */
            double z;		/**< z (internal use for computation purposes - Applications should not rely on this element to always be valid) */
        }
        /// <summary>
        ///	A structure to encapsulate raw, unscaled RGB data from the device.<BR>
        /// This data is uncalibrated, and sensor S/N specific.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct i1d3RGB_t
        {
            double R;       /**< Red unscaled raw data 	*/
            double G;       /**< Green unscaled raw data */
            double B;		/**< Blue unscaled raw data */
        }

        /// <summary>
        /// A structure to encapsulate XYZ data from the device
        /// 封装来自设备的XYZ数据的结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct i1d3XYZ_t
        {
            double X;       /**< X tristimulus value (1931 CIE Standard Observer) 	*/
            double Y;       /**< Y tristimulus value (1931 CIE Standard Observer) */
            double Z;		/**< Z tristimulus value (1931 CIE Standard Observer) */
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct i1d3DEVICE_INFO
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string strProductName;
            ushort usProductType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string strFirmwareVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string strFirmwareDate;
            public byte ucIsLocked;
        }

        //public IntPtr i1d3Handle;

        /// <summary>
        /// This function initializes the SDK. This call must be called before any 
        /// other i1d3 SDK calls.It must be paired with a call to i1d3Destroy.
        /// 此函数初始化SDK。 必须在其他i1d3 SDK调用之前调用此调用。
        /// </summary>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3Initialize", CallingConvention = CallingConvention.Cdecl)]
        //, CallingConvention = CallingConvention.Cdecl  , CallingConvention = CallingConvention.StdCall
        public static extern i1d3Status_t i1d3Initialize();

        /// <summary>
        /// This function cleans up the SDK; closing any open devices, and cleans up allocated memory.
        /// 该函数清理SDK； 关闭所有打开的设备，并清理分配的内存。
        /// </summary>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3Destroy", CallingConvention = CallingConvention.Cdecl)]
        //, CallingConvention = CallingConvention.Cdecl  , CallingConvention = CallingConvention.StdCall
        public static extern i1d3Status_t i1d3Destroy();

        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3OverrideDeviceDefaults", CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3OverrideDeviceDefaults(uint vid, uint pid, ref byte[] productkey);

        /// <summary>
        /// Returns the number of devices attached and enumerated on USB
        /// 返回USB上已连接并枚举的设备数
        /// </summary>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3GetNumberOfDevices", CallingConvention = CallingConvention.Cdecl)]
        //, CallingConvention = CallingConvention.Cdecl  , CallingConvention = CallingConvention.StdCall
        public static extern uint i1d3GetNumberOfDevices();

        /// <summary>
        /// Returns the device handle.
        /// 返回USB上已连接并枚举的设备数
        /// </summary>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3GetDeviceHandle",CallingConvention = CallingConvention.Cdecl)]
        //, CallingConvention = CallingConvention.Cdecl  , CallingConvention = CallingConvention.StdCall
        public static extern i1d3Status_t i1d3GetDeviceHandle(uint whichDevice, ref IntPtr i1d3Handle);

        /// <summary>
        /// This function opens a device via a handle received from i1d3GetDeviceHandle()
        /// </summary>
        /// <param name="devHndl"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3DeviceOpen", CallingConvention = CallingConvention.Cdecl)]
        //, CallingConvention = CallingConvention.Cdecl  , CallingConvention = CallingConvention.StdCall
        public static extern i1d3Status_t i1d3DeviceOpen(IntPtr devHndl);

        /// <summary>
        /// This function closes a device via a handle recieved from i1d3GetDeviceHandle()
        /// </summary>
        /// <param name="devHndl"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3DeviceClose", CallingConvention = CallingConvention.Cdecl)]
        //, CallingConvention = CallingConvention.Cdecl  , CallingConvention = CallingConvention.StdCall
        public static extern i1d3Status_t i1d3DeviceClose(IntPtr devHndl);

        /// <summary>
        /// Returns the serial number of the device.
        /// </summary>
        /// <param name="devHndl"></param>
        /// <param name="sn"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3GetSerialNumber", CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3GetSerialNumber(IntPtr devHndl, ref string sn);


        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3GetDeviceInfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3GetDeviceInfo(IntPtr devHndl, ref i1d3DEVICE_INFO infostruct);

        /// <summary>
        /// Specifies file path where SDK looks for support files.
        /// </summary>
        /// <param name="devHndl"></param>
        /// <param name="sn"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3SetSupportFilePath", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3SetSupportFilePath(IntPtr devHndl, string path);

        

        #region  Measurement Setup functions
        /// <summary>
        /// This function sets the measurement mode in the device.
        /// </summary>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3SetMeasurementMode", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3SetMeasurementMode(IntPtr devHndl, int measMode);

        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3SetIntegrationTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3SetIntegrationTime(IntPtr devHndl, double dSeconds);

        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3SetTargetLCDTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3SetTargetLCDTime(IntPtr devHndl, double dSeconds);

        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3SetMeasurementMode", CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3SetMeasurementMode(IntPtr devHndl, i1d3MeasMode_t measMode);
        #endregion

        #region  Measurement functions
        /// <summary>
        /// This function takes a measurement using the current measurement configuration, and returns the raw RGB data in a i1d3RGB_t structure.
        /// 此函数使用当前的测量配置进行测量，并以i1d3RGB_t结构返回原始RGB数据。
        /// </summary>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3MeasureRGB", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3MeasureRGB(IntPtr devHndl, ref i1d3RGB_t dRGBMeas);

        /// <summary>
        /// This function takes a measurement using the current configuration, and returns	XYZ values.
        /// 此功能使用当前配置进行测量，并返回XYZ值。
        /// </summary>
        /// <param name="devHndl"></param>
        /// <param name="dXYZmeas"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3MeasureXYZ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3MeasureXYZ(IntPtr devHndl, ref i1d3XYZ_t dXYZmeas);

        /// <summary>
        /// This function takes a measurement using the current configuration, and returns	the Yxy luminance and chrominance values.
        /// 此功能使用当前配置进行测量，并返回Yxy亮度和色度值。
        /// </summary>
        /// <param name="devHndl"></param>
        /// <param name="dYxy"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3MeasureYxy", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3MeasureYxy(IntPtr devHndl, ref i1d3Yxy_t dYxy);

        /// <summary>
        /// This function takes a measurement of ambient light using the current configuration, and returns the Yxy luminance and chrominance values.
        /// 此功能使用当前配置对环境光进行测量，并返回Yxy亮度和色度值。
        /// </summary>
        /// <param name="devHndl"></param>
        /// <param name="dYxy"></param>
        /// <returns></returns>
        [DllImport("i1d3SDK.dll", EntryPoint = "i1d3MeasureAmbient", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern i1d3Status_t i1d3MeasureAmbient(IntPtr devHndl, ref i1d3Yxy_t dYxy);

        #endregion
    }
}
