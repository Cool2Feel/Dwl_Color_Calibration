// i1Display3CmdDemo.cpp : Defines the entry point for the console application.
//
#if defined ( _WIN32 )
  #include "windows.h"
  #include <direct.h>
  int _tmain(int argc, char* argv[])
  {
    return 0;
  }
#elif defined ( __GNUC__ )
  #include <unistd.h>
  #include <stdbool.h>
  // usleep(n) sleeps for n _micro_seconds
  #define Sleep(xMilliseconds) usleep(1000 * (xMilliseconds))
#endif

#include <cstdlib>
#include <cstdio>
#include <cstring>
#include <iostream>
#include <iomanip>
#include <string>
#include "i1d3SDK.h"

i1d3Handle m_hi1d3;
i1d3Status_t m_err;
i1d3Yxy_t m_dYxyMeas;
unsigned long m_errLong;

#ifndef RESOURCE_PATH
  #define RESOURCE_PATH "../i1d3 Support Files/" // Must have trailing '/'
#endif

#define TECHNOLOGY_STRING_FILE RESOURCE_PATH"TechnologyStrings.txt"

void CheckStatus(const char *txt)
{
  if (m_err)
  {
    std::cout << txt << " returned " << m_err << std::endl;
    std::cout << "EXITING, press return..." << std::endl;
    i1d3Destroy();
    std::cin.get();
    exit(-1);
  }
  std::cout << txt << ": OK" << std::endl;
}

bool GetTechnologyString(int type, char *strToReturn)
{
  if (!strToReturn)
    return false;

  // Look for the file TechnologyStrings.txt which we're using from the
  // directory in which this program is located. If it is found, look for
  // an entry for the 'type' passed in. If not found, return a generic
  // string which includes that type number.

  FILE *fp = fopen (TECHNOLOGY_STRING_FILE, "r");
  bool found = false;
  bool eof = false;
  int idxFound;
  char str[64];

  if (fp)
  {
    while (!found && !eof)
    {
      if (fscanf(fp, "%d,%[^\r\n]*", &idxFound, &str[0]) != 2)
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

char calName[32];
char *GetCalName(i1d3CALIBRATION_ENTRY *cal)
{
  if ((cal->calSource == CS_GENERIC_DISPLAY) &&
    (GetTechnologyString(cal->edrDisplayType, calName)))
    return calName;
  return (cal->key);
}

int main (int argc, char * const argv[])
{
  char wd[2000];
#if defined( _WIN32 )
  _getcwd(wd, 2000);
#else
  getcwd(wd, 2000);
#endif
  std::cout << "Working Directory: " << wd << std::endl;
  std::cout << "i1Display3 command-line demonstration program" << std::endl;

#if defined ( __x86_64__ ) || defined ( _WIN64 )
  std::cout << "(Running in 64-bit mode)" << std::endl;
#else
  std::cout << "(Running in 32-bit mode)" << std::endl;
#endif

  char *version = i1d3GetToolkitVersion(NULL);
  std::cout << "SDK Version: " << version << std::endl;
  m_err = i1d3Initialize();
  CheckStatus("i1d3Initialize");

  int i = i1d3GetNumberOfDevices();
  std::cout << "Number of devices reported = " << i << std::endl;
  if (i==0)
  {
    std::cout << "Exiting since there are no devices connected" << std::endl;
    return -1;
  }
  m_err = i1d3GetDeviceHandle(0, &m_hi1d3);
  CheckStatus("i1d3GetDeviceHandle");



  //to access device info only quick open is necessary
  m_err = i1d3DeviceQuickOpen(m_hi1d3);
  CheckStatus("i1d3DeviceQuickOpen");

  i1d3DEVICE_INFO info;
  //read device information to obtain firmware version
  m_err = i1d3GetDeviceInfo(m_hi1d3, &info);
  CheckStatus("i1d3GetDeviceInfo");
  std::cout << "Firmware Version: " << info.strFirmwareVersion << std::endl;

  // Attempt to open the i1d3 with the OEM product key
  // If that fails, try to use the "null" product key.
  unsigned char ucOEM[] = {0xD4,0x9F,0xD4,0xA4,0x59,0x7E,0x35,0xCF,0};
  i1d3OverrideDeviceDefaults(0,0,ucOEM );

  //fully open device
  m_err = i1d3DeviceOpen(m_hi1d3);
  if (m_err != i1d3Success)
  {
    unsigned char ucNull [] = {0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0};
    std::cout << "Could not open device with OEM product key" << std::endl;
    std::cout << "Trying with null product key" << std::endl;
    i1d3OverrideDeviceDefaults(0,0,ucNull);
    m_err = i1d3DeviceOpen (m_hi1d3);
    if (m_err == i1d3Success)
      std::cout << "i1d3 successfully opened" << std::endl;
    else
    {
      std::cout << "i1d3 could not be opened" << std::endl;
      CheckStatus("i1d3DeviceOpen");
    }
  }

  char sn[30];
  m_err = i1d3GetSerialNumber(m_hi1d3, sn);
  CheckStatus("i1d3GetSerialNumber");
  std::cout << "Serial Number: " << sn << std::endl << std::endl;

  int numCals, originalNumCals;
  i1d3CALIBRATION_LIST *calList;
  i1d3CALIBRATION_ENTRY *currentCal;

  m_err = i1d3GetCalibration (m_hi1d3, &currentCal);
  CheckStatus("Attempting to get current calibration...");
  // Got the calibration so we printf information about it
  std::cout << "Current calibration key: <" << GetCalName(currentCal) << ">" << std::endl;

  m_err = i1d3GetCalibrationList(m_hi1d3, &numCals, &calList);
  std::cout << "Before setting resource path, number of calibrations: " << numCals << std::endl;

  std::cout << "List of calibrations:" << std::endl;
  for (i=0;i<numCals;i++)
    std:: cout << " <" << GetCalName(calList->cals[i]) << ">" << std::endl;

  originalNumCals = numCals;
  m_err = i1d3SetSupportFilePath(m_hi1d3, RESOURCE_PATH);
  std::cout << "Setting file path to: " << RESOURCE_PATH;
  CheckStatus("");

  m_err = i1d3GetCalibrationList(m_hi1d3, &numCals, &calList);
  CheckStatus("i1d3GetCalibrationList");
  std::cout << std::endl;

  std::cout << "After setting support file path, number of cals: " << numCals << std::endl;

  if (numCals != originalNumCals)
  {
    std:: cout << "list of calibrations:" << std::endl;
    for (i=0;i<numCals;i++)
      std::cout << " <" << GetCalName(calList->cals[i]) << ">" << std::endl;
  }

  if (numCals >= 2)
  {
    std::cout << "Selecting calibration " << GetCalName(calList->cals[numCals-2]) << "...";
    m_err = i1d3SetCalibration (m_hi1d3, calList->cals[numCals-2]);
    CheckStatus("");
  }

  m_err = i1d3GetCalibration (m_hi1d3, &currentCal);
  CheckStatus("i1d3GetCalibration");
  std::cout << "Current calibration key: <" << GetCalName(currentCal) << ">" << std::endl << std::endl;

  unsigned char curDiffuserPos;
  m_err = i1d3ReadDiffuserPosition(m_hi1d3, &curDiffuserPos);
  CheckStatus("i1d3ReadDiffuserPosition");

  if (curDiffuserPos == 0)
  {
    std::cout << "Diffuser is off, please put it in place for ambient measurement" << std::endl;
    fflush(stdout);
    while (curDiffuserPos == 0)
    {
      Sleep(1000);
      m_err = i1d3ReadDiffuserPosition(m_hi1d3, &curDiffuserPos);
      if(m_err != i1d3Success) {
        CheckStatus("i1d3ReadDiffuserPosition");
      }
    }
  }

  m_err = i1d3MeasureAmbient(m_hi1d3, &m_dYxyMeas);
  CheckStatus("Measuring ambient...");

  std::cout << "--->" << std::fixed
            << " Y:" << std::setprecision(2) << m_dYxyMeas.Y
            << " x:" << std::setprecision(3) << m_dYxyMeas.x
            << " y:" << std::setprecision(3) << m_dYxyMeas.y
            << std::endl
            << std::endl;

  std::cout << "Please remove diffuser for normal measurement" << std::endl;
  while (curDiffuserPos == 1) {
    m_err = i1d3ReadDiffuserPosition(m_hi1d3, &curDiffuserPos);
    if(m_err != i1d3Success) {
      CheckStatus("i1d3ReadDiffuserPosition");
    }
  }

  std::cout << "Place i1display3 on screen and press return..." << std::endl;
  std::cin.get();
  for (i = 1; i < numCals; i++)
  {
    m_err = i1d3SetCalibration (m_hi1d3, calList->cals[i]);
    CheckStatus("i1d3SetCalibration");

    m_err = i1d3Measure (m_hi1d3, i1d3LumUnitsNits, i1d3MeasModeCRT, &m_dYxyMeas);
    CheckStatus("Measuring with measure mode: i1d3MeasModeCRT...");
    std::cout << GetCalName(calList->cals[i]) << "--->"
              << " Y:" << std::setprecision(2) << m_dYxyMeas.Y
              << " x:" << std::setprecision(3) << m_dYxyMeas.x
              << " y:" << std::setprecision(3) << m_dYxyMeas.y
              << std::endl;


    m_err = i1d3Measure (m_hi1d3, i1d3LumUnitsNits, i1d3MeasModeLCD, &m_dYxyMeas);
    CheckStatus("Measuring with measure mode: i1d3MeasModeLCD...");
    std::cout << GetCalName(calList->cals[i]) << "--->"
              << " Y:" << std::setprecision(2) << m_dYxyMeas.Y
              << " x:" << std::setprecision(3) << m_dYxyMeas.x
              << " y:" << std::setprecision(3) << m_dYxyMeas.y
              << std::endl;


    m_err = i1d3Measure (m_hi1d3, i1d3LumUnitsNits, i1d3MeasModeBurst, &m_dYxyMeas);
    CheckStatus("Measuring with measure mode: i1d3MeasModeBurst...");
    std::cout << GetCalName(calList->cals[i]) << "--->"
              << " Y:" << std::setprecision(2) << m_dYxyMeas.Y
              << " x:" << std::setprecision(3) << m_dYxyMeas.x
              << " y:" << std::setprecision(3) << m_dYxyMeas.y
              << std::endl;

    if(i1d3SupportsAIOMode(m_hi1d3) == i1d3Success)
    {
      m_err = i1d3Measure (m_hi1d3, i1d3LumUnitsNits, i1d3MeasModeAIO, &m_dYxyMeas);
      CheckStatus("Measuring with measure mode: i1d3MeasModeAIO...");
      std::cout << GetCalName(calList->cals[i]) << "--->"
                << " Y:" << std::setprecision(2) << m_dYxyMeas.Y
                << " x:" << std::setprecision(3) << m_dYxyMeas.x
                << " y:" << std::setprecision(3) << m_dYxyMeas.y
                << std::endl;
    }
  }

  if(i1d3SupportsAIOMode(m_hi1d3) == i1d3Success)
  {
    std::cout << std::endl
              << std::endl
              << "Running AIO mode with advanced functionality..."
              << std::endl;

    unsigned short backlightFreqHz = 0;
    unsigned short correctedBacklightFreqHz = 0;
    unsigned short refreshRateHz = 0;

    std::cout << "This should be done on a white display!"
              << std::endl
              << "Press return to start the measurement...";
    std::cin.get();
    m_err = i1d3MeasureBacklightFrequency(m_hi1d3, &backlightFreqHz);
    CheckStatus("i1d3MeasureBacklightFrequency");

    switch (backlightFreqHz)
    {
    case 0:
      {
        std::cout 
          << "The display seems to have a stable backlight "
          << "or a very high backlight frequency."
          << "No need to sync measurement to it."
          << std::endl;

        m_err = i1d3SetBacklightFreq(m_hi1d3, 0);
        CheckStatus("Setting backlight frequency to 0...");

        m_err = i1d3SetBacklightFreqSync(m_hi1d3, backlightSyncOff);
        CheckStatus("Turning off backlight synchronization...");

      } break;
    case 1:
      {
        std::cout 
          << "The display is too dark to measure the "
          << "backlight frequency, try remeasuring with "
          << "different settings."
          << std::endl;
      }
    default:
      {
        std::cout << "The display's backlight is not stable." << std::endl;
        std::cout << "Measured backlight frequency: " << backlightFreqHz << "Hz" << std::endl;

        refreshRateHz = 60; // setting a default value, should be the actual refresh rate of the display
        std::cout << "Assumed display refresh rate: " << refreshRateHz << "Hz" << std::endl;

        // The display's backlight frequency must be an integer multiple of the displays's refresh rate.
        // remove any decimal places using an integer division
        correctedBacklightFreqHz = ( backlightFreqHz / refreshRateHz ) * refreshRateHz;
        std::cout << "Corrected backlight frequency: " << correctedBacklightFreqHz << "Hz" << std::endl;

        m_err = i1d3SetBacklightFreq(m_hi1d3, correctedBacklightFreqHz);
        CheckStatus("Set backlight frequency...");

        m_err = i1d3SetBacklightFreqSync(m_hi1d3, backlightSyncOn);
        CheckStatus("Turning on backlight synchronization...");
      }
    } 

    m_err = i1d3Measure (m_hi1d3, i1d3LumUnitsNits, i1d3MeasModeAIO, &m_dYxyMeas);
    CheckStatus("Measuring with measure mode: i1d3MeasModeAIO...");
        
    std::cout << "--->"
              << " Y:" << std::setprecision(2) << m_dYxyMeas.Y
              << " x:" << std::setprecision(3) << m_dYxyMeas.x
              << " y:" << std::setprecision(3) << m_dYxyMeas.y
              << std::endl;
  }


  /*************************** Selecting the White LED EDR file ***********************/
  std::cout << std::endl;
  for (i = 1; i < numCals; i++)
  {
    if ((calList->cals[i]->calSource == CS_GENERIC_DISPLAY) && (calList->cals[i]->edrDisplayType == 9))
    {
      m_err = i1d3SetCalibration (m_hi1d3, calList->cals[i]);
      CheckStatus("i1d3SetCalibration");
      break;
    }
  }
  // For debug, verify that the calibration we wanted is what we got...
  m_err = i1d3GetCalibration (m_hi1d3, &currentCal);
  CheckStatus("i1d3GetCalibration");
  std::cout << "Selected calibration key: <" << GetCalName(currentCal) << ">" << std::endl;
  /***********************************************************************************/
  i1d3Destroy();
  std::cout << "End of program, press return" << std::endl;
  std::cin.get();
  return 0;
}
