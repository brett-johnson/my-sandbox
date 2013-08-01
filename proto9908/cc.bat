set WIXSRC=proto9908
candle -arch x64 %WIXSRC%.wxs
set MSINAME=xenspoof.msi
if not errorlevel == 1 light %WIXSRC%.wixobj -o %MSINAME%
@rem use /qn instead of /qb for a TOTALLY silent install/uninstall
if not errorlevel == 1 msiexec /qb /i %MSINAME%
if not errorlevel == 1 pause Hit any key to uninstall %MSINAME%
if not errorlevel == 1 msiexec /qb /x %MSINAME%
