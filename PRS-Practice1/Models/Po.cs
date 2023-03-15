namespace PRS_Practice1.Models {
    public class Po {
        public Vendor Vendor { get; set; }
        public IEnumerable<Poline> Polines { get; set; }
        public decimal PoTotal { get; set; }
    }
}
