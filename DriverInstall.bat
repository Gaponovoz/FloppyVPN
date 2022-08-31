::[Bat To Exe Converter]
::
::fBE1pAF6MU+EWH3eyHEHGydHWAuQAFyVNJ41xs/HyeaIsl0EYtIRRKDL37q4EM43+EzycIQRgC4UldgFbA==
::fBE1pAF6MU+EWH3eyHEHGydHWAuQAFyVNJ41xs/HyeaIsl0EYtIRRKDL37q4EM43+EzycIQRjiwUldgFbA==
::YAwzoRdxOk+EWAnk
::fBw5plQjdG8=
::YAwzuBVtJxjWCl3EqQJgSA==
::ZR4luwNxJguZRRnk
::Yhs/ulQjdF+5
::cxAkpRVqdFKZSTk=
::cBs/ulQjdF+5
::ZR41oxFsdFKZSTk=
::eBoioBt6dFKZSDk=
::cRo6pxp7LAbNWATEpCI=
::egkzugNsPRvcWATEpCI=
::dAsiuh18IRvcCxnZtBJQ
::cRYluBh/LU+EWAnk
::YxY4rhs+aU+IeA==
::cxY6rQJ7JhzQF1fEqQJQ
::ZQ05rAF9IBncCkqN+0xwdVs0
::ZQ05rAF9IAHYFVzEqQJQ
::eg0/rx1wNQPfEVWB+kM9LVsJDGQ=
::fBEirQZwNQPfEVWB+kM9LVsJDGQ=
::cRolqwZ3JBvQF1fEqQJQ
::dhA7uBVwLU+EWH6F5E0+Jw1bVmQ=
::YQ03rBFzNR3SWATElA==
::dhAmsQZ3MwfNWATE21I1Ji1kYmQ=
::ZQ0/vhVqMQ3MEVWAtB9wSA==
::Zg8zqx1/OA3MEVWAtB9wSA==
::dhA7pRFwIByZRRnk
::Zh4grVQjdCuDJGqzx34jPBRGcCCnD0CGKaUZ5t7Lwc6Vq1sYRqw6YIq7
::YB416Ek+ZG8=
::
::
::978f952a14a936cc963da21a135fa983
reg Query "HKLM\Hardware\Description\System\CentralProcessor\0" | find /i "x86" > NUL && set OS=32BIT || set OS=64BIT
				   
if %OS%==32BIT msiexec /i "86.msi" ADDLOCAL=OpenVPN,Drivers.TAPWindows6,Drivers /passive REINSTALL=ALL REINSTALLMODE=A
if %OS%==64BIT msiexec /i "64.msi" ADDLOCAL=OpenVPN,Drivers.TAPWindows6,Drivers /passive REINSTALL=ALL REINSTALLMODE=A
timeout 3
if %OS%==32BIT msiexec /i "86.msi" ADDLOCAL=OpenVPN,Drivers.TAPWindows6,Drivers /passive
if %OS%==64BIT msiexec /i "64.msi" ADDLOCAL=OpenVPN,Drivers.TAPWindows6,Drivers /passive
