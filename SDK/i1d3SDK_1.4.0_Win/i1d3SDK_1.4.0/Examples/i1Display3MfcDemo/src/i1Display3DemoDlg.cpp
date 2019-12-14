// i1Display3DemoDlg.cpp : implementation file
//

#include <windows.h>
#include "stdafx.h"
#include "i1Display3Demo.h"
#include "i1Display3DemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// Ci1Display3DemoDlg dialog

Ci1Display3DemoDlg::Ci1Display3DemoDlg(CWnd* pParent /*=NULL*/)
: CDialog(Ci1Display3DemoDlg::IDD, pParent)
{
  //{{AFX_DATA_INIT(Ci1Display3DemoDlg)
  // NOTE: the ClassWizard will add member initialization here
  //}}AFX_DATA_INIT
  // Note that LoadIcon does not require a subsequent DestroyIcon in Win32
  m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void Ci1Display3DemoDlg::DoDataExchange(CDataExchange* pDX)
{
  CDialog::DoDataExchange(pDX);
  //{{AFX_DATA_MAP(Ci1Display3DemoDlg)
  DDX_Control(pDX, IDC_BUTTON_OPENCLOSE, m_buttonOpenClose);
  //}}AFX_DATA_MAP
  DDX_Control(pDX, IDC_CAL_COMBO, m_calCombo);
  DDX_Control(pDX, IDC_EDIT_DEVICE_NUM, m_sn);
}

BEGIN_MESSAGE_MAP(Ci1Display3DemoDlg, CDialog)
  //{{AFX_MSG_MAP(Ci1Display3DemoDlg)
  ON_BN_CLICKED(IDC_BUTTON_OPENCLOSE, OnButtonOpenClose)
  ON_WM_CLOSE()
  //}}AFX_MSG_MAP
  ON_BN_CLICKED(IDC_BUTTON_READ_DIFFUSOR_POS, &Ci1Display3DemoDlg::OnBnClickedButtonReadDiffusorPos)
  ON_CBN_SELCHANGE(IDC_CAL_COMBO, &Ci1Display3DemoDlg::OnCbnSelchangeCalCombo)
  ON_BN_CLICKED(IDC_LOAD_CUSTOM_EDR, &Ci1Display3DemoDlg::OnBnClickedLoadCustomEdr)
  ON_BN_CLICKED(IDC_BUTTON_MEASURE_AMBIENT, &Ci1Display3DemoDlg::OnBnClickedButtonMeasureAmbient)
  ON_BN_CLICKED(IDC_BUTTON_SET, &Ci1Display3DemoDlg::OnBnClickedButtonSet)
  ON_BN_CLICKED(IDC_BUTTON_MEASURE_CRT, &Ci1Display3DemoDlg::OnBnClickedButtonMeasureCrt)
  ON_BN_CLICKED(IDC_BUTTON_MEASURE_LCD, &Ci1Display3DemoDlg::OnBnClickedButtonMeasureLcd)
  ON_BN_CLICKED(IDC_BUTTON_MEASURE_BURST, &Ci1Display3DemoDlg::OnBnClickedButtonMeasureBurst)
  ON_BN_CLICKED(IDC_BUTTON_MEASURE_AIO, &Ci1Display3DemoDlg::OnBnClickedButtonMeasureAio)
  ON_BN_CLICKED(IDC_BUTTON_MEASURE_BACKLIGHT_FREQ, &Ci1Display3DemoDlg::OnBnClickedButtonMeasureBacklightFreq)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// Ci1Display3DemoDlg message handlers


/***************************************************************************************

This program demonstrates how to use the basic functions of the i1Display3 SDK. 
All functions of interest begin with "i1d3". All other code supports user interactions.

Specific features shown within this program include the following:

1) Opening and initializing the SDK and the device itself. When opened, the device's
automatically selected calibration matrix will be the CMF-derived matrix unless
the device has not been initialized in the factory in which case an identity
matrix will be provided.

2) The ability to perform emissive measurements in either period mode or frequency mode.
Period mode is generally used to measure a device for a specified integration
time and is used for displaye without flicker (such as an LCD).
Frequency mode is generally used to measure a device with flicker such as a CRT.

Fields are provided into which the program's user may specify the integration and
measurement times but these have default values and need only be changed if
the defaults are too long or short for the application. (Generally the 1 second
default values are suitable.)

When one of the measurement buttons is pressed, the current time settings are
passed to the SDK but need not be sent unless overridden.

The resulting measurement data is displayed in both Yxy values (luminance in nits
(a.k.a. Candelas per square meter) and XYZ values.

3) The ability to perform ambient measurements. (Period and/or frequency mode settings
apply as they did for emissive measurements.

Ambient measurement results are in Yxy format with luminance in lux.

4) A listing of all of the available calibrations available to the SDK for this device
is provided through the use of the i1d3GetCalibrationList function. All of the
calibrations known to the the device are listed in the listbox. Selection of any
of them will immediately cause the associated matrix to be selected in the device
and all subsequent measurements will use that matrix.

There are three sources of calibration data:
a) The CMF-derived default matrix
b) Generic display-type matrices (as provided along with the SDK)
c) User-specified matrix data (targetted for a specific display)

5) The ability to provide display-specific calibration data is provided with the
i1d3SetCalibrationFromFile() function which is called when the user presses
the "Load Custom EDR File" button. A file dialog box is opened with which the
user may select the EDR file from which a matrix is to be calculated. If the
file is valid, the newly calculated matrix will appear in the listbox and
will be selected as the current matrix for measurements.

6) The position of the ambient diffuser may be determined from the SDK at any time
that the device is opened. This is a single read of the position and doesn't
update as the position is changed. To remain up-to-date, the application may
choose to periodically poll the position.


***************************************************************************************/


BOOL Ci1Display3DemoDlg::OnInitDialog()
{
  CDialog::OnInitDialog();

  SetIcon(m_hIcon, TRUE);			// Set big icon
  SetIcon(m_hIcon, FALSE);		// Set small icon

  strcpy (m_technologyStringFile, "..\\i1d3 Support Files\\TechnologyStrings.txt");

  i1d3Initialize();
  m_bIsOpen = FALSE;

  // update the dialog window with s/w version and toolkit version
  CString	s;
  char	m_cBuf[128];

  GetWindowText(s);
  s += " v";
  s += VERSION;
  i1d3GetToolkitVersion(m_cBuf);
  s += "; SDK Version: ";
  s += m_cBuf;
  SetWindowText(s);

  SetDlgItemText(IDC_EDIT_INTTIME_SECONDS, "1.000");
  SetDlgItemText(IDC_EDIT_TARGET_TIME, "1.000");

  CheckRadioButton(IDC_RADIO_OFF, IDC_RADIO_PULSE, IDC_RADIO_PULSE);
  SetDlgItemText(IDC_EDIT_LED_OFF_TIME, "7.5");
  SetDlgItemText(IDC_EDIT_LED_ON_TIME, "1.4");
  SetDlgItemText(IDC_EDIT_LED_REPS, "128");

  return TRUE;  // return TRUE  unless you set the focus to a control
}


void Ci1Display3DemoDlg::OnButtonOpenClose() 
{
  CWaitCursor	wait;

  m_calCombo.ResetContent();

  if(m_bIsOpen == FALSE)
  {
    i1d3Destroy();
    m_err=i1d3Initialize();

    int ii = i1d3GetNumberOfDevices();

    if(i1d3GetNumberOfDevices() == 0)
    {
      MessageBox("No i1d3 devices found!");
      return;
    }

    // At least one device found. Open the first.
    m_err=i1d3GetDeviceHandle(0, &m_hi1d3);
    if(m_err != i1d3Success)
    {
      CString s;
      s.Format("Error %d", m_err);
      MessageBox("Error getting handle!", s);
      return;
    }

    i1d3SetSupportFilePath(m_hi1d3,"..\\i1d3 Support Files");

    // Try to open without a product key. If that fails,
    // try the standard i1d3 key.
    if (i1d3DeviceOpen(m_hi1d3) != i1d3Success)
    {
      unsigned char key[] = { 0xD4,0x9F,0xD4,0xA4,0x59,0x7E,0x35,0xCF };
      i1d3OverrideDeviceDefaults(NULL,NULL,key);
      m_err=i1d3DeviceOpen(m_hi1d3);
    }

    if(m_err != i1d3Success)
    {
      CString s;
      s.Format("Error %d", m_err);
      MessageBox("Error opening i1d3!", s);
      return;
    }

    // Display the serial number.
    char sn[21];
    i1d3GetSerialNumber(m_hi1d3, &sn[0]);
    SetDlgItemText(IDC_EDIT_DEVICE_NUM, sn);

    i1d3DEVICE_INFO info;
    //read device information to obtain firmware version
    i1d3GetDeviceInfo(m_hi1d3, &info);
    SetDlgItemText(IDC_EDIT_FIRMWARE_VER, info.strFirmwareVersion);

    m_bIsOpen = TRUE;
    m_buttonOpenClose.SetWindowText("Close");

    if(i1d3SupportsAIOMode(m_hi1d3) != i1d3Success) {
      GetDlgItem(IDC_BUTTON_MEASURE_AIO)->EnableWindow(FALSE);
      GetDlgItem(IDC_BUTTON_MEASURE_BACKLIGHT_FREQ)->EnableWindow(FALSE);
    }

    LoadCalibrationList();
  }
  else
  {
    // Close the device.
    i1d3DeviceClose(m_hi1d3);
    m_bIsOpen = FALSE;
    SetDlgItemText(IDC_EDIT_DEVICE_NUM, "");
    SetDlgItemText(IDC_EDIT_FIRMWARE_VER, "");
    m_buttonOpenClose.SetWindowText("Open");
    GetDlgItem(IDC_BUTTON_MEASURE_AIO)->EnableWindow(TRUE);
    GetDlgItem(IDC_BUTTON_MEASURE_BACKLIGHT_FREQ)->EnableWindow(TRUE);
  }
}

void Ci1Display3DemoDlg::OnClose() 
{
  if(m_bIsOpen == true)
    i1d3DeviceClose(m_hi1d3);

  i1d3Destroy();

  CDialog::OnClose();
}

bool Ci1Display3DemoDlg::DiffuserInEmissiveMeasurementPosition()
{
  unsigned char ucDiffuser;
  if((m_err=i1d3ReadDiffuserPosition(m_hi1d3, &ucDiffuser)) != i1d3Success)
  {
    CString s;
    s.Format("Error %ld", m_err);
    MessageBox(s);
    return false;
  }
  return ucDiffuser ? false:true;
}

void Ci1Display3DemoDlg::OnBnClickedButtonMeasureLcd() 
{
  CWaitCursor	wait;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if (!DiffuserInEmissiveMeasurementPosition())
  {
    MessageBox("Diffuser is not in correct position for measurement.", "Error");
    return;
  }

  // Integration time
  GetDlgItemText(IDC_EDIT_INTTIME_SECONDS, s);
  double dIntTime = (double)atof(s);
  i1d3SetIntegrationTime(m_hi1d3, dIntTime);

  // LCD target time
  GetDlgItemText(IDC_EDIT_TARGET_TIME, s);
  double dTargetTime = (double)atof(s);
  i1d3SetTargetLCDTime(m_hi1d3, dTargetTime);

  m_MeasMode = i1d3MeasModeLCD;
  i1d3SetMeasurementMode(m_hi1d3, m_MeasMode);

  GetDlgItemText(IDC_EDIT_TARGET_TIME, s);
  dTargetTime = (double)atof(s);

  i1d3SetTargetLCDTime(m_hi1d3, dTargetTime);
  m_err = i1d3Measure(m_hi1d3, m_LumUnits, m_MeasMode, &m_dYxyMeas);

  if(m_err != i1d3Success)
  {
    s.Format("Error %ld", m_err);
    MessageBox(s);
    return;
  }

  DisplayEmissiveResults();
}


void Ci1Display3DemoDlg::OnBnClickedButtonReadDiffusorPos()
{
  unsigned char	ucPos;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  i1d3ReadDiffuserPosition(m_hi1d3, &ucPos);

  if(ucPos)
    SetDlgItemText(IDC_STATIC_DIFFUSOR_POS, "On");
  else
    SetDlgItemText(IDC_STATIC_DIFFUSOR_POS, "Off");
}


void Ci1Display3DemoDlg::OnCbnSelchangeCalCombo()
{
  int indexToSelect = m_calCombo.GetCurSel();
  TRACE ("CurSel:%d\n",indexToSelect);

  // Now select the calibration that matches up with our listbox position

  i1d3CALIBRATION_LIST *calList;
  int numCals;
  i1d3GetCalibrationList(m_hi1d3, &numCals, &calList);

  i1d3SetCalibration(m_hi1d3, calList->cals[indexToSelect]);

  m_calCombo.SetTopIndex(indexToSelect);
}


void Ci1Display3DemoDlg::OnBnClickedLoadCustomEdr()
{
  if(m_bIsOpen == FALSE)
  {
    MessageBeep(-1);
    return;
  }

  // Open a file browser and allow user to select an EDR file.

  char curPath[MAX_PATH];
  CString fileName;

  GetCurrentDirectory(MAX_PATH, curPath);
  strcat(curPath, "\\*.edr");

  CFileDialog dlg(TRUE, NULL, curPath, 0, "*.edr", NULL);

  if (dlg.DoModal() == IDOK)
  {
    fileName = dlg.GetPathName();
    TRACE("filename:%s\n",fileName);

    long res=i1d3SetCalibrationFromFile(m_hi1d3, (unsigned char*)fileName.GetBuffer(0));

    if (res == i1d3Success)
      LoadCalibrationList();
    else
    {
      char errString[64];
      sprintf(errString,"error %d in EDR file operation", res);
      MessageBox(errString, "EDR File Data",MB_ICONEXCLAMATION);
    }
  }
}

void Ci1Display3DemoDlg::LoadCalibrationList()
{
  // Get the list of calibrations currently available in the
  // i1d3 and add their keys to the listbox for selection.
  int numCals;
  i1d3CALIBRATION_LIST *calList;
  i1d3CALIBRATION_ENTRY *currentCal;
  i1d3GetCalibration(m_hi1d3,&currentCal);
  i1d3GetCalibrationList(m_hi1d3, &numCals, &calList);

  m_calCombo.ResetContent();

  int i;
  i1d3CALIBRATION_ENTRY *entry;
  for (i=0; i< numCals; i++)
  {
    entry = calList->cals[i];
    // Add the name to the listbox

    // If this is a generic EDR file and we have the TechnologyStrings.txt
    // file, and there is an entry within it for this technology, 
    // use that string as the identifier in the listbox. 
    // Otherwise, we'll call it "Generic Type n" where 'n' is the
    // type.
    if (entry->calSource == CS_GENERIC_DISPLAY)
    {
      char techString[32];
      GetTechnologyString(entry->edrDisplayType, techString);

      TRACE ("<%s>\n",techString);
      m_calCombo.AddString(techString);
    }
    else
    {
      TRACE ("<%s>\n",entry->key);
      m_calCombo.AddString(entry->key);
    }

    if (entry == currentCal)
    {
      int numEntries = m_calCombo.GetCount();
      m_calCombo.SetTopIndex(numEntries-1);
      m_calCombo.SetCurSel(numEntries-1);
    }
  }
}

bool Ci1Display3DemoDlg::GetTechnologyString(int type, char *strToReturn)
{
  if (!strToReturn)
    return false;

  // Look for the file TechnologyStrings.txt which we're using from the
  // directory in which this program is located. If it is found, look for
  // an entry for the 'type' passed in. If not found, return a generic
  // string which includes that type number.

  FILE *fp = fopen (m_technologyStringFile, "r");
  bool found = false;
  bool eof = false;
  int idxFound;
  char str[64];
  char *buf = &str[0];

  if (fp)
  {
    while (!found && !eof)
    {
      if (fscanf(fp, "%d,%[^\r\n]*", &idxFound, &str) != 2)
      {
        eof = true;
      }
      else 
      {
        if (idxFound == type)
        {
          strcpy(strToReturn, str);
          fclose(fp);
          return true;
        }
      }
    }
    // EOF seen without a match
    fclose(fp);
    sprintf (strToReturn, "Generic display Type %d", type);
    return true;
  }
  sprintf (strToReturn, "Generic Display Type %d", type);
  return true;
}

void Ci1Display3DemoDlg::OnBnClickedButtonMeasureCrt()
{
  CWaitCursor	wait;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if (!DiffuserInEmissiveMeasurementPosition())
  {
    MessageBox("Diffuser is not in correct position for measurement.", "Error");
    return;
  }

  // Integration time
  GetDlgItemText(IDC_EDIT_INTTIME_SECONDS, s);
  double dIntTime = (double)atof(s);
  i1d3SetIntegrationTime(m_hi1d3, dIntTime);

  i1d3SetMeasurementMode(m_hi1d3, i1d3MeasModeCRT);

  GetDlgItemText(IDC_EDIT_INTTIME_SECONDS, s);
  dIntTime = (double)atof(s);
  i1d3SetIntegrationTime(m_hi1d3, dIntTime);

  m_err = i1d3Measure(m_hi1d3, m_LumUnits, i1d3MeasModeCRT, &m_dYxyMeas);

  if(m_err != i1d3Success)
  {
    s.Format("Error %ld", m_err);
    MessageBox(s);
    return;
  }
  DisplayEmissiveResults();
}

void Ci1Display3DemoDlg::DisplayEmissiveResults()
{
  s.Format("%0.4lf", m_dYxyMeas.x);
  SetDlgItemText(IDC_MEAS_X, s);

  s.Format("%0.4lf", m_dYxyMeas.y);
  SetDlgItemText(IDC_MEAS_Y, s);

  s.Format("%0.4lf", m_dYxyMeas.Y);
  SetDlgItemText(IDC_MEAS_L, s);

  i1d3GetLastMeasurement(m_hi1d3, i1d3ColorSpaceXYZ, i1d3LumUnitsNits, &m_dXYZMeas);
  s.Format("%0.4lf", m_dXYZMeas.X);
  SetDlgItemText(IDC_MEAS_CAP_X, s);

  s.Format("%0.4lf", m_dXYZMeas.Y);
  SetDlgItemText(IDC_MEAS_CAP_Y, s);

  s.Format("%0.4lf", m_dXYZMeas.Z);
  SetDlgItemText(IDC_MEAS_CAP_Z, s);
}

void Ci1Display3DemoDlg::OnBnClickedButtonMeasureAmbient()
{
  // Read the diffuser position and inform caller if not correct
  // for ambient measurement. If in correct position, do the measurement
  // and display on the screen.
  // We also demonstrate how to disable and re-enable the LED settings
  // around the measurement operation.

  CWaitCursor	wait;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if (DiffuserInEmissiveMeasurementPosition())
  {
    MessageBox("Diffuser is not in correct position for measurement.", "Error");
    return;
  }

  m_err = i1d3MeasureAmbient(m_hi1d3, &m_ambientMeas);

  s.Format("%0.4lf", m_ambientMeas.x);
  SetDlgItemText(IDC_MEAS_AMBIENT_X, s);

  s.Format("%0.4lf", m_ambientMeas.y);
  SetDlgItemText(IDC_MEAS_AMBIENT_Y, s);

  s.Format("%0.2lf lux", m_ambientMeas.Y);
  SetDlgItemText(IDC_MEAS_AMBIENT_L, s);

}

void Ci1Display3DemoDlg::OnBnClickedButtonSet()
{
  CString	s;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if(IsDlgButtonChecked(IDC_RADIO_OFF))
    m_LEDconfig.Ctrl = i1d3LED_OFF;
  else if(IsDlgButtonChecked(IDC_RADIO_FLASH))
    m_LEDconfig.Ctrl = i1d3LED_FLASH;
  else if(IsDlgButtonChecked(IDC_RADIO_PULSE))
    m_LEDconfig.Ctrl = i1d3LED_PULSE;

  GetDlgItemText(IDC_EDIT_LED_OFF_TIME, s);
  m_LEDconfig.dOff = (double)atof(s);

  GetDlgItemText(IDC_EDIT_LED_ON_TIME, s);
  m_LEDconfig.dOn = (double)atof(s);

  GetDlgItemText(IDC_EDIT_LED_REPS, s);
  m_LEDconfig.ucCount = (unsigned char)atoi(s);

  if((m_err=i1d3SetLEDControl(m_hi1d3, m_LEDconfig.Ctrl, m_LEDconfig.dOff, m_LEDconfig.dOn, m_LEDconfig.ucCount)) != i1d3Success)
  {
    CString s;
    s.Format("Error %ld", m_err);
    MessageBox(s);
    return;
  }

  i1d3GetLEDControlSettings(m_hi1d3, &m_LEDconfig.Ctrl, &m_LEDconfig.dOff, &m_LEDconfig.dOn, &m_LEDconfig.ucCount);

  s.Format("%0.4f", m_LEDconfig.dOff);
  SetDlgItemText(IDC_EDIT_LED_OFF_TIME, s);

  s.Format("%0.4f", m_LEDconfig.dOn);
  SetDlgItemText(IDC_EDIT_LED_ON_TIME, s);

  s.Format("%d", m_LEDconfig.ucCount);
  SetDlgItemText(IDC_EDIT_LED_REPS, s);
}


void Ci1Display3DemoDlg::OnBnClickedButtonMeasureBurst()
{
  CWaitCursor	wait;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if (!DiffuserInEmissiveMeasurementPosition())
  {
    MessageBox("Diffuser is not in correct position for measurement.", "Error");
    return;
  }

  // Integration time
  GetDlgItemText(IDC_EDIT_INTTIME_SECONDS, s);
  double dIntTime = (double)atof(s);
  i1d3SetIntegrationTime(m_hi1d3, dIntTime);

  // LCD target time
  GetDlgItemText(IDC_EDIT_TARGET_TIME, s);
  double dTargetTime = (double)atof(s);
  i1d3SetTargetLCDTime(m_hi1d3, dTargetTime);

  m_MeasMode = i1d3MeasModeBurst;
  i1d3SetMeasurementMode(m_hi1d3, m_MeasMode);

  m_err = i1d3Measure(m_hi1d3, m_LumUnits, m_MeasMode, &m_dYxyMeas);

  if(m_err != i1d3Success)
  {
    s.Format("Error %ld", m_err);
    MessageBox(s);
    return;
  }

  DisplayEmissiveResults();
}

void Ci1Display3DemoDlg::OnBnClickedButtonMeasureAio()
{
  CWaitCursor	wait;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if (!DiffuserInEmissiveMeasurementPosition())
  {
    MessageBox("Diffuser is not in correct position for measurement.", "Error");
    return;
  }

  // Integration time
  GetDlgItemText(IDC_EDIT_INTTIME_SECONDS, s);
  double dIntTime = (double)atof(s);
  i1d3SetIntegrationTime(m_hi1d3, dIntTime);

  // LCD target time
  GetDlgItemText(IDC_EDIT_TARGET_TIME, s);
  double dTargetTime = (double)atof(s);
  i1d3SetTargetLCDTime(m_hi1d3, dTargetTime);

  m_err = i1d3Measure (m_hi1d3, i1d3LumUnitsNits, i1d3MeasModeAIO, &m_dYxyMeas);
  if(m_err != i1d3Success)
  {
    s.Format("Error (i1d3Measure): %ld", m_err);
    MessageBox(s);
    return;
  }

  DisplayEmissiveResults();
}

/*
Attention: The purpose of this function is to demonstrate how to obtain a
display's refresh rate and does not cover all possible scenaries
with multiple displays. E.g. an application might be displayed across more
than one display. Make sure to obtain the refresh rate of the display
the measurement will be run on.

For more information on the Windows function used below, see here:
http://msdn.microsoft.com/en-us/library/dd162611%28v=VS.85%29.aspx
*/
unsigned short Ci1Display3DemoDlg::GetDisplayRefreshRate()
{
  LPCWSTR lpszDeviceName = NULL;
  DWORD iModeNum = ENUM_CURRENT_SETTINGS;
  DEVMODEW lpDevMode;

  lpDevMode.dmSize = sizeof(DEVMODE);
  lpDevMode.dmDriverExtra = 0;

  EnumDisplaySettingsW(lpszDeviceName, iModeNum, &lpDevMode);

  return (unsigned short)lpDevMode.dmDisplayFrequency;
}

void Ci1Display3DemoDlg::OnBnClickedButtonMeasureBacklightFreq()
{
  CWaitCursor	wait;

  if(m_bIsOpen == FALSE)
  {
    MessageBox("No device open");
    return;
  }

  if (!DiffuserInEmissiveMeasurementPosition())
  {
    MessageBox("Diffuser is not in correct position for measurement.", "Error");
    return;
  }

  unsigned short backlightFreqHz = 0;
  unsigned short correctedBacklightFreqHz = 0;
  unsigned short refreshRateHz = 0;

  m_err = i1d3MeasureBacklightFrequency(m_hi1d3, &backlightFreqHz);
  if(m_err != i1d3Success)
  {
    s.Format("Error (i1d3MeasureBacklightFrequency): %ld", m_err);
    MessageBox(s);
    return;
  }

  switch (backlightFreqHz)
  {
  case 0:
    {
      m_err = i1d3SetBacklightFreq(m_hi1d3, 0);
      m_err = i1d3SetBacklightFreqSync(m_hi1d3, backlightSyncOff);

      s.SetString("Stable");
      SetDlgItemText(IDC_DISPLAY_BACKLIGHT_FREQ, s);

      s.SetString("OFF");
      SetDlgItemText(IDC_DISPLAY_BACKLIGHT_SYNC, s);

      s.SetString("");
      SetDlgItemText(IDC_DISPLAY_REFRESH_RATE, s);

    } break;
  case 1:
    {
      s.SetString("");
      SetDlgItemText(IDC_DISPLAY_BACKLIGHT_FREQ, s);
      SetDlgItemText(IDC_DISPLAY_BACKLIGHT_SYNC, s);
      SetDlgItemText(IDC_DISPLAY_REFRESH_RATE, s);

      s.Format("Error: measurement to dark, please measure a white patch at full display brightness.");
      MessageBox(s);
      return;
    } break;
  default:
    {
      refreshRateHz = GetDisplayRefreshRate(); // setting a default value, should be the actual refresh rate of the display

      // The display's backlight frequency must be an integer multiple of the displays's refresh rate.
      // remove any decimal places using an integer division
      correctedBacklightFreqHz = ( backlightFreqHz / refreshRateHz ) * refreshRateHz;

      m_err = i1d3SetBacklightFreq(m_hi1d3, correctedBacklightFreqHz);
      m_err = i1d3SetBacklightFreqSync(m_hi1d3, backlightSyncOn);

      s.Format("%d Hz", correctedBacklightFreqHz);
      SetDlgItemText(IDC_DISPLAY_BACKLIGHT_FREQ, s);

      s.SetString("ON");
      SetDlgItemText(IDC_DISPLAY_BACKLIGHT_SYNC, s);

      s.Format("@%d Hz", refreshRateHz);
      SetDlgItemText(IDC_DISPLAY_REFRESH_RATE, s);
    }
  }
}