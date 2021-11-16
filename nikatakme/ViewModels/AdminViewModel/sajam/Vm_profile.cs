using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ViewModels.AdminViewModel.sajam {
    public class Vm_profile {
        [Key]
        //personal_info 

        public string national_code { get; set; }

        public string mobile { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string father_name { get; set; }

        public string gender { get; set; }

        public string serial_char { get; set; }

        public string serial_number { get; set; }

        public string serial { get; set; }

        public string birth_date { get; set; }

        public string id_number { get; set; }

        public string place_of_issue { get; set; }

        public string place_of_birth { get; set; }
         public string Mont { get; set; }
          public string Day { get; set; }
           public string Yers { get; set; }


         //address_info  
	 
		public string postal_code{ get; set; } 
		public string country_id{ get; set; } 
		public string province_id { get; set; } 
		public string city_id { get; set; } 
		public string section_id{ get; set; } 
		public string address{ get; set; } 
		public string alley { get; set; } 
		public string building_number{ get; set; } 
		public string city_prefix{ get; set; } 
		public string phone{ get; set; } 
		public string country_prefix{ get; set; } 
		public string emergency_mobile { get; set; } 
		public string emergency_phone{ get; set; } 
		public string emergency_phone_city_prefix{ get; set; } 
		public string email { get; set; } 


        //payment_info 
	
		public int amount { get; set; } 
		public string reference_number { get; set; } 
		public string sale_reference_id { get; set; } 
		public string discount { get; set; } 
		public DateTime date_time { get; set; } 
     	public string service_id { get; set; } 
		public string order_id { get; set; } 



        //bank_accounts
	public string Bankname{ get; set; } 
		public string account{ get; set; } 
		public string account_type{ get; set; } 
		public string iban { get; set; }
		public string bank_id{ get; set; } 
		public string branch_code{ get; set; } 
		public string branch_name { get; set; }
		public string branch_city_id{ get; set; } 
        public string default_account{ get; set; }


        //job_info
	
		public string job_id { get; set; } 
		public string employment_date { get; set; } 
		public string company_name { get; set; } 
		public string company_address { get; set; } 
		public string company_postal_code { get; set; } 
		public string company_email { get; set; } 
		public string company_web_site { get; set; } 
		public string company_city_prefix { get; set; } 
		public string company_phone { get; set; } 
		public string position { get; set; } 
		public string company_fax_prefix { get; set; } 
		public string company_fax { get; set; } 
		public string job_description{ get; set; } 
		public string token{ get; set; } 




    }
}