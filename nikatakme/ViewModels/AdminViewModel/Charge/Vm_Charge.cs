namespace ViewModels.AdminViewModel.Charge
{
    public class Vm_Charge
    {
        public string CellNumber { get; set; }
        public int TotalAmount { get; set; }
        public short OperatorId { get; set; }
        public int ChargeType { get; set; }
        public long Reserve { get; set; }
        public long Reference { get; set; }
    }
}