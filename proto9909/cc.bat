candle -arch x64 proto9909.wxs
if not errorlevel == 1 light proto9909.wixobj -o proto9909.msi
@rem use /qn instead of /qb for a TOTALLY silent install/uninstall
if not errorlevel == 1 msiexec /qb /i proto9909.msi
rem if not errorlevel == 1 pause Check out the installation first
rem if not errorlevel == 1 msiexec /qb /x proto9909.msi
