using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRTGAutoTaskScheduler.Model.Configuration;
using Newtonsoft.Json;

namespace PRTGAutoTaskScheduler.Utilities.AutoTask
{
    public class AutoTaskConfiguration
    {

        public static void GetAllConfigurationItems()
        {

            string API = "https://webservices14.autotask.net/ATServicesRest/V1.0/ConfigurationItems/query?search={\"Filter\":[{\"field\":\"Id\",\"op\":\"gte\",\"value\":0}]}";
            AllConfigurationItemsExecution(API);
        }

        private static void AllConfigurationItemsExecution(string API)
        {

            IRestResponse response = Common.ExecuteAutoTaskAPI(API);

            AutoTaskConfigurationItemsModel AutoTaskConfigurationItemsModel = JsonConvert.DeserializeObject<AutoTaskConfigurationItemsModel>(response.Content);

            SaveData(AutoTaskConfigurationItemsModel);
        }

        private static void SaveData(AutoTaskConfigurationItemsModel autoTaskConfigurationItemsModel)
        {
            try
            {
                PRTGAutotaskEntities pRTGAutotaskEntities = new PRTGAutotaskEntities();
                var ExistingAutotaskConfigurationItems = pRTGAutotaskEntities.AutoTaskConfigurationItems;

                foreach (var x in autoTaskConfigurationItemsModel.items)
                {
                    int? ConfigurationItem = x.id;

                    var existing = pRTGAutotaskEntities.AutoTaskConfigurationItems
                       .Where(c => c.Id == ConfigurationItem)
                       .FirstOrDefault();

                    if (existing == null)
                    {
                        AutoTaskConfigurationItem autoTaskConfigurationItem = new AutoTaskConfigurationItem();

                        autoTaskConfigurationItem.Id = x.id;
                        autoTaskConfigurationItem.ApiVendorID = Convert.ToString(x.apiVendorID);
                        autoTaskConfigurationItem.ConfigurationItemCategoryID = x.configurationItemCategoryID;
                        autoTaskConfigurationItem.CompanyID = x.companyID;
                        autoTaskConfigurationItem.CompanyLocationID = Convert.ToString(x.companyLocationID);
                        autoTaskConfigurationItem.ConfigurationItemType = x.configurationItemType;
                        autoTaskConfigurationItem.ContactID = Convert.ToString(x.contactID);
                        autoTaskConfigurationItem.ContractID = Convert.ToString(x.contractID);
                        autoTaskConfigurationItem.ContractServiceBundleID = Convert.ToString(x.contractServiceBundleID);
                        autoTaskConfigurationItem.ContractServiceID = Convert.ToString(x.contractServiceID);
                        autoTaskConfigurationItem.CreateDate = x.createDate;
                        autoTaskConfigurationItem.CreatedByPersonID = x.createdByPersonID;
                        autoTaskConfigurationItem.DailyCost = Convert.ToString(x.dailyCost);
                        autoTaskConfigurationItem.DattoAvailableKilobytes = Convert.ToString(x.dattoAvailableKilobytes);
                        autoTaskConfigurationItem.DattoDeviceMemoryMegabytes = Convert.ToString(x.dattoDeviceMemoryMegabytes);
                        autoTaskConfigurationItem.DattoDrivesErrors = Convert.ToString(x.dattoDrivesErrors);
                        autoTaskConfigurationItem.DattoHostname = Convert.ToString(x.dattoHostname);
                        autoTaskConfigurationItem.DattoInternalIP = Convert.ToString(x.dattoInternalIP);
                        autoTaskConfigurationItem.DattoKernelVersionID = Convert.ToString(x.dattoKernelVersionID);
                        autoTaskConfigurationItem.DattoLastCheckInDateTime = Convert.ToString(x.dattoLastCheckInDateTime);
                        autoTaskConfigurationItem.DattoNICSpeedKilobitsPerSecond = Convert.ToString(x.dattoNICSpeedKilobitsPerSecond);
                        autoTaskConfigurationItem.DattoNumberOfAgents = Convert.ToString(x.dattoNumberOfAgents);
                        autoTaskConfigurationItem.DattoNumberOfDrives = Convert.ToString(x.dattoNumberOfDrives);
                        autoTaskConfigurationItem.DattoNumberOfVolumes = Convert.ToString(x.dattoNumberOfVolumes);
                        autoTaskConfigurationItem.DattoOffsiteUsedBytes = Convert.ToString(x.dattoOffsiteUsedBytes);
                        autoTaskConfigurationItem.DattoOSVersionID = Convert.ToString(x.dattoOSVersionID);
                        autoTaskConfigurationItem.DattoPercentageUsed = Convert.ToString(x.dattoPercentageUsed);
                        autoTaskConfigurationItem.DattoProtectedKilobytes = Convert.ToString(x.dattoProtectedKilobytes);
                        autoTaskConfigurationItem.DattoRemoteIP = Convert.ToString(x.dattoRemoteIP);
                        autoTaskConfigurationItem.DattoSerialNumber = Convert.ToString(x.dattoSerialNumber);
                        autoTaskConfigurationItem.DattoUptimeSeconds = Convert.ToString(x.dattoUptimeSeconds);
                        autoTaskConfigurationItem.DattoUsedKilobytes = Convert.ToString(x.dattoUsedKilobytes);
                        autoTaskConfigurationItem.DattoZFSVersionID = Convert.ToString(x.dattoZFSVersionID);
                        autoTaskConfigurationItem.DeviceNetworkingID = Convert.ToString(x.deviceNetworkingID);
                        autoTaskConfigurationItem.HourlyCost = Convert.ToString(x.hourlyCost);
                        autoTaskConfigurationItem.ImpersonatorCreatorResourceID = Convert.ToString(x.impersonatorCreatorResourceID);
                        autoTaskConfigurationItem.InstallDate = x.installDate;
                        autoTaskConfigurationItem.InstalledByContactID = Convert.ToString(x.installedByContactID);
                        autoTaskConfigurationItem.InstalledByID = x.installedByID;
                        autoTaskConfigurationItem.IsActive = Convert.ToString(x.isActive);
                        autoTaskConfigurationItem.LastActivityPersonID = x.lastActivityPersonID;
                        autoTaskConfigurationItem.LastActivityPersonType = x.lastActivityPersonType;
                        autoTaskConfigurationItem.LastModifiedTime = x.lastModifiedTime;
                        autoTaskConfigurationItem.Location = x.location;
                        autoTaskConfigurationItem.MonthlyCost = Convert.ToString(x.monthlyCost);
                        autoTaskConfigurationItem.Notes = Convert.ToString(x.notes);
                        autoTaskConfigurationItem.NumberOfUsers = Convert.ToString(x.numberOfUsers);
                        autoTaskConfigurationItem.ParentConfigurationItemID = Convert.ToString(x.parentConfigurationItemID);
                        autoTaskConfigurationItem.PerUseCost = Convert.ToString(x.perUseCost);
                        autoTaskConfigurationItem.ProductID = x.productID;
                        autoTaskConfigurationItem.ReferenceNumber = x.referenceNumber;
                        autoTaskConfigurationItem.ReferenceTitle = x.referenceTitle;
                        autoTaskConfigurationItem.RmmDeviceAuditAntivirusStatusID = x.rmmDeviceAuditAntivirusStatusID;
                        autoTaskConfigurationItem.RmmDeviceAuditArchitectureID = x.rmmDeviceAuditArchitectureID;
                        autoTaskConfigurationItem.RmmDeviceAuditBackupStatusID = Convert.ToString(x.rmmDeviceAuditBackupStatusID);
                        autoTaskConfigurationItem.RmmDeviceAuditDescription = x.rmmDeviceAuditDescription;
                        autoTaskConfigurationItem.RmmDeviceAuditDeviceTypeID = x.rmmDeviceAuditDeviceTypeID;
                        autoTaskConfigurationItem.RmmDeviceAuditDisplayAdaptorID = x.rmmDeviceAuditDisplayAdaptorID;
                        autoTaskConfigurationItem.RmmDeviceAuditDomainID = x.rmmDeviceAuditDomainID;
                        autoTaskConfigurationItem.RmmDeviceAuditExternalIPAddress = x.rmmDeviceAuditExternalIPAddress;
                        autoTaskConfigurationItem.RmmDeviceAuditHostname = x.rmmDeviceAuditHostname;
                        autoTaskConfigurationItem.RmmDeviceAuditIPAddress = x.rmmDeviceAuditIPAddress;
                        autoTaskConfigurationItem.RmmDeviceAuditLastUser = Convert.ToString(x.rmmDeviceAuditLastUser);
                        autoTaskConfigurationItem.RmmDeviceAuditMacAddress = x.rmmDeviceAuditMacAddress;
                        autoTaskConfigurationItem.RmmDeviceAuditManufacturerID = x.rmmDeviceAuditManufacturerID;
                        autoTaskConfigurationItem.RmmDeviceAuditMemoryBytes = (int?)x.rmmDeviceAuditMemoryBytes;
                        autoTaskConfigurationItem.RmmDeviceAuditMissingPatchCount = x.rmmDeviceAuditMissingPatchCount;
                        autoTaskConfigurationItem.RmmDeviceAuditMobileNetworkOperatorID = Convert.ToString(x.rmmDeviceAuditMobileNetworkOperatorID);
                        autoTaskConfigurationItem.RmmDeviceAuditMobileNumber = x.rmmDeviceAuditMobileNumber;
                        autoTaskConfigurationItem.RmmDeviceAuditModelID = x.rmmDeviceAuditModelID;
                        autoTaskConfigurationItem.RmmDeviceAuditMotherboardID = x.rmmDeviceAuditMotherboardID;
                        autoTaskConfigurationItem.RmmDeviceAuditOperatingSystem = x.rmmDeviceAuditOperatingSystem;
                        autoTaskConfigurationItem.RmmDeviceAuditPatchStatusID = x.rmmDeviceAuditPatchStatusID;
                        autoTaskConfigurationItem.RmmDeviceAuditProcessorID = x.rmmDeviceAuditProcessorID;
                        autoTaskConfigurationItem.RmmDeviceAuditServicePackID = x.rmmDeviceAuditServicePackID;
                        autoTaskConfigurationItem.RmmDeviceAuditSNMPContact = x.rmmDeviceAuditSNMPContact;
                        autoTaskConfigurationItem.RmmDeviceAuditSNMPLocation = x.rmmDeviceAuditSNMPLocation;
                        autoTaskConfigurationItem.RmmDeviceAuditSNMPName = x.rmmDeviceAuditSNMPName;
                        autoTaskConfigurationItem.RmmDeviceAuditSoftwareStatusID = x.rmmDeviceAuditSoftwareStatusID;
                        autoTaskConfigurationItem.RmmDeviceAuditStorageBytes = (int?)x.rmmDeviceAuditStorageBytes;
                        autoTaskConfigurationItem.RmmDeviceID = x.rmmDeviceID;
                        autoTaskConfigurationItem.RmmDeviceUID = x.rmmDeviceUID;
                        autoTaskConfigurationItem.RmmOpenAlertCount = x.rmmOpenAlertCount;
                        autoTaskConfigurationItem.SerialNumber = x.serialNumber;
                        autoTaskConfigurationItem.ServiceBundleID = Convert.ToString(x.serviceBundleID);
                        autoTaskConfigurationItem.ServiceID = Convert.ToString(x.serviceID);
                        autoTaskConfigurationItem.ServiceLevelAgreementID = Convert.ToString(x.serviceLevelAgreementID);
                        autoTaskConfigurationItem.SetupFee = Convert.ToString(x.setupFee);
                        autoTaskConfigurationItem.SourceChargeID = Convert.ToString(x.sourceChargeID);
                        autoTaskConfigurationItem.SourceChargeType = Convert.ToString(x.sourceChargeType);
                        autoTaskConfigurationItem.VendorID = Convert.ToString(x.vendorID);
                        autoTaskConfigurationItem.WarrantyExpirationDate = Convert.ToString(x.warrantyExpirationDate);

                        pRTGAutotaskEntities.AutoTaskConfigurationItems.Add(autoTaskConfigurationItem);
                        pRTGAutotaskEntities.SaveChanges();

                    }
                }
                if (autoTaskConfigurationItemsModel.pageDetails.nextPageUrl != null)
                {
                    string API = autoTaskConfigurationItemsModel.pageDetails.nextPageUrl.ToString();
                    AllConfigurationItemsExecution(API);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();

            }

        }
    }
}
