candle -arch x64 -sw1138 proto9906.wxs
if not errorlevel == 1 light proto9906.wixobj -o proto9906.msi
copy /y proto9906.msi C:\Windows\TEMP\.
@rem use /qn instead of /qb for a TOTALLY silent install/uninstall
rem if not errorlevel == 1 msiexec /qb /i proto9906.msi
rem if not errorlevel == 1 pause Check out the installation first
rem if not errorlevel == 1 msiexec /qb /x proto9906.msi
