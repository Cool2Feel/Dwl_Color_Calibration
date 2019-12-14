// i1Display3DemoDlg.h : header file
//

#if !defined(AFX_I1DISPLAY3DEMODLG_H__094584F4_71C3_4311_B018_9E2D0CD28DB6__INCLUDED_)
#define AFX_I1DISPLAY3DEMODLG_H__094584F4_71C3_4311_B018_9E2D0CD28DB6__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define VERSION	"1.3"
//  17Sep10 0.0.1 - Initial version
//	20Sep10	1.0.0 - Simplified version
//	28Sep10	1.0.1 - Changed how we use calibration lists
//   6Dec10 1.0.2 - Removed Device Number. To be replaced with Serial Number.
//   9Jun12 1.1   - Changed measurement modes and added Burst mode example.
//  21Jul12 1.2   - Changed path to be relative for support files.
//  14May13 1.3   - Added AIO mode example

#include "afxwin.h"

/////////////////////////////////////////////////////////////////////////////
// Ci1Display3DemoDlg dialog

class Ci1Display3DemoDlg : public CDialog
{
// Construction
public:
	i1d3Handle m_hi1d3;
	i1d3Status_t m_err;
	i1d3RGB_t m_dRGBMeas;
	i1d3XYZ_t m_dXYZMeas;
	i1d3Yxy_t m_dYxyMeas;
	i1d3Yxy_t m_ambientMeas;
	i1d3MeasMode_t m_MeasMode;
	i1d3LumUnits_t m_LumUnits;
	CString	s;
	bool GetTechnologyString(int type, char *strToReturn);
	char m_technologyStringFile[MAX_PATH];
	bool DiffuserInEmissiveMeasurementPosition();

	bool m_bIsOpen;

	typedef struct {
	  i1d3LED_Control	Ctrl;
	  double			dOff, dOn;
	  unsigned char	ucCount;
    } LED_CONFIG;

	LED_CONFIG m_LEDconfig;

	Ci1Display3DemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(Ci1Display3DemoDlg)
	enum { IDD = IDD_I1DISPLAY3DEMO_DIALOG };
	CButton	m_buttonOpenClose;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(Ci1Display3DemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(Ci1Display3DemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnButtonOpenClose();
	afx_msg void OnClose();
	afx_msg void OnBnClickedButtonMeasurePeriod();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonReadDiffusorPos();
	afx_msg void OnBnClickedButtonStart();
	afx_msg void OnCbnSelchangeCalCombo();
	CComboBox m_calCombo;
	afx_msg void OnBnClickedLoadCustomEdr();
	afx_msg void OnBnClickedLoadCustomCMF();
	afx_msg void OnBnClickedButtonMeasureFreq();
	CEdit m_sn;
	afx_msg void OnBnClickedButtonMeasureAmbient();
	afx_msg void OnBnClickedButtonSet();
	afx_msg void OnBnClickedButtonMeasureCrt();
	afx_msg void OnBnClickedButtonMeasureLcd();
	afx_msg void OnBnClickedButtonMeasureBurst();
	afx_msg void OnBnClickedButtonMeasureAio();
    afx_msg void OnBnClickedButtonMeasureBacklightFreq();

private:
   	unsigned short GetDisplayRefreshRate();
    void DisplayEmissiveResults();
    void LoadCalibrationList();
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_I1DISPLAY3DEMODLG_H__094584F4_71C3_4311_B018_9E2D0CD28DB6__INCLUDED_)
