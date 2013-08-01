candle -sw1138 -arch x64 proto9905.wxs
if not errorlevel == 1 light proto9905.wixobj -o proto9905.msi
@rem use /qn instead of /qb for a TOTALLY silent install/uninstall
if not errorlevel == 1 msiexec /qb /i proto9905.msi
if not errorlevel == 1 pause Check out the installation first
if not errorlevel == 1 msiexec /qb /x proto9905.msi
