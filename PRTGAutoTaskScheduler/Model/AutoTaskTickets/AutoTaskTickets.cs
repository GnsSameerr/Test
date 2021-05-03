using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTGAutoTaskScheduler.Model.AutoTaskTickets
{
     


    public class AutoTaskTickets
    {
        public Item[] items { get; set; }
        public Pagedetails pageDetails { get; set; }
    }

    public class Pagedetails
    {
        public int count { get; set; }
        public int requestCount { get; set; }
        public object prevPageUrl { get; set; }
        public string nextPageUrl { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public object apiVendorID { get; set; }
        public int? assignedResourceID { get; set; }
        public int? assignedResourceRoleID { get; set; }
        public int? billingCodeID { get; set; }
        public object changeApprovalBoard { get; set; }
        public int? changeApprovalStatus { get; set; }
        public int? changeApprovalType { get; set; }
        public string changeInfoField1 { get; set; }
        public string changeInfoField2 { get; set; }
        public string changeInfoField3 { get; set; }
        public string changeInfoField4 { get; set; }
        public string changeInfoField5 { get; set; }
        public int companyID { get; set; }
        public int? companyLocationID { get; set; }
        public int completedByResourceID { get; set; }
        public DateTime completedDate { get; set; }
        public int? configurationItemID { get; set; }
        public int? contactID { get; set; }
        public object contractID { get; set; }
        public object contractServiceBundleID { get; set; }
        public object contractServiceID { get; set; }
        public DateTime createDate { get; set; }
        public int? createdByContactID { get; set; }
        public int creatorResourceID { get; set; }
        public int creatorType { get; set; }
        public object currentServiceThermometerRating { get; set; }
        public string description { get; set; }
        public DateTime dueDateTime { get; set; }
        public float? estimatedHours { get; set; }
        public string externalID { get; set; }
        public int? firstResponseAssignedResourceID { get; set; }
        public DateTime firstResponseDateTime { get; set; }
        public DateTime? firstResponseDueDateTime { get; set; }
        public int? firstResponseInitiatingResourceID { get; set; }
        public float? hoursToBeScheduled { get; set; }
        public object impersonatorCreatorResourceID { get; set; }
        public int? issueType { get; set; }
        public DateTime lastActivityDate { get; set; }
        public int lastActivityPersonType { get; set; }
        public int lastActivityResourceID { get; set; }
        public DateTime? lastCustomerNotificationDateTime { get; set; }
        public DateTime? lastCustomerVisibleActivityDateTime { get; set; }
        public DateTime lastTrackedModificationDateTime { get; set; }
        public int? monitorID { get; set; }
        public int? monitorTypeID { get; set; }
        public object opportunityID { get; set; }
        public object organizationalLevelAssociationID { get; set; }
        public object previousServiceThermometerRating { get; set; }
        public int priority { get; set; }
        public object problemTicketId { get; set; }
        public object projectID { get; set; }
        public string purchaseOrderNumber { get; set; }
        public int queueID { get; set; }
        public string resolution { get; set; }
        public DateTime resolutionPlanDateTime { get; set; }
        public DateTime? resolutionPlanDueDateTime { get; set; }
        public DateTime resolvedDateTime { get; set; }
        public DateTime? resolvedDueDateTime { get; set; }
        public object rmaStatus { get; set; }
        public object rmaType { get; set; }
        public string rmmAlertID { get; set; }
        public bool? serviceLevelAgreementHasBeenMet { get; set; }
        public int? serviceLevelAgreementID { get; set; }
        public object serviceLevelAgreementPausedNextEventHours { get; set; }
        public object serviceThermometerTemperature { get; set; }
        public int source { get; set; }
        public int status { get; set; }
        public int? subIssueType { get; set; }
        public int ticketCategory { get; set; }
        public string ticketNumber { get; set; }
        public int ticketType { get; set; }
        public string title { get; set; }
        public Userdefinedfield[] userDefinedFields { get; set; }
    }

    public class Userdefinedfield
    {
        public string name { get; set; }
        public object value { get; set; }
    }

}
