using EntityLayer.Concrete;
using MTAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.Abstrack
{
    public interface ILicenseRepository
    {
        LicenseCheckResult IsLicenseValid(string licenseKey, string serverName, string allowedIp);

        List<license> GetAllLicenses();
        license AddLicense(license license);
        license GetLicenseByKey(string licenseKey);
        license UpdateLicense(license license);
        void DeleteLicense(string licenseKey);
    }
}
