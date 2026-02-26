using System;
using System.Collections.Generic;
using System.Text;

namespace Trainova.Domain.Certificates
{
    public enum CertificateStatus
    {
        Issued = 1,
        Revoked,
        Verified
    }
}
