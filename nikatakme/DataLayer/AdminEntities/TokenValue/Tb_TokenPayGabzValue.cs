using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.AdminEntities.TokenValue {
    public class Tb_TokenPayGabzValue {
        
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public string Refresh { get; set; }
        public DateTime LifeTime { get; set; }
        public string Scopes { get; set; }
        public string Name { get; set; }
        
        

    }

}