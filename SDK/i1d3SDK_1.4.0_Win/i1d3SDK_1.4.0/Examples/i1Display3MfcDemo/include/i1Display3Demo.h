// i1Display3Demo.h : main header file for the I1DISPLAY3DEMO application
//

#if !defined(AFX_I1DISPLAY3DEMO_H__21C9FBC1_6435_4600_829C_B1BAA45939EC__INCLUDED_)
#define AFX_I1DISPLAY3DEMO_H__21C9FBC1_6435_4600_829C_B1BAA45939EC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols
#include "i1d3SDK.h"

/////////////////////////////////////////////////////////////////////////////
// Ci1Display3DemoApp:
// See i1Display3Demo.cpp for the implementation of this class
//

class Ci1Display3DemoApp : public CWinApp
{
public:
	Ci1Display3DemoApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(Ci1Display3DemoApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(Ci1Display3DemoApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_I1DISPLAY3DEMO_H__21C9FBC1_6435_4600_829C_B1BAA45939EC__INCLUDED_)
