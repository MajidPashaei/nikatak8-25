using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModel.Tavanam;
using DataLayer.AdminEntities.Request;
using faraboom.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Admin.Controllers {
    [Area("Admin")]

    public class TestController : Controller {

        public async Task<IActionResult> Index ()
         {

           var b = 
            "{\"operation_time\":1628774858929,\"reason_codes\":\"خیلی پایین بودنِ تعداد ماههای دارای پرداخت خوب در حداقل یک قرارداد, دارای 2 ماه یا بیشتر با وضعیت منفی (سررسید گذشته، معوق و مشکوک الوصول) در قرارداد جاری در 24 ماه گذشته‫‬‬‬‬‬‬‬‬‬‬‬‬‬‬‬‬‬, خیلی زیاد بودن نسبت مبلغ وثیقه به مبلغ کل وام(اصل و فرع) در 2 ماه گذشته‫‬‬‬‬‬‬‬, گروه سنی جوان, دارای ‪‫حداقل یک قرارداد خاتمه یاقته اصلی در 3 سال گذشته می باشد‬‬‬‬‬‬‬‬‬‬‬‬‬‬\",\"rate\":\"562\",\"rank\":\"C1\",\"description\":\"  ریسک متوسط\",\"report_file\":[],\"report_data\":\"{\\\"TrackingCode\\\":\\\"1400052111202325\\\",\\\"BasicData\\\":{\\\"PersonalData\\\":{\\\"NationalCode\\\":\\\"1720188408\\\",\\\"FatherName\\\":\\\"حسين\\\",\\\"FirstName\\\":\\\"محسن\\\",\\\"LastName\\\":\\\"پاشائي\\\",\\\"BirthDate\\\":\\\"1999-12-22T00:00:00\\\",\\\"BirthCountry\\\":\\\"تبریز\\\",\\\"Gender\\\":\\\"مرد\\\",\\\"MaritalStatus\\\":\\\"مجرد\\\",\\\"BorrowerClassification\\\":0,\\\"BasicDataStr\\\":\\\"1378/10/01\\\"},\\\"CompanyData\\\":{\\\"RegistrationNumber\\\":null,\\\"CompanyName\\\":\\\"محسن\\\",\\\"CompanyId\\\":\\\"1720188408\\\",\\\"LegalForm\\\":null},\\\"ContactData\\\":{\\\"Emails\\\":null,\\\"Faxes\\\":null,\\\"PhoneNumbers\\\":[\\\" - \\\",\\\" 09054113328 \\\",\\\" 04435220039 \\\",\\\" - \\\"],\\\"WebPages\\\":null,\\\"Addresses\\\":[\\\"-\\\"]},\\\"NegativeSubjectStatusDatas\\\":[{\\\"LastUpdate\\\":\\\"2021-06-03T00:00:00\\\",\\\"LastUpdateStr\\\":\\\"1400/03/13\\\",\\\"NegativeSubjectStatus\\\":\\\"فاقد وضعیت منفی\\\",\\\"Creditor\\\":\\\"بانک انصار\\\"},{\\\"LastUpdate\\\":\\\"2021-05-21T00:00:00\\\",\\\"LastUpdateStr\\\":\\\"1400/02/31\\\",\\\"NegativeSubjectStatus\\\":\\\"فاقد وضعیت منفی\\\",\\\"Creditor\\\":\\\"بانک قرض الحسنه رسالت\\\"}]},\\\"Inquiry\\\":null,\\\"Summary\\\":{\\\"TotalDebtOverdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"TotalNumberOfUnpaidInstalments\\\":null,\\\"TotalOutstandingAmount\\\":{\\\"Amount\\\":4172507.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"NumberOfExistingOperations\\\":1,\\\"NumberOfTerminatedOperations\\\":1,\\\"NegativeStatusReports\\\":[{\\\"NegativeContractStatus\\\":\\\"سررسید گذشته\\\",\\\"LastUpdate\\\":\\\"2021-04-08T00:00:00\\\",\\\"LastUpdateStr\\\":\\\"1400/01/19\\\",\\\"Creditor\\\":\\\"بانک انصار\\\"},{\\\"NegativeContractStatus\\\":\\\"سررسید گذشته\\\",\\\"LastUpdate\\\":\\\"2021-03-07T00:00:00\\\",\\\"LastUpdateStr\\\":\\\"1399/12/17\\\",\\\"Creditor\\\":\\\"بانک انصار\\\"},{\\\"NegativeContractStatus\\\":\\\"سررسید گذشته\\\",\\\"LastUpdate\\\":\\\"2021-01-19T00:00:00\\\",\\\"LastUpdateStr\\\":\\\"1399/10/30\\\",\\\"Creditor\\\":\\\"بانک انصار\\\"},{\\\"NegativeContractStatus\\\":\\\"سررسید گذشته\\\",\\\"LastUpdate\\\":\\\"2020-09-12T00:00:00\\\",\\\"LastUpdateStr\\\":\\\"1399/06/22\\\",\\\"Creditor\\\":\\\"بانک انصار\\\"}],\\\"Creditor\\\":null},\\\"SummaryCreditors\\\":[{\\\"TotalDebtOverdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"TotalNumberOfUnpaidInstalments\\\":null,\\\"TotalOutstandingAmount\\\":{\\\"Amount\\\":4172507.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"NumberOfExistingOperations\\\":1,\\\"NumberOfTerminatedOperations\\\":0,\\\"NegativeStatusReports\\\":null,\\\"Creditor\\\":\\\"بانک انصار\\\"},{\\\"TotalDebtOverdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"TotalNumberOfUnpaidInstalments\\\":null,\\\"TotalOutstandingAmount\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"NumberOfExistingOperations\\\":0,\\\"NumberOfTerminatedOperations\\\":1,\\\"NegativeStatusReports\\\":null,\\\"Creditor\\\":\\\"بانک قرض الحسنه رسالت\\\"}],\\\"BaseDataOperation\\\":{\\\"ExistingOperationDebtorID\\\":0,\\\"TerminatedOperationDebtorsID\\\":0,\\\"TerminatedOperationGuarantorsID\\\":0,\\\"ExistingOperationDebtors\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"GeneralInformationID\\\":0,\\\"GeneralInformationParentID\\\":0,\\\"CollateralsID\\\":0,\\\"CollateralsParentID\\\":0,\\\"InstalmentsID\\\":0,\\\"InstalmentsParentID\\\":0,\\\"ConnectedSubjectsID\\\":0,\\\"ConnectedSubjectsParentID\\\":0,\\\"InstalmentDetail\\\":{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"TypeOfFinancingInstalment\\\":\\\"سایر\\\",\\\"TypeOfInstalment\\\":\\\"اقساط ثابت\\\",\\\"PeriodicityOfPayment\\\":\\\"ماهانه\\\",\\\"MethodOfPayment\\\":\\\"پرداخت مستقیم (نقدی)\\\",\\\"TotalCredit\\\":{\\\"Amount\\\":10652507.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"NumberOfInstalments\\\":30,\\\"PeriodicalInstalment\\\":{\\\"Amount\\\":360000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"Outstanding\\\":{\\\"Amount\\\":4172507.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"OutstandingAmount\\\":\\\"4,172,507\\\",\\\"OverdueAmount\\\":\\\"0\\\",\\\"PeriodicalInstalmentAmount\\\":\\\"360,000\\\",\\\"TotalCreditAmount\\\":\\\"10,652,507\\\"},\\\"Instalments\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":4,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":3,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":2,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":2160000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":1,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":6},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":2160000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":12,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":6},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":11,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":1440000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":10,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":4},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":720000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":9,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":2},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":1080000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":8,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":3},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":7,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":1080000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":6,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":3},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":5,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0}],\\\"GeneralInformation\\\":{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NegativeContractStatus\\\":\\\"فاقد وضعیت منفی\\\",\\\"Date\\\":{\\\"StartDate\\\":\\\"2019-08-29T00:00:00\\\",\\\"ExpectedEndDate\\\":\\\"2022-05-28T00:00:00\\\",\\\"RealEndDate\\\":null},\\\"CurrencyCode\\\":\\\"ریال\\\",\\\"PurposeOfTheCredit\\\":\\\"ایجاد\\\",\\\"RoleOfConnectedSubject\\\":\\\"متقاضی اصلی\\\",\\\"Creditor\\\":\\\"بانک انصار\\\",\\\"LastUpdate\\\":\\\"2021-06-11T00:00:00\\\",\\\"PhaseOfOperation\\\":\\\"درجریان\\\",\\\"RecordInfo\\\":{\\\"ParentID\\\":0,\\\"Identifier\\\":\\\"-\\\",\\\"Source\\\":\\\"\\\"},\\\"RecordInfoID\\\":0,\\\"RecordInfoParentID\\\":0},\\\"ConnectedSubjects\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NationalCode\\\":\\\"2840474425\\\",\\\"RoleOfConnectedSubject\\\":\\\"ضامن\\\"}],\\\"Collaterals\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"TypeOfGuarantee\\\":\\\"برات و سفته\\\",\\\"Guarantee\\\":{\\\"Amount\\\":50000000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"}}]}],\\\"TerminatedOperationDebtors\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"GeneralInformationID\\\":0,\\\"GeneralInformationParentID\\\":0,\\\"CollateralsID\\\":0,\\\"CollateralsParentID\\\":0,\\\"InstalmentsID\\\":0,\\\"InstalmentsParentID\\\":0,\\\"ConnectedSubjectsID\\\":0,\\\"ConnectedSubjectsParentID\\\":0,\\\"InstalmentDetail\\\":{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"TypeOfFinancingInstalment\\\":\\\"قرض الحسنه\\\",\\\"TypeOfInstalment\\\":\\\"اقساط ثابت\\\",\\\"PeriodicityOfPayment\\\":\\\"ماهانه\\\",\\\"MethodOfPayment\\\":\\\"پرداخت مستقیم (نقدی)\\\",\\\"TotalCredit\\\":{\\\"Amount\\\":7000000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"NumberOfInstalments\\\":10,\\\"PeriodicalInstalment\\\":{\\\"Amount\\\":777000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"Outstanding\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"OutstandingAmount\\\":\\\"0\\\",\\\"OverdueAmount\\\":\\\"0\\\",\\\"PeriodicalInstalmentAmount\\\":\\\"777,000\\\",\\\"TotalCreditAmount\\\":\\\"7,000,000\\\"},\\\"Instalments\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":4,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":3,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":2,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":1,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":12,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":11,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":10,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":9,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":8,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":7,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":6,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":5,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0}],\\\"GeneralInformation\\\":{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NegativeContractStatus\\\":\\\"فاقد وضعیت منفی\\\",\\\"Date\\\":{\\\"StartDate\\\":\\\"2018-10-16T00:00:00\\\",\\\"ExpectedEndDate\\\":\\\"2019-08-19T00:00:00\\\",\\\"RealEndDate\\\":\\\"2021-05-21T00:00:00\\\"},\\\"CurrencyCode\\\":\\\"ریال\\\",\\\"PurposeOfTheCredit\\\":\\\"سایر\\\",\\\"RoleOfConnectedSubject\\\":\\\"متقاضی اصلی\\\",\\\"Creditor\\\":\\\"بانک قرض الحسنه رسالت\\\",\\\"LastUpdate\\\":\\\"2021-05-21T00:00:00\\\",\\\"PhaseOfOperation\\\":\\\"خاتمه یافته عادی طبق قرارداد\\\",\\\"RecordInfo\\\":{\\\"ParentID\\\":0,\\\"Identifier\\\":\\\"-\\\",\\\"Source\\\":\\\"\\\"},\\\"RecordInfoID\\\":0,\\\"RecordInfoParentID\\\":0},\\\"ConnectedSubjects\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NationalCode\\\":\\\"-\\\",\\\"RoleOfConnectedSubject\\\":\\\"ضامن\\\"}],\\\"Collaterals\\\":[]}],\\\"TerminatedOperationGuarantors\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"GeneralInformationID\\\":0,\\\"GeneralInformationParentID\\\":0,\\\"CollateralsID\\\":0,\\\"CollateralsParentID\\\":0,\\\"InstalmentsID\\\":0,\\\"InstalmentsParentID\\\":0,\\\"ConnectedSubjectsID\\\":0,\\\"ConnectedSubjectsParentID\\\":0,\\\"InstalmentDetail\\\":{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"TypeOfFinancingInstalment\\\":\\\"سایر\\\",\\\"TypeOfInstalment\\\":\\\"اقساط ثابت\\\",\\\"PeriodicityOfPayment\\\":\\\"ماهانه\\\",\\\"MethodOfPayment\\\":\\\"پرداخت مستقیم (نقدی)\\\",\\\"TotalCredit\\\":{\\\"Amount\\\":256776192.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"NumberOfInstalments\\\":32,\\\"PeriodicalInstalment\\\":{\\\"Amount\\\":8024000.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"Outstanding\\\":{\\\"Amount\\\":192584192.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"OutstandingAmount\\\":\\\"192,584,192\\\",\\\"OverdueAmount\\\":\\\"0\\\",\\\"PeriodicalInstalmentAmount\\\":\\\"8,024,000\\\",\\\"TotalCreditAmount\\\":\\\"256,776,192\\\"},\\\"Instalments\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":4,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":3,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":2,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":1,\\\"YearCount\\\":1400,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":12,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":11,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":10,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":9,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":8,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":7,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":6,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"Overdue\\\":{\\\"Amount\\\":0.0,\\\"CurrencyCode\\\":\\\"ریال\\\"},\\\"MonthCount\\\":5,\\\"YearCount\\\":1399,\\\"OverdueInstalmentsCount\\\":0}],\\\"GeneralInformation\\\":{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NegativeContractStatus\\\":\\\"فاقد وضعیت منفی\\\",\\\"Date\\\":{\\\"StartDate\\\":\\\"2020-09-17T00:00:00\\\",\\\"ExpectedEndDate\\\":\\\"2023-05-17T00:00:00\\\",\\\"RealEndDate\\\":null},\\\"CurrencyCode\\\":\\\"ریال\\\",\\\"PurposeOfTheCredit\\\":\\\"ایجاد\\\",\\\"RoleOfConnectedSubject\\\":\\\"ضامن\\\",\\\"Creditor\\\":\\\"بانک انصار\\\",\\\"LastUpdate\\\":\\\"2021-06-11T00:00:00\\\",\\\"PhaseOfOperation\\\":\\\"درجریان\\\",\\\"RecordInfo\\\":{\\\"ParentID\\\":0,\\\"Identifier\\\":\\\"-\\\",\\\"Source\\\":\\\"\\\"},\\\"RecordInfoID\\\":0,\\\"RecordInfoParentID\\\":0},\\\"ConnectedSubjects\\\":[{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NationalCode\\\":\\\"1728910048\\\",\\\"RoleOfConnectedSubject\\\":\\\"متقاضی اصلی\\\"},{\\\"ID\\\":0,\\\"ParentID\\\":0,\\\"NationalCode\\\":\\\"1720188416\\\",\\\"RoleOfConnectedSubject\\\":\\\"ضامن\\\"}],\\\"Collaterals\\\":[]}]},\\\"ReportStatus\\\":0,\\\"SummaryReport\\\":{\\\"TrackingCode\\\":null,\\\"NegativeStatusAndInquiry\\\":{\\\"NumberOfInquiries\\\":[{\\\"SubscriberType\\\":\\\"بانک مرکزی\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"بانک ها و موسسات اعتباری\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"تلکام/سازمان هاي خدماتی\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"سازمان های خرده فروشی\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"سازمان های عمومی/دولتی\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"سازمان های قضايی\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"مصرف کنندگان\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"موسسات اعتباري غير متشکل\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0},{\\\"SubscriberType\\\":\\\"موسسات صادر کننده کارت اعتباری\\\",\\\"LastMonthCount\\\":0,\\\"LastYearCount\\\":0}],\\\"CurrentNegativeStatusContracts\\\":null,\\\"CurrentNegativeStatusSubjects\\\":null},\\\"Contract\\\":{\\\"ContractRecords\\\":[{\\\"TypeOfContract\\\":\\\"تسهیلات\\\",\\\"TypeOfFinancingInstalment\\\":null,\\\"Subscriber\\\":\\\"بانک انصار\\\",\\\"SubscriberLocalName\\\":\\\"بانک انصار\\\",\\\"CurrencyCode\\\":\\\"ریال\\\",\\\"NumberOfOpenContracts\\\":1,\\\"NumberOfTerminatedContracts\\\":0,\\\"OutstandingAmount\\\":4172507.0,\\\"OverdueAmount\\\":0.0},{\\\"TypeOfContract\\\":\\\"تسهیلات\\\",\\\"TypeOfFinancingInstalment\\\":null,\\\"Subscriber\\\":\\\"بانک قرض الحسنه رسالت\\\",\\\"SubscriberLocalName\\\":\\\"بانک قرض الحسنه رسالت\\\",\\\"CurrencyCode\\\":\\\"ریال\\\",\\\"NumberOfOpenContracts\\\":0,\\\"NumberOfTerminatedContracts\\\":1,\\\"OutstandingAmount\\\":0.0,\\\"OverdueAmount\\\":0.0}],\\\"TotalRecord\\\":{\\\"CurrencyCode\\\":\\\"ریال\\\",\\\"NumberOfOpenContracts\\\":1,\\\"NumberOfTerminatedContracts\\\":1,\\\"OutstandingAmount\\\":4172507.0,\\\"OverdueAmount\\\":0.0}},\\\"LettersOfGuarantee\\\":{\\\"ContractRecords\\\":[],\\\"TotalRecord\\\":{\\\"CurrencyCode\\\":\\\"IRR\\\",\\\"NumberOfOpenContracts\\\":0,\\\"NumberOfTerminatedContracts\\\":0,\\\"OutstandingAmount\\\":0,\\\"OverdueAmount\\\":0}},\\\"SubjectRoles\\\":[{\\\"RoleOfConnectedSubject\\\":\\\"متقاضی اصلی\\\",\\\"NumberOfContracts\\\":1},{\\\"RoleOfConnectedSubject\\\":\\\"ضامن\\\",\\\"NumberOfContracts\\\":1}],\\\"ReportDate\\\":\\\"2021-08-12T17:58:15.4219424+04:30\\\"},\\\"ScoringData\\\":{\\\"ICSScore\\\":562,\\\"RiskGrade\\\":6,\\\"ReasonCodes\\\":[68,18,28,14,52],\\\"ScoreRange\\\":null,\\\"ScoreDescription\\\":\\\"  ریسک متوسط\\\",\\\"Comments\\\":null}}\"}"
            ;

            var myDeserializedClass = JsonConvert.DeserializeObject<RootAll>(b);
            ViewBag.result = myDeserializedClass ;
            var ReportData= myDeserializedClass.ReportData;
            var x = JsonConvert.DeserializeObject<Root>(ReportData);


            return View ();
         }

        public class RootAll
        {
            [JsonProperty("operation_time")]
            public long OperationTime { get; set; }

            [JsonProperty("reason_codes")]
            public string ReasonCodes { get; set; }

            [JsonProperty("rate")]
            public string Rate { get; set; }

            [JsonProperty("rank")]
            public string Rank { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("report_file")]
            public List<int> ReportFile { get; set; }

            [JsonProperty("report_data")]
            public string ReportData { get; set; }
        }


// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class PersonalData
        {
            [JsonProperty("NationalCode")]
            public string NationalCode { get; set; }
    
            [JsonProperty("FatherName")]
            public string FatherName { get; set; }
    
            [JsonProperty("FirstName")]
            public string FirstName { get; set; }
    
            [JsonProperty("LastName")]
            public string LastName { get; set; }
    
            [JsonProperty("BirthDate")]
            public DateTime BirthDate { get; set; }
    
            [JsonProperty("BirthCountry")]
            public string BirthCountry { get; set; }
    
            [JsonProperty("Gender")]
            public string Gender { get; set; }
    
            [JsonProperty("MaritalStatus")]
            public string MaritalStatus { get; set; }
    
            [JsonProperty("BorrowerClassification")]
            public int BorrowerClassification { get; set; }
    
            [JsonProperty("BasicDataStr")]
            public string BasicDataStr { get; set; }
        }
    
        public class CompanyData
        {
            [JsonProperty("RegistrationNumber")]
            public object RegistrationNumber { get; set; }
    
            [JsonProperty("CompanyName")]
            public string CompanyName { get; set; }
    
            [JsonProperty("CompanyId")]
            public string CompanyId { get; set; }
    
            [JsonProperty("LegalForm")]
            public object LegalForm { get; set; }
        }
    
        public class ContactData
        {
            [JsonProperty("Emails")]
            public object Emails { get; set; }
    
            [JsonProperty("Faxes")]
            public object Faxes { get; set; }
    
            [JsonProperty("PhoneNumbers")]
            public List<string> PhoneNumbers { get; set; }
    
            [JsonProperty("WebPages")]
            public object WebPages { get; set; }
    
            [JsonProperty("Addresses")]
            public List<string> Addresses { get; set; }
        }
    
        public class NegativeSubjectStatusData
        {
            [JsonProperty("LastUpdate")]
            public DateTime LastUpdate { get; set; }
    
            [JsonProperty("LastUpdateStr")]
            public string LastUpdateStr { get; set; }
    
            [JsonProperty("NegativeSubjectStatus")]
            public string NegativeSubjectStatus { get; set; }
    
            [JsonProperty("Creditor")]
            public string Creditor { get; set; }
        }
    
        public class BasicData
        {
            [JsonProperty("PersonalData")]
            public PersonalData PersonalData { get; set; }
    
            [JsonProperty("CompanyData")]
            public CompanyData CompanyData { get; set; }
    
            [JsonProperty("ContactData")]
            public ContactData ContactData { get; set; }
    
            [JsonProperty("NegativeSubjectStatusDatas")]
            public List<NegativeSubjectStatusData> NegativeSubjectStatusDatas { get; set; }
        }
    
        public class TotalDebtOverdue
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class TotalOutstandingAmount
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class NegativeStatusReport
        {
            [JsonProperty("NegativeContractStatus")]
            public string NegativeContractStatus { get; set; }
    
            [JsonProperty("LastUpdate")]
            public DateTime LastUpdate { get; set; }
    
            [JsonProperty("LastUpdateStr")]
            public string LastUpdateStr { get; set; }
    
            [JsonProperty("Creditor")]
            public string Creditor { get; set; }
        }
    
        public class Summary
        {
            [JsonProperty("TotalDebtOverdue")]
            public TotalDebtOverdue TotalDebtOverdue { get; set; }
    
            [JsonProperty("TotalNumberOfUnpaidInstalments")]
            public object TotalNumberOfUnpaidInstalments { get; set; }
    
            [JsonProperty("TotalOutstandingAmount")]
            public TotalOutstandingAmount TotalOutstandingAmount { get; set; }
    
            [JsonProperty("NumberOfExistingOperations")]
            public int NumberOfExistingOperations { get; set; }
    
            [JsonProperty("NumberOfTerminatedOperations")]
            public int NumberOfTerminatedOperations { get; set; }
    
            [JsonProperty("NegativeStatusReports")]
            public List<NegativeStatusReport> NegativeStatusReports { get; set; }
    
            [JsonProperty("Creditor")]
            public object Creditor { get; set; }
        }
    
        public class SummaryCreditor
        {
            [JsonProperty("TotalDebtOverdue")]
            public TotalDebtOverdue TotalDebtOverdue { get; set; }
    
            [JsonProperty("TotalNumberOfUnpaidInstalments")]
            public object TotalNumberOfUnpaidInstalments { get; set; }
    
            [JsonProperty("TotalOutstandingAmount")]
            public TotalOutstandingAmount TotalOutstandingAmount { get; set; }
    
            [JsonProperty("NumberOfExistingOperations")]
            public int NumberOfExistingOperations { get; set; }
    
            [JsonProperty("NumberOfTerminatedOperations")]
            public int NumberOfTerminatedOperations { get; set; }
    
            [JsonProperty("NegativeStatusReports")]
            public object NegativeStatusReports { get; set; }
    
            [JsonProperty("Creditor")]
            public string Creditor { get; set; }
        }
    
        public class TotalCredit
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class PeriodicalInstalment
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class Overdue
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class Outstanding
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class InstalmentDetail
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("TypeOfFinancingInstalment")]
            public string TypeOfFinancingInstalment { get; set; }
    
            [JsonProperty("TypeOfInstalment")]
            public string TypeOfInstalment { get; set; }
    
            [JsonProperty("PeriodicityOfPayment")]
            public string PeriodicityOfPayment { get; set; }
    
            [JsonProperty("MethodOfPayment")]
            public string MethodOfPayment { get; set; }
    
            [JsonProperty("TotalCredit")]
            public TotalCredit TotalCredit { get; set; }
    
            [JsonProperty("NumberOfInstalments")]
            public int NumberOfInstalments { get; set; }
    
            [JsonProperty("PeriodicalInstalment")]
            public PeriodicalInstalment PeriodicalInstalment { get; set; }
    
            [JsonProperty("Overdue")]
            public Overdue Overdue { get; set; }
    
            [JsonProperty("Outstanding")]
            public Outstanding Outstanding { get; set; }
    
            [JsonProperty("OutstandingAmount")]
            public string OutstandingAmount { get; set; }
    
            [JsonProperty("OverdueAmount")]
            public string OverdueAmount { get; set; }
    
            [JsonProperty("PeriodicalInstalmentAmount")]
            public string PeriodicalInstalmentAmount { get; set; }
    
            [JsonProperty("TotalCreditAmount")]
            public string TotalCreditAmount { get; set; }
        }
    
        public class Instalment
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("Overdue")]
            public Overdue Overdue { get; set; }
    
            [JsonProperty("MonthCount")]
            public int MonthCount { get; set; }
    
            [JsonProperty("YearCount")]
            public int YearCount { get; set; }
    
            [JsonProperty("OverdueInstalmentsCount")]
            public int OverdueInstalmentsCount { get; set; }
        }
    
        public class Date
        {
            [JsonProperty("StartDate")]
            public DateTime StartDate { get; set; }
    
            [JsonProperty("ExpectedEndDate")]
            public DateTime ExpectedEndDate { get; set; }
    
            [JsonProperty("RealEndDate")]
            public object RealEndDate { get; set; }
        }
    
        public class RecordInfo
        {
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("Identifier")]
            public string Identifier { get; set; }
    
            [JsonProperty("Source")]
            public string Source { get; set; }
        }
    
        public class GeneralInformation
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("NegativeContractStatus")]
            public string NegativeContractStatus { get; set; }
    
            [JsonProperty("Date")]
            public Date Date { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
    
            [JsonProperty("PurposeOfTheCredit")]
            public string PurposeOfTheCredit { get; set; }
    
            [JsonProperty("RoleOfConnectedSubject")]
            public string RoleOfConnectedSubject { get; set; }
    
            [JsonProperty("Creditor")]
            public string Creditor { get; set; }
    
            [JsonProperty("LastUpdate")]
            public DateTime LastUpdate { get; set; }
    
            [JsonProperty("PhaseOfOperation")]
            public string PhaseOfOperation { get; set; }
    
            [JsonProperty("RecordInfo")]
            public RecordInfo RecordInfo { get; set; }
    
            [JsonProperty("RecordInfoID")]
            public int RecordInfoID { get; set; }
    
            [JsonProperty("RecordInfoParentID")]
            public int RecordInfoParentID { get; set; }
        }
    
        public class ConnectedSubject
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("NationalCode")]
            public string NationalCode { get; set; }
    
            [JsonProperty("RoleOfConnectedSubject")]
            public string RoleOfConnectedSubject { get; set; }
        }
    
        public class Guarantee
        {
            [JsonProperty("Amount")]
            public double Amount { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
        }
    
        public class Collateral
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("TypeOfGuarantee")]
            public string TypeOfGuarantee { get; set; }
    
            [JsonProperty("Guarantee")]
            public Guarantee Guarantee { get; set; }
        }
    
        public class ExistingOperationDebtor
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("GeneralInformationID")]
            public int GeneralInformationID { get; set; }
    
            [JsonProperty("GeneralInformationParentID")]
            public int GeneralInformationParentID { get; set; }
    
            [JsonProperty("CollateralsID")]
            public int CollateralsID { get; set; }
    
            [JsonProperty("CollateralsParentID")]
            public int CollateralsParentID { get; set; }
    
            [JsonProperty("InstalmentsID")]
            public int InstalmentsID { get; set; }
    
            [JsonProperty("InstalmentsParentID")]
            public int InstalmentsParentID { get; set; }
    
            [JsonProperty("ConnectedSubjectsID")]
            public int ConnectedSubjectsID { get; set; }
    
            [JsonProperty("ConnectedSubjectsParentID")]
            public int ConnectedSubjectsParentID { get; set; }
    
            [JsonProperty("InstalmentDetail")]
            public InstalmentDetail InstalmentDetail { get; set; }
    
            [JsonProperty("Instalments")]
            public List<Instalment> Instalments { get; set; }
    
            [JsonProperty("GeneralInformation")]
            public GeneralInformation GeneralInformation { get; set; }
    
            [JsonProperty("ConnectedSubjects")]
            public List<ConnectedSubject> ConnectedSubjects { get; set; }
    
            [JsonProperty("Collaterals")]
            public List<Collateral> Collaterals { get; set; }
        }
    
        public class TerminatedOperationDebtor
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("GeneralInformationID")]
            public int GeneralInformationID { get; set; }
    
            [JsonProperty("GeneralInformationParentID")]
            public int GeneralInformationParentID { get; set; }
    
            [JsonProperty("CollateralsID")]
            public int CollateralsID { get; set; }
    
            [JsonProperty("CollateralsParentID")]
            public int CollateralsParentID { get; set; }
    
            [JsonProperty("InstalmentsID")]
            public int InstalmentsID { get; set; }
    
            [JsonProperty("InstalmentsParentID")]
            public int InstalmentsParentID { get; set; }
    
            [JsonProperty("ConnectedSubjectsID")]
            public int ConnectedSubjectsID { get; set; }
    
            [JsonProperty("ConnectedSubjectsParentID")]
            public int ConnectedSubjectsParentID { get; set; }
    
            [JsonProperty("InstalmentDetail")]
            public InstalmentDetail InstalmentDetail { get; set; }
    
            [JsonProperty("Instalments")]
            public List<Instalment> Instalments { get; set; }
    
            [JsonProperty("GeneralInformation")]
            public GeneralInformation GeneralInformation { get; set; }
    
            [JsonProperty("ConnectedSubjects")]
            public List<ConnectedSubject> ConnectedSubjects { get; set; }
    
            [JsonProperty("Collaterals")]
            public List<object> Collaterals { get; set; }
        }
    
        public class TerminatedOperationGuarantor
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
    
            [JsonProperty("ParentID")]
            public int ParentID { get; set; }
    
            [JsonProperty("GeneralInformationID")]
            public int GeneralInformationID { get; set; }
    
            [JsonProperty("GeneralInformationParentID")]
            public int GeneralInformationParentID { get; set; }
    
            [JsonProperty("CollateralsID")]
            public int CollateralsID { get; set; }
    
            [JsonProperty("CollateralsParentID")]
            public int CollateralsParentID { get; set; }
    
            [JsonProperty("InstalmentsID")]
            public int InstalmentsID { get; set; }
    
            [JsonProperty("InstalmentsParentID")]
            public int InstalmentsParentID { get; set; }
    
            [JsonProperty("ConnectedSubjectsID")]
            public int ConnectedSubjectsID { get; set; }
    
            [JsonProperty("ConnectedSubjectsParentID")]
            public int ConnectedSubjectsParentID { get; set; }
    
            [JsonProperty("InstalmentDetail")]
            public InstalmentDetail InstalmentDetail { get; set; }
    
            [JsonProperty("Instalments")]
            public List<Instalment> Instalments { get; set; }
    
            [JsonProperty("GeneralInformation")]
            public GeneralInformation GeneralInformation { get; set; }
    
            [JsonProperty("ConnectedSubjects")]
            public List<ConnectedSubject> ConnectedSubjects { get; set; }
    
            [JsonProperty("Collaterals")]
            public List<object> Collaterals { get; set; }
        }
    
        public class BaseDataOperation
        {
            [JsonProperty("ExistingOperationDebtorID")]
            public int ExistingOperationDebtorID { get; set; }
    
            [JsonProperty("TerminatedOperationDebtorsID")]
            public int TerminatedOperationDebtorsID { get; set; }
    
            [JsonProperty("TerminatedOperationGuarantorsID")]
            public int TerminatedOperationGuarantorsID { get; set; }
    
            [JsonProperty("ExistingOperationDebtors")]
            public List<ExistingOperationDebtor> ExistingOperationDebtors { get; set; }
    
            [JsonProperty("TerminatedOperationDebtors")]
            public List<TerminatedOperationDebtor> TerminatedOperationDebtors { get; set; }
    
            [JsonProperty("TerminatedOperationGuarantors")]
            public List<TerminatedOperationGuarantor> TerminatedOperationGuarantors { get; set; }
        }
    
        public class NumberOfInquiry
        {
            [JsonProperty("SubscriberType")]
            public string SubscriberType { get; set; }
    
            [JsonProperty("LastMonthCount")]
            public int LastMonthCount { get; set; }
    
            [JsonProperty("LastYearCount")]
            public int LastYearCount { get; set; }
        }
    
        public class NegativeStatusAndInquiry
        {
            [JsonProperty("NumberOfInquiries")]
            public List<NumberOfInquiry> NumberOfInquiries { get; set; }
    
            [JsonProperty("CurrentNegativeStatusContracts")]
            public object CurrentNegativeStatusContracts { get; set; }
    
            [JsonProperty("CurrentNegativeStatusSubjects")]
            public object CurrentNegativeStatusSubjects { get; set; }
        }
    
        public class ContractRecord
        {
            [JsonProperty("TypeOfContract")]
            public string TypeOfContract { get; set; }
    
            [JsonProperty("TypeOfFinancingInstalment")]
            public object TypeOfFinancingInstalment { get; set; }
    
            [JsonProperty("Subscriber")]
            public string Subscriber { get; set; }
    
            [JsonProperty("SubscriberLocalName")]
            public string SubscriberLocalName { get; set; }
    
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
    
            [JsonProperty("NumberOfOpenContracts")]
            public int NumberOfOpenContracts { get; set; }
    
            [JsonProperty("NumberOfTerminatedContracts")]
            public int NumberOfTerminatedContracts { get; set; }
    
            [JsonProperty("OutstandingAmount")]
            public double OutstandingAmount { get; set; }
    
            [JsonProperty("OverdueAmount")]
            public double OverdueAmount { get; set; }
        }
    
        public class TotalRecord
        {
            [JsonProperty("CurrencyCode")]
            public string CurrencyCode { get; set; }
    
            [JsonProperty("NumberOfOpenContracts")]
            public int NumberOfOpenContracts { get; set; }
    
            [JsonProperty("NumberOfTerminatedContracts")]
            public int NumberOfTerminatedContracts { get; set; }
    
            [JsonProperty("OutstandingAmount")]
            public double OutstandingAmount { get; set; }
    
            [JsonProperty("OverdueAmount")]
            public double OverdueAmount { get; set; }
        }
    
        public class Contract
        {
            [JsonProperty("ContractRecords")]
            public List<ContractRecord> ContractRecords { get; set; }
    
            [JsonProperty("TotalRecord")]
            public TotalRecord TotalRecord { get; set; }
        }
    
        public class LettersOfGuarantee
        {
            [JsonProperty("ContractRecords")]
            public List<object> ContractRecords { get; set; }
    
            [JsonProperty("TotalRecord")]
            public TotalRecord TotalRecord { get; set; }
        }
    
        public class SubjectRole
        {
            [JsonProperty("RoleOfConnectedSubject")]
            public string RoleOfConnectedSubject { get; set; }
    
            [JsonProperty("NumberOfContracts")]
            public int NumberOfContracts { get; set; }
        }
    
        public class SummaryReport
        {
            [JsonProperty("TrackingCode")]
            public object TrackingCode { get; set; }
    
            [JsonProperty("NegativeStatusAndInquiry")]
            public NegativeStatusAndInquiry NegativeStatusAndInquiry { get; set; }
    
            [JsonProperty("Contract")]
            public Contract Contract { get; set; }
    
            [JsonProperty("LettersOfGuarantee")]
            public LettersOfGuarantee LettersOfGuarantee { get; set; }
    
            [JsonProperty("SubjectRoles")]
            public List<SubjectRole> SubjectRoles { get; set; }
    
            [JsonProperty("ReportDate")]
            public DateTime ReportDate { get; set; }
        }
    
        public class ScoringData
        {
            [JsonProperty("ICSScore")]
            public int ICSScore { get; set; }
    
            [JsonProperty("RiskGrade")]
            public int RiskGrade { get; set; }
    
            [JsonProperty("ReasonCodes")]
            public List<int> ReasonCodes { get; set; }
    
            [JsonProperty("ScoreRange")]
            public object ScoreRange { get; set; }
    
            [JsonProperty("ScoreDescription")]
            public string ScoreDescription { get; set; }
    
            [JsonProperty("Comments")]
            public object Comments { get; set; }
        }
    
        public class Root
        {
            [JsonProperty("TrackingCode")]
            public string TrackingCode { get; set; }
    
            [JsonProperty("BasicData")]
            public BasicData BasicData { get; set; }
    
            [JsonProperty("Inquiry")]
            public object Inquiry { get; set; }
    
            [JsonProperty("Summary")]
            public Summary Summary { get; set; }
    
            [JsonProperty("SummaryCreditors")]
            public List<SummaryCreditor> SummaryCreditors { get; set; }
    
            [JsonProperty("BaseDataOperation")]
            public BaseDataOperation BaseDataOperation { get; set; }
    
            [JsonProperty("ReportStatus")]
            public int ReportStatus { get; set; }
    
            [JsonProperty("SummaryReport")]
            public SummaryReport SummaryReport { get; set; }
    
            [JsonProperty("ScoringData")]
            public ScoringData ScoringData { get; set; }
        }
    
        public async Task<IActionResult> Client ()
        {
        
            return View ();
        }
    
        public void GetData () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Bearer", "Your Access Token");
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "Your Device Id");
            client.DefaultRequestHeaders.Add ("Bank-Id", "BEGNIR ");
            client.DefaultRequestHeaders.Add ("Token-Id", "xukHh7W5wozX0mRmvIldAO0Paz7xViCYt6SPxj3boVrAIlEDXX4Dfz3JVEl3j0Lzl2suE8fmoL1tuEXP1x4HpV1Q");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");
        }

    }
}