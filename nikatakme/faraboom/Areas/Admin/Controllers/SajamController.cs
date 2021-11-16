using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModels.AdminViewModel.sajam;

namespace Admin.Controllers {
    [Area ("Admin")]
    [Authorize]
    public class SajamController : Controller {

        public IActionResult Index () {
            return View ();
        }

        public async Task<IActionResult> SendSajamcode () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> ShowSajamcode (Vm_sajam vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                mobile = vg.mobile,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/issuers/otp", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> ShowAuthentication (Vm_Ehraz vg) {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> ShowCheckprofile (Vm_Checkprofile vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                mobile = vg.mobile,
                otp = vg.otp,
                identifier = vg.identifier,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/issuers/accounts/validate", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
        public async Task<IActionResult> ListofSajambanks () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
        public async Task<IActionResult> Showbank (Vm_Showbank vg) {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/banks", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public IActionResult Completeprofile () {
            return View ();
        }

        public async Task<IActionResult> ShowCompleteprofile (Vm_profile vg) {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                issuer_otp = "",
                personal_info = new {

                national_code = vg.national_code,
                mobile = vg.mobile,
                first_name = vg.mobile,
                last_name = vg.last_name,
                father_name = vg.father_name,
                gender = vg.gender,
                serial_char = vg.serial_char,
                serial_number = vg.serial_number,
                serial = vg.serial,
                birth_date = vg.birth_date,
                id_number = vg.id_number,
                place_of_issue = vg.place_of_issue,
                place_of_birth = vg.place_of_birth
                },

                address_info = new {

                postal_code = vg.postal_code,
                country_id = vg.country_id,
                province_id = vg.province_id,
                city_id = vg.city_id,
                section_id = vg.section_id,
                address = vg.address,
                alley = vg.alley,
                building_number = vg.building_number,
                city_prefix = vg.city_prefix,
                phone = vg.phone,
                country_prefix = vg.country_prefix,
                emergency_mobile = vg.emergency_mobile,
                emergency_phone = vg.emergency_phone,
                emergency_phone_city_prefix = vg.emergency_phone_city_prefix,
                email = vg.email
                },

                payment_info = new {

                amount = vg.amount,
                reference_number = vg.reference_number,
                sale_reference_id = vg.sale_reference_id,
                discount = vg.discount,
                date_time = vg.date_time,
                service_id = vg.service_id,
                order_id = vg.order_id
                },

                job_info = new {

                job_id = vg.job_id,
                employment_date = vg.employment_date,
                company_name = vg.company_name,
                company_address = vg.company_address,
                company_postal_code = vg.company_address,
                company_email = vg.company_email,
                company_web_site = vg.company_web_site,
                company_city_prefix = vg.company_city_prefix,
                company_phone = vg.company_phone,
                position = vg.position,
                company_fax_prefix = vg.company_fax_prefix,
                company_fax = vg.company_fax,
                job_description = vg.job_description
                },
                bank_accounts = new [] {
                new {

                account = vg.account,
                account_type = vg.account_type,
                iban = vg.iban,
                bank_id = vg.bank_id,
                branch_code = vg.branch_code,
                branch_name = vg.branch_name,
                branch_city_id = vg.branch_city_id,
                default_account = vg.default_account
                }
                },
                // financial_info = new {

                // assets_value = 0,
                // incoming_average = 0,
                // stock_exchange_transaction = 0,
                // mercantile_exchange_transaction = 0,
                // foreign_exchange_transaction = 0,
                // transaction_level = "one",
                // trading_knowledge_level = "excellent"
                // },
                trading_codes = new [] {
                new {

                type = "energy",
                first_part = "",
                second_part = "",
                third_part = ""
                }
                },
                token = "eyJhbGciOiJNRDUiLCJ0eXAiOiJKV1QifQ.eyJjZCI6IjIwMjEtMDQtMTlUMTM6MzU6NDguODc2NDg1NyswNDozMCIsImsiOiJjNzUwMTNjNjAxNDM0NjFhOTBjMzdhNzEyNjlkM2ZmMyIsInAiOnsicyI6MTAyNDYsInUiOjEwMjcyfX0.vgrzGq4x5IhQ2TP497Y4DA"
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/issuers/accounts/profiles", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return RedirectToAction ("Completeprofile");
        }
        public async Task<IActionResult> ShowGetprofile (Vm_Getprofile vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", " 13457");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                identifier = vg.identifier,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/authenticators/accounts/profiles/inquiry", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Checkprofile () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
        public async Task<IActionResult> countries () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Showcountries (Vm_countries vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/countries", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> provinces () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Showprovinces (Vm_provinces vg) {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                country_id = vg.country_id,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/provinces", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();

        }
        public async Task<IActionResult> cities () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> Showcities (Vm_cities vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                province_id = vg.province_id,
                country_id = vg.country_id,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/cities", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Showsections (Vm_sections vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                city_id = vg.city_id,
                province_id = vg.province_id,
                country_id = vg.country_id,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/areas", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> sections () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Getprofile () {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> jobs () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Showjobs (Vm_jobs vg) {

            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/jobs", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult> Listofservices () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
        public async Task<IActionResult> Showservices (Vm_Showservices vg) {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/authenticators/services", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();
            return View ();
        }

        public async Task<IActionResult> Servicespecifications () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };

            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }
        public async Task<IActionResult> Showinfo (Vm_Showinfo vg) {

            var baseAddress = new System.Uri ("https://api.portal.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                service_id = vg.service_id,
                token = vg.token
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/authenticators/services/{id}", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

        public async Task<IActionResult>  Showbody () {
            var baseAddress = new System.Uri ("https://api.faraboom.co/v1/");
            var client = new System.Net.Http.HttpClient { BaseAddress = baseAddress };
            client.DefaultRequestHeaders.AcceptLanguage.Clear ();
            client.DefaultRequestHeaders.AcceptLanguage.Add (new StringWithQualityHeaderValue ("fa"));
            client.DefaultRequestHeaders.Add ("App-Key", "13075");
            client.DefaultRequestHeaders.Add ("Device-Id", "185.159.152.2");
            client.DefaultRequestHeaders.Add ("Token-Id", "TZrkictjvr6gqkJLvsu1GryJXkr3NUMOmIkHLTnLQHYYfBtmV2ff0gvGFq7H22nI8RD2ScQfDHkzNfdkqHnobMGo");
            client.DefaultRequestHeaders.Add ("CLIENT-DEVICE-ID", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-IP-ADDRESS", "127.0.0.1");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-AGENT", "User Agent");
            client.DefaultRequestHeaders.Add ("CLIENT-USER-ID", "09120000000");
            client.DefaultRequestHeaders.Add ("CLIENT-PLATFORM-TYPE", "WEB");

            var data = new {
                username = "faraboom",
                password = "9kkqmibz"
            };
            var response = await client.PostAsJsonAsync ("stock-market/sejam/auth/authenticators/login", data);
            ViewBag.result = await response.Content.ReadAsStringAsync ();

            return View ();
        }

           public IActionResult Authenticationbody () {

            return View ();
        }

        public IActionResult Authentication () {

            return View ();
        }

        public IActionResult Sendatoken () {
            return View ();
        }
        public IActionResult Sendatokentoport () {
            return View ();
        }
        public IActionResult Paymentconfirmation () {
            return View ();
        }
        public IActionResult Paymentinquiry () {
            return View ();
        }
        public IActionResult Authenticationside () {
            return View ();
        }
        public IActionResult TrackingCode () {
            return View ();
        }
        public IActionResult Specificationsprofile () {
            return View ();
        }

    }
}